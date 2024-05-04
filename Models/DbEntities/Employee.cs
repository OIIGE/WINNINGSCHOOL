using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WINNINGSCHOOL.Models.DbEntities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Emails { get; set; }
        public string PhoneNumbers { get; set; }
        public double Salary { get; set; }
    }
}
