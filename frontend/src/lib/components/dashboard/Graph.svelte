<script lang="ts">
    import UserInfo from "$lib/managers/UserInfo";

    let internalID = "loading...";
    let us = new UserInfo(localStorage.getItem("apiKey"));
    // console.log(us.get());

    async function load() {
        internalID = (await us.get())['pred'];
    }
    
    load();

</script>
<h1>
    InternalID: {internalID}
</h1>