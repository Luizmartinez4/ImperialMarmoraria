namespace ImperialMarmoraria.Communication.Requests.User
{
    public class RequestChangePasswordJson
    {
        public string Password { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
