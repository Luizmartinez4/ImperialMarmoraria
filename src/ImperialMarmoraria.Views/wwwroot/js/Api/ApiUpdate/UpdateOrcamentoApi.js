import { apiConfig } from "../ApiConfig.js"

export async function UpdateApi(id, { nome, celular, email, descricao, valor, status }, form) {
    try {
        const errorNome = form.querySelectorAll(".error_message")[0]
        const errorCelular = form.querySelectorAll(".error_message")[2]
        const errorEmail = form.querySelectorAll(".error_message")[1]
        const errorDescricao = form.querySelectorAll(".error_message")[3]
        const carregamento = document.querySelector(".carregamento-container")
        const overlayCarregamento = carregamento.parentNode
        overlayCarregamento.classList.remove("hidden")

        

        const response = await fetch(`${apiConfig.baseUrl}api/Orcamento/${id}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ nome, celular, email, descricao, valor, status })
        })

        errorNome.textContent = ""
        errorCelular.textContent = ""
        errorEmail.textContent = ""
        errorDescricao.textContent = ""

        if (!response.ok) {
            overlayCarregamento.classList.add("hidden")

            const confirmarUpdate = document.querySelector(".confirmarUpdate")
            const overlay = confirmarUpdate.parentNode
            overlay.classList.add("hidden")

            const errorData = await response.json()

            errorData.errorMessages.forEach((error) => {
                if (error == "O campo nome não pode estar vazio!") {
                    errorNome.textContent = error
                }

                if (error == "O campo celular não pode estar vazio!") {
                    errorCelular.textContent = error
                } else if (error == "Insira um telefone válido!" && errorCelular.textContent != "O campo celular não pode estar vazio!") {
                    errorCelular.textContent = error
                }

                if (error == "O campo email não pode estar vazio!") {
                    errorEmail.textContent = error
                } else if (error == "Insira um email válido!" && errorEmail.textContent != "O campo email não pode estar vazio!") {
                    errorEmail.textContent = error
                }

                if (error == "O campo descrição não pode estar vazio!") {
                    errorDescricao.textContent = error
                }
            })

            for (let i = 0; i < errors.length; i++) {
                errors[i].style.color = "red";
                errors[i].style.paddingTop = "10px";
            }
        } else {
            const atualizado = document.querySelector(".atualizado")
            const overlayAtualizado = atualizado.parentNode
            overlayCarregamento.classList.add("hidden")
            overlayAtualizado.classList.remove("hidden")

            const button = atualizado.querySelector("button")
            button.onclick = () => {
                location.reload()
            }
        }

    } catch (e) {
        console.log(e)
    }
}