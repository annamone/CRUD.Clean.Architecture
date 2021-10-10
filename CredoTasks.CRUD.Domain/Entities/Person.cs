using CredoTasks.CRUD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredoTasks.CRUD.Domain.Entities
{
    public class Person : CommonEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }
    }
}
