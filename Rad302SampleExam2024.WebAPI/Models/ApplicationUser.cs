using Microsoft.AspNetCore.Identity;

namespace Rad302SampleExam2024.WebAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
