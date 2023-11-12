export default abstract class ApiInterface {
    constructor (private apiKey: string | null) {}

    protected async apiFetch(path: string, method: "get"|"post"|"patch"|"delete", body?: Object) {
        let fetchUrl = `http://api.hs.willjay.rocks/api/${path}?`

        // Assign params if the user has an api key
        if (this.apiKey) {
            let params = new URLSearchParams({ key: this.apiKey })
            fetchUrl += params;
        }
        
        let res = await fetch(fetchUrl, { method, body: JSON.stringify(body) });
        return await res.json();
    }

}