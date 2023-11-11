using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackSheffield.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HackSheffield.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<TextResponse>> Login()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string requestBody = await reader.ReadToEndAsync();
                Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(requestBody);
                
                
                return new TextResponse(Models.User.auth(data["email"] as String, data["password"] as String));
            }
            // return Models.User.auth(data["email"].ToString(), data["password"].ToString());
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<TextResponse>> Add()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string requestBody = await reader.ReadToEndAsync();
                Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(requestBody);

                Models.User.insert(data["email"] as String, data["password"] as String);
                return new TextResponse(Models.User.auth(data["email"] as String, data["password"] as String));
            }
            // return Models.User.auth(data["email"].ToString(), data["password"].ToString());
        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<bool>> Update()
        {
            return true;
        }
    }
}
