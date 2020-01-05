using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.Model
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Employee() { }
        public Employee(int id, string name, string surname, string email, string phone)
        {
            this.EmployeeId = id;
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Phone = phone;
        }
    }
}
