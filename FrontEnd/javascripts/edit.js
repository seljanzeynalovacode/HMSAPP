const API_URL = "https://localhost:7223/api/Doctors";
const urlParams = new URLSearchParams(window.location.search);
const id = urlParams.get('id');

async function getDoctorDetails() {
    try {
        const res = await fetch(`${API_URL}/${id}`);
        const doc = await res.json();

        document.getElementById('name').value = doc.name || doc.Name;
        document.getElementById('surname').value = doc.surname || doc.Surname;
        document.getElementById('email').value = doc.email || doc.Email;
        document.getElementById('phone').value = doc.phone || doc.Phone;
        document.getElementById('specialty').value = doc.specialty || doc.Specialty;
        document.getElementById('licenseNumber').value = doc.licenseNumber || doc.LicenseNumber;
        document.getElementById('clinicAddress').value = doc.clinicAddress || doc.ClinicAddress;
        document.getElementById('clinicPhoneNumber').value = doc.clinicPhoneNumber || doc.ClinicPhoneNumber;
    } catch (err) {
        console.error("Xəta:", err);
    }
}

document.getElementById('editForm').addEventListener('submit', async (e) => {
    e.preventDefault();

    const updatedData = {
        id: id,
        Name: document.getElementById('name').value,
        Surname: document.getElementById('surname').value,
        Email: document.getElementById('email').value,
        Phone: document.getElementById('phone').value,
        Specialty: document.getElementById('specialty').value,
        LicenseNumber: document.getElementById('licenseNumber').value,
        ClinicAddress: document.getElementById('clinicAddress').value,
        ClinicPhoneNumber: document.getElementById('clinicPhoneNumber').value
    };

    try {
        const res = await fetch(`${API_URL}/${id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(updatedData)
        });

        if (res.ok) {
            window.location.href = "index.html";
        }
    } catch (err) {
        console.error("Xəta:", err);
    }
});

getDoctorDetails();