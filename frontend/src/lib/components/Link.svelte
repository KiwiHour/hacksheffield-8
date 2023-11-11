<script lang="ts">
    import { goto } from "$app/navigation";


    export let path: string;

    async function gotoAndRefresh() {
        await goto(path)
    }
</script>

<button on:click={gotoAndRefresh}><slot /></button>
