<script lang="ts">
    import { onMount } from 'svelte';
    import { goto } from '$app/navigation';

    let loadPage = false;

    onMount(async () => {
        if (!["/login","/register"].includes(location.pathname)) {
            let apiKey = localStorage.getItem("apiKey")
            if (!apiKey) {
                await goto("/login")
            }
        }

        loadPage = true;

    })
</script>

{#if loadPage}
    <body>
        <div id = "header">
            <button on:click = {() => goto("home")}><h1>Energy 2, Electric Boogaloo</h1></button>
            <ul id = "navbar">
                <li>Account</li>
                <li>Login</li>
                <li>Quiz</li>
            </ul>
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
        --dark-colour: #1c1e21;
        --light-colour: #fcf8f8;

        box-sizing: border-box;
    }

    #header {
        display: flex;
        flex-flow: row wrap;
        justify-content: space-between;
        background: var(--tertiary-colour);
        color: var(--light-colour);
    }

    #navbar {
        display: flex;
        flex-flow: row nowrap;
        justify-content: space-around;
        list-style-type: none;
        width: 30vw;
        font-size: 3vw;
    }

    #footer {
        display: flex;
        flex-flow: row wrap;
        justify-content: space-between;
        background: var(--tertiary-colour);
        color: var(--light-colour);
    }

    body {
        background: var(--light-colour);
    }

    h1 {
        & a {
            color: var(--light-colour);
            background-color: transparent;
            text-decoration: none;
        }
    }
</style>

