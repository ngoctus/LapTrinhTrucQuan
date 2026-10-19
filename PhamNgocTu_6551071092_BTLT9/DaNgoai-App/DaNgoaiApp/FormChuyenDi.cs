using DaNgoaiApp.Data;
using DaNgoaiApp.Services;
using Microsoft.EntityFrameworkCore;

namespace DaNgoaiApp;

public partial class FormChuyenDi : Form
{
    private static readonly Color NeutralBack = Color.FromArgb(232, 241, 251);
    private static readonly Color RainBack = Color.Orange;
    private static readonly Color ErrorBack = Color.FromArgb(255, 228, 225);

    // Giá trị lưu trong CSDL (tiếng Việt) -> khóa chuỗi hiển thị
    private static readonly (string Key, string LangKey)[] Transports =
    {
        ("Xe máy", "tr_motorbike"),
        ("Ô tô", "tr_car"),
        ("Xe khách", "tr_coach"),
        ("Tàu hỏa", "tr_train"),
    };

    private readonly BindingSource _bs = new();
    private readonly CancellationTokenSource _cts = new();
    private Action? _weatherView;   // cách vẽ lại panel thời tiết (để đổi ngôn ngữ ngay)
    private bool _loading;          // chặn event khi đang nạp dữ liệu / đổi ngôn ngữ
    private bool _ready;
    private int? _selectedId;

    public FormChuyenDi()
    {
        InitializeComponent();
        ConfigureGrid();

        _loading = true;
        (Lang.Code == "en" ? rdoEn : rdoVi).Checked = true;
        dtpTu.Value = DateTime.Today;
        dtpDen.Value = DateTime.Today.AddDays(30);
        dtpTu.Enabled = dtpDen.Enabled = false;
        _loading = false;

        ApplyLanguage(reload: false);

        Load += FormChuyenDi_Load;
        FormClosing += (_, _) => _cts.Cancel();
    }

    private void FormChuyenDi_Load(object? sender, EventArgs e)
    {
        _ready = true;
        LoadData();
    }

