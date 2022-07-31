using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : Controller
    {
        [HttpPost]
        public IActionResult Post(TaskModel model)
        {
            ObjectResult result = new ObjectResult(model);

            return result;
        }

        [HttpGet]
        public IActionResult Get()
        {
            ObjectResult result = new ObjectResult(new TaskModel());

            return result;
        }
    }
}
