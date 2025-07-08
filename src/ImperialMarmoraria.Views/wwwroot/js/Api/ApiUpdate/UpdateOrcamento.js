import { UpdateApi } from "./UpdateOrcamentoApi.js"

export function Update(e, id, i) {
    e.preventDefault()

    const form = e.target.closest("form")
    const inputs = form.querySelectorAll("input, textarea")

    inputs.forEach((input, index) => {
        if (index != 5 && index != 6) {
            input.removeAttribute("readonly")
        }

        if (index == 4) {
            const select = document.createElement("select")
            select.setAttribute("name", "status")
            select.setAttribute("id", "status")

            const options = ["Novo", "Em andamento", "Finalizado"]
            options.forEach((opt, index) => {
                const option = document.createElement("option")
                option.value = index
                option.textContent = opt

                if (index == i) {
                    option.selected = true
                }

                select.appendChild(option)
            })

            input.parentNode.replaceChild(select, input)
        }
    })

    const button = e.target
    button.textContent = "Enviar"

    button.onclick = (e) => {
        e.preventDefault()

        const confirmarUpdate = document.querySelector(".confirmarUpdate")
        const overlay = confirmarUpdate.parentNode

        overlay.classList.remove("hidden")

        const nao = document.querySelector("#confirmarNao")
        nao.onclick = (e) => {
            e.preventDefault()
            overlay.classList.add("hidden")
        }

        const sim = document.querySelector("#confirmarSim")
        sim.addEventListener("click", (e) => {
            e.preventDefault()
            const nome = form.querySelectorAll("input")[0].value
            const email = form.querySelectorAll("input")[1].value
            const celular = form.querySelectorAll("input")[2].value
            const descricao = form.querySelector("textarea").value
            const valor = form.querySelectorAll("input")[3].value
            const status = form.querySelector("select").value

            UpdateApi(id, { nome, celular, email, descricao, valor, status }, form)
        })
    }

    const buttonCancel = e.target.previousElementSibling
    buttonCancel.textContent = "Cancelar"

    buttonCancel.onclick = (e) => {
        e.preventDefault()

        const cancelaUpdate = document.querySelector(".cancelarUpdate")
        const overlay = cancelaUpdate.parentNode

        overlay.classList.remove("hidden")

        const nao = document.querySelector("#cancelarNao")
        nao.onclick = (e) => {
            e.preventDefault()
            overlay.classList.add("hidden")
        }

        const sim = document.querySelector("#cancelarSim")
        sim.onclick = () => {
            location.reload()
        }
    }
}