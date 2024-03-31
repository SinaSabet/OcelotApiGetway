namespace PushNotiffication.Email.ServiceDiscovery
{
    public static class Config
    {
        public static Uri ServiceDiscoveryAddress = new("http://localhost:8500");
        public static Uri ServiceAddress = new("http://localhost:5147");
        public static Uri HealthCheckEndPoint = new("http://localhost:5147/api/email/hc");
        public static string ServiceName = "EmailService";
        public static string ServiceId=$"{ServiceName}_{01}";
    }
}
