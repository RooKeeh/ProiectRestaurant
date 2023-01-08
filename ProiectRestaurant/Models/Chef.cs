using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProiectRestaurant.Models
{
    public class Chef
    {
        public int ID { get; set; }
        [Display(Name = "First Name:")]
        public string? FirstName { get; set; }
        [Display(Name = "Last Name:")]
        public string? LastName { get; set; }
        [Display(Name = "Full Name:")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
