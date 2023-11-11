<script lang="ts">
    import { onMount } from 'svelte';
    import type { LayoutData } from './$types';
    import { goto } from '$app/navigation';
    import Link from '$lib/components/Link.svelte';
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
    <body>
        <div id = "header">
            <Link path="home"><h1>Wattage Wizard</h1></Link>
            <div id = "navbar">
                <Link path="account">Account</Link>
                <Link path="login">Login</Link>
                <Link path="quiz">Quiz</Link>
            </div>
        </div>

        <main>
            <slot />
        </main>

        <div id = "footer">
            <p>ew</p>
        </div>
    </body>
{/if}

<style>
    :root {
        --primary-colour: #ba1b1b;
        --secondary-colour: #7d2626;
        --tertiary-colour: #353047;
        --tertiary-border-colour: #2b273a;
        --dark-colour: #1c1e21;
        --light-colour: #fcf8f8;

        box-sizing: border-box;
    }

    #header {
        display: flex;
        flex-flow: row wrap;
        justify-content: space-between;
        background: var(--tertiary-colour);
        & button {
            background: var(--tertiary-colour);
            color: var(--light-colour);
            border-right: 1px solid var(--tertiary-border-colour);
            border-left: 1px solid var(--tertiary-border-colour);
            border-top: 0px;
            border-bottom: 0px;
        }
    }

    #navbar {
        display: flex;
        flex-flow: row nowrap;
        justify-content: flex-end;
        list-style-type: none;
        width: 30vw;
        font-size: 3vw;
        & button {
            float: left;
            background: var(--tertiary-colour);
            color: var(--light-colour);
            border-right: 1px solid var(--tertiary-border-colour);
            border-left: 1px solid var(--tertiary-border-colour);
            border-top: 0px;
            border-bottom: 0px;
        }
    }

    #footer {
        display: flex;
        flex-flow: row wrap;
        justify-content: center;
        background: var(--tertiary-colour);
        color: var(--light-colour);
    }

    body {
        background: var(--light-colour);
    }

    h1 {
        text-align: center;
        & a {
            color: var(--light-colour);
            background-color: transparent;
            text-decoration: none;
        }
    }
</style>

