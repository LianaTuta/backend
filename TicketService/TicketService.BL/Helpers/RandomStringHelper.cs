using System.Text;

namespace TicketService.BL.Helpers
{
    public static class RandomStringHelper
    {
        private static readonly Random _random = new();
        private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static string Generate(int length)
        {
            StringBuilder sb = new(length);
            for (int i = 0; i < length; i++)
            {
                _ = sb.Append(_chars[_random.Next(_chars.Length)]);
            }
            return sb.ToString();
        }
    }
}
