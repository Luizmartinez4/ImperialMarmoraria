import { GetAllOrcamentos } from "./ApiGetAllOrcamentos.js"
import { divPages } from "./ChangePages.js"

const table = document.querySelector(".table-contatos")

window.addEventListener("DOMContentLoaded", async () => {
    const { orcamentos } = await GetAllOrcamentos()

    await divPages(0, orcamentos);

    await ShowOrcamentosOnScreen(orcamentos);

    reactiveEvents(orcamentos)
})

function reactiveEvents(orcamento) {
    const pages = document.querySelectorAll(".table-pages > div")

    pages.forEach(page => {
        page.addEventListener("click", () => {
            const pageIndex = Number(page.textContent) - 1;
            divPages(pageIndex, orcamento);
            ShowOrcamentosOnScreen(orcamento);

            reactiveEvents(orcamento)
        })

    })
}

function ShowOrcamentosOnScreen(Valores) {
    const paginaActive = document.querySelector(".table-pages > .active")
    const value = (Number(paginaActive.textContent) - 1) * 10
    const quantidade = Math.min(value + 10, Valores.length);

    table.innerHTML = ""

    const orcamentos = Valores

    for (let i = value; i < quantidade; i++) {
        const div = document.createElement("div")

        if (i % 2 != 0) {
            div.classList.add("table-gray")
        }

        const nome = document.createElement("p")
        nome.textContent = orcamentos[i].nome

        const email = document.createElement("p")
        email.textContent = orcamentos[i].email

        const telefone = document.createElement("p")
        telefone.textContent = orcamentos[i].celular

        div.appendChild(nome)
        div.appendChild(email)
        div.appendChild(telefone)

        table.appendChild(div)
    }
}