import { apiConfig } from "../ApiConfig.js"

export async function GetByStatus(status) {
    try {
        const response = await fetch(`${apiConfig.baseUrl}api/Orcamento/Status?status=${status}`, {
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