import { orcamentoNew } from "./OrcamentoNew.js"
import { FormataCelular } from "../../FormataCelularClass.js"

// Recupera o formulário de orçamentos
const orcamentoForm = document.getElementById("orcamentoForm");

// Recupera os inputs
const nomeInput = document.getElementById("nome");
const celularInput = document.getElementById("celular");
const emailInput = document.getElementById("email");
const descricaoInput = document.getElementById("descricao");

FormataCelular(celularInput)

orcamentoForm.onsubmit = async (e) => {
    e.preventDefault();

    // Tenta enviar as informações para a api
    try {
        // Recupera os valores dos inputs
        const nome = nomeInput.value
        const celular = celularInput.value
        const email = emailInput.value
        const descricao = descricaoInput.value

        // envia as informações
        await orcamentoNew({ nome, celular, email, descricao })

    } catch (e) {
        console.log(e)
    }
}