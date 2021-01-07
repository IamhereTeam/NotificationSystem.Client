using System;
using NS.DTO.Acount;
using NS.DTO.Notification;
using System.Threading.Tasks;
using System.Collections.Generic;
using NS.Client.Services.Interfaces;

namespace NS.Client.Services.Mock
{
    public class MockNotificationService : INotificationService
    {
        public Task<Result<CreateNotificationModel>> Create(CreateNotificationModel newNotificationModel)
        {
            return Task.FromResult(new Result<CreateNotificationModel>().Succeed(newNotificationModel));
        }

        public Task<Result<IEnumerable<UserNotificationModel>>> GetAll()
        {
            var userModel = new UserModel
            {
                Id = 10,
                FirstName = "Elon",
                LastName = "Musk",
                Username = "elon",
                DepartmentId = 5,
                Department = new DepartmentModel { Id = 5, Name = "Management" }
            };
            var message = "A 'Hello, World!' program generally is a computer program that outputs or displays the message 'Hello, World!'. Such a program is very simple in most programming languages, and is often used to illustrate the basic syntax of a programming language. It is often the first program written by people learning to code.";

            var data = new List<UserNotificationModel>
            {
                new UserNotificationModel { Id = 1, NotificationId = 1, Date = DateTime.Now, WasRead= true, Sender = userModel,  Subject ="hello world" ,Message=message   },
                new UserNotificationModel { Id = 1, NotificationId = 1, Date = DateTime.Now, WasRead= true, Sender = userModel,  Subject ="hello world" ,Message=message   },
                new UserNotificationModel { Id = 1, NotificationId = 1, Date = DateTime.Now, WasRead= true, Sender = userModel,  Subject ="hello world" ,Message=message   }
            };

            return Task.FromResult(new Result<IEnumerable<UserNotificationModel>>().Succeed(data));
        }
    }
}