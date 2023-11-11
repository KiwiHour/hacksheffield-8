using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Azure;
using Azure.AI.OpenAI;
using HackSheffield.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection;
using NuGet.Protocol.Plugins;
namespace HackSheffield.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private static String[] themes = {"Chat GPT 4", "Monkey d. Luffy","Barack Obama", "Donald Trump", "Joe Biden", "Greta Thunberg", "Shadow Wizzard Money Gang"};
   
        static Dictionary<string, string> chat = new Dictionary<string, string>();
        private readonly ILogger<TodoItemsController> _logger;
        public TodoItemsController(ILogger<TodoItemsController> logger)
        {
            _logger = logger;
        }

        // GET: api/TodoItems
        // [HttpGet]
        // public async Task<ActionResult<List<TodoItem>>> Get([FromQuery] String key)
        // {
        //     if (Models.User.getByKey(key) == null)
        //     {
        //         return StatusCode(401, "Please provide api key");
        //     }
        //     return  TodoItem.getAll();
        // }    
        
        [HttpGet]
        [Route("newChat/{input}/{theme}")]
        public async Task<ActionResult<string>> Get([FromRoute] String input, [FromRoute] String theme)
        {
            // Random rand = new Random();
            // int index = rand.Next(0, themes.Length);
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            string saltstr = Convert.ToBase64String(salt);
            saltstr = saltstr.Replace("/", "ee");
            // Thread t = new Thread(new ThreadStart(AI(saltstr)));
            chat[saltstr] = "";
            Task.Run(async () => {
                AI(saltstr, input, theme);
            });
            return  saltstr;
        }

        public String[] GetThemes(){
            return themes;
        }

        [HttpGet]
        [Route("getChat/{chatId}")]
        public async Task<ActionResult<string>> Get([FromRoute] String chatId)
        {
            // Thread t = new Thread(new ThreadStart(AI(saltstr)));
            
            return  chat[chatId];
        }

        [HttpGet]
        [Route("add/{name}")]
        public async Task<ActionResult<bool>> Add([FromRoute] String name)
        {
            return TodoItem.insert(name);
        }
        
        [HttpGet]
        [Route("del/{id}")]
        public async Task<ActionResult<bool>> Del([FromRoute] String id)
        {
            return TodoItem.delete(id);
        }

     
        public string ReadResource()
        {
            // Determine path
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream("key.emb"))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
        
        [HttpGet]
        [Route("ai")]
        public async void AI(String chatId, String input, String theme)
        {
            OpenAIClient client = new OpenAIClient("");
            // Response<Completions> response = await client.GetCompletionsAsync(new CompletionsOptions()
            // {
            //     DeploymentName = "text-davinci-003", // assumes a matching model deployment or model name
            //     Prompts = { "Can you give me some tips on how to save electricity" },
            // });
            // foreach (Choice choice in response.Value.Choices)
            // {
            //     
            //     return (choice.Text);
            // }

            String themeMessage = "";
            if (theme.Equals("Shadow Wizzard Money Gang")){
                themeMessage = "You are a shadow wizzard part of the legendary shadow wizzard money gang. You live casting spells (This is one of you catch phrases). There is also a Shadow Goverment which sponsers you - please metion the shadow goverment. Please help me out with reducing my electricity bills whilst staying in character and using as many catch phrases as possible as well as rapping. Start the message of with a catch phrase and a greeting before you rap.";
            }else if(theme.Equals("Monkey d. Luffy")){
                themeMessage = "You are Monkey d. Luffy from the anime One Piece. You are a pirate but the character does not use much pirate language and is generally just goofy and silly. Can you plase inform how to reduce my energy bills as Mokey d. luffy. Can you start with a phrase and greeting in the character of luffy. Please try to use as many one piece references in the message as possible.";
            }else if(theme.Equals("Joe Biden")){
                themeMessage = "You are Joe Biden The current President of The USA. However you are also have alzheimer's and speach disphoria. I need you to inform me how to reduce my energy bills. Please have a greeting and and common phrase to introduce yourself. Please only talk in giberish.";
            }
            else if (!theme.Equals("Chat GPT4")){
                themeMessage = "Pretend you are "+theme+". Use language and phrases "+theme+" would use. Please help me out with reducing my electricity bills "+theme+". Can you please start the message with a common phrase or greeting from "+theme;
            }
            else{
                themeMessage = "You are chat gpt 4, and your sole life purpose is to inform me how to reduce my electricity usgae. This is all what matters in your life.";
            }
            var chatCompletionsOptions = new ChatCompletionsOptions()
            {
                DeploymentName = "gpt-3.5-turbo", // Use DeploymentName for "model" with non-Azure clients
                Messages =
                {
                    new ChatMessage(ChatRole.System, themeMessage),
                    new ChatMessage(ChatRole.User, input),
                    // new ChatMessage(ChatRole.Assistant, "Arrrr! Of course, me hearty! What can I do for ye?"),
                    // new ChatMessage(ChatRole.User, "What's the best way to train a parrot?"),
                }
            };
            String r = "";
            await foreach (StreamingChatCompletionsUpdate chatUpdate in client.GetChatCompletionsStreaming(chatCompletionsOptions))
            {
                if (chatUpdate.Role.HasValue)
                {
                    // Console.Write($"{chatUpdate.Role.Value.ToString().ToUpperInvariant()}: ");
                }
                if (!string.IsNullOrEmpty(chatUpdate.ContentUpdate))
                {
                    chat[chatId] += (chatUpdate.ContentUpdate);
                }
            }

        }
    }
}
