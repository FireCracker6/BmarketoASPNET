using Microsoft.AspNetCore.Mvc.Rendering;

namespace BMarketo.ViewModels;

public class ManageRolesUserViewModel
{
    public string UserId { get; set; }
    public string Email { get; set; }
    public List<string> Roles { get; set; }
    public List<SelectListItem> AvailableRoles { get; set; }
    public string NewRole { get; set; }
    public string SelectedRole { get; set; }
}
