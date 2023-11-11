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

namespace HackSheffield.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
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

     
        
        
        [HttpGet]
        [Route("ai")]
        public async void AI(String chatId, String input, String theme)
        {
            OpenAIClient client = new OpenAIClient("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");
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
            var chatCompletionsOptions = new ChatCompletionsOptions()
            {
                DeploymentName = "gpt-3.5-turbo", // Use DeploymentName for "model" with non-Azure clients
                Messages =
                {
                    new ChatMessage(ChatRole.System, "You are a helpful assistant with the sole purpose of giving me eneregy saving tips, while talking like "+theme),
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
                    Console.WriteLine(chat[chatId]);
                }
            }

        }
    }
}
