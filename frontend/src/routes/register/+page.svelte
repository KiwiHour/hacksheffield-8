<script lang="ts">
    import CookieManager from "$lib/managers/CookieManager";
    import User from "$lib/managers/User";
    
    let email: string;
    let password: string;

    async function registerUser() {
        let user = new User(null, email, password);
        let apiKey = await user.register() as string;
        console.log(apiKey)
        
        let cookieManager = new CookieManager(document);
        cookieManager.setCookie("apiKey", apiKey);
    }

</script>

<div id="register-wrapper">
    <input type="email" placeholder="Email" bind:value={email} />
    <input type="text" placeholder="Password" bind:value={password} />
    <input type="button" value="Register" on:click={registerUser}>
</div>