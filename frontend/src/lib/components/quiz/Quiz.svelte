<script lang="ts">
  import { onMount, beforeUpdate } from 'svelte';
    import Question from './Question.svelte';
    import { fly } from 'svelte/transition';

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
  function handleDish(n:number) {
    if (selected[n] == 0) {
      selected[n] = 1
    }
    else {
      selected[n] = 0
    }
    
  }
  function handleFinish() {
    console.log("send data");
  }

  // This variable is used to reset the x value before updating to trigger the transition
  let x = 0;

  let selected = [0,0,0,0,0,0,0];
  let ac:string = 0;
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
    {#if currentQuestion == 5}
    <div in:fly={{y:-1000, duration: 500}} out:fly={{y:1000, duration: 500}} class="question">
      <h1>Number of lights</h1>
    </div>
    {/if}
    {#if currentQuestion == 4}
    <div in:fly={{y:-1000, duration: 500}} out:fly={{y:1000, duration: 500}}>
      <h1>Types of light fittings</h1>
      <tr>
        <rd><button class="button-9" on:click={handleSubmit}>1 Bed</button></rd>
      
        <rd><button class="button-9"on:click={handleSubmit}>2 Bed</button></rd>
      </tr>
      <tr>
        <rd><button class="button-9"on:click={handleSubmit}>3 Bed</button></rd>
      
        <rd><button class="button-9"on:click={handleSubmit}>4 Bed</button></rd>
      </tr>
    </div>
    {/if}
    {#if currentQuestion == 3}
    <div in:fly={{y:-1000, duration: 500}} out:fly={{y:1000, duration: 500}} class="question">
      <h1>How many hours a day is the heating/air conditioning running</h1>
      <h3>{ac} hours</h3>
      <input type="range" id="volume" name="volume" min="0" max="24" value="0" style="width:100%" on:mousemove={(item) => {ac = item.currentTarget.value}} />
    </div>
    {/if}
    {#if currentQuestion == 2}
    <div in:fly={{y:-1000, duration: 500}} out:fly={{y:1000, duration: 500}} class="question">
      <h1>Tick the appliances you have</h1>

      <table style="width:100vw">
        <tr>
          <rd><button class="button-9" on:click={() => {handleDish(0)}}>Refridgerator {#if selected[0] == 1}tick{/if}</button></rd>
        
          <rd><button class="button-9" on:click={() => {handleDish(1)}}>Washing Machine {#if selected[1] == 1}tick{/if}</button></rd>
        </tr>
        <tr>
          <rd><button class="button-9" on:click={() => {handleDish(2)}}>Dishwasher {#if selected[2] == 1}tick{/if}</button></rd>
        
          <rd><button class="button-9" on:click={() => {handleDish(3)}}>Dryer {#if selected[3] == 1}tick{/if}</button></rd>
        </tr>
        <tr>
          <rd><button class="button-9" on:click={() => {handleDish(4)}}>Gaming Console {#if selected[4] == 1}tick{/if}</button></rd>
        
          <rd><button class="button-9" on:click={() => {handleDish(5)}}>Desktop Computer {#if selected[5] == 1}tick{/if}</button></rd>
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
          <rd><button class="button-9" on:click={handleSubmit}>1 Bed</button></rd>
        
          <rd><button class="button-9"on:click={handleSubmit}>2 Bed</button></rd>
        </tr>
        <tr>
          <rd><button class="button-9"on:click={handleSubmit}>3 Bed</button></rd>
        
          <rd><button class="button-9"on:click={handleSubmit}>4 Bed</button></rd>
        </tr>
        <tr>
          <rd><button class="button-9"on:click={handleSubmit}>5 Bed</button></rd>
        
          <rd><button class="button-9"on:click={handleSubmit}>6+ Bed</button></rd>
        </tr>
      </table>
    </div>
    {/if}
  </div>
  

  {#if currentQuestion != 5}
  
  {:else}
  <button on:click={handleFinish}>Submit</button>
  {/if}
</main>
