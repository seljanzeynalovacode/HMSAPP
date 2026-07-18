namespace HMSAPP.Contract.DTOs;

public record DoctorDto : BaseDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Specialty { get; set; }
    public string LicenseNumber { get; set; }
    public string ClinicAddress { get; set; }
    public string ClinicPhoneNumber { get; set; }

}
