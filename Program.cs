using Microsoft.AspNetCore.SignalR.Client;

class Program
{
    static async Task Main(string[] args)
    {
        // Kết nối tới SignalR Hub
        var connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7176/hubs/notification") // Thay URL theo cấu hình API của bạn
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
