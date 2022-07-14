using Entity.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concretes.DTO
{
    public class ListUserTaskDTO : IDto
    {
        public int TaskID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CategoryName { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
    }
}
