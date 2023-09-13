using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sec_09CrudOperation.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Class { get; set; }

        public string Email { get; set; }
    }
}