<script lang="ts">

    export let path: string;

    async function gotoAndRefresh() {
        window.location.pathname = `/${path}`
    }
</script>

<button on:click={gotoAndRefresh}><slot /></button>
