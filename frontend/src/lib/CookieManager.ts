interface Cookies {
    [x: string]: string
}

export default class CookieManager {
    constructor (private cookie: string) {}

    public getCookies(): Cookies {
        let cookies: Cookies = {};
        let cookiesRaw = this.cookie.split("; ")

        for (let cookieRaw of cookiesRaw) {
            let [key, value] = cookieRaw.split("=");
            cookies[key] = value;
        }

        return cookies;
    }

}