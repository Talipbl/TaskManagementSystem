using Entity.Abstracts;
using System;
using System.Collections.Generic;

namespace Entity.Concretes.Models
{
    public class User : IEntity
    {
        public User()
        {
            TaskDetailFroms = new HashSet<TaskDetail>();
            ToDos = new HashSet<ToDo>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MailAdress { get; set; }

        public virtual Password Password { get; set; }
        public virtual ICollection<ToDo> ToDos { get; set; }
        public virtual ICollection<TaskDetail> TaskDetailFroms { get; set; }
    }
}
