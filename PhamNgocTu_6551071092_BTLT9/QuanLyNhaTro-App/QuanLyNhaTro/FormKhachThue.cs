using System.Net.Http;
using System.Text.RegularExpressions;
using QuanLyNhaTro.Data;
using QuanLyNhaTro.Models;
using QuanLyNhaTro.Services;
using Serilog;

namespace QuanLyNhaTro;

public partial class FormKhachThue : Form
{
    private const string MsgApiLoi = "Không tải được danh sách địa chỉ, vui lòng kiểm tra mạng";
    private const string LoadingText = "Đang tải…";
    private const string TatCaPhong = "(Tất cả phòng)";
    private const string TatCaTinh = "(Tất cả tỉnh/thành)";

    private bool _binding;          // true: đang gán dữ liệu bằng code, bỏ qua các event SelectedIndexChanged...
    private bool _manualMode;       // true: API lỗi -> cho gõ tay Tỉnh/Thành, Phường/Xã
    private bool _provincesLoaded;
    private bool _warnedOffline;    // chỉ bật MessageBox báo lỗi mạng 1 lần cho tới khi API hoạt động lại
    private List<AddressItem> _provinces = new();
    private readonly Dictionary<int, List<AddressItem>> _wardCache = new();
    private CancellationTokenSource? _wardCts;

    public FormKhachThue()
    {
        InitializeComponent();

        dtpNgaySinh.Value = new DateTime(2000, 1, 1);
        dtpNgaySinh.MinDate = new DateTime(1900, 1, 1);
        dtpNgaySinh.MaxDate = DateTime.Today;
    }

    // =====================================================================
    //  FORM LOAD
    // =====================================================================
    private async void FormKhachThue_Load(object? sender, EventArgs e)
    {
        Execute(() =>
        {
            LoadPhongCombo(null);
            LoadLocPhong();
            LoadLocTinh();
            LoadGrid();
        }, "Không đọc được dữ liệu từ SQL Server.");

        ClearWardCombo();
        await LoadTinhAsync(); // gọi API bất đồng bộ, giao diện không bị đơ
    }

