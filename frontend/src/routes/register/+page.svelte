<script lang="ts">
    import { goto } from "$app/navigation";
    import User from "$lib/managers/User";

    let email: string;
    let password: string;

    async function registerUser() {
        let user = new User(null, email, password);
        let apiKey = await user.register() as string;
        localStorage.setItem("apiKey", apiKey)
        await goto("/login")
    }

</script>

<div id="register-wrapper">
    <input type="email" placeholder="Email" bind:value={email} />
    <input type="password" placeholder="Password" bind:value={password} />
    <input type="button" value="Register" on:click={registerUser}>
</div>

<style>
    #register-wrapper {
        display: flex;
        flex-flow: column wrap;
        justify-content: space-between;
    }
</style>
