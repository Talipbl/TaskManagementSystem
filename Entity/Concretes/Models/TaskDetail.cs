using Entity.Abstracts;
using System;
using System.Collections.Generic;

namespace Entity.Concretes.Models
{
    public class TaskDetail : IEntity
    {
        public int TaskDetailsId { get; set; }
        public int TaskId { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public bool? Status { get; set; }

        public virtual User UserFrom { get; set; }
        public virtual ToDo Task { get; set; }
        public virtual User UserTo { get; set; }
    }
}
