<script lang="ts">
    import { goto } from "$app/navigation";

    export let path: string;

    async function gotoAndRefresh() {
        console.log("goto: "+path)
        await goto(path)
    }
</script>

<button on:click={gotoAndRefresh}><slot /></button>
