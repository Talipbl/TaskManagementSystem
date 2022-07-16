using Entity.Abstracts;
using System;
using System.Collections.Generic;

namespace Entity.Concretes.Models
{
    public class Information : IEntity
    {
        public int InfoId { get; set; }
        public int TaskId { get; set; }
        public DateTime SendDate { get; set; }
        public string Format { get; set; }
        public virtual ToDo Task { get; set; }
    }
}
