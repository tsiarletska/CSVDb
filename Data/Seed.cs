using CsvDatabase.Models;

namespace CsvDatabase.Data
{
    public class Seed
    {

        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();


                // Seed Sex - first sex
                if (!context.Record.Any())
                {
                    context.Record.AddRange(new List<Record>
                    {
                        new Record {
                            RecordId = 100,
                            Name = "Whatever",
                            BirthDay = new DateTime (1990, 05, 17),
                            Married = false,
                            PhoneNum = "38064537382962",
                            Salary = 550
                        }
                    });
                }
                context.SaveChanges();
            }
        }
    }
}
