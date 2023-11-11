interface Cookies {
    [x: string]: string
}

export default class CookieManager {

    constructor(private document: Document) {}

    public getCookies() {
        let cookies: Cookies = {};
        let cookiesRaw = this.document.cookie.split("; ");
    
        for (let cookieRaw of cookiesRaw) {
            let [key, value] = cookieRaw.split("=");
            cookies[key] = value;
        }
        
        return cookies;
    }

    public setCookie(key: string, value: string) {
        let cookies = this.getCookies()
        cookies[key] = value;
        this.document.cookie = this.convertToRawCookie(cookies);
    }

    private convertToRawCookie(cookies: Cookies) {
        let rawCookies: string[] = [];
        for (let [key, value] of Object.entries(cookies)) {
            rawCookies.push(`${key}=${value}`);
        }
        return rawCookies.join("; ");
    }
}