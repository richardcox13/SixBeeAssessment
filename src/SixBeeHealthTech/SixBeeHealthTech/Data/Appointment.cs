using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SixBeeHealthTech.Data;

public class Appointment {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required, MaxLength(80)]
    public string Name { get; set; } = null!;

    [Required]
    public DateTime When { get; set; }

    [Required] // Defauls to nvarchar(max): was never a good default.
    public string Description { get; set; } = null!;

    [Required, MaxLength(80)]
    public string ContactPhone { get; set; } = null!;

    [Required, MaxLength(80)]
    public string Email { get; set; } = null!;

    public bool Approved { get; set; }
}
