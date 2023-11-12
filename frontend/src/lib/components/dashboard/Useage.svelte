<script lang="ts">
    import UserInfo from "$lib/managers/UserInfo";

    let PU = "loading...";
    let us = new UserInfo(localStorage.getItem("apiKey"));
    // console.log(us.get());

    async function load() {
        PU = (await us.get())['predUse'];
    }
    
    load();

</script>
<div>
    <p>Your predicted useage:</p>
    <div style="width:100%; background-color:light-gray; border-radius:30px">
        <h1>{PU}</h1><p>WATTS</p>
    </div>
    <p>Powered by generative AI</p>
</div>
