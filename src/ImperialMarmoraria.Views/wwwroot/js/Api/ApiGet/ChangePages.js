import { Valores } from "./Teste.js"

export function divPages(activePage = 0) {
    const divPages = document.querySelector(".table-pages")
    divPages.innerHTML = ""

    const totalPages = Math.ceil(Valores.length / 10)
    const pages = []

    pages.push(1)

    if (activePage > 11) {
        pages.push("...")

        const start = Math.max(activePage - 5, 2)
        const end = Math.min(activePage + 12, totalPages - 3)

        for (let i = start; i <= end; i++) {
            pages.push(i)
        }

        if (end < totalPages - 3) {
            pages.push("...")
        }

        for (let i = totalPages - 2; i <= totalPages - 1; i++) {
            if (i > end && i > 1) {
                pages.push(i)
            }
        }
    } else {
        for (let i = 2; i <= Math.min(17, totalPages - 4); i++) {
            pages.push(i)
        }

        if (totalPages > 18) {
            pages.push("...")
        }

        for (let i = totalPages - 2; i <= totalPages - 1; i++) {
            if (i > 17 && i > 1) {
                pages.push(i)
            }
        }
    }

    if (totalPages > 1) pages.push(totalPages)

    pages.forEach(page => {
        let element;
        if (page === "...") {
            element = document.createElement("span")
            element.textContent = "..."
        } else {
            element = document.createElement("div")
            element.textContent = page

            if (page - 1 === activePage) {
                element.classList.add("active")
            }
        }

        divPages.appendChild(element)
    })
}