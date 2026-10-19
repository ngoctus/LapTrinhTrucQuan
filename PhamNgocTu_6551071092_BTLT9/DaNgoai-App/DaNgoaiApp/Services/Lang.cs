using System.Globalization;

namespace DaNgoaiApp.Services;

/// <summary>Đa ngôn ngữ Việt/Anh: chuỗi + CultureInfo.</summary>
public static class Lang
{
    public static string Code { get; private set; } = "vi";
    public static CultureInfo Culture { get; private set; } = new("vi-VN");

    public static void Set(string? code)
    {
        Code = code == "en" ? "en" : "vi";
        Culture = new CultureInfo(Code == "en" ? "en-US" : "vi-VN");
        CultureInfo.CurrentCulture = Culture;
        CultureInfo.CurrentUICulture = Culture;
        CultureInfo.DefaultThreadCurrentCulture = Culture;
        CultureInfo.DefaultThreadCurrentUICulture = Culture;
    }

    public static string T(string key)
        => Dict.TryGetValue(key, out var v) ? (Code == "en" ? v.En : v.Vi) : key;

    public static string T(string key, params object[] args)
        => string.Format(Culture, T(key), args);

    private static readonly Dictionary<string, (string Vi, string En)> Dict = new()
    {
        ["form_title"]   = ("Kế hoạch dã ngoại", "Picnic Trip Planner"),
        ["grp_info"]     = ("Thông tin chuyến đi", "Trip details"),
        ["lbl_name"]     = ("Tên chuyến", "Trip name"),
        ["lbl_place"]    = ("Địa điểm", "Destination"),
        ["lbl_date"]     = ("Ngày đi", "Date"),
        ["lbl_people"]   = ("Số người", "People"),
        ["lbl_budget"]   = ("Ngân sách (VND)", "Budget (VND)"),
        ["lbl_transport"]= ("Phương tiện", "Transport"),
        ["chk_done"]     = ("Đã hoàn thành", "Completed"),
        ["lbl_note"]     = ("Ghi chú", "Notes"),
        ["btn_add"]      = ("Thêm", "Add"),
        ["btn_edit"]     = ("Sửa", "Edit"),
        ["btn_delete"]   = ("Xóa", "Delete"),
        ["btn_refresh"]  = ("Làm mới", "Refresh"),
        ["grp_lang"]     = ("Ngôn ngữ", "Language"),
        ["rdo_vi"]       = ("Tiếng Việt", "Tiếng Việt"),
        ["rdo_en"]       = ("English", "English"),
        ["grp_weather"]  = ("Dự báo thời tiết", "Weather forecast"),
        ["btn_weather"]  = ("Xem thời tiết", "Check weather"),
        ["grp_filter"]   = ("Tìm kiếm / Lọc", "Search / Filter"),
        ["lbl_search"]   = ("Tìm kiếm:", "Search:"),
        ["chk_pending"]  = ("Chỉ hiện chuyến chưa hoàn thành", "Show unfinished trips only"),
        ["chk_range"]    = ("Ngày đi:", "Date range:"),
        ["lbl_from"]     = ("Từ", "From"),
        ["lbl_to"]       = ("Đến", "To"),

        ["col_id"]       = ("Mã", "ID"),
        ["col_name"]     = ("Tên chuyến", "Trip name"),
        ["col_place"]    = ("Địa điểm", "Destination"),
        ["col_date"]     = ("Ngày đi", "Date"),
        ["col_people"]   = ("Số người", "People"),
        ["col_budget"]   = ("Ngân sách (VND)", "Budget (VND)"),
        ["col_transport"]= ("Phương tiện", "Transport"),
        ["col_done"]     = ("Hoàn thành", "Completed"),
        ["col_note"]     = ("Ghi chú", "Notes"),

        ["tr_motorbike"] = ("Xe máy", "Motorbike"),
        ["tr_car"]       = ("Ô tô", "Car"),
        ["tr_coach"]     = ("Xe khách", "Coach"),
        ["tr_train"]     = ("Tàu hỏa", "Train"),

        ["msg_title_warn"]    = ("Thông báo", "Notice"),
        ["msg_title_error"]   = ("Lỗi", "Error"),
        ["msg_title_confirm"] = ("Xác nhận", "Confirm"),
        ["val_name"]     = ("Vui lòng nhập tên chuyến.", "Please enter the trip name."),
        ["val_place"]    = ("Vui lòng nhập địa điểm.", "Please enter the destination."),
        ["val_date"]     = ("Ngày đi không được nhỏ hơn hôm nay.", "The trip date cannot be earlier than today."),
        ["val_people"]   = ("Số người phải ≥ 1.", "Number of people must be ≥ 1."),
        ["val_budget"]   = ("Ngân sách phải ≥ 0.", "Budget must be ≥ 0."),
        ["msg_added"]    = ("Đã thêm chuyến đi.", "Trip added."),
        ["msg_updated"]  = ("Đã cập nhật chuyến đi.", "Trip updated."),
        ["msg_deleted"]  = ("Đã xóa chuyến đi.", "Trip deleted."),
        ["msg_select"]   = ("Vui lòng chọn một chuyến đi trong danh sách.", "Please select a trip from the list."),
        ["msg_not_found_row"] = ("Chuyến đi không còn tồn tại.", "This trip no longer exists."),
        ["msg_confirm_delete"] = ("Bạn có chắc muốn xóa chuyến \"{0}\"?", "Are you sure you want to delete the trip \"{0}\"?"),
        ["msg_db_error"] = ("Không thể truy cập cơ sở dữ liệu QL_DaNgoai.\nHãy chắc chắn đã chạy script Database\\QL_DaNgoai.sql trên .\\SQLEXPRESS.\n\nChi tiết: {0}",
                            "Cannot access the QL_DaNgoai database.\nMake sure Database\\QL_DaNgoai.sql was run on .\\SQLEXPRESS.\n\nDetails: {0}"),

        ["w_pick"]       = ("Chọn một chuyến đi rồi bấm \"Xem thời tiết\".", "Select a trip, then click \"Check weather\"."),
        ["w_loading"]    = ("Đang tải dự báo...", "Loading forecast..."),
        ["w_clear"]      = ("Trời quang", "Clear sky"),
        ["w_cloudy"]     = ("Có mây", "Cloudy"),
        ["w_fog"]        = ("Sương mù", "Fog"),
        ["w_rain"]       = ("Mưa", "Rain"),
        ["w_snow"]       = ("Tuyết", "Snow"),
        ["w_storm"]      = ("Dông", "Thunderstorm"),
        ["w_other"]      = ("Khác", "Other"),
        ["w_where"]      = ("{0} – {1}", "{0} – {1}"),
        ["w_temp"]       = ("Nhiệt độ: {0:0.#}°C – {1:0.#}°C", "Temperature: {0:0.#}°C – {1:0.#}°C"),
        ["w_rainprob"]   = ("Xác suất mưa: {0}%", "Chance of rain: {0}%"),
        ["w_advice"]     = ("Nên mang áo mưa hoặc cân nhắc dời lịch", "Bring a raincoat or consider rescheduling"),
        ["w_no_data"]    = ("Chưa có dữ liệu dự báo", "No forecast data available yet"),
        ["w_no_data_hint"] = ("(Chỉ dự báo được trong vòng 16 ngày tới.)", "(Forecasts only cover the next 16 days.)"),
        ["w_not_found"]  = ("Không tìm thấy địa danh \"{0}\". Hãy thử tên không dấu, ví dụ \"Da Lat\".",
                            "Place \"{0}\" was not found. Try the name without diacritics, e.g. \"Da Lat\"."),
        ["w_net_error"]  = ("Không kết nối được mạng. Vui lòng kiểm tra Internet rồi thử lại.",
                            "Cannot connect to the network. Please check your Internet connection and try again."),
        ["w_timeout"]    = ("Máy chủ thời tiết phản hồi quá chậm (quá 8 giây). Vui lòng thử lại.",
                            "The weather server took too long to respond (over 8 seconds). Please try again."),
        ["w_error"]      = ("Không lấy được dự báo: {0}", "Could not get the forecast: {0}"),
    };
}
