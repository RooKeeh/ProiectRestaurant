using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProiectRestaurant.Models
{
    public class Client
    {
        public int ID { get; set; }
        [Display(Name = "First Name:")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula")]
        [StringLength(30, MinimumLength = 3)]
        public string? FirstName { get; set; }
        [Display(Name = "Last Name:")]
        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Numele trebuie sa inceapa cu majuscula")]
        [StringLength(30, MinimumLength = 3)]
        public string? LastName { get; set; }
        [StringLength(70)]
        [Display(Name = "Adress:")]
        public string? Adress { get; set; }
        [Display(Name = "Email:")]
        public string Email { get; set; }
        [Display(Name = "Phone:")]
        [RegularExpression(@"^\(?(0{1})([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa inceapa cu cifra 0 si sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123'")]
        public string? Phone { get; set; }
        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public ICollection<Order>? Orders { get; set; }
    }
}
