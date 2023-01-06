using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProiectRestaurant.Models
{
    public class Chef
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
