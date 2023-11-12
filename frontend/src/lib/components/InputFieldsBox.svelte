<div class="input-field-box">
    <div class="input-fields">
        <slot />
    </div>
</div>

<style>

    .input-field-box {
        width: 100%;
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
    }

    .input-fields {
        width: clamp(100px, 50%, 300px);
        display: flex;
        flex-direction: column;
    }
    
</style>