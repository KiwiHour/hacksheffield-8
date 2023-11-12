<script lang="ts">
  import { onMount, beforeUpdate } from 'svelte';
    import Question from './Question.svelte';
    import { fly } from 'svelte/transition';
    import Loader from './Loader.svelte';
    import ApiInterface from '$lib/managers/ApiInterface';

  let questions = ['Question 1', 'Question 2', 'Question 3'];
  let currentQuestion = 1;

  onMount(() => {
    // Add any initialization logic here
  });

  

  function handleSubmit() {
    // Add logic to handle submission
    // You can add animation logic here before moving to the next question
    
    currentQuestion += 1;
  }
  function handleDish(n:number, device:string) {
    if (selected[n] == "") {
      selected[n] = device
    }
    else {
      selected[n] = ""
    }
    
  }
  function handleFinish() {
    console.log("send data");
    let data = {
      "devices in household":selected,
      "Number of hours the aircon/heating is on per day": ac,
      "Number of bedrooms in the house": b,
      "Number of bulbs in the house": bn,
      "The type of bulbs": l 
    };
    currentQuestion++;
    // print(data);
    console.log(data);
    work(data);
  }

  async function work(body) {
    console.log("here");
    let fetchUrl = `http://localhost:5203/api/test/setQuiz?`

        // Assign params if the user has an api key
        
            let params = new URLSearchParams({ key: "DmWwPaicIRGGnss7hN4rSA==" })
            fetchUrl += params;
        
        let method = "post"
        
        let res = await fetch(fetchUrl, { method, body: JSON.stringify(body) });
        currentQuestion++;
  }
  function handleBed(n:Number) {
    b = n.toString();
    handleSubmit();
  }
  function handleBulb(n:string) {
    bn = n.toString();
    handleSubmit();
  }

  // This variable is used to reset the x value before updating to trigger the transition
  let x = 0;

  let selected = ["","","","","",""];
  let ac = "0";
  let l = "Mixed";
  let b = "0"
  let bn = "0"
</script>

<main>
  
  <style>
    div {
      transition: transform 0.5s;
    }
    .question{
      height: 90%;
      width:40%;
      background-color: lightGray;
      padding: 5%;
      border-radius: 30px;
    }
    button{
      width:20%;
    }
    
/* CSS */
.button-9 {
  appearance: button;
  backface-visibility: hidden;
  background-color: #405cf5;
  border-radius: 6px;
  border-width: 0;
  box-shadow: rgba(50, 50, 93, .1) 0 0 0 1px inset,rgba(50, 50, 93, .1) 0 2px 5px 0,rgba(0, 0, 0, .07) 0 1px 1px 0;
  box-sizing: border-box;
  color: #fff;
  cursor: pointer;
  font-family: -apple-system,system-ui,"Segoe UI",Roboto,"Helvetica Neue",Ubuntu,sans-serif;
  font-size: 100%;

  line-height: 1.15;
  margin: 12px 0 12px;
  height: 90pxz
  outline: none;
  overflow: hidden;
  padding: 50 25px;
  position: relative;
  text-align: center;
  text-transform: none;
  transform: translateZ(0);
  transition: all .2s,box-shadow .08s ease-in;
  user-select: none;
  -webkit-user-select: none;
  touch-action: manipulation;
  height: 90px;

}

.button-9:disabled {
  cursor: default;
}

