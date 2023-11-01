using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AM.ApplicationCore.Domain
{
    [Owned]
    public class FullName
    {
        public String FirstName { get; set; }

        public String LastName { get; set; }

    }
}
