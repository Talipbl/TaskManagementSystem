using Entity.Abstracts;
using System;
using System.Collections.Generic;

namespace Entity.Concretes.Models
{
    public class ToDo : IEntity
    {
        public ToDo()
        {
            Informations = new HashSet<Information>();
            TaskDetails = new HashSet<TaskDetail>();
        }

        public int TaskId { get; set; }
        public int CategoryId { get; set; }
        public string Subject { get; set; }
        public string? Description { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Information> Informations { get; set; }
        public virtual ICollection<TaskDetail> TaskDetails { get; set; }
    }
}
