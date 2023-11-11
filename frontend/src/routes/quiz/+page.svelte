<script lang="ts">
    import type { PageData } from './$types';
    import Quiz from './../../lib/components/quiz/Quiz.svelte';

    export let data: PageData;
</script>
<Quiz data={data}></Quiz>