    // ================= Lưới =================
    private void ConfigureGrid()
    {
        dgv.AutoGenerateColumns = false;
        dgv.ReadOnly = true;
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.MultiSelect = false;
        dgv.RowHeadersVisible = false;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.BackgroundColor = SystemColors.Window;

        dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMa", DataPropertyName = nameof(ChuyenDiRow.MaChuyen), FillWeight = 35 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTen", DataPropertyName = nameof(ChuyenDiRow.TenChuyen), FillWeight = 150 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDiaDiem", DataPropertyName = nameof(ChuyenDiRow.DiaDiem), FillWeight = 90 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNgay", DataPropertyName = nameof(ChuyenDiRow.NgayDi), FillWeight = 80 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSoNguoi", DataPropertyName = nameof(ChuyenDiRow.SoNguoi), FillWeight = 55 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNganSach", DataPropertyName = nameof(ChuyenDiRow.NganSach), FillWeight = 90 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPT", DataPropertyName = nameof(ChuyenDiRow.PhuongTien), FillWeight = 75 });
        dgv.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colHT", DataPropertyName = nameof(ChuyenDiRow.DaHoanThanh), FillWeight = 65 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colGhiChu", DataPropertyName = nameof(ChuyenDiRow.GhiChu), FillWeight = 130 });

        dgv.Columns["colNganSach"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgv.Columns["colSoNguoi"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        dgv.DataSource = _bs;
    }

    // ================= Đa ngôn ngữ =================
    private void ApplyLanguage(bool reload)
    {
        bool wasLoading = _loading;
        _loading = true;

        Text = Lang.T("form_title");
        grpThongTin.Text = Lang.T("grp_info");
        lblTen.Text = Lang.T("lbl_name");
        lblDiaDiem.Text = Lang.T("lbl_place");
        lblNgayDi.Text = Lang.T("lbl_date");
        lblSoNguoi.Text = Lang.T("lbl_people");
        lblNganSach.Text = Lang.T("lbl_budget");
        lblPhuongTien.Text = Lang.T("lbl_transport");
        chkDaHoanThanh.Text = Lang.T("chk_done");
        lblGhiChu.Text = Lang.T("lbl_note");
        btnThem.Text = Lang.T("btn_add");
        btnSua.Text = Lang.T("btn_edit");
        btnXoa.Text = Lang.T("btn_delete");
        btnLamMoi.Text = Lang.T("btn_refresh");
        grpNgonNgu.Text = Lang.T("grp_lang");
        rdoVi.Text = Lang.T("rdo_vi");
        rdoEn.Text = Lang.T("rdo_en");
        grpThoiTiet.Text = Lang.T("grp_weather");
        btnThoiTiet.Text = Lang.T("btn_weather");
        grpLoc.Text = Lang.T("grp_filter");
        lblTimKiem.Text = Lang.T("lbl_search");
        chkChuaHT.Text = Lang.T("chk_pending");
        chkLocNgay.Text = Lang.T("chk_range");
        lblTu.Text = Lang.T("lbl_from");
        lblDen.Text = Lang.T("lbl_to");

        // Định dạng ngày theo culture
        string datePattern = Lang.Culture.DateTimeFormat.ShortDatePattern;
        foreach (var d in new[] { dtpNgayDi, dtpTu, dtpDen })
        {
            d.Format = DateTimePickerFormat.Custom;
            d.CustomFormat = datePattern;
        }
        // Làm mới dấu phân cách hàng nghìn theo culture mới
        nudNganSach.ThousandsSeparator = false;
        nudNganSach.ThousandsSeparator = true;

        // ComboBox phương tiện (giữ nguyên lựa chọn)
        string? selKey = cboPhuongTien.SelectedValue as string;
        cboPhuongTien.DisplayMember = nameof(ComboItem.Text);
        cboPhuongTien.ValueMember = nameof(ComboItem.Key);
        cboPhuongTien.DataSource = Transports.Select(t => new ComboItem(t.Key, Lang.T(t.LangKey))).ToList();
        cboPhuongTien.SelectedValue = selKey ?? Transports[0].Key;

        // Tiêu đề cột + định dạng
        dgv.Columns["colMa"]!.HeaderText = Lang.T("col_id");
        dgv.Columns["colTen"]!.HeaderText = Lang.T("col_name");
        dgv.Columns["colDiaDiem"]!.HeaderText = Lang.T("col_place");
        dgv.Columns["colNgay"]!.HeaderText = Lang.T("col_date");
        dgv.Columns["colSoNguoi"]!.HeaderText = Lang.T("col_people");
        dgv.Columns["colNganSach"]!.HeaderText = Lang.T("col_budget");
        dgv.Columns["colPT"]!.HeaderText = Lang.T("col_transport");
        dgv.Columns["colHT"]!.HeaderText = Lang.T("col_done");
        dgv.Columns["colGhiChu"]!.HeaderText = Lang.T("col_note");

        var dateStyle = dgv.Columns["colNgay"]!.DefaultCellStyle;
        dateStyle.FormatProvider = Lang.Culture;
        dateStyle.Format = datePattern;
        var moneyStyle = dgv.Columns["colNganSach"]!.DefaultCellStyle;
        moneyStyle.FormatProvider = Lang.Culture;
        moneyStyle.Format = "N0";

        _loading = wasLoading;

        if (reload && _ready) LoadData(_selectedId);

        if (_weatherView != null) _weatherView(); else ShowHint();
    }

    private void rdoLang_CheckedChanged(object? sender, EventArgs e)
    {
        if (_loading || sender is not RadioButton { Checked: true } rb) return;
        string code = rb == rdoEn ? "en" : "vi";
        Lang.Set(code);
        SettingsService.Save(new UserSettings { Language = code });
        ApplyLanguage(reload: true);
    }

    // ================= Nạp dữ liệu + lọc =================
    private void LoadData(int? keepId = null)
    {
        try
        {
            using var db = new QL_DaNgoaiContext();
            IQueryable<ChuyenDi> q = db.ChuyenDis.AsNoTracking();

            string kw = txtTimKiem.Text.Trim();
            if (kw.Length > 0)
                q = q.Where(c => c.TenChuyen.Contains(kw) || c.DiaDiem.Contains(kw));

            if (chkChuaHT.Checked)
                q = q.Where(c => !c.DaHoanThanh);

            if (chkLocNgay.Checked)
            {
                var from = DateOnly.FromDateTime(dtpTu.Value);
                var to = DateOnly.FromDateTime(dtpDen.Value);
                q = q.Where(c => c.NgayDi >= from && c.NgayDi <= to);
            }

            var rows = q.OrderBy(c => c.NgayDi).ThenBy(c => c.MaChuyen)
                        .AsEnumerable().Select(ToRow).ToList();

            _loading = true;
            _bs.DataSource = rows;

            int idx = keepId is null ? -1 : rows.FindIndex(r => r.MaChuyen == keepId);
            if (idx >= 0)
            {
                dgv.ClearSelection();
                dgv.Rows[idx].Selected = true;
                dgv.CurrentCell = dgv.Rows[idx].Cells["colTen"];
                _selectedId = rows[idx].MaChuyen;
                FillInput(rows[idx]);
            }
            else
            {
                dgv.CurrentCell = null;
                dgv.ClearSelection();
                _selectedId = null;
            }
            _loading = false;
        }
        catch (Exception ex)
        {
            _loading = false;
            ShowDbError(ex);
        }
    }

    private static ChuyenDiRow ToRow(ChuyenDi c) => new()
    {
        MaChuyen = c.MaChuyen,
        TenChuyen = c.TenChuyen,
        DiaDiem = c.DiaDiem,
        NgayDi = c.NgayDi.ToDateTime(TimeOnly.MinValue),
        SoNguoi = c.SoNguoi,
        NganSach = c.NganSach,
        PhuongTien = TransportText(c.PhuongTien),
        PhuongTienKey = c.PhuongTien,
        DaHoanThanh = c.DaHoanThanh,
        GhiChu = c.GhiChu,
    };

    private static string TransportText(string key)
    {
        var t = Transports.FirstOrDefault(x => x.Key == key);
        return t.LangKey is null ? key : Lang.T(t.LangKey);
    }

    private void FilterChanged(object? sender, EventArgs e)
    {
        if (!_ready || _loading) return;
        dtpTu.Enabled = dtpDen.Enabled = chkLocNgay.Checked;
        LoadData(_selectedId);
    }

    private void dgv_SelectionChanged(object? sender, EventArgs e)
    {
        if (_loading) return;
        if (dgv.CurrentRow?.DataBoundItem is ChuyenDiRow row)
        {
            bool changed = _selectedId != row.MaChuyen;
            _selectedId = row.MaChuyen;
            FillInput(row);
            if (changed) { _weatherView = null; ShowHint(); }
        }
    }

    private void FillInput(ChuyenDiRow r)
    {
        txtTen.Text = r.TenChuyen;
        txtDiaDiem.Text = r.DiaDiem;
        dtpNgayDi.Value = r.NgayDi;
        nudSoNguoi.Value = Math.Clamp(r.SoNguoi, (int)nudSoNguoi.Minimum, (int)nudSoNguoi.Maximum);
        nudNganSach.Value = Math.Clamp(r.NganSach, nudNganSach.Minimum, nudNganSach.Maximum);
        cboPhuongTien.SelectedValue = r.PhuongTienKey;
        chkDaHoanThanh.Checked = r.DaHoanThanh;
        txtGhiChu.Text = r.GhiChu ?? "";
    }

    private void ClearInput()
    {
        txtTen.Clear();
        txtDiaDiem.Clear();
        dtpNgayDi.Value = DateTime.Today;
        nudSoNguoi.Value = 1;
        nudNganSach.Value = 0;
        cboPhuongTien.SelectedIndex = 0;
        chkDaHoanThanh.Checked = false;
        txtGhiChu.Clear();
    }

    // ================= CRUD =================
    private bool ValidateInput(bool isNew)
    {
        if (string.IsNullOrWhiteSpace(txtTen.Text)) return Fail("val_name", txtTen);
        if (string.IsNullOrWhiteSpace(txtDiaDiem.Text)) return Fail("val_place", txtDiaDiem);
        if (isNew && dtpNgayDi.Value.Date < DateTime.Today) return Fail("val_date", dtpNgayDi);
        if (nudSoNguoi.Value < 1) return Fail("val_people", nudSoNguoi);
        if (nudNganSach.Value < 0) return Fail("val_budget", nudNganSach);
        return true;
    }

    private bool Fail(string key, Control control)
    {
        MessageBox.Show(this, Lang.T(key), Lang.T("msg_title_warn"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        control.Focus();
        return false;
    }

    private void Apply(ChuyenDi e)
    {
        e.TenChuyen = txtTen.Text.Trim();
        e.DiaDiem = txtDiaDiem.Text.Trim();
        e.NgayDi = DateOnly.FromDateTime(dtpNgayDi.Value);
        e.SoNguoi = (int)nudSoNguoi.Value;
        e.NganSach = nudNganSach.Value;
        e.PhuongTien = cboPhuongTien.SelectedValue as string ?? Transports[0].Key;
        e.DaHoanThanh = chkDaHoanThanh.Checked;
        var note = txtGhiChu.Text.Trim();
        e.GhiChu = note.Length == 0 ? null : note;
    }

    private void btnThem_Click(object? sender, EventArgs e)
    {
        if (!ValidateInput(isNew: true)) return;
        try
        {
            using var db = new QL_DaNgoaiContext();
            var entity = new ChuyenDi();
            Apply(entity);
            db.ChuyenDis.Add(entity);
            db.SaveChanges();
            LoadData(entity.MaChuyen);
            MessageBox.Show(this, Lang.T("msg_added"), Lang.T("msg_title_warn"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex) { ShowDbError(ex); }
    }

    private void btnSua_Click(object? sender, EventArgs e)
    {
        if (_selectedId is not int id)
        {
            MessageBox.Show(this, Lang.T("msg_select"), Lang.T("msg_title_warn"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        if (!ValidateInput(isNew: false)) return;
        try
        {
            using var db = new QL_DaNgoaiContext();
            var entity = db.ChuyenDis.Find(id);
            if (entity is null)
            {
                MessageBox.Show(this, Lang.T("msg_not_found_row"), Lang.T("msg_title_warn"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadData();
                return;
            }
            Apply(entity);
            db.SaveChanges();
            LoadData(id);
            MessageBox.Show(this, Lang.T("msg_updated"), Lang.T("msg_title_warn"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex) { ShowDbError(ex); }
    }

    private void btnXoa_Click(object? sender, EventArgs e)
    {
        if (_selectedId is not int id || dgv.CurrentRow?.DataBoundItem is not ChuyenDiRow row)
        {
            MessageBox.Show(this, Lang.T("msg_select"), Lang.T("msg_title_warn"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        var confirm = MessageBox.Show(this, Lang.T("msg_confirm_delete", row.TenChuyen),
            Lang.T("msg_title_confirm"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        try
        {
            using var db = new QL_DaNgoaiContext();
            db.ChuyenDis.Where(c => c.MaChuyen == id).ExecuteDelete();
            _selectedId = null;
            _weatherView = null;
            LoadData();
            ClearInput();
            ShowHint();
            MessageBox.Show(this, Lang.T("msg_deleted"), Lang.T("msg_title_warn"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex) { ShowDbError(ex); }
    }

    private void btnLamMoi_Click(object? sender, EventArgs e)
    {
        _loading = true;
        txtTimKiem.Clear();
        chkChuaHT.Checked = false;
        chkLocNgay.Checked = false;
        dtpTu.Value = DateTime.Today;
        dtpDen.Value = DateTime.Today.AddDays(30);
        dtpTu.Enabled = dtpDen.Enabled = false;
        _loading = false;

        ClearInput();
        _selectedId = null;
        _weatherView = null;
        LoadData();
        ShowHint();
    }

    private void ShowDbError(Exception ex)
    {
        var inner = ex.InnerException?.Message ?? ex.Message;
        MessageBox.Show(this, Lang.T("msg_db_error", inner), Lang.T("msg_title_error"),
            MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    // ================= Thời tiết =================
    private async void btnThoiTiet_Click(object? sender, EventArgs e)
    {
        if (dgv.CurrentRow?.DataBoundItem is not ChuyenDiRow row)
        {
            MessageBox.Show(this, Lang.T("msg_select"), Lang.T("msg_title_warn"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        _weatherView = null;
        ShowInfo("⏳", Lang.T("w_loading"), NeutralBack);
        SetBusy(true);
        try
        {
            var result = await WeatherService.GetForecastAsync(row.DiaDiem, row.NgayDi, Lang.Code, _cts.Token);

            // Người dùng đã chọn dòng khác trong lúc chờ -> bỏ kết quả cũ
            if (_selectedId != row.MaChuyen) return;

            switch (result.Status)
            {
                case WeatherStatus.Ok:
                {
                    var info = result.Info!;
                    var place = result.PlaceName ?? row.DiaDiem;
                    var date = row.NgayDi;
                    _weatherView = () => RenderWeather(info, place, date);
                    break;
                }
                case WeatherStatus.PlaceNotFound:
                {
                    var name = row.DiaDiem;
                    _weatherView = () => ShowInfo("🔍", Lang.T("w_not_found", name), ErrorBack);
                    break;
                }
                case WeatherStatus.NoData:
                    _weatherView = () => ShowInfo("🕒",
                        Lang.T("w_no_data") + Environment.NewLine + Lang.T("w_no_data_hint"), NeutralBack);
                    break;
                case WeatherStatus.NetworkError:
                    _weatherView = () => ShowInfo("📡", Lang.T("w_net_error"), ErrorBack);
                    break;
                case WeatherStatus.Timeout:
                    _weatherView = () => ShowInfo("⏱️", Lang.T("w_timeout"), ErrorBack);
                    break;
                default:
                {
                    var detail = result.Detail ?? "";
                    _weatherView = () => ShowInfo("⚠️", Lang.T("w_error", detail), ErrorBack);
                    break;
                }
            }
            _weatherView?.Invoke();
        }
        catch (OperationCanceledException) { /* form đang đóng */ }
        finally
        {
            if (!IsDisposed) SetBusy(false);
        }
    }

    private void SetBusy(bool busy)
    {
        btnThoiTiet.Enabled = !busy;
        progressBar.Visible = busy;
        UseWaitCursor = busy;
    }

    private void ShowHint() => ShowInfo("🌤️", Lang.T("w_pick"), NeutralBack);

    private void ShowInfo(string icon, string text, Color back)
    {
        panelWeather.BackColor = back;
        lblIcon.Text = icon;
        lblInfo.Text = text;
        foreach (var l in new[] { lblDesc, lblWhere, lblTemp, lblRain, lblAdvice }) l.Visible = false;
        lblInfo.Visible = true;
    }

    private void RenderWeather(WeatherInfo w, string place, DateTime date)
    {
        bool rainy = w.RainProbability >= 60;
        panelWeather.BackColor = rainy ? RainBack : NeutralBack;

        lblIcon.Text = WeatherCodes.Icon(w.Code);
        lblDesc.Text = Lang.T(WeatherCodes.Key(w.Code));
        lblWhere.Text = Lang.T("w_where", place, date.ToString("d", Lang.Culture));
        lblTemp.Text = Lang.T("w_temp", w.TempMin, w.TempMax);
        lblRain.Text = Lang.T("w_rainprob", w.RainProbability);
        lblAdvice.Text = Lang.T("w_advice");

        lblInfo.Visible = false;
        lblDesc.Visible = lblWhere.Visible = lblTemp.Visible = lblRain.Visible = true;
        lblAdvice.Visible = rainy;
    }
}
