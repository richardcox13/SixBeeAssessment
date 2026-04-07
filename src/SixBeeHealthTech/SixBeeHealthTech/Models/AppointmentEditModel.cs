using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SixBeeHealthTech.Data;

namespace SixBeeHealthTech.Models;

public class AppointmentEditModel {
    public AppointmentEditModel() { /* no-op */ }

    public AppointmentEditModel(Appointment appt) {
        Id = appt.Id;
        Name = appt.Name;
        When = appt.When;
        Description = appt.Description;
        ContactPhone = appt.ContactPhone;
        Email = appt.Email;
    }

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

    public Appointment UpdateAppointment(Appointment appt) {
        appt.Name = Name;
        appt.When = When;
        appt.Description = Description;
        appt.ContactPhone = ContactPhone;
        appt.Email = Email;

        return appt;
    }
}
