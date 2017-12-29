using System.ComponentModel.DataAnnotations.Schema;

namespace bankWebApi.Services.DatabaseModels
{
    [Table("transactions")]
    public class TransactionModel
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("sender_account_number")]
        public string SenderAccountNumber { get; set; }
        [Column("recipient_account_number")]
        public string RecipientAccountNumber { get; set; }
        [Column("amount")]
        public int Amount { get; set; }
    }
}