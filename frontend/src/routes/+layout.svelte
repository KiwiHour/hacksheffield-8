<script lang="ts">
    import { onMount } from 'svelte';
    import type { LayoutData } from './$types';
    import { goto } from '$app/navigation';
    import CookieManager from '$lib/managers/CookieManager';

    export let data: LayoutData;
    let loadPage = false;

    onMount(async () => {
        if (location.pathname != "/login") {
            let cookieManager = new CookieManager(document)
            let cookies = cookieManager.getCookies()
            if (!cookies.apiKey) {
                await goto("/login")
            }
        }

        loadPage = true;

    })
</script>

{#if loadPage}
    <div id = "navbar">
        <h1><a href="/">Home</a></h1>
        <ul>
            <li></li>
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

