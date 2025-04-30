import { orcamentoNew } from "./OrcamentoNew.js"

// Recupera o formulário de orçamentos
const orcamentoForm = document.getElementById("orcamentoForm");

// Recupera os inputs
const nomeInput = document.getElementById("nome");
const celularInput = document.getElementById("celular");
const emailInput = document.getElementById("email");
const descricaoInput = document.getElementById("descricao");

// Faz a formatação do telefone
celularInput.oninput = function(e) {
    let celular = celularInput.value
    celular = celular.replace(/\D/g, '')

    if (celular.length > 11) celular = celular.slice(0, 11);

    celular = celular.replace(/(\d{2})(\d{4,5})(\d{0,4})/, '($1) $2-$3');

    e.target.value = celular
}

orcamentoForm.onsubmit = async (e) => {
    e.preventDefault();

    // Tenta enviar as informações para a api
    try {
        // Recupera os valores dos inputs
        const nome = nomeInput.value
        const celular = celularInput.value
        const email = emailInput.value
        const descricao = descricaoInput.value

        await orcamentoNew({ nome, celular, email, descricao })

    } catch (e) {
        console.log(e)
    }
}