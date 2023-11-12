<script lang="ts">
	import ChatBoxEntry from './../../lib/components/dashboard/ChatBoxEntry.svelte';
    import type { PageData } from './$types';
    import AiInterface from '$lib/managers/AiInterface';
    import { onMount } from 'svelte';

    export let data: PageData;
    let aiInterface: AiInterface
    let chatId: string;
    let questionContent: string;
    let currAnswerId: number;
    let chatPingIntervalId: number;
    let selectedPersonality: Personality = "Joe Biden";

    interface IChatBoxEntry {
        type: "question" | "answer"
        content: string
        answerId?: number
    }

    type Personality = "Chat GPT 4"| "Monkey d. Luffy"|"Barack Obama"|"Donald Trump"|"Joe Biden"|"Greta Thunberg"|"Shadow Wizzard Money Gang"|"Borat"|"Mute"
    const personalities: Personality[] = ["Chat GPT 4", "Monkey d. Luffy","Barack Obama", "Donald Trump", "Joe Biden", "Greta Thunberg", "Shadow Wizzard Money Gang", "Borat", "Mute"]

    let chatBoxEntries: IChatBoxEntry[] = [];

    async function pingAndUpdate() {
        let response = await aiInterface.pingForResponse(chatId);
        let currentChatBoxEntry = chatBoxEntries.find(val => val.answerId == currAnswerId)
        if (!currentChatBoxEntry) {
            chatBoxEntries.push({type:"answer", content: response})
        } else {
            currentChatBoxEntry.content = response;
            if ((response as string).endsWith("&&&"))
                currAnswerId++;
        }
    }

    async function submitQuestion() {
        await aiInterface.submitQuery(questionContent, selectedPersonality)
        chatPingIntervalId = setInterval(pingAndUpdate, 500)
    }

    onMount(() => {
        aiInterface = new AiInterface(localStorage.getItem("apiKey"))
    })

</script>
<main style="display:flex">
    <div style="width:66% ;border: 3px solid black; height:80vh; position:relative">
        <div id="chatbox">
            {#each chatBoxEntries as chatBoxEntry}
                <ChatBoxEntry content={chatBoxEntry.content} />
            {/each}
        </div>
        <div style="bottom:0px; width:100%; border:3px solid black; height: 5rem; position:absolute; display:flex">
            
            <input type="text" style="width:80%; height:100%" bind:value={questionContent} />
            <button style="width:20%; height: 100%" on:click={submitQuestion}>Send</button>
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
