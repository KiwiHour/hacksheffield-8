<script lang="ts">
    import type { LayoutData } from './$types';

    export let data: LayoutData;
</script>

<div id = "navbar">
    <h1>
    <ul>
        <li>Home</li>
        <li></li>
        <li></li>
    </ul>
</div>

<main>
    <slot />
</main>

<div id = "footer">

</div>

<style>
    :root {
        --primary-colour: #ba1b1b;
        --secondary-colour: #7d2626;
        --tertiary-colour: #353047;
        --dark-colour: #1c1e21;
        --light-colour: #dcc9c9;

        box-sizing: border-box;
    }

    #header {

    }

    #footer {

    }
</style>

