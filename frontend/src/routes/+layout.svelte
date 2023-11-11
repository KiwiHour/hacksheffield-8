<script lang="ts">
    import { onMount, tick } from 'svelte';
    import type { LayoutData } from './$types';
    import { getCookies } from '$lib/functions/getCookies';
    import { goto } from '$app/navigation';

    export let data: LayoutData;
    let loadPage = false;

    onMount(async () => {
        if (location.pathname != "/login") {
            let cookies = getCookies(document)
            if (!cookies.apiKey) {
                console.log("No apikey")
                await goto("/login")
            }
        }

        loadPage = true;

    })
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

{/if}

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

