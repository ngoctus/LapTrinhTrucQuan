using Microsoft.EntityFrameworkCore;
using QL_TraSua.Models;

namespace QL_TraSua;

public class FormThucDon : Form
{
    private class MonRow
    {
        public int MaMon { get; set; }
        public string TenMon { get; set; } = "";
        public string TenDM { get; set; } = "";
        public decimal GiaBan { get; set; }
        public bool DangBan { get; set; }
        public int MaDM { get; set; }
    }

    private readonly TextBox txtTen = new() { Bounds = new Rectangle(110, 25, 280, 25) };
    private readonly ComboBox cboDM = new() { Bounds = new Rectangle(110, 60, 280, 25), DropDownStyle = ComboBoxStyle.DropDownList };
    private readonly NumericUpDown numGia = new()
    {
        Bounds = new Rectangle(500, 25, 150, 25), Maximum = 10_000_000, Increment = 1000, ThousandsSeparator = true
    };
    private readonly CheckBox chkBan = new() { Text = "Đang bán", Checked = true, Bounds = new Rectangle(500, 60, 150, 25) };

    private readonly TextBox txtTim = new() { Bounds = new Rectangle(80, 25, 250, 25) };
    private readonly ComboBox cboLoc = new() { Bounds = new Rectangle(430, 25, 200, 25), DropDownStyle = ComboBoxStyle.DropDownList };
    private readonly DataGridView dgv = new() { Bounds = new Rectangle(10, 190, 860, 360), Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right };

    private int _selectedId;
    private bool _loading;

    public FormThucDon()
    {
        Text = "Quản lý thực đơn";
        ClientSize = new Size(880, 560);
        StartPosition = FormStartPosition.CenterParent;
        BuildUi();
        Load += (_, _) => { LoadCategories(); LoadMon(); };
    }

    private void BuildUi()
    {
        var gb = new GroupBox { Text = "Thông tin món", Bounds = new Rectangle(10, 10, 860, 100) };
        var btnThem = new Button { Text = "Thêm", Bounds = new Rectangle(670, 22, 85, 30) };
        var btnSua = new Button { Text = "Sửa", Bounds = new Rectangle(670, 57, 85, 30) };
        var btnXoa = new Button { Text = "Xóa", Bounds = new Rectangle(765, 22, 85, 30) };
        var btnMoi = new Button { Text = "Làm mới", Bounds = new Rectangle(765, 57, 85, 30) };
        btnThem.Click += (_, _) => Them();
        btnSua.Click += (_, _) => Sua();
        btnXoa.Click += (_, _) => Xoa();
        btnMoi.Click += (_, _) => ClearInputs();
        gb.Controls.AddRange(new Control[]
        {
            Helper.Lbl("Tên món:", 15, 26), txtTen,
            Helper.Lbl("Danh mục:", 15, 61), cboDM,
            Helper.Lbl("Giá bán:", 410, 26), numGia,
            chkBan, btnThem, btnSua, btnXoa, btnMoi
        });

        var gbTim = new GroupBox { Text = "Tìm kiếm / lọc", Bounds = new Rectangle(10, 120, 860, 60) };
        var btnXoaLoc = new Button { Text = "Xóa lọc", Bounds = new Rectangle(650, 21, 90, 28) };
        btnXoaLoc.Click += (_, _) =>
        {
            _loading = true; txtTim.Clear(); cboLoc.SelectedIndex = 0; _loading = false; LoadMon();
        };
        txtTim.TextChanged += (_, _) => { if (!_loading) LoadMon(); };
        cboLoc.SelectedIndexChanged += (_, _) => { if (!_loading) LoadMon(); };
        gbTim.Controls.AddRange(new Control[]
        {
            Helper.Lbl("Tên món:", 15, 26, 65), txtTim,
            Helper.Lbl("Danh mục:", 350, 26, 75), cboLoc, btnXoaLoc
        });

        Helper.StyleGrid(dgv);
        dgv.Columns.Add(Helper.Col("MaMon", "Mã", 40));
        dgv.Columns.Add(Helper.Col("TenMon", "Tên món", 200));
        dgv.Columns.Add(Helper.Col("TenDM", "Danh mục", 110));
        dgv.Columns.Add(Helper.Col("GiaBan", "Giá bán", 90, "N0"));
        dgv.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "DangBan", HeaderText = "Đang bán", FillWeight = 60 });
        dgv.SelectionChanged += Dgv_SelectionChanged;

        Controls.AddRange(new Control[] { gb, gbTim, dgv });
    }

    private void LoadCategories()
    {
        _loading = true;
        using var db = AppServices.CreateDb();
        var list = db.DanhMucMons.OrderBy(x => x.TenDM).Select(x => new DmItem(x.MaDM, x.TenDM)).ToList();

        cboDM.DataSource = list.ToList();
        cboDM.DisplayMember = nameof(DmItem.TenDM);
        cboDM.ValueMember = nameof(DmItem.MaDM);

        var loc = new List<DmItem> { new(0, "-- Tất cả --") };
        loc.AddRange(list);
        cboLoc.DataSource = loc;
        cboLoc.DisplayMember = nameof(DmItem.TenDM);
        cboLoc.ValueMember = nameof(DmItem.MaDM);
        _loading = false;
    }

    private void LoadMon()
    {
        try
        {
            using var db = AppServices.CreateDb();
            var q = from m in db.MonUongs
                    join d in db.DanhMucMons on m.MaDM equals d.MaDM
                    select new MonRow
                    {
                        MaMon = m.MaMon, TenMon = m.TenMon, TenDM = d.TenDM,
                        GiaBan = m.GiaBan, DangBan = m.DangBan, MaDM = m.MaDM
                    };

            var kw = txtTim.Text.Trim();
            if (kw.Length > 0) q = q.Where(x => x.TenMon.Contains(kw));

            var loc = cboLoc.SelectedValue is int v ? v : 0;
            if (loc > 0) q = q.Where(x => x.MaDM == loc);

            dgv.DataSource = q.OrderBy(x => x.MaMon).ToList();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không đọc được dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void Dgv_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgv.CurrentRow?.DataBoundItem is not MonRow r) return;
        _selectedId = r.MaMon;
        txtTen.Text = r.TenMon;
        cboDM.SelectedValue = r.MaDM;
        numGia.Value = Math.Clamp(r.GiaBan, numGia.Minimum, numGia.Maximum);
        chkBan.Checked = r.DangBan;
    }

    private void ClearInputs()
    {
        _selectedId = 0;
        txtTen.Clear();
        numGia.Value = 0;
        chkBan.Checked = true;
        if (cboDM.Items.Count > 0) cboDM.SelectedIndex = 0;
        dgv.ClearSelection();
        txtTen.Focus();
    }

    private bool ValidateInput(out string ten)
    {
        ten = txtTen.Text.Trim();
        if (ten.Length == 0)
        {
            MessageBox.Show("Vui lòng nhập tên món.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTen.Focus();
            return false;
        }
        if (numGia.Value <= 0)
        {
            MessageBox.Show("Giá bán phải lớn hơn 0.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            numGia.Focus();
            return false;
        }
        if (cboDM.SelectedValue is not int)
        {
            MessageBox.Show("Vui lòng chọn danh mục.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }

    private void Them()
    {
        if (!ValidateInput(out var ten)) return;
        try
        {
            using var db = AppServices.CreateDb();
            db.MonUongs.Add(new MonUong
            {
                TenMon = ten, GiaBan = numGia.Value, DangBan = chkBan.Checked, MaDM = (int)cboDM.SelectedValue!
            });
            db.SaveChanges();
            LoadMon();
            MessageBox.Show("Đã thêm món.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không thêm được: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void Sua()
    {
        if (_selectedId == 0)
        {
            MessageBox.Show("Hãy chọn một món trong danh sách.", "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (!ValidateInput(out var ten)) return;
        try
        {
            using var db = AppServices.CreateDb();
            var m = db.MonUongs.Find(_selectedId);
            if (m == null) { MessageBox.Show("Món không còn tồn tại."); LoadMon(); return; }
            m.TenMon = ten;
            m.GiaBan = numGia.Value;
            m.DangBan = chkBan.Checked;
            m.MaDM = (int)cboDM.SelectedValue!;
            db.SaveChanges();
            LoadMon();
            MessageBox.Show("Đã cập nhật món.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không sửa được: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void Xoa()
    {
        if (_selectedId == 0)
        {
            MessageBox.Show("Hãy chọn một món trong danh sách.", "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (MessageBox.Show("Xóa món đang chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;
        try
        {
            using var db = AppServices.CreateDb();
            if (db.ChiTietHoaDons.Any(c => c.MaMon == _selectedId))
            {
                MessageBox.Show("Món này đã có trong hóa đơn nên không thể xóa.\nHãy bỏ chọn \"Đang bán\" rồi bấm Sửa.",
                    "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var m = db.MonUongs.Find(_selectedId);
            if (m != null)
            {
                db.MonUongs.Remove(m);
                db.SaveChanges();
            }
            ClearInputs();
            LoadMon();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không xóa được: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
