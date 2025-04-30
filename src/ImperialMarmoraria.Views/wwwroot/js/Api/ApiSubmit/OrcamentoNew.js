import { apiConfig } from "../ApiConfig.js"

export async function orcamentoNew({ nome, celular, email, descricao }) {
    try {
        await fetch(`${apiConfig.baseUrl}api/Orcamento`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ nome, celular, email, descricao })
        })

    } catch (e) {
        console.log(e);
    }
}