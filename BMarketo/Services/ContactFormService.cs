using BMarketo.Models;

namespace BMarketo.Services;

public class ContactFormService
{
    private readonly List<ContactFormModel> _contacts = new()
    {
        new ContactFormModel()
        {
           Title = "Write something",
           NameLabel = "Your Name*",
           NameError = "Your name is required",
           EmailLabel = "Your Email*",
           EmailError = "Your email is required",
           PhoneLabel = "Phone Number (optional)",
           CompanyNameLabel = "Company (optional)",
           MessageLabel = "Message*",
           MessageError = "Message is required",
           SaveUserInfoLabel = "Save my name, email in the this browser for the next time I comment.",
           SubmitButton = "Submit"
        }
    };
    public ContactFormModel GetLatest()
    {
        return _contacts.LastOrDefault()!;
    }
}
