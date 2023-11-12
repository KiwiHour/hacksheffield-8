import ApiInterface from "./ApiInterface";

export default class UserInfo extends ApiInterface {

    constructor(apiKey: string | null) {
        super(apiKey);
    }

    /**
     * Creates new user on the database
     */
    async get() {
        // console.log(this.email, this.password)
        let data = await this.apiFetch("user/getAll", "get")
        return data;
    }
}