<script lang="ts">
    import { goto } from "$app/navigation";

    export let path: string;

    async function gotoAndRefresh() {
        await goto(`/${path}`);
        window.location.reload();
    }
</script>

<button on:click={gotoAndRefresh}><slot /></button>
