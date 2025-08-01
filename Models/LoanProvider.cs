using System.ComponentModel.DataAnnotations;
namespace LoanProviderService.Models
{
    public class LoanProvider
    {
          [Key]
          public int Id { get; set; }
          [Required]
          public string? ProviderName { get; set; }
          [Required]
          public string? BankName {  get; set; }
          [Required]
          public string? LicenseInfo { get; set; }

    }
}
