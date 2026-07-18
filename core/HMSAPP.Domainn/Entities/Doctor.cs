namespace HMSAPP.Domainn.Entities;

public class Doctor : Person
{
    public string Specialty { get; set; }
    public string LicenseNumber { get; set; }
    public string ClinicAddress { get; set; }
    public string ClinicPhoneNumber { get; set; }
}
