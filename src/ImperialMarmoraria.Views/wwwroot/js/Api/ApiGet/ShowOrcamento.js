import { ShowOrcamentosOnScreen } from "./TableOrcamentos.js"
import { divPages } from "./ChangePages.js"

const table = document.getElementsByClassName("table-hover")[0]

window.addEventListener("DOMContentLoaded", async () => {
    await divPages();

    await ShowOrcamentosOnScreen();

    reactiveEvents()

})

function reactiveEvents() {
    const pages = document.querySelectorAll(".table-pages > div")

    pages.forEach(page => {
        page.addEventListener("click", () => {
            const pageIndex = Number(page.textContent) - 1;
            divPages(pageIndex);
            ShowOrcamentosOnScreen(pageIndex);

            table.classList.remove("table-hover")
            void table.offsetWidth;
            table.classList.add("table-hover")

            reactiveEvents()
        })

    })
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