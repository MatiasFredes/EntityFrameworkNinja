using DataModel;
using Entity_Framework_Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ninjaContext = new NinjaContext())
            {
                ninjaContext.Database.Log = Console.WriteLine;
                // AddNinja(ninjaContext);
                // GetAllNinjas(ninjaContext);
                // DeleteNinjaById(ninjaContext);
                // UpdateNinjaById(ninjaContext);
                // AddEquipmentNinja(ninjaContext);
                GetNinjaWithEquipmentUsingEagerLoading(ninjaContext);
            }

            Console.ReadKey();
        }

        private static void GetAllNinjas(NinjaContext ninjaContext)
        {
            var ninjas = ninjaContext.Ninjas.Where(x=>x.ServedInOniwan == false);

            foreach (var ninja in ninjas)
            {
                Console.WriteLine(ninja.Name);
            }
        }

        private static void AddNinja(NinjaContext ninjaContext)
        {
            ninjaContext.Ninjas.Add(new Ninja()
            {
                Name = "pepe",
                Clan = new Clan() { ClanName = "gago" },
                DateOfBirth = DateTime.Now,
                ServedInOniwan = false
            });

            ninjaContext.SaveChanges();
        }

        private static void DeleteNinjaById(NinjaContext ninjaContext)
        {
            var ninja = ninjaContext.Ninjas.Where(x => x.Id == 1).FirstOrDefault();
            if (ninja != null)
            {
                ninjaContext.Ninjas.Remove(ninja);
                ninjaContext.SaveChanges();
            }
        }

        private static void UpdateNinjaById(NinjaContext ninjaContext)
        {
            var ninja = ninjaContext.Ninjas.Where(x => x.Id == 2).FirstOrDefault();
            if (ninja != null)
            {
                ninja.ServedInOniwan = true;
                ninjaContext.SaveChanges();
            }
        }

        private static void AddEquipmentNinja(NinjaContext ninjaContext)
        {
            ninjaContext.Ninjas.Add(new Ninja()
            {
                Name = "pepe",
                Clan = new Clan() { ClanName = "aa" },
                DateOfBirth = DateTime.Now,
                ServedInOniwan = false,
                EquipmentOwned = new List<NinjaEquipment>() { new NinjaEquipment() { EquipmentType = EquipmentType.Weapon, Name= "Spunk" } }
                 
            });

            ninjaContext.SaveChanges();
        }

        private static void GetNinjaWithEquipmentUsingEagerLoading(NinjaContext ninjaContext)
        {
            //DbSet.Include()
            var ninja = ninjaContext.Ninjas.Include("EquipmentOwned").Where(x => x.Id == 4).FirstOrDefault();
            if (ninja != null)
            {
                Console.WriteLine(ninja.Name);
                Console.WriteLine(ninja.EquipmentOwned.First().Name);
            }
        }

        private static void GetNinjaWithEquipmentUsingExplicitLoading(NinjaContext ninjaContext)
        {
            // You can explicitly load a navigation property via the DbContext.Entry(...) API.
            var ninja = ninjaContext.Ninjas.Where(x => x.Id == 4).FirstOrDefault();
            if (ninja != null)
            {
                Console.WriteLine(ninja.Name);
                ninjaContext.Entry(ninja).Collection(x => x.EquipmentOwned).Load();
                Console.WriteLine(ninja.EquipmentOwned.First().Name);
            }
        }
    }
}
