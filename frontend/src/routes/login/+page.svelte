<script lang="ts">
    let email: String;
    let password: String;
</script>

<div id="login-wrapper">
    <input type="email" placeholder="Email" bind:value={email} />
    <input type="text" placeholder="Password" bind:value={password} />
    <input type="button" value="login" on:click={() => "do shit"}>
</div>

<div id="register">
    <p>Need an account?</p><br>
    <p><a href="/register">Register</a></p>
</div>
