import { apiConfig } from "../ApiConfig.js"

window.addEventListener("DOMContentLoaded", async () => {
    await protectHome()
})
async function protectHome() {
    const token = localStorage.getItem("token")

    if (!token) {
        alert("Você precisa estar logado.");
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
        const role = localStorage.getItem("role")

        if (role == "administrator") {
            const section = document.querySelector("section")
            const fourthChild = section.children[3];

            const a = document.createElement("a")
            a.textContent = "Funcionarios"
            a.setAttribute("href", "/funcionarios")

            section.insertBefore(a, fourthChild);
        }

    } catch (e) {
        alert("Sessão inválida ou expirada.");
        localStorage.removeItem("token");
        localStorage.removeItem("role");
        window.location.href = "/login";
    }
}