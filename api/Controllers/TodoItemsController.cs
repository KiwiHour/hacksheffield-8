using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.OpenAI;
using HackSheffield.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HackSheffield.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ILogger<TodoItemsController> _logger;
        public TodoItemsController(ILogger<TodoItemsController> logger)
        {
            _logger = logger;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<List<TodoItem>>> Get([FromQuery] String key)
        {
            if (Models.User.getByKey(key) == null)
            {
                return StatusCode(401, "Please provide api key");
            }
            return  TodoItem.getAll();
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
        public async Task<ActionResult<String>> AI()
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
                    new ChatMessage(ChatRole.System, "You are a helpful assistant with the sole purpose of giving me eneregy saving tips, while talking like a pirate"),
                    new ChatMessage(ChatRole.User, "Can you help me save money on my gigh energy bill?"),
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
                    r += (chatUpdate.ContentUpdate);
                }
            }

            return r;
        }
    }
}
