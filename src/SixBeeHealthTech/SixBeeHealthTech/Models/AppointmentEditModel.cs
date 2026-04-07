using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SixBeeHealthTech.Models;

public class AppointmentEditModel {
    [HiddenInput(DisplayValue = false)]
    public int Id { get; set; }

    [Required, MaxLength(80)]
    public string Name { get; set; } = null!;

    [Required]
    public DateTime When { get; set; }

    [Required] // Defauls to nvarchar(max): was never a good default.
    public string Description { get; set; } = null!;

    [Required, MaxLength(80)]
    [Phone]
    public string ContactPhone { get; set; } = null!;

    [Required, MaxLength(80)]
    [EmailAddress]
    public string Email { get; set; } = null!;
}
