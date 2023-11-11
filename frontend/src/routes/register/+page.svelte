<script lang="ts">

    let username: string;
    let password: string;

</script>

<div id="register-wrapper">
    <input type="text" placeholder="Username" bind:value={username} />
    <input type="text" placeholder="Password" bind:value={password} />
</div>