import { apiConfig } from "../ApiConfig.js"

window.addEventListener("DOMContentLoaded", async () => {
    await protectRegister()
})
async function protectRegister() {
    const token = localStorage.getItem("token")
    const role = localStorage.getItem("role")

    if (!token) {
        alert("Você precisa estar logado.");
        window.location.href = "/login";
    }

    if (role != "administrator") {
        alert("Você precisa ser administrador para acessar esta página.");
        window.location.href = "/login";
    }

    try {
        const response = await fetch(`${apiConfig.baseUrl}api/Home`, {
            headers: {
                "Authorization": "Bearer " + token
            }
        })

        if (!response.ok) {
            throw new Error("Acesso não autorizado");
            localStorage.removeItem("token");
            localStorage.removeItem("role");
            window.location.href = "/login";
        }


        document.body.style.display = "flex";

    } catch (e) {
        alert("Sessão inválida ou expirada.");
        localStorage.removeItem("token");
        localStorage.removeItem("role");
        window.location.href = "/login";
    }
}