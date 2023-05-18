namespace RedisDemo.Models
{
    [Serializable]
    public class DashboardData
    {
        public int TotalCustomerCount { get; set; }
        public int TotalRevenue { get; set; }
        public string TotalSpellingProductName { get; set; }
        public string TotalSpellingCountryName { get; set; }
    }
}
