using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_crud_mvc.Models
{
    public class Ingredienti
    {
        public int Id { get; set; }
        public string ingrediente { get; set; }

        public List<Pizze>? Pizzza { get; set; }

        public Ingredienti()
        {

        }
    }
}
