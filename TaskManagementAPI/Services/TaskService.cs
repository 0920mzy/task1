using EasyNetQ;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Services
{
    public class TaskService
    {
        public static TaskModel GenerateTaskMessage(TaskModel model)
        {
            string HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST");
            int Port = Convert.ToInt32(Environment.GetEnvironmentVariable("RABBITMQ_PORT"));

            var connStr = "host="+ HostName +":"+ Port + ";virtualHost=/;username=guest;password=guest";
            using (var bus = RabbitHutch.CreateBus(connStr))
            {
                var adbus = bus.Advanced;
                string modelString = JsonConvert.SerializeObject(model);

                bus.SendReceive.Send("tasks", modelString);

            }
            return model;
        }



    }
}
