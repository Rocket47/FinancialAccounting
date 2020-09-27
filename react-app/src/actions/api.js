import axios from "axios"

const baseUrl = "https://localhost:44394/api/"

export default {
    dUser(url = baseUrl + 'users') {
        return {
            fetchAll : () => axios.get(url)
        }
    }
}