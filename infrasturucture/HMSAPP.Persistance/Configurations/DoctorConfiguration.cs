using HMSAPP.Domainn.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HMSAPP.Persistance.Configurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        // 1. Cədvəl adı
        builder.ToTable("Doctors");

       

        // 3. Person (Abstract) sinfindən gələn mülklər
        builder.Property(d => d.Name)
               .IsRequired()
               .HasMaxLength(50); // Maksimum uzunluq mütləq qoyulmalıdır (nargs(max) olmasın)

        builder.Property(d => d.Surname)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(d => d.Email)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(d => d.Phone)
               .IsRequired(false) // Boş (null) ola bilər
               .HasMaxLength(20);

        // 4. Doctor sinfinin özünəməxsus mülkləri
        builder.Property(d => d.Specialty)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(d => d.LicenseNumber)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(d => d.ClinicAddress)
               .IsRequired(false)
               .HasMaxLength(250);

        builder.Property(d => d.ClinicPhoneNumber)
               .IsRequired(false)
               .HasMaxLength(20);

        // 5. İndekslər (Indexes)
        // Hər həkimin lisenziya nömrəsi unikal olmalıdır, axtarışlar sürətli getsin deyə Index veririk
        builder.HasIndex(d => d.LicenseNumber)
               .IsUnique();

        // Email-ə görə də unikal indeks qoymaq olar
        builder.HasIndex(d => d.Email)
               .IsUnique();
    }
}

