using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Demo
{
    public class Ninja
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ServedInOniwan { get; set; }
        public Clan Clan { get; set; }
        public int ClanId { get; set; }
        public IList<NinjaEquipment> EquipmentOwned { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
