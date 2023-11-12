<script lang="ts">
    import Link from "$lib/components/Link.svelte";
    import User from "$lib/managers/User";
    import { goto } from "$app/navigation";

    let email: string;
    let password: string;

    async function login() {
        let user = new User(null, email, password);
        let apiKey = await user.register() as string;
        localStorage.setItem("apiKey", apiKey)
        await goto("/dashboard")
    }
</script>

<div id="login-wrapper">
    <input class="text-input" type="email" placeholder="Email" bind:value={email} />
    <input class="text-input" type="password" placeholder="Password" bind:value={password} />
    <input id="login-button" type="button" value="login" on:click={() => login()}>
</div>
<!--  -->
<div id="register">
    <p>Need an account?</p><br>
    <Link path="register">Register</Link>
</div>

<style>
    #login-wrapper {
        width: 50%;
        display: flex;
        flex-flow: column wrap;
        align-items: center;
        justify-content: space-between;
        margin: auto auto;

        & .text-input {
            width: 100%
        }

        & #login-button {
            width: 50%;
        }
    }


    #register {
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
    }

</style>
