using System.ComponentModel.DataAnnotations.Schema;

namespace bankWebApi.Services.DatabaseModels
{
    [Table("client_account")]
    public class ClientAccountModel
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("client_id")]
        public int ClientId { get; set; }
        [Column("account_number")]
        public string AccountNumber { get; set; }
        [Column("money")]
        public int Money { get; set; }
        [Column("active")]
        public bool IsActive { get; set; }
    }
}