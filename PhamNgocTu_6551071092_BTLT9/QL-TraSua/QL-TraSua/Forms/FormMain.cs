namespace QL_TraSua;

public class FormMain : Form
{
    public FormMain()
    {
        var shop = AppServices.Payment.ShopName;
        Text = shop;
        ClientSize = new Size(420, 330);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        Controls.Add(new Label
        {
            Text = shop.ToUpper(),
            Font = new Font("Segoe UI", 16, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleCenter,
            Bounds = new Rectangle(10, 20, 400, 50)
        });

        AddButton("Bán hàng (lập đơn)", 90, () => new FormBanHang().ShowDialog(this));
        AddButton("Quản lý thực đơn", 160, () => new FormThucDon().ShowDialog(this));
        AddButton("Danh sách hóa đơn", 230, () => new FormHoaDon().ShowDialog(this));
    }

    private void AddButton(string text, int y, Action onClick)
    {
        var b = new Button
        {
            Text = text,
            Font = new Font("Segoe UI", 12),
            Bounds = new Rectangle(70, y, 280, 52)
        };
        b.Click += (_, _) => onClick();
        Controls.Add(b);
    }
}
