using Entity.Abstracts;
using System;
using System.Collections.Generic;

namespace Entity.Concretes.Models
{
    public class Category : IEntity
    {
        //public Category()
        //{
        //    ToDos = new HashSet<ToDo>();
        //}

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<ToDo> ToDos { get; set; }
    }
}
