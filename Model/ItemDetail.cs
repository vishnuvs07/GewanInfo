namespace GewanInfo.Model
{
    public class ItemDetail
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ItemMasterId { get; set; }
        public ItemMaster ItemMaster { get; set; }
    }
}
