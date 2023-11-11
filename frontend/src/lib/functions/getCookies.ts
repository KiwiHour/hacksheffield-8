import CookieManager from "$lib/CookieManager";

export function getCookies(document: Document) {
    let cookieManager = new CookieManager(document.cookie);
    return cookieManager.getCookies()
}