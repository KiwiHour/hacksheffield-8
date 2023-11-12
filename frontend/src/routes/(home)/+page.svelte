<script>

    import Link from "$lib/components/Link.svelte";

</script>

<div id = "home-wrapper">
    <img src="logo.png" alt="Wattage.Compare Logo">
    <h1>Welcome to Wattage.Compare!</h1>

    <h2>Learn about your home's energy efficiency through the power of AI!</h2>
    <h3>Basically it's ChatGPT but it has access to your power useage </h3>
    <p>We wanted to combine the fun of character AI with real world analytical data about power useage in order to provide a fun experience with real world applications to lowering energy useage.</p>
    <p>(Sadly, website styling only displays well on desktop)</p>

    <p></p>

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
