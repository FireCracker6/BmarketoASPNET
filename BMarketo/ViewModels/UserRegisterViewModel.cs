using System.ComponentModel.DataAnnotations;
using BMarketo.Models.Contexts.Identity;
using BMarketo.Models.Entities;

namespace BMarketo.ViewModels;

public class UserRegisterViewModel
{
	[Display(Name = "First Name*")]
	[Required(ErrorMessage = "First name is required")]
	[RegularExpression(@"^[a-zA-Z\u00C0-\u017F]+([ -][a-zA-Z\u00C0-\u017F]+)*$", ErrorMessage = "You must provide a valid first name ")]
	public string FirstName { get; set; } = null!;


	[Display(Name = "Last Name*")]
	[Required(ErrorMessage = "Last name is required")]
	[RegularExpression(@"^[a-zA-Z\u00C0-\u017F]+([ -][a-zA-Z\u00C0-\u017F]+)*$", ErrorMessage = "You must provide a valid last name")]
	public string LastName { get; set; } = null!;

	[Display(Name = "Street Name*")]
	[Required(ErrorMessage = "Street name is required")]
	public string StreetName { get; set; } = null!;

	[Display(Name = "Postal Code")]
	[Required(ErrorMessage = "Postal code is required")]
	public string PostalCode { get; set; } = null!;

	[Display(Name = "City*")]
	[Required(ErrorMessage = "City is required")]
	public string City { get; set; } = null!;

	[Display(Name = "Mobile (optional)")]

	public string? Mobile { get; set; }

	[Display(Name = "Company (optional)")]
	public string? Company { get; set; }


	[Display(Name = "E-Mail*")]
	[DataType(DataType.EmailAddress)]
	[RegularExpression(@"^[^\s@]+@[^\s@]+\.[^\s@]+$", ErrorMessage = "You must provide a valid E-mail address")]
	[Required(ErrorMessage = "E-mail is required")]
	public string Email { get; set; } = null!;

	[Display(Name = "Password*")]
	[DataType(DataType.Password)]
	[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "You must provide a valid password")]
	[Required(ErrorMessage = "Password is required")]
	public string Password { get; set; } = null!;

	[Display(Name = "Confirm Password*")]
	[DataType(DataType.Password)]
	[Required(ErrorMessage = "You must confirm your password")]
	[Compare(nameof(Password), ErrorMessage = "Your password does not match, please try again")]
	public string ConfirmPassword { get; set; } = null!;

    [Display(Name = "Upload Profile Image (optional)")]
    [DataType(DataType.Upload)]
    public IFormFile? ProfileImage { get; set; }


    [Display(Name = "I have read and accept the terms and conditions.")]
	[Required(ErrorMessage = "You must agree to the terms and conditions.")]
	public bool TermsAndConditions { get; set; } = false;

    [Display(Name = "Upload Profile Image (optional)")]
    [DataType(DataType.Upload)]
    

    public static implicit operator AppUser(UserRegisterViewModel viewModel)
	{
		return new AppUser
		{
			UserName = viewModel.Email,
			FirstName = viewModel.FirstName,
			LastName = viewModel.LastName,
			Email = viewModel.Email,
			PhoneNumber = viewModel.Mobile,
			CompanyName = viewModel.Company,
			//ImageUrl = viewModel.ProfileImage
		};
	}

	public static implicit operator AddressEntity(UserRegisterViewModel viewModel)
	{
		return new AddressEntity
		{
			StreetName = viewModel.StreetName,
			PostalCode = viewModel.PostalCode,
            City = viewModel.City
        };
	}




}
