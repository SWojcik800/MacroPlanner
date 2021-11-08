using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MacroPlanner.Entity
{
    public enum Role
    {
        User,
        Admin
    }
    public class BoardMembers
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        public int ApplicationUserId { get; set; }
        public Role Role { get; set; }
    }
}
