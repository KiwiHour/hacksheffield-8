from openai import OpenAI
import time
f = open("openai.txt", "r")
print(f.read())
client = OpenAI(
    api_key=f.read()
)

def main():
    thread = client.beta.threads.create()
    message = client.beta.threads.messages.create(
        thread_id=thread.id,
        role="user",
        content="Can you load in the data file"
    )
    run = client.beta.threads.runs.create(
        thread_id=thread.id,
        assistant_id="asst_Zw32y1MnuJ3AUrcAR2Fib1Hk",
        instructions="Pease be consise"
    )
    for i in range(100):
        run = client.beta.threads.runs.retrieve(
            thread_id=thread.id,
            run_id=run.id
        )
        messages = client.beta.threads.messages.list(
            thread_id=thread.id
        )
        time.sleep(1)
        print(run.status)
        if run.status == 'completed':
            # print(str(messages))
            break

        if (run.status == 'failed'):
            print(str(run.last_error))
            break;
    


    
    message = client.beta.threads.messages.create(
        thread_id=thread.id,
        role="user",
        content="Given we have a user with a wattage of 800 watts, which customerID is the most similar to this person"
    )
    run2 = client.beta.threads.runs.create(
         thread_id=thread.id,
        assistant_id="asst_Zw32y1MnuJ3AUrcAR2Fib1Hk",
        instructions="Pease be consise"
    )
    
    print(run2.status)
    for i in range(100):
        run2 = client.beta.threads.runs.retrieve(
            thread_id=thread.id,
            run_id=run2.id
        )
        messages2 = client.beta.threads.messages.list(
            thread_id=thread.id
        )
        time.sleep(1)
        # print(run2.status)
        if run2.status == 'completed':
            print(messages2.data[0].content[0].text.value)
            # print(str(messages2))
            break
        if (run2.status == 'failed'):
            print(str(run2.last_error))
            break
    

    # print("done")
    

main()