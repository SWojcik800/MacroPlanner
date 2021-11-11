using MacroPlanner.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MacroPlanner.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual List<Board> Boards { get; set; }



    }
}
