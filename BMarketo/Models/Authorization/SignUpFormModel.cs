namespace BMarketo.Models.Authorization;

public class SignUpFormModel
{
	public string Title { get; set; } = null!;
	
	public string FirstNameLabel { get; set; } = null!;
	public string FirstNameError { get; set; } = null!;

	public string LastNameLabel { get; set; } = null!;
	public string LastNameError { get; set; } = null!;

	public string StreetNameLabel { get; set; } = null!;
	public string StreetNameError { get; set;} = null!;

	public string PostalCodeLabel { get; set; } = null!;
	public string PostalCodeError { get; set; } = null!;

	public string CityLabel { get; set; } = null!;
	public string CityError { get; set; } = null!;

	public string PhoneLabel { get; set; } = null!;

	public string? CompanyNameLabel { get; set; } = null!;


	public string EmailLabel { get; set; } = null!;
	public string EmailError { get; set; } = null!;

	public string PasswordLabel { get; set; } = null!;
	public string PasswordError { get; set; } = null!;

	public string ConfirmPasswordLabel { get; set; } = null!;
	public string ConfirmPasswordError { get; set; } = null!;

	public string? UserProfileImage { get; set; } 
	
	public string? AgreementLabel { get; set; } = null!;
	public string SubmitButton { get; set; } = null!;
}
