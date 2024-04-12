using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATTWOOLSCHOOL.Models
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
        [Column(TypeName = "VarChar(50)")]
        public String Address { get; set; }
        public string ParentFullName { get; set; }
        [Column(TypeName = "VarChar(50)")]
        public int ParentPhoneNumber { get; set; }
        public String ParentAddress { get; set; }
        public String GuidanceEmail { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
