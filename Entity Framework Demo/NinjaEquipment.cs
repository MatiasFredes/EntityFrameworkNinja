namespace Entity_Framework_Demo
{
    public class NinjaEquipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EquipmentType EquipmentType { get; set; }
        public Ninja Ninja { get; set; }
    }
}