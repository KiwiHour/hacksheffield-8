import ApiInterface from "./ApiInterface";

export default class User extends ApiInterface {

    constructor(apiKey: string | null, private email: string, private password: string) {
        super(apiKey);
    }

    /**
     * Creates new user on the database
     */
    async register() {
        console.log(this.email, this.password)
        let { data: apiKey } = await this.apiFetch("user/add", "post", { email: this.email, password: this.password })
        return apiKey;
    }

    async login() {
        console.log(this.email, this.password)
        let { data: apiKey } = await this.apiFetch("user/login", "post", { email: this.email, password: this.password })
        return apiKey;
    }
}