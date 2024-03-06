
namespace ListaDeComprasApp
{
    public class ItemService : IItemService
    {
        private readonly AppDbContext _context;
        public ItemService(AppDbContext context)
        {
            _context = context;
        }
        public List<Item> GetAllItems()
        {
            return _context.Itens.ToList();
        }
    }
}
