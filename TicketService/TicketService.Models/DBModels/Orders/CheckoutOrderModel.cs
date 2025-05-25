using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("checkout_order")]
public class CheckoutOrderModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("order")]
    public required string Order { get; set; }
    [Column("step")]
    public int Step { get; set; }

    [Column("date_created")]
    public DateTime DateCreated { get; set; }

    [Column("date_updated")]
    public DateTime? DateUpdated { get; set; }
}
