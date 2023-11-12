<script>

    import Link from "$lib/components/Link.svelte";

</script>

<div id="title-wrapper">
    <!--<img src="" alt="">-->
    <h1>Welcome to Wattage.Compare!</h1>
</div>

<p>Learn about your home's energy efficiency!</p>

<Link path="login"> Login</Link>

<style>
    #title-wrapper {
        display: flex;
        flex-flow: row wrap;
        justify-content: center;
        align-items: center;
        & h1 {
            flex-grow: 1;
        }
    }
</style>
