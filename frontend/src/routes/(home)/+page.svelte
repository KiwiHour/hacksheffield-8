<script>

    import Link from "$lib/components/Link.svelte";

</script>

<div id = "home-wrapper">
    <div id="title-wrapper">
        <img src="logo.png" alt="Wattage.Compare Logo">
        <h1>Welcome to Wattage.Compare!</h1>
    </div>

    <h2>Learn about your home's energy efficiency through the power of AI!</h2>

    <Link path="login"> Login</Link>

    <p></p>
</div>

<style>
    #home-wrapper {
        display: flex;
        flex-flow: column wrap;
        justify-content: center;
        align-items: center;
    }

    #title-wrapper {
        display: flex;
        flex-flow: row wrap;
        justify-content: center;
        align-items: center;
        margin: auto;
    }

    h2 {
        text-align: center;
    }

</style>
