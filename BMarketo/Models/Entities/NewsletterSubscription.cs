using System.ComponentModel.DataAnnotations;

namespace BMarketo.Models.Entities;

public class NewsletterSubscription
{
    public int Id { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
