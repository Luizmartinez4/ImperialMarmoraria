import { ShowOrcamentosOnScreen } from "./TableOrcamentos.js"
import { divPages } from "./ChangePages.js"
import { GetAllOrcamentos } from "./ApiGetAllOrcamentos.js"
import { GetByStatus } from "./ApiGetOrcamentosByStatus.js"
import { GetByName } from "./ApiGetOrcamentosByName.js"

const table = document.getElementsByClassName("table-hover")[0]
const filtro = document.getElementById("progresso")
const pesquisa = document.getElementById("pesquisa")

window.addEventListener("DOMContentLoaded", async () => {
    const { orcamentos } = await GetAllOrcamentos()

    await divPages(0 ,orcamentos);

    await ShowOrcamentosOnScreen(orcamentos);

    reactiveEvents(orcamentos)

})

function reactiveEvents(listaOrcamentos) {
    const pages = document.querySelectorAll(".table-pages > div")

    pages.forEach(page => {
        page.addEventListener("click", () => {
            const pageIndex = Number(page.textContent) - 1;
            divPages(pageIndex, listaOrcamentos);
            ShowOrcamentosOnScreen(listaOrcamentos);

            table.classList.remove("table-hover")
            void table.offsetWidth;
            table.classList.add("table-hover")

            reactiveEvents(listaOrcamentos)
        })

    })
}

filtro.onchange = async () => {
    const status = filtro.value

    if (status == "all") {
        const { orcamentos } = await GetAllOrcamentos()

        await divPages(0, orcamentos);

        await ShowOrcamentosOnScreen(orcamentos);

        reactiveEvents(orcamentos)
    } else {
        const { orcamentos } = await GetByStatus(status)

        await divPages(0, orcamentos);

        await ShowOrcamentosOnScreen(orcamentos);

        reactiveEvents(orcamentos)
    }
}

pesquisa.oninput = async () => {
    const name = pesquisa.value

    if (name == "") {
        const { orcamentos } = await GetAllOrcamentos()

        await divPages(0, orcamentos);

        await ShowOrcamentosOnScreen(orcamentos);

        reactiveEvents(orcamentos)
    } else {
        const { orcamentos } = await GetByName(name)

        await divPages(0, orcamentos);

        await ShowOrcamentosOnScreen(orcamentos);

        reactiveEvents(orcamentos)
    }
}

let podeTrocar = true

export function setPodeTrocar(value) {
    podeTrocar = value;
}

table.addEventListener("click", (e) => {
    const orcamentoTable = e.target.closest(".orcamento")

    if (orcamentoTable) {
        if (podeTrocar) {
            const form = orcamentoTable.nextElementSibling
            const button = form.querySelectorAll("button")[1]

            const allForms = document.querySelectorAll("form")

            if (form) {
                if (!form.classList.contains("disabled")) {
                    form.classList.add("disabled")

                } else {
                    allForms.forEach(f => {
                        f.classList.add("disabled")
                    });

                    form.classList.remove("disabled")
                }
            }
        } else {
            const confirmacaoNecessaria = document.querySelector(".confirmacaoNecessaria")
            const overlay = confirmacaoNecessaria.parentNode
            const button = document.querySelector(".confirmacaoNecessaria button")

            overlay.classList.remove("hidden")

            button.onclick = () => {
                overlay.classList.add("hidden")
            }
        }
    }
})