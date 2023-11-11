<script lang="ts">
    import Link from "$lib/components/Link.svelte";

    let email: String;
    let password: String;
</script>

<div id="login-wrapper">
    <input type="email" placeholder="Email" bind:value={email} />
    <input type="password" placeholder="Password" bind:value={password} />
    <input type="button" value="login" on:click={() => "do shit"}>
</div>

<div id="register">
    <p>Need an account?</p><br>
    <Link path="register">Register</Link>
</div>

<style>
    #login-wrapper {
        width: 50%;
        display: flex;
        flex-flow: column wrap;
        justify-content: space-between;
        margin: auto auto;
    }

</style>
