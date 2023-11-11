interface Cookies {
    [x: string]: string
}

export function getCookies(document: Document) {
    let cookies: Cookies = {};
    let cookiesRaw = document.cookie.split("; ")

    for (let cookieRaw of cookiesRaw) {
        let [key, value] = cookieRaw.split("=");
        cookies[key] = value;
    }
    
    return cookies;
}