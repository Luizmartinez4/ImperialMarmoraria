import { apiConfig } from "../ApiConfig.js"

export async function DeleteOrcamentoApi(id) {
    try {
        const carregamento = document.querySelector(".carregamento-container")
        const overlayCarregamento = carregamento.parentNode
        overlayCarregamento.classList.remove("hidden")

        const response = await fetch(`${apiConfig.baseUrl}api/Orcamento/${id}`, {
            method: "DELETE",
            headers: {
                "Content-Type": "application/json"
            }
        })


        if (response.ok) {
            overlayCarregamento.classList.add("hidden")

            const deletado = document.querySelector(".excluido")
            const overlayDeletado = deletado.parentNode
            overlayDeletado.classList.remove("hidden")

            const button = deletado.querySelector("button")
            button.onclick = () => {
                location.reload()
            }
        }

    } catch (e) {
        console.log(e)
    }
}