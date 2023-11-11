<script lang="ts">
    import User from "$lib/managers/User";

    let email: string;
    let password: string;

    async function registerUser() {
        let user = new User(null, email, password);
        let apiKey = await user.register() as string;
        localStorage.setItem("apiKey", apiKey)
    }

</script>

<div id="register-wrapper">
    <input type="email" placeholder="Email" bind:value={email} />
    <input type="text" placeholder="Password" bind:value={password} />
    <input type="button" value="Register" on:click={registerUser}>
</div>