using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ImportXmlToJson.Models;

namespace ImportXmlToJson.Data
{
    public class ImportXmlToJsonContext : DbContext
    {
        public ImportXmlToJsonContext (DbContextOptions<ImportXmlToJsonContext> options)
            : base(options)
        {
        }

        public DbSet<ImportXmlToJson.Models.Contract> Contract { get; set; } = default!;

        public DbSet<ImportXmlToJson.Models.Imports> Imports { get; set; }
    }
}
