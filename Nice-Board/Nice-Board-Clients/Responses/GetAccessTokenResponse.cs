namespace Nice_Board.GoogleClient.Responses
{
    public class GetAccessTokenResponse
    {
        public string error { get; set; }
        public string error_description { get; set; }
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string refresh_token { get; set; }
    }
}
