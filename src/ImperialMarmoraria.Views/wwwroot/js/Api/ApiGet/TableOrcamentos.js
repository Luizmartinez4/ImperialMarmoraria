import { Valores } from "./Teste.js"

export function ShowOrcamentosOnScreen() {
    const table = document.getElementsByClassName("table-hover")[0]
    table.innerHTML = ""

    const paginaActive = document.querySelector(".table-pages > .active")
    const value = (Number(paginaActive.textContent) - 1) * 10
    const quantidade = Math.min(value + 10, Valores.length);

    const orcamentos = Valores
    for (let i = value; i < quantidade; i++) {
        let tableItens = document.createElement("div")

        let div = document.createElement("div")
        div.classList.add("orcamento")
        if (i % 2 != 0) {
            div.classList.add("table-gray")
        }

        // Adicionando dados da tabela
        let id = document.createElement("p")
        id.textContent = i + 1

        let nome = document.createElement("p")
        nome.textContent = orcamentos[i].Nome

        let data = document.createElement("p")
        data.textContent = orcamentos[i].Data

        let status = document.createElement("p")
        status.textContent = orcamentos[i].Status

        let orcamento = document.createElement("p")
        orcamento.textContent = orcamentos[i].Orcamento

        let dataFim = document.createElement("p")
        dataFim.textContent = orcamentos[i].DataFim

        div.appendChild(id)
        div.appendChild(nome)
        div.appendChild(data)
        div.appendChild(status)
        div.appendChild(orcamento)
        div.appendChild(dataFim)

        // Adicionando formulário
        let form = document.createElement("form")
        form.classList.add("disabled")

        let div1 = document.createElement("div")

        // Acicionando nome
        let divNome = document.createElement("div")

        let labelNome = document.createElement("label")
        labelNome.setAttribute("for", "nome")
        labelNome.textContent = "Nome completo:"

        let inputNome = document.createElement("input")
        inputNome.setAttribute("type", "text")
        inputNome.setAttribute("value", orcamentos[i].Nome)
        inputNome.setAttribute("readonly", true)

        divNome.appendChild(labelNome)
        divNome.appendChild(inputNome)

        // Adicionando email
        let divEmail = document.createElement("div")

        let labelEmail = document.createElement("label")
        labelEmail.setAttribute("for", "email")
        labelEmail.textContent = "Email:"

        let inputEmail = document.createElement("input")
        inputEmail.setAttribute("type", "text")
        inputEmail.setAttribute("value", "fulanodasilva@gmail.com")
        inputEmail.setAttribute("readonly", true)

        divEmail.appendChild(labelEmail)
        divEmail.appendChild(inputEmail)

        // Adicionando Telefone
        let divTelefone = document.createElement("div")

        let labelTelefone = document.createElement("label")
        labelTelefone.setAttribute("for", "telefone")
        labelTelefone.textContent = "Telefone:"

        let inputTelefone = document.createElement("input")
        inputTelefone.setAttribute("type", "text")
        inputTelefone.setAttribute("value", "(99) 99999-9999")
        inputTelefone.setAttribute("readonly", true)

        divTelefone.appendChild(labelTelefone)
        divTelefone.appendChild(inputTelefone)

        div1.appendChild(divNome)
        div1.appendChild(divEmail)
        div1.appendChild(divTelefone)

        let div2 = document.createElement("div")

        // Adicionando Orcamento
        let divOrcamento = document.createElement("div")

        let labelOrcamento = document.createElement("label")
        labelOrcamento.setAttribute("for", "orcamento")
        labelOrcamento.textContent = "Orcamento:"

        let inputOrcamento = document.createElement("input")
        inputOrcamento.setAttribute("type", "text")
        inputOrcamento.setAttribute("value", orcamentos[i].Orcamento)
        inputOrcamento.setAttribute("readonly", true)

        divOrcamento.appendChild(labelOrcamento)
        divOrcamento.appendChild(inputOrcamento)

        // Adicionando Status
        let divStatus = document.createElement("div")

        let labelStatus = document.createElement("label")
        labelStatus.setAttribute("for", "status")
        labelStatus.textContent = "Status:"

        let inputStatus = document.createElement("input")
        inputStatus.setAttribute("type", "text")
        inputStatus.setAttribute("value", orcamentos[i].Status)
        inputStatus.setAttribute("readonly", true)

        divStatus.appendChild(labelStatus)
        divStatus.appendChild(inputStatus)

        // Adicionando Data de Entrada
        let divDataEntrada = document.createElement("div")

        let labelDataEntrada = document.createElement("label")
        labelDataEntrada.setAttribute("for", "DataEntrada")
        labelDataEntrada.textContent = "DataEntrada:"

        let inputDataEntrada = document.createElement("input")
        inputDataEntrada.setAttribute("type", "text")
        inputDataEntrada.setAttribute("value", orcamentos[i].Data)
        inputDataEntrada.setAttribute("readonly", true)

        divDataEntrada.appendChild(labelDataEntrada)
        divDataEntrada.appendChild(inputDataEntrada)

        // Adicionando Data de Finalização
        let divDataFim = document.createElement("div")

        let labelDataFim = document.createElement("label")
        labelDataFim.setAttribute("for", "DataFim")
        labelDataFim.textContent = "DataFim:"

        let inputDataFim = document.createElement("input")
        inputDataFim.setAttribute("type", "text")
        inputDataFim.setAttribute("value", orcamentos[i].DataFim)
        inputDataFim.setAttribute("readonly", true)

        divDataFim.appendChild(labelDataFim)
        divDataFim.appendChild(inputDataFim)

        div2.appendChild(divOrcamento)
        div2.appendChild(divStatus)
        div2.appendChild(divDataEntrada)
        div2.appendChild(divDataFim)

        // Criando o textarea
        let labelDescricao = document.createElement("label")
        labelDescricao.setAttribute("for", "Descricao")
        labelDescricao.textContent = "Descricao:"

        let textarea = document.createElement("textarea")
        textarea.setAttribute("name", "descricao")
        textarea.setAttribute("id", "descricao")
        textarea.setAttribute("readonly", true)
        textarea.textContent = "Um texto qualquer..."

        let div3 = document.createElement("div")

        let buttonDelete = document.createElement("button")
        buttonDelete.textContent = "Excluir"

        let buttonUpdate = document.createElement("button")
        buttonUpdate.textContent = "Atualizar"

        div3.appendChild(buttonDelete)
        div3.appendChild(buttonUpdate)

        form.appendChild(div1)
        form.appendChild(div2)
        form.appendChild(labelDescricao)
        form.appendChild(textarea)
        form.appendChild(div3)

        tableItens.appendChild(div)
        tableItens.appendChild(form)

        table.appendChild(tableItens)
    }
}