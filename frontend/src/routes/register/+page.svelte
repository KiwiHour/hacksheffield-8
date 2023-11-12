<script lang="ts">
    import { goto } from "$app/navigation";
    import User from "$lib/managers/User";

    let email: string;
    let password: string;

    async function registerUser() {
        let user = new User(null, email, password);
        let apiKey = await user.register() as string;
        localStorage.setItem("apiKey", apiKey)
        await goto("/quiz")
    }

</script>

<div id="register-wrapper">
    <h1>Register</h1>
    <input class="text-input" type="email" placeholder="Email" bind:value={email} />
    <input class="text-input" type="password" placeholder="Password" bind:value={password} />
    <input id="register-button" type="button" value="Register" on:click={registerUser}>
</div>

<style>
    #register-wrapper {
        width: 50%;
        height: auto;
        display: flex;
        flex-flow: column wrap;
        align-items: center;
        justify-content: center;
        margin: auto;

        & .text-input {
            width: 60%;
            padding: 10px;
            margin-bottom: 20px;
        }

        & #register-button {
            width: 25%;
            padding: 10px;
        }

        & #register-button:hover {
            cursor: pointer;
        }
    }
</style>
