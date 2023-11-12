<script lang="ts">
    import { onMount } from 'svelte';
    import { goto } from '$app/navigation';
    import Link from '$lib/components/Link.svelte';

    let loadPage = false;
    let loggedIn = false;
    onMount(async () => {
        console.log("checking apikey")
        if (!["/login","/register"].includes(location.pathname)) {
            let apiKey = localStorage.getItem("apiKey")
            if (!apiKey) {
                await goto("/login")
            }
        }

        loadPage = true;


        
        if (localStorage.getItem("apiKey")) {
            loggedIn = true;
        }
        else {
            loggedIn = false;
        }

    })
</script>

{#if loadPage}
    <div id="wrapper">
        <div id = "header">
            <Link path="/"><h1>Wattage.Compare</h1>
            </Link>
            
            <div id = "navbar" style="font-size:2rem !important" >
                <img src="logo.png" style="height:7vh"/>
                {#if loggedIn}
                <Link path="dashboard">Dashboard</Link>
                <Link path="logout">Logout</Link>
                {:else}
                <Link path="login">Login</Link>
                {/if}
                <!-- <Link path="quiz">Quiz</Link> -->
            </div>
        </div>

        <main>
            <slot />
        </main>

        <div id = "footer">
            <p>Made by Will, Matt, Ayyub and Ben</p>
        </div>
    </div>
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

    #wrapper {
        display: flex;
        flex-direction: column;
        height: 100%;
    }

    main {
        height: 100%;
        overflow-y: auto;
        align-items: center;
        justify-content: center;
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
        & button:hover {
            background-color: var(--tertiary-border-colour);
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

