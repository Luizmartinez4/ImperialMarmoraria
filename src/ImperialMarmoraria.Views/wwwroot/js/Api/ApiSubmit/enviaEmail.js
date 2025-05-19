import { apiConfig } from "../ApiConfig.js"

export async function enviaEmail({ email }) {
    const response = await fetch(`${apiConfig.baseUrl}api/Email/send`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ email })
    })
}