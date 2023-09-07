using ImportXmlToJson.Data;
using Microsoft.EntityFrameworkCore;

namespace ImportXmlToJson.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ImportXmlToJsonContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ImportXmlToJsonContext>>()))
            {
                // Look for any movies.
                if (context.Contract.Any())
                {
                    return;   // DB has been seeded
                }
                context.Contract.AddRange(
                    new Contract
                    {
                        Name_Contract = "Test",
                        Shifr_Contract = 999,
                        Seller = "Testich"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
