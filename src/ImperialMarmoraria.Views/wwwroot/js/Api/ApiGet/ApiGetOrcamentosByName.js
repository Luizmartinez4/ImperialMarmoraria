import { apiConfig } from "../ApiConfig.js"

export async function GetByName(name) {
    try {
        const response = await fetch(`${apiConfig.baseUrl}api/Orcamento/Name?name=${name}`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json"
            }
        })

        const result = await response.json()

        return result

    } catch (e) {
        console.log(e)
    }
}