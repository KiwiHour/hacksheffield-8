<script lang="ts">
    import { goto } from "$app/navigation";

    export let path:string;
</script>

<button on:click = {() => goto(`/${path}`)}><slot /></button>
