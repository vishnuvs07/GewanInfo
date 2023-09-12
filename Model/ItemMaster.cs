namespace GewanInfo.Model
{
    public class ItemMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ItemDetail> Details { get; set; }
    }
}
