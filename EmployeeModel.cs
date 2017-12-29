using System.ComponentModel.DataAnnotations.Schema;

namespace bankWebApi.Services.DatabaseModels
{
    [Table("employee")]
    public class EmployeeModel
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("login")]
        public string Login { get; set; }
        [Column("phone_number")]
        public string PhoneNumber { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("password_hash")]
        public string PasswordHash { get; set; }
    }
}