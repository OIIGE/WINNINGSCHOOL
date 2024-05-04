using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WINNINGSCHOOL.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        [Column(TypeName = "VarChar(50)")]
        public string FirstName { get; set; }
        [Column(TypeName = "VarChar(50)")]
        public String LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string StateOfOrigin { get; set; }
        
        public String Address { get; set; }
      
        public string ParentFullName { get; set; }
        public string ParentPhoneNumber { get; set; }
        
        public String ParentAddress { get; set; }
        public String GuidanceEmail { get; set; }
        public DateTime EnrollmentDate { get; set; }
        
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
