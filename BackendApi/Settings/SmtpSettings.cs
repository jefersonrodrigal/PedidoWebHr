namespace BackendApi.Settings
{
    public class SmtpSettings
    {
        public string DefaultAddress { get; set; } = string.Empty;
        public string Host { get; set; } = "";
        public int Port { get; set; }
        public string User { get; set; } = "";
        public string Password { get; set; } = "";
        public bool Ssl { get; set; } = true;
    }
}