.button-9:focus {
  box-shadow: rgba(50, 50, 93, .1) 0 0 0 1px inset, rgba(50, 50, 93, .2) 0 6px 15px 0, rgba(0, 0, 0, .1) 0 2px 2px 0, rgba(50, 151, 211, .3) 0 0 0 4px;
}
    
  </style>
  <div style="">
    <h1></h1>
    {#if currentQuestion == 7}
      <h1>Done</h1>
    {/if}
    {#if currentQuestion == 6}
      <Loader></Loader>
    {/if}
    {#if currentQuestion == 5}
    <div in:fly={{y:-1000, duration: 500}} out:fly={{y:1000, duration: 500}} class="question">
      <h1>Number of lights</h1>
      <h3>{l} lights</h3>
      <input type="range" id="volume" name="volume" min="0" max="30" value="0" style="width:100%" on:mousemove={(item) => {l = item.currentTarget.value}} />
      <button class="button-9" on:click={() => {handleFinish()}} style="width: 40%">Submit</button>
    </div>
    {/if}
    {#if currentQuestion == 4}
    <div in:fly={{y:-1000, duration: 500}} out:fly={{y:1000, duration: 500}} class="question">
      <h1>Types of light fittings</h1>
      <tr>
        <rd><button class="button-9" on:click={() => {handleBulb("Incandescent")}}>Incandescent Bulbs</button></rd>
      
        <rd><button class="button-9"on:click={() => {handleBulb("halogen")}}>Halogen</button></rd>
      </tr>
      <tr>
        <rd><button class="button-9"on:click={() => {handleBulb("LEDs")}}>LEDs</button></rd>
      
        <rd><button class="button-9"on:click={() => {handleBulb("Mixture")}}>Mixture</button></rd>
      </tr>
      
    </div>
    {/if}
    {#if currentQuestion == 3}
    <div in:fly={{y:-1000, duration: 500}} out:fly={{y:1000, duration: 500}} class="question">
      <h1>How many hours a day is the heating/air conditioning running</h1>
      <h3>{ac} hours</h3>
      <input type="range" id="volume" name="volume" min="0" max="24" value="0" style="width:100%" on:mousemove={(item) => {ac = item.currentTarget.value}} />
      <button class="button-9" on:click={() => {handleSubmit()}} style="width: 40%">Submit</button>
    </div>
    {/if}
    {#if currentQuestion == 2}
    <div in:fly={{y:-1000, duration: 500}} out:fly={{y:1000, duration: 500}} class="question">
      <h1>Tick the appliances you have</h1>

      <table style="width:100vw">
        <tr>
          <rd><button class="button-9" on:click={() => {handleDish(0, "Refriderator")}}>Refridgerator {#if selected[0] != ""}tick{/if}</button></rd>
        
          <rd><button class="button-9" on:click={() => {handleDish(1, "Washing Machine")}}>Washing Machine {#if selected[1] != ""}tick{/if}</button></rd>
        </tr>
        <tr>
          <rd><button class="button-9" on:click={() => {handleDish(2, "Dishwasher")}}>Dishwasher {#if selected[2] != ""}tick{/if}</button></rd>
        
          <rd><button class="button-9" on:click={() => {handleDish(3, "Tumble Dryer")}}>Dryer {#if selected[3] != ""}tick{/if}</button></rd>
        </tr>
        <tr>
          <rd><button class="button-9" on:click={() => {handleDish(4, "Powerful Gaming Console")}}>Gaming Console {#if selected[4] != ""}tick{/if}</button></rd>
        
          <rd><button class="button-9" on:click={() => {handleDish(5, "Powerful desktop computer")}}>Desktop Computer {#if selected[5] != ""}tick{/if}</button></rd>
        </tr>
        <tr>
          <button class="button-9" on:click={() => {handleSubmit()}} style="width: 40%">Submit</button>
        </tr>
        </table>
        <!-- <button class="button-9" on:click={() => {handleSubmit()}} style="width: 100%">Submit</button> -->
    </div>
    {/if}
    {#if currentQuestion == 1}
    <div in:fly={{y:-1000, duration: 500}} out:fly={{y:1000, duration: 500}} class="question">
      <h1 style="text-align: center; font-family: Arial, Helvetica, sans-serif;">How big is your house?</h1>
      <table style="width:100vw">
        <tr>
          <rd><button class="button-9" on:click={() => {handleBed(1)}}>1 Bed</button></rd>
        
          <rd><button class="button-9"on:click={() => {handleBed(2)}}>2 Bed</button></rd>
        </tr>
        <tr>
          <rd><button class="button-9"on:click={() => {handleBed(3)}}>3 Bed</button></rd>
        
          <rd><button class="button-9"on:click={() => {handleBed(4)}}>4 Bed</button></rd>
        </tr>
        <tr>
          <rd><button class="button-9"on:click={() => {handleBed(5)}}>5 Bed</button></rd>
        
          <rd><button class="button-9"on:click={() => {handleBed(6)}}>6+ Bed</button></rd>
        </tr>
      </table>
    </div>
    {/if}
  </div>
</main>
