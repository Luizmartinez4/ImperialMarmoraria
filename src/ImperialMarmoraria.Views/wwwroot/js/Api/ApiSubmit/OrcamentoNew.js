import { apiConfig } from "../ApiConfig.js"
import { draw } from "../../CheckAnimation.js"
import { enviaEmail } from "../ApiSubmit/enviaEmail.js"

const errorNome = document.getElementById("error_nome")
const errorCelular = document.getElementById("error_celular")
const errorEmail = document.getElementById("error_email")
const errorDescricao = document.getElementById("error_descricao")

const errors = document.getElementsByClassName("error_message")

const orcamentoForm = document.getElementById("orcamentoForm")
const carregamento = document.getElementById("carregamento")
const mensagemCheck = document.getElementById("check_message")
const canvas = document.querySelector("canvas")

export async function orcamentoNew({ nome, celular, email, descricao }) {
    try {
        carregamento.style.display = "block"
        orcamentoForm.style.display = "none"

         const response = await fetch(`${apiConfig.baseUrl}api/Orcamento`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ nome, celular, email, descricao })
         })

        errorNome.textContent = ""
        errorCelular.textContent = ""
        errorEmail.textContent = ""
        errorDescricao.textContent = ""

        if (!response.ok) {
            carregamento.style.display = "none"
            orcamentoForm.style.display = "block"

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
            orcamentoForm.style.display = "none"
            carregamento.style.display = "none"
            canvas.style.display = "block"
            draw()
            enviaEmail({ email })
        }

    } catch (e) {
        console.log(e)
    }
}