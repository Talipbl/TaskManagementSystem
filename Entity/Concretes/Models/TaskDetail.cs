using Entity.Abstracts;
using System;
using System.Collections.Generic;

namespace Entity.Concretes.Models
{
    public class TaskDetail : IEntity
    {
        public int TaskDetailID { get; set; }
        public int TaskId { get; set; }
        public int FromId { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public bool? Status { get; set; }

        public virtual User User { get; set; }
        public virtual ToDo ToDo { get; set; }
    }
}
