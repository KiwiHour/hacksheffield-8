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

{#if loadPage}
    <div id = "navbar"></div>

    <main>
        <slot />
    </main>
{/if}

<style>
    h1 {

        & p {
            text-align: center;
        }
    }
</style>

