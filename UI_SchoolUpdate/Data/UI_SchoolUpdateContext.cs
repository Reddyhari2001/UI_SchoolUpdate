using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UI_SchoolUpdate.Models;

namespace UI_SchoolUpdate.Data
{
    public class UI_SchoolUpdateContext : DbContext
    {
        public UI_SchoolUpdateContext (DbContextOptions<UI_SchoolUpdateContext> options)
            : base(options)
        {
        }

        public DbSet<UI_SchoolUpdate.Models.UiSchool> UiSchool { get; set; } = default!;
    }
}
