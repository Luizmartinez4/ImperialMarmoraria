import { DeleteOrcamentoApi } from "./DeleteOrcamentoApi.js"

export function Delete(id) {
    const confirmaDelete = document.querySelector(".confirmarDelete")
    const overlay = confirmaDelete.parentNode

    overlay.classList.remove("hidden")

    const sim = document.getElementById("confirmarExclusaoSim")
    sim.onclick = (e) => {
        e.preventDefault()
        overlay.classList.add("hidden")
        DeleteOrcamentoApi(id)
    }
    const nao = document.getElementById("confirmarExclusaoNao")
    nao.onclick = (e) => {
        e.preventDefault()
        overlay.classList.add("hidden")
    }
}