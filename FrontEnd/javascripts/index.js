const API_URL = "https://localhost:7223/api/Doctors";

async function fetchDoctors() {
    try {
        const response = await fetch(API_URL);
        if (!response.ok) throw new Error("Məlumat gətirilmədi");

        const doctors = await response.json();
        const tableBody = document.getElementById('doctorTableBody');
        tableBody.innerHTML = '';

        if (doctors.length === 0) {
            tableBody.innerHTML = '<tr><td colspan="7" style="text-align:center;">Hələ ki, heç bir həkim əlavə edilməyib.</td></tr>';
            return;
        }

        doctors.forEach(doc => {
            const id = doc.id || doc.Id;
            const name = doc.name || doc.Name;
            const surname = doc.surname || doc.Surname;
            const email = doc.email || doc.Email;
            const phone = doc.phone || doc.Phone;
            const specialty = doc.specialty || doc.Specialty;
            const license = doc.licenseNumber || doc.LicenseNumber;
            const address = doc.clinicAddress || doc.ClinicAddress;
            const clinicPhone = doc.clinicPhoneNumber || doc.ClinicPhoneNumber;

            tableBody.innerHTML += `
                <tr>
                    <td>${id}</td>
                    <td><b>${name} ${surname}</b></td>
                    <td>${specialty}</td>
                    <td>${email}<br><small style="color:#64748b;">${phone}</small></td>
                    <td>${license}</td>
                    <td>${address}<br><small style="color:#64748b;">${clinicPhone}</small></td>
                    <td class="actions">
                        <a href="edit.html?id=${id}" class="btn-edit">Düzəliş et</a>
                        <a href="delete.html?id=${id}" class="btn-delete">Sil</a>
                    </td>
                </tr>
            `;
        });
    } catch (error) {
        console.error("Xəta:", error);
        document.getElementById('doctorTableBody').innerHTML = 
            '<tr><td colspan="7" style="text-align:center; color:red;">Serverə qoşulmaq mümkün olmadı! Backend-in işlədiyini yoxlayın.</td></tr>';
    }
}

fetchDoctors();