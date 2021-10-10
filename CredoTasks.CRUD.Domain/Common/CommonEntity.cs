using System;
using System.Collections.Generic;
using System.Text;

namespace CredoTasks.CRUD.Domain.Common
{
    public class CommonEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
