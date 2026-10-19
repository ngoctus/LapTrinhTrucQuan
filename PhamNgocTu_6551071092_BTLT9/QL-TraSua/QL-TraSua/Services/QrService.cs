namespace QL_TraSua;

public static class QrService
{
    private static readonly HttpClient Http = new() { Timeout = TimeSpan.FromSeconds(10) };

    /// <summary>
    /// https://img.vietqr.io/image/{BankId}-{AccountNo}-{Template}.png?amount=..&amp;addInfo=..&amp;accountName=..
    /// </summary>
    public static string BuildUrl(PaymentSettings p, decimal amount, string addInfo)
    {
        return $"https://img.vietqr.io/image/{Uri.EscapeDataString(p.BankId)}-{Uri.EscapeDataString(p.AccountNo)}-{Uri.EscapeDataString(p.Template)}.png" +
               $"?amount={(long)amount}" +
               $"&addInfo={Uri.EscapeDataString(addInfo)}" +
               $"&accountName={Uri.EscapeDataString(p.AccountName)}";
    }

    public static Task<byte[]> DownloadAsync(string url) => Http.GetByteArrayAsync(url);
}
