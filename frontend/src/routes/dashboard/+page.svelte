<script lang="ts">
    import ChatBoxEntry from "./../../lib/components/dashboard/ChatBoxEntry.svelte";
    import type { PageData } from "./$types";
    import AiInterface from "$lib/managers/AiInterface";
    import { onMount } from "svelte";

    import { Button, Dropdown, DropdownItem } from "flowbite-svelte";
    import { ChevronDownSolid } from "flowbite-svelte-icons";
    import Graph from "$lib/components/dashboard/Graph.svelte";
    import Useage from "$lib/components/dashboard/Useage.svelte";

    export let data: PageData;
    let aiInterface: AiInterface;
    let chatId: string;
    let questionContent: string;
    let currAnswerId: number;
    let chatPingIntervalId: number;
    let selectedPersonality: Personality = "Shadow Wizzard Money Gang";

    interface IChatBoxEntry {
        type: "question" | "answer";
        content: string;
        answerId?: number;
        typing: boolean;
    }

    type Personality =
        | "Chat GPT 4"
        | "Monkey d. Luffy"
        | "Barack Obama"
        | "Donald Trump"
        | "Joe Biden"
        | "Greta Thunberg"
        | "Shadow Wizzard Money Gang"
        | "Borat"
        | "Mute";
    const personalities: Personality[] = [
        "Chat GPT 4",
        "Monkey d. Luffy",
        "Barack Obama",
        "Donald Trump",
        "Joe Biden",
        "Greta Thunberg",
        "Shadow Wizzard Money Gang",
        "Borat",
        "Mute",
    ];

    let chatBoxEntries: IChatBoxEntry[] = [];

    async function pingAndUpdate() {
        let response = (await aiInterface.pingForResponse(chatId))["data"];
        // let currentChatBoxEntry = chatBoxEntries.find(
        //     (val) => val.answerId == currAnswerId
        // );
        if (chatBoxEntries.length<2) {
            chatBoxEntries.push({ type: "answer", content: response, typing:true });
        } else {
            chatBoxEntries[1].content = response;

            if (response.endsWith("&&&")){
                response = response.replace("&&&", "");
                chatBoxEntries[1].typing = false;

            }

            chatBoxEntries[1] = chatBoxEntries[1];

            
            // chatBoxEntries[0] = currentChatBoxEntry;

            //if ((response as string).endsWith("&&&"))
            //    currAnswerId++;
        }
    }

    async function submitQuestion() {
        chatBoxEntries[0] = { type: "question", content: questionContent, typing:false };
        console.log("here");
        chatId = (
            await aiInterface.submitQuery(questionContent, selectedPersonality)
        )["data"];

        
        chatPingIntervalId = setInterval(pingAndUpdate, 500);
    }

    onMount(() => {
        aiInterface = new AiInterface(localStorage.getItem("apiKey"));
    });
</script>
<link
    rel="stylesheet"
    href="https://unpkg.com/flowbite@latest/dist/flowbite.min.css"
/>
<main style="display:flex; flex-wrap:false">
    <div
        style="width:66% ;border: 3px solid black; height:80vh; position:relative; display:flex; flex-direction:column;"
    >
        <div>
            <Button
                class="text-dark "
                style="border: 1px solid black; border-radios: 10px solid black"
                >{selectedPersonality}<ChevronDownSolid
                    class="w-3 h-3 ml-2 text-dark"
                /></Button
            >
            <Dropdown
            on:show={(e) => {console.log(e); return null}}
            >
                {#each personalities as personality}
                    <DropdownItem on:click={(e) => {
                        if(e.target) {
                            var selected = e.target.innerHTML;
                            selectedPersonality = selected;
                            
                        } 

                    }}>{personality}</DropdownItem>
                {/each}
            </Dropdown>
        </div>
        <div id="chatbox" style="display:flex; flex-direction: column; height: auto;">
            <div class="flex flex-col mt-5" style="overflow-y: scroll; flex-grow: 1; height:55vh">
                {#key chatBoxEntries}
                    {#each chatBoxEntries as chatBoxEntry}
                        <ChatBoxEntry content={chatBoxEntry.content} user={chatBoxEntry.type=="question"} typing={chatBoxEntry.typing}/>
                    {/each}
                {/key}
            </div>
            <div
                style="bottom:0px; width:100%; border:3px solid black; height: 5rem; position:absolute; display:flex"
            >
                <input
                    type="text"
                    style="width:80%; height:100%"
                    bind:value={questionContent}
                />
                <button
                    style="width:20%; height: 100%"
                    on:click={submitQuestion}>Send</button
                >
            </div>
        </div>
        </div>
        <div style="width:33%; border: 3px solid black;height:80vh">
            <div style="height:50%; border: 3px solid black;">
                <Graph></Graph>
            </div>
            <div style="height:50%; border: 3px solid black;">
                <Useage></Useage>
            </div>
        </div>
    
</main>
