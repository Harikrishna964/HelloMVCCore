using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WelcomeController : Controller
    {
        private readonly WelcomeMessage _message;
        public WelcomeController(WelcomeMessage message)
        {
            _message = message;
        }

        [HttpGet]
        public string SayHello()
        {
            return _message.Message;
        }

        
       
    }
}
