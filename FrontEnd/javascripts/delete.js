const API_URL = "https://localhost:7223/api/Doctors";
const urlParams = new URLSearchParams(window.location.search);
const id = urlParams.get('id');

async function loadDoctorDetails() {
    try {
        const res = await fetch(`${API_URL}/${id}`);
        const doc = await res.json();

        document.getElementById('doctorDetails').innerHTML = `
            <p><b>Ad Soyad:</b> ${doc.name || doc.Name} ${doc.surname || doc.Surname}</p>
            <p><b>İxtisas:</b> ${doc.specialty || doc.Specialty}</p>
            <p><b>E-poçt:</b> ${doc.email || doc.Email}</p>
            <p><b>Telefon:</b> ${doc.phone || doc.Phone}</p>
            <p><b>Lisenziya №:</b> ${doc.licenseNumber || doc.LicenseNumber}</p>
            <p><b>Klinika:</b> ${doc.clinicAddress || doc.ClinicAddress}</p>
        `;
    } catch (err) {
        document.getElementById('doctorDetails').innerText = "Məlumat tapılmadı!";
    }
}

document.getElementById('confirmDeleteBtn').addEventListener('click', async () => {
    try {
        const res = await fetch(`${API_URL}/${id}`, { method: 'DELETE' });
        if (res.ok) {
            window.location.href = "index.html";
        }
    } catch (err) {
        console.error("Xəta:", err);
    }
});

loadDoctorDetails();