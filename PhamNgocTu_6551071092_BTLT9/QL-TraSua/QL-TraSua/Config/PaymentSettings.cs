namespace QL_TraSua;

/// <summary>Lớp cấu hình có kiểu, bind từ mục "Payment" trong appsettings.json.</summary>
public class PaymentSettings
{
    public string ShopName { get; set; } = "Quán trà sữa";
    public string BankId { get; set; } = "";
    public string AccountNo { get; set; } = "";
    public string AccountName { get; set; } = "";
    public string Template { get; set; } = "compact2";
}
