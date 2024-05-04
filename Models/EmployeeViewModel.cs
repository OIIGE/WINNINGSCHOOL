using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WINNINGSCHOOL.Models
{
    public class EmployeeViewModel
    {
        //it will be used for display purpose
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Datge of Birth")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("E-mail")]
        public string Emails { get; set; }
        public string PhoneNumbers { get; set; }
        public double Salary { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
