<script lang="ts">
    import Link from "$lib/components/Link.svelte";

    let email: String;
    let password: String;
</script>

<div id="login-wrapper">
    <h1>Login</h1>
    <input class="text-input" type="email" placeholder="Email" bind:value={email} />
    <input class="text-input" type="password" placeholder="Password" bind:value={password} />
    <input id="login-button" type="button" value="Login" on:click={() => "do shit"}>
</div>

<div id="register">
    <p>Need an account?</p><br>
    <Link path="register">Register</Link>
</div>

<style>
    #login-wrapper {
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

        & #login-button {
            width: 25%;
            padding: 10px;
        }
    }

    #register {
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
    }
</style>
