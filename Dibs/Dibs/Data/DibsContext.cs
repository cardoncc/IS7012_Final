using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dibs.Models;

namespace Dibs.Data
{
    public class DibsContext : DbContext
    {
        public DibsContext (DbContextOptions<DibsContext> options)
            : base(options)
        {
        }

        public DbSet<Dibs.Models.Attendee> Attendee { get; set; }

        public DbSet<Dibs.Models.Meeting> Meeting { get; set; }

        public DbSet<Dibs.Models.MeetingUser> MeetingUser { get; set; }

        public DbSet<Dibs.Models.Room> Room { get; set; }
    }
}
