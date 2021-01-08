using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sandu_Ana_Alexandra_Proiect.Data;
using System;
using System.Linq;

namespace Sandu_Ana_Alexandra_Proiect.Models
{
    public class Date
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Sandu_Ana_Alexandra_ProiectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Sandu_Ana_Alexandra_ProiectContext>>()))
            {
                // Look for any movies.
                if (context.Vacanta.Any())
                {
                    return;   // DB has been seeded
                }

                context.Vacanta.AddRange(
                    new Vacanta
                    {
                        
                    },

                    new Vacanta
                    {
                       
                    },

                    new Vacanta
                    {
                        
                    },

                    new Vacanta
                    {
                        
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
