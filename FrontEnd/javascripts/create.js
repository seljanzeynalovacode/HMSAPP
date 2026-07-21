const API_URL = "https://localhost:7223/api/Doctors";

document.getElementById('createForm').addEventListener('submit', async (e) => {
    e.preventDefault();

    const newDoctor = {
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
        const res = await fetch(API_URL, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(newDoctor)
        });

        if (res.ok) {
            window.location.href = "index.html";
        } else {
            console.error("Əlavə edilərkən xəta baş verdi.");
        }
    } catch (err) {
        console.error("Xəta:", err);
    }
});