using System.Collections.Generic;

namespace Entity_Framework_Demo
{
    public class Clan
    {
        public int Id { get; set; }
        public string ClanName { get; set; }
        public IList<Ninja> Ninjas { get; set; }

    }
}