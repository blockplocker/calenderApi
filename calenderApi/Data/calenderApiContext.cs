using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using calenderApi.Models;

namespace calenderApi.Data
{
    public class calenderApiContext : DbContext
    {
        public calenderApiContext (DbContextOptions<calenderApiContext> options)
            : base(options)
        {
        }

        public DbSet<calenderApi.Models.Event> Event { get; set; } = default!;
    }
}
