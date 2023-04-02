namespace BMarketo.Models
{
    public class ContactFormModel
    {
        public string Title { get; set; } = null!;
        public string NameLabel { get; set; } = null!;
        public string NameError { get; set; } = null!;
        public string EmailLabel { get; set; } = null!;
        public string EmailError { get; set; } = null!;
        public string PhoneLabel { get; set; } = null!;
        public string? CompanyNameLabel { get; set; } = null!;
        public string MessageLabel { get; set; } = null!;
        public string MessageError { get; set; } = null!;
        public string? SaveUserInfoLabel { get; set; } = null!;
        public string SubmitButton { get; set; } = null!;
    }
}
