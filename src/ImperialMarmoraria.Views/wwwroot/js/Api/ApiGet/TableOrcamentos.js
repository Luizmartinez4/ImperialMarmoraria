import { GetAllOrcamentos } from "./ApiGetAllOrcamentos.js"

export async function ShowOrcamentosOnScreen() {
    const table = document.getElementsByClassName("table-hover")[0]
    table.innerHTML = ""

    const paginaActive = document.querySelector(".table-pages > .active")
    const value = (Number(paginaActive.textContent) - 1) * 10
    const { orcamentos } = await GetAllOrcamentos()
    const quantidade = Math.min(value + 10, orcamentos.length);

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

        let Nome = document.createElement("p")
        Nome.textContent = orcamentos[i].nome

        let dataInicioFormatada = formataData(orcamentos[i].dataInicio)

        let Data = document.createElement("p")
        Data.textContent = dataInicioFormatada

        // formata os resultados do status
        let status;
        if (orcamentos[i].status == 0) {
            status = "Novo"
        } else if (orcamentos[i].status == 1) {
            status = "Em andamento"
        } else {
            status = "Finalizado"
        }

        let Status = document.createElement("p")
        Status.textContent = status

        let orcamento = document.createElement("p")
        orcamento.textContent = orcamentos[i].valor

        // Formata a data
        let dataFimFormatada
        if (orcamentos[i].dataFim == null) {
            dataFimFormatada = ""
        } else {
            dataFimFormatada = formataData(orcamentos[i].dataFim)
        }

        let DataFim = document.createElement("p")
        DataFim.textContent = dataFimFormatada

        div.appendChild(id)
        div.appendChild(Nome)
        div.appendChild(Data)
        div.appendChild(Status)
        div.appendChild(orcamento)
        div.appendChild(DataFim)

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
        inputNome.setAttribute("value", orcamentos[i].nome)
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
        inputEmail.setAttribute("value", orcamentos[i].email)
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
        inputTelefone.setAttribute("value", orcamentos[i].celular)
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
        inputOrcamento.setAttribute("value", orcamentos[i].valor)
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
        inputStatus.setAttribute("value", status)
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
        inputDataEntrada.setAttribute("value", dataInicioFormatada)
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
        inputDataFim.setAttribute("value", dataFimFormatada)
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
        textarea.textContent = orcamentos[i].descricao

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

function formataData(data) {
    let [year, month, day] = data.split("-")

    return `${day}/${month}/${year}`
}