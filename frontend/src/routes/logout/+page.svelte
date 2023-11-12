<script lang="ts">
    import { goto } from "$app/navigation";

    
        localStorage.removeItem("apiKey");
        goto("login");
    

</script>
