using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListaDeComprasApp.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Item> Itens { get; set; } = new();

        private readonly AppDbContext _dbContext;

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            Itens = _dbContext.Itens.ToList();
        }

        public RedirectToPageResult OnPost()
        {
            string nome = Request.Form["nome"];
            int quantidade = Int32.Parse(Request.Form["quantidade"]);
            _dbContext.Add(new Item(nome, quantidade));
            _dbContext.SaveChanges();
            return RedirectToPage("/Index");
        }

        public RedirectToPageResult OnPostDelete(int id)
        {
            Item ?item = _dbContext.Itens.Find(id);
            if (item != null)
            {
                _dbContext.Remove(item);
                _dbContext.SaveChanges();
            }
            return RedirectToPage("/Index");
        }

        public RedirectToPageResult OnGetComprado(int id)
        {
            Item? item = _dbContext.Itens.Find(id);
            if (item != null)
            {
                item.Comprado = !item.Comprado;
                _dbContext.Itens.Update(item);
                _dbContext.SaveChanges();
            }
            return RedirectToPage("/Index");
        }
    }
}
