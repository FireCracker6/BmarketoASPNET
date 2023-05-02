using BMarketo.Models;
using BMarketo.Models.Authorization;

namespace BMarketo.Services.Authorization;

public class SignUpFormService
{
	private readonly List<SignUpFormModel> _signup = new()
	{
		new SignUpFormModel()
		{
			Title = "Please Register Your new Account",
			FirstNameLabel = "First Name*",
			FirstNameError = "Your first name is required",
			LastNameLabel = "Last Name*",
			LastNameError = "Your last name is required",
			StreetNameLabel = "Street Name*",
			StreetNameError = "Your streetname is required",
			PostalCodeLabel = "Postal Code*",
			PostalCodeError = "Postal code is required",
			CityLabel = "City*",
			CityError = "City is required",
			PhoneLabel = "Mobile (optional)",
			CompanyNameLabel = "Company (optional)",
			EmailLabel = "E-mail*",
			EmailError = "Your e-mail address is required",
			PasswordLabel = "Password*",
			PasswordError = "You must choose a password",
			ConfirmPasswordLabel = "Confirm Password*",
			ConfirmPasswordError = "Password does not match",
			UserProfileImage = "Upload Profile Image (optional)",
			AgreementLabel = "I have read and accept the terms and agreements.",
			SubmitButton = "SIGN UP"

		}
	};
	public SignUpFormModel GetLatest()
	{
		return _signup.LastOrDefault()!;
	}
}