    // =====================================================================
    //  GỌI API TỈNH / PHƯỜNG-XÃ (9.4) + CHỊU LỖI MẠNG
    // =====================================================================
    private async Task LoadTinhAsync()
    {
        _manualMode = false;
        _provincesLoaded = false;
        SetLoading(cboTinh);
        ClearWardCombo();

        try
        {
            var list = await AddressApiService.GetProvincesAsync();
            _provinces = list;
            _provincesLoaded = true;
            BindAddress(cboTinh, list);
            WithBinding(() => cboTinh.SelectedIndex = -1);
            _warnedOffline = false;
        }
        catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException)
        {
            Log.Warning(ex, "Không tải được danh sách tỉnh/thành từ API (mạng lỗi hoặc quá 10 giây)");
            EnterManualMode();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi không mong đợi khi tải danh sách tỉnh/thành");
            EnterManualMode();
        }
    }

    private async Task LoadWardsAsync(int provinceCode, int? selectCode = null, string? selectName = null)
    {
        _wardCts?.Cancel();
        var cts = new CancellationTokenSource();
        _wardCts = cts;
        var ct = cts.Token;

        try
        {
            if (!_wardCache.TryGetValue(provinceCode, out var wards))
            {
                SetLoading(cboPhuongXa);
                wards = await AddressApiService.GetWardsAsync(provinceCode, ct);
                if (ct.IsCancellationRequested) return;
                _wardCache[provinceCode] = wards;
            }

            BindAddress(cboPhuongXa, wards);

            var chon = wards.FirstOrDefault(w => selectCode.HasValue && w.code == selectCode.Value)
                       ?? wards.FirstOrDefault(w => !string.IsNullOrEmpty(selectName) && w.name == selectName);
            WithBinding(() =>
            {
                if (chon != null) cboPhuongXa.SelectedItem = chon;
                else cboPhuongXa.SelectedIndex = -1;
            });
            _warnedOffline = false;
        }
        catch (OperationCanceledException) when (ct.IsCancellationRequested)
        {
            // Người dùng đã chọn tỉnh khác -> bỏ qua yêu cầu cũ.
        }
        catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException)
        {
            Log.Warning(ex, "Không tải được phường/xã của tỉnh {Code} từ API", provinceCode);
            EnterWardManualMode(selectName);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi không mong đợi khi tải phường/xã của tỉnh {Code}", provinceCode);
            EnterWardManualMode(selectName);
        }
    }

    /// <summary>Không có danh sách tỉnh: cho gõ tay cả Tỉnh/Thành và Phường/Xã để vẫn lưu được khách.</summary>
    private void EnterManualMode()
    {
        _manualMode = true;
        WithBinding(() =>
        {
            foreach (var c in new[] { cboTinh, cboPhuongXa })
            {
                c.DataSource = null;
                c.DropDownStyle = ComboBoxStyle.DropDown;
                c.Enabled = true;
                c.Text = "";
            }
        });
        NotifyOffline();
    }

    /// <summary>Có tỉnh nhưng không tải được phường/xã: chỉ ô Phường/Xã chuyển sang gõ tay.</summary>
    private void EnterWardManualMode(string? prefill)
    {
        WithBinding(() =>
        {
            cboPhuongXa.DataSource = null;
            cboPhuongXa.DropDownStyle = ComboBoxStyle.DropDown;
            cboPhuongXa.Enabled = true;
            cboPhuongXa.Text = prefill ?? "";
        });
        NotifyOffline();
    }

    private void NotifyOffline()
    {
        lblTrangThai.Text = MsgApiLoi + " – bạn vẫn có thể gõ tay Phường/Xã (và Tỉnh/Thành) để lưu khách.";
        if (_warnedOffline) return;
        _warnedOffline = true;
        MessageBox.Show(
            MsgApiLoi + ".\n\nBạn vẫn có thể gõ tay Tỉnh/Thành, Phường/Xã rồi lưu khách bình thường.",
            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    /// <summary>Hiện "Đang tải…" và khóa ComboBox trong lúc chờ API.</summary>
    private void SetLoading(ComboBox cbo)
    {
        WithBinding(() =>
        {
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo.DisplayMember = "name";
            cbo.ValueMember = "code";
            cbo.DataSource = new List<AddressItem> { new() { code = 0, name = LoadingText } };
            cbo.Enabled = false;
        });
    }

    private void BindAddress(ComboBox cbo, List<AddressItem> items)
    {
        WithBinding(() =>
        {
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo.DisplayMember = "name";
            cbo.ValueMember = "code";
            cbo.DataSource = items;
            cbo.Enabled = true;
        });
    }

    private void ClearWardCombo()
    {
        WithBinding(() =>
        {
            cboPhuongXa.DataSource = null;
            cboPhuongXa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhuongXa.Enabled = false;
            cboPhuongXa.Text = "";
        });
    }

    private async void cboTinh_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_binding || _manualMode) return;
        if (cboTinh.SelectedItem is AddressItem p && p.code != 0)
            await LoadWardsAsync(p.code);
    }

    private static (int? Ma, string Ten) ReadAddress(ComboBox cbo)
    {
        if (!cbo.Enabled) return (null, "");
        if (cbo.DropDownStyle == ComboBoxStyle.DropDownList && cbo.SelectedItem is AddressItem a && a.code != 0)
            return (a.code, a.name);
        return (null, cbo.Text.Trim());
    }

    private async Task SelectAddressAsync(KhachView k)
    {
        if (_manualMode)
        {
            cboTinh.Text = k.TenTinh;
            cboPhuongXa.Text = k.TenPhuongXa;
            return;
        }
        if (!_provincesLoaded) return; // đang tải, bỏ qua

        var p = (k.MaTinh.HasValue ? _provinces.FirstOrDefault(x => x.code == k.MaTinh.Value) : null)
                ?? _provinces.FirstOrDefault(x => x.name == k.TenTinh);

        WithBinding(() => cboTinh.SelectedItem = p);

        if (p == null)
        {
            ClearWardCombo();
            return;
        }
        await LoadWardsAsync(p.code, k.MaPhuongXa, k.TenPhuongXa);
    }

    // =====================================================================
    //  NẠP DỮ LIỆU CHO COMBOBOX / LƯỚI
    // =====================================================================
    private void LoadPhongCombo(int? includeMaPhong)
    {
        var rooms = NhaTroRepository.GetPhongChoNhap(includeMaPhong)
            .Select(p => new RoomItem(p.MaPhong, $"{p.TenPhong} – {p.GiaThue:N0}đ"))
            .ToList();

        WithBinding(() =>
        {
            cboPhong.DataSource = null;
            cboPhong.DisplayMember = "Text";
            cboPhong.ValueMember = "MaPhong";
            cboPhong.DataSource = rooms;
            if (includeMaPhong.HasValue && rooms.Any(r => r.MaPhong == includeMaPhong.Value))
                cboPhong.SelectedValue = includeMaPhong.Value;
            else
                cboPhong.SelectedIndex = -1;
        });
    }

    private void LoadLocPhong()
    {
        int dangChon = cboLocPhong.SelectedValue is int v ? v : 0;
        var list = new List<RoomItem> { new(0, TatCaPhong) };
        list.AddRange(NhaTroRepository.GetAllPhong().Select(p => new RoomItem(p.MaPhong, p.TenPhong)));

        WithBinding(() =>
        {
            cboLocPhong.DataSource = null;
            cboLocPhong.DisplayMember = "Text";
            cboLocPhong.ValueMember = "MaPhong";
            cboLocPhong.DataSource = list;
            cboLocPhong.SelectedValue = list.Any(r => r.MaPhong == dangChon) ? dangChon : 0;
        });
    }

    private void LoadLocTinh()
    {
        var dangChon = cboLocTinh.SelectedIndex > 0 ? cboLocTinh.SelectedItem as string : null;
        var list = new List<string> { TatCaTinh };
        list.AddRange(NhaTroRepository.GetDanhSachTinh());

        WithBinding(() =>
        {
            cboLocTinh.DataSource = null;
            cboLocTinh.DataSource = list;
            cboLocTinh.SelectedIndex = dangChon != null && list.Contains(dangChon) ? list.IndexOf(dangChon) : 0;
        });
    }

    private void LoadGrid()
    {
        string? keyword = txtTimKiem.Text;
        int? maPhong = cboLocPhong.SelectedValue is int p && p > 0 ? p : null;
        string? tinh = cboLocTinh.SelectedIndex > 0 ? cboLocTinh.SelectedItem as string : null;

        int? giuLaiId = (dgvKhach.CurrentRow?.DataBoundItem as KhachView)?.MaKhach;
        var data = NhaTroRepository.GetKhachViews(keyword, maPhong, tinh);

        WithBinding(() =>
        {
            dgvKhach.DataSource = data;
            dgvKhach.CurrentCell = null;
            dgvKhach.ClearSelection();

            if (giuLaiId.HasValue)
            {
                foreach (DataGridViewRow row in dgvKhach.Rows)
                {
                    if (row.DataBoundItem is KhachView kv && kv.MaKhach == giuLaiId.Value)
                    {
                        dgvKhach.CurrentCell = row.Cells[0];
                        row.Selected = true;
                        break;
                    }
                }
            }
        });

        lblTrangThai.Text = $"Hiển thị {data.Count} khách thuê.";
    }

    private void RefreshAll()
    {
        LoadLocPhong();
        LoadLocTinh();
        LoadGrid();
    }

    // =====================================================================
    //  FORM <-> DỮ LIỆU
    // =====================================================================
    private async void dgvKhach_SelectionChanged(object? sender, EventArgs e)
    {
        if (_binding) return;
        if (dgvKhach.CurrentRow?.DataBoundItem is not KhachView k) return;
        await FillFormAsync(k);
    }

    private async Task FillFormAsync(KhachView k)
    {
        WithBinding(() =>
        {
            txtHoTen.Text = k.HoTen;
            rdoNam.Checked = k.GioiTinh == "Nam";
            rdoNu.Checked = k.GioiTinh != "Nam";

            var ns = k.NgaySinh.ToDateTime(TimeOnly.MinValue);
            if (ns < dtpNgaySinh.MinDate) ns = dtpNgaySinh.MinDate;
            if (ns > dtpNgaySinh.MaxDate) ns = dtpNgaySinh.MaxDate;
            dtpNgaySinh.Value = ns;

            txtSDT.Text = k.SoDienThoai;
            chkTamTru.Checked = k.DaDangKyTamTru;
        });

        Execute(() => LoadPhongCombo(k.MaPhong), "Không tải được danh sách phòng.");
        await SelectAddressAsync(k);
    }

    private void ClearForm()
    {
        _wardCts?.Cancel();

        WithBinding(() =>
        {
            txtHoTen.Clear();
            rdoNam.Checked = true;
            dtpNgaySinh.Value = new DateTime(2000, 1, 1);
            txtSDT.Clear();
            chkTamTru.Checked = false;

            dgvKhach.CurrentCell = null;
            dgvKhach.ClearSelection();

            if (_manualMode)
            {
                cboTinh.Text = "";
                cboPhuongXa.Text = "";
            }
            else if (_provincesLoaded)
            {
                cboTinh.SelectedIndex = -1;
            }
        });

        if (!_manualMode && _provincesLoaded) ClearWardCombo();

        Execute(() => LoadPhongCombo(null), "Không tải được danh sách phòng.");
        txtHoTen.Focus();
    }

    /// <summary>Đọc và kiểm tra dữ liệu nhập. Trả về null nếu có lỗi (đã báo cho người dùng).</summary>
    private KhachThue? ReadForm()
    {
        var hoTen = txtHoTen.Text.Trim();
        if (hoTen.Length == 0) { Warn("Vui lòng nhập họ tên.", txtHoTen); return null; }

        var sdt = txtSDT.Text.Trim();
        if (!Regex.IsMatch(sdt, @"^\d{9,11}$"))
        {
            Warn("Số điện thoại không hợp lệ (chỉ gồm 9–11 chữ số).", txtSDT);
            return null;
        }

        if (cboPhong.SelectedValue is not int maPhong)
        {
            Warn(cboPhong.Items.Count == 0
                    ? "Hiện không còn phòng trống để thêm khách."
                    : "Vui lòng chọn phòng.",
                cboPhong);
            return null;
        }

        var (maTinh, tenTinh) = ReadAddress(cboTinh);
        if (tenTinh.Length == 0) { Warn("Vui lòng chọn (hoặc gõ) Tỉnh/Thành.", cboTinh); return null; }

        var (maPx, tenPx) = ReadAddress(cboPhuongXa);
        if (tenPx.Length == 0) { Warn("Vui lòng chọn (hoặc gõ) Phường/Xã.", cboPhuongXa); return null; }

        return new KhachThue
        {
            HoTen = hoTen,
            GioiTinh = rdoNam.Checked ? "Nam" : "Nữ",
            NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value),
            SoDienThoai = sdt,
            MaTinh = maTinh,
            TenTinh = tenTinh,
            MaPhuongXa = maPx,
            TenPhuongXa = tenPx,
            DaDangKyTamTru = chkTamTru.Checked,
            MaPhong = maPhong
        };
    }

    // =====================================================================
    //  CÁC NÚT CRUD
    // =====================================================================
    private void btnThem_Click(object? sender, EventArgs e)
    {
        var k = ReadForm();
        if (k == null) return;

        if (!Execute(() => NhaTroRepository.AddKhach(k), "Không lưu được khách thuê.")) return;

        MessageBox.Show("Đã thêm khách thuê.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        AfterChange();
    }

    private void btnSua_Click(object? sender, EventArgs e)
    {
        if (dgvKhach.CurrentRow?.DataBoundItem is not KhachView chon)
        {
            MessageBox.Show("Vui lòng chọn một khách trong bảng để sửa.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var k = ReadForm();
        if (k == null) return;
        k.MaKhach = chon.MaKhach;

        if (!Execute(() => NhaTroRepository.UpdateKhach(k), "Không cập nhật được khách thuê.")) return;

        MessageBox.Show("Đã cập nhật khách thuê.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        AfterChange();
    }

    private void btnXoa_Click(object? sender, EventArgs e)
    {
        if (dgvKhach.CurrentRow?.DataBoundItem is not KhachView chon)
        {
            MessageBox.Show("Vui lòng chọn một khách trong bảng để xóa.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var hoi = MessageBox.Show($"Xóa khách \"{chon.HoTen}\" khỏi phòng {chon.TenPhong}?", "Xác nhận xóa",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        if (hoi != DialogResult.Yes) return;

        if (!Execute(() => NhaTroRepository.DeleteKhach(chon.MaKhach), "Không xóa được khách thuê.")) return;

        AfterChange();
    }

    private async void btnLamMoi_Click(object? sender, EventArgs e)
    {
        WithBinding(() =>
        {
            txtTimKiem.Clear();
            if (cboLocPhong.Items.Count > 0) cboLocPhong.SelectedIndex = 0;
            if (cboLocTinh.Items.Count > 0) cboLocTinh.SelectedIndex = 0;
        });

        ClearForm();
        Execute(RefreshAll, "Không tải lại được dữ liệu.");

        // Nếu trước đó API lỗi thì thử gọi lại khi bấm Làm mới.
        if (_manualMode) await LoadTinhAsync();
    }

    private void AfterChange()
    {
        ClearForm();
        Execute(RefreshAll, "Không tải lại được dữ liệu.");
    }

    // =====================================================================
    //  TÌM KIẾM / LỌC
    // =====================================================================
    private void LocThayDoi(object? sender, EventArgs e)
    {
        if (_binding) return;
        Execute(LoadGrid, "Không tìm kiếm được dữ liệu.");
    }

    private void btnBoLoc_Click(object? sender, EventArgs e)
    {
        WithBinding(() =>
        {
            txtTimKiem.Clear();
            if (cboLocPhong.Items.Count > 0) cboLocPhong.SelectedIndex = 0;
            if (cboLocTinh.Items.Count > 0) cboLocTinh.SelectedIndex = 0;
        });
        Execute(LoadGrid, "Không tải được dữ liệu.");
    }

    // =====================================================================
    //  NÚT ẨN "GÂY LỖI THỬ" (Ctrl + Shift + F12 để hiện/ẩn)
    // =====================================================================
    private void FormKhachThue_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Control && e.Shift && e.KeyCode == Keys.F12)
        {
            btnGayLoi.Visible = !btnGayLoi.Visible;
            e.Handled = true;
        }
    }

    private void btnGayLoi_Click(object? sender, EventArgs e)
    {
        // Cố tình không bắt lỗi: để trình xử lý lỗi toàn cục (Program.cs) ghi log và báo thân thiện.
        throw new InvalidOperationException("Lỗi thử nghiệm: người dùng bấm nút 'Gây lỗi thử'.");
    }

    // =====================================================================
    //  TIỆN ÍCH
    // =====================================================================
    private void WithBinding(Action action)
    {
        var old = _binding;
        _binding = true;
        try { action(); }
        finally { _binding = old; }
    }

    private static void Warn(string message, Control focus)
    {
        MessageBox.Show(message, "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        focus.Focus();
    }

    /// <summary>Chạy thao tác DB, bắt lỗi, ghi log và báo thân thiện. Trả về true nếu thành công.</summary>
    private bool Execute(Action action, string errorMessage)
    {
        try
        {
            action();
            return true;
        }
        catch (NghiepVuException ex)
        {
            MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "{Message}", errorMessage);
            MessageBox.Show($"{errorMessage}\nThông tin lỗi đã được ghi lại, bạn có thể thử lại.",
                "Quản lý nhà trọ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
    }
}
