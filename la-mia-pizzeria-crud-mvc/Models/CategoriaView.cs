using Microsoft.AspNetCore.Mvc.Rendering;

namespace la_mia_pizzeria_crud_mvc.Models
{
    public class CategoriaView
    {
        public Pizze Pizza { get; set; }
        public List<Categoria>? Categorie { get; set; }
        public List<SelectListItem>? Ingrediente { get; set; }
        public List<string>? IngredientiSelectedFromMultipleSelect { get; set; }
    }
}
