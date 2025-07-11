import { apiConfig } from "../ApiConfig.js"

const form = document.querySelector("form")
const errorMessage = document.getElementById("errorMessage")

form.onsubmit = async (e) => {
    e.preventDefault()

    const email = document.getElementById("email").value
    const password = document.getElementById("password").value

    try {
        const response = await fetch(`${apiConfig.baseUrl}api/Login`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ email, password })
        })

        if (!response.ok) {
            const errorData = await response.json()

            errorData.errorMessages.forEach((error) => {
                errorMessage.textContent = error
            })
        } else {
            const data = await response.json();
            localStorage.removeItem("token");
            localStorage.removeItem("role");
            localStorage.setItem('token', data.token);
            localStorage.setItem('role', data.role);
            window.location.href = "/home";
        }

    } catch (e) {
        console.log(e)
    }  
}