namespace net.personaldata.domain.Entities
{
    public class OAuth2Settings
    {
        public string AuthorizationUrl { get; set; }
        public string TokenUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Realm { get; set; }
        public string AppName { get; set; }
    }
}
