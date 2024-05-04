using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WINNINGSCHOOL.Models.DbEntities
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "VarChar(50)")]
        public string FirstName { get; set; }
        [Column(TypeName = "VarChar(50)")]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string StateOfOrigin { get; set; }

        public string Address { get; set; }
        [Column(TypeName = "VarChar(50)")]
        public string ParentFullName { get; set; }

        public string ParentPhoneNumber { get; set; }

        public string ParentAddress { get; set; }
        public string GuidanceEmail { get; set; }

        public DateTime EnrollmentDate { get; set; }

    }
}
