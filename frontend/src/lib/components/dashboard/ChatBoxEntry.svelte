<script lang="ts">

    export let content: string;
    export let user: boolean;
    export let typing: boolean;

</script>
<style>
.blinking2 {
     width: 0.5rem;
     height: 1rem;
     background-color: rgba(116,127,224,.65);
     animation-name: blinking;
     animation-duration: 1s;
     animation-iteration-count: infinite;
}

@keyframes blinking {
    50% {
        background-color: transparent
    }
}
</style>

<div id="chatbox-entry">
    <div class="flex justify-start mb-4">
        {#if user}
        <img
          src="https://images.unsplash.com/photo-1506794778202-cad84cf45f1d?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
          class="object-cover h-8 w-8 rounded-full"
          alt=""
        />
        {:else}
        <img
        src="https://images.unsplash.com/photo-1498050108023-c5249f4df085?q=80&w=2072&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
        class="object-cover h-8 w-8 rounded-full"
        alt=""
      />
        {/if}
        <div
          class="ml-2 py-3 px-4 bg-gray-400 rounded-br-3xl rounded-tr-3xl rounded-tl-xl text-white" style="display: inline;"
        >
          {content}{#if typing}<div class="blinking2"></div>{/if}
        </div>
        </div>
</div>