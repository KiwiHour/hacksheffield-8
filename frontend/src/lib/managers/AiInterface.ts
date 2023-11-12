import ApiInterface from "./ApiInterface";

export default class AiInterface extends ApiInterface {

    constructor(apiKey: string | null) {
        super(apiKey);
    }

    async submitQuery(query: string, personality: string) {
        let chatId = await this.apiFetch(`test/newChat/${query}/${personality}`, "get")
        return chatId;
    }

    /** returns string if response was found, null */
    async pingForResponse(chatId: string) {
        let response = await this.apiFetch(`test/getChat/${chatId}`, "get");
        return response;
    }
}