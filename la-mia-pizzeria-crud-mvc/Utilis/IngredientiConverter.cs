using Azure;
using la_mia_pizzeria_crud_mvc.Database;
using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_crud_mvc.Utilis
{
    public class IngredientiConverter
    {
        public static List<SelectListItem> getListIngredienteForMultipleSelect()
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                List<Ingredienti> ingredientiFromDb = db.Ingrediente.ToList<Ingredienti>();

              
                List<SelectListItem> listaPerLaSelectMultipla = new List<SelectListItem>();

                foreach (Ingredienti ingredienti in ingredientiFromDb)
                {
                    SelectListItem opzioneSingolaSelectMultipla = new SelectListItem() { Text = ingredienti.ingrediente, Value = ingredienti.Id.ToString() };
                    listaPerLaSelectMultipla.Add(opzioneSingolaSelectMultipla);
                }

                return listaPerLaSelectMultipla;
            }
        }
    }
}
