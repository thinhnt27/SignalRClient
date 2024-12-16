using Microsoft.AspNetCore.SignalR.Client;

class Program
{
    static async Task Main(string[] args)
    {
        // Tạo JWT token (giả sử bạn đã có một token hợp lệ)
        string jwtToken = "token_here"; // Thay bằng JWT token thực tế

        // Kết nối tới SignalR Hub
        var connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7176/hubs/notification", options =>
            {
                options.AccessTokenProvider = async () => jwtToken; // Truyền JWT token
            })
            .Build();

        // Lắng nghe sự kiện "ReceiveNotification"
        connection.On<string>("ReceiveNotification", (message) =>
        {
            Console.WriteLine($"Thông báo nhận được: {message}");
        });

        try
        {
            // Kết nối tới SignalR Server
            await connection.StartAsync();
            Console.WriteLine("Kết nối SignalR thành công!");

            // Chờ input từ người dùng (giữ app chạy)
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi kết nối SignalR: {ex.Message}");
        }
    }
}
