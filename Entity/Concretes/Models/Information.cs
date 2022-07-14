using Entity.Abstracts;
using System;
using System.Collections.Generic;

namespace Entity.Concretes.Models
{
    public class Information : IEntity
    {
        public int InfoId { get; set; }
        public int TaskId { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public DateTime SendDate { get; set; }
        public string Format { get; set; }
        public virtual User UserFrom { get; set; }
        public virtual ToDo Task { get; set; }
        public virtual User UserTo { get; set; }
    }
}
