<script lang="ts">
    import type { PageData } from './$types';

    export let data: PageData;
</script>
<main style="display:flex">
    <div style="width:66% ;border: 3px solid black; height:80vh; position:relative">
        <div>
            
            <p>Send</p>
            <p>Receive</p>
        </div>
        <div style="bottom:0px; width:100%; border:3px solid black; height: 5rem; position:absolute; display:flex">
            
            

            <input type="text" style="width:80%; height:100%" />
            <button style="width:20%; height: 100%"> S </button>
        </div>
    </div>
    <div style="width:33%; border: 3px solid black;height:80vh">
        <div style="height:50%; border: 3px solid black;">
            <p>Insert graph here</p>
        </div>
        <div style="height:50%; border: 3px solid black;">
            <p>Insert things like user data here</p>
        </div>
    </div>
</main>
