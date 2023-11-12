<script>

    import Link from "$lib/components/Link.svelte";

</script>

<div id = "home-wrapper">
    <img src="logo.png" alt="Wattage.Compare Logo">
    <h1>Welcome to Wattage.Compare!</h1>

    <h2>Learn about your home's energy efficiency through the power of AI!</h2>

    <Link path="login"> Login</Link>
</div>

<style>
    #home-wrapper {
        display: flex;
        flex-flow: column wrap;
        justify-content: center;
        align-items: center;
        margin: auto;
    }

    h2 {
        text-align: center;
    }

    img {
        width: 15vw;
    }
</style>
