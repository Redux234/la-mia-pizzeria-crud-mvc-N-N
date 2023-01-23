using Azure;
using la_mia_pizzeria_crud_mvc.Database;
using la_mia_pizzeria_crud_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using la_mia_pizzeria_crud_mvc.Utilis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace la_mia_pizzeria_crud_mvc.Controllers
{
    public class PizzeController : Controller
    {

        public IActionResult Index()
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                List<Pizze> ListaDellePizze = db.Pizza.ToList<Pizze>();
                return View("Index", ListaDellePizze);
            }

        }

        public IActionResult Details(int id)
        {

            using (PizzeriaContext db = new PizzeriaContext())
            {

                Pizze pizzeTrovate = db.Pizza
                   .Where(PizzaNelDb => PizzaNelDb.Id == id)
                   .Include(pizze => pizze.Categorie)
                   .Include(pizze => pizze.Ingrediente)
                   .FirstOrDefault();



                if (pizzeTrovate != null)
                {
                    return View(pizzeTrovate);
                }

                return NotFound("La pizza con l'id inserito non esiste!");

            }

        }

        [HttpGet]
        public IActionResult Create()
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                List<Categoria> categorieDb = db.Categorie.ToList<Categoria>();

                CategoriaView modelForView = new CategoriaView();
                modelForView.Pizza = new Pizze();
                modelForView.Categorie = categorieDb;
                modelForView.Ingrediente = IngredientiConverter.getListIngredienteForMultipleSelect();


                return View("Crea", modelForView);
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoriaView formData)
        {
            
            if (!ModelState.IsValid)
            {

                using (PizzeriaContext db = new PizzeriaContext())
                {
                    List<Categoria> categorie = db.Categorie.ToList<Categoria>();
                    formData.Categorie = categorie;
                    formData.Ingrediente = IngredientiConverter.getListIngredienteForMultipleSelect();
                }


                return View("Crea", formData);
            }
            using (PizzeriaContext db = new PizzeriaContext())
            {
                if (formData.IngredientiSelectedFromMultipleSelect != null)
                {
                    formData.Pizza.Ingrediente = new List<Ingredienti>();

                    foreach (string ingredienteId in formData.IngredientiSelectedFromMultipleSelect)
                    {
                        int IngredienteIdIntFromSelect = int.Parse(ingredienteId);

                        Ingredienti ingredienti = db.Ingrediente.Where(ingredientiDb => ingredientiDb.Id == IngredienteIdIntFromSelect).FirstOrDefault();

                       

                        formData.Pizza.Ingrediente.Add(ingredienti);
                    }
                }

                db.Pizza.Add(formData.Pizza);
                db.SaveChanges();
            }


            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Update(int id)
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizze pizzaToUpdate = db.Pizza.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaToUpdate == null)
                {
                    return NotFound("Il post non è stato trovato");
                }

                List<Categoria> categorie = db.Categorie.ToList<Categoria>();

                CategoriaView modelForView = new CategoriaView();
                modelForView.Pizza = pizzaToUpdate;
                modelForView.Categorie = categorie;


                List<Ingredienti> listIngredientiFromDb = db.Ingrediente.ToList<Ingredienti>();

                List<SelectListItem> listaOpzioniPerLaSelect = new List<SelectListItem>();

                foreach (Ingredienti ingredienti in listIngredientiFromDb)
                {
                    
                    bool eraStatoSelezionato = pizzaToUpdate.Ingrediente.Any(ingredientiSelezionati => ingredientiSelezionati.Id == ingredienti.Id);

                    SelectListItem opzioneSingolaSelect = new SelectListItem() { Text = ingredienti.ingrediente, Value = ingredienti.Id.ToString(), Selected = eraStatoSelezionato };
                    listaOpzioniPerLaSelect.Add(opzioneSingolaSelect);
                }

                modelForView.Ingrediente = listaOpzioniPerLaSelect;

                return View("Update", modelForView);
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, CategoriaView formData)
        {
            if (!ModelState.IsValid)
            {

                using (PizzeriaContext db = new PizzeriaContext())
                {
                    List<Categoria> categorie = db.Categorie.ToList<Categoria>();

                    formData.Categorie = categorie;
                }


            }

            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizze PizzaToUpdate = db.Pizza.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (PizzaToUpdate != null)
                {

                    PizzaToUpdate.Pizza = formData.Pizza.Pizza;
                    PizzaToUpdate.Descrizione = formData.Pizza.Descrizione;
                    PizzaToUpdate.Immagine = formData.Pizza.Immagine;
                    PizzaToUpdate.CategoriaId = formData.Pizza.CategoriaId;
                    PizzaToUpdate.Ingrediente.Clear();

                    if (formData.IngredientiSelectedFromMultipleSelect != null)
                    {

                        foreach (string ingredienteId in formData.IngredientiSelectedFromMultipleSelect)
                        {
                            int ingredienteIdIntFromSelect = int.Parse(ingredienteId);

                            Ingredienti ingredienti = db.Ingrediente.Where(ingredienteDb => ingredienteDb.Id == ingredienteIdIntFromSelect).FirstOrDefault();



                            PizzaToUpdate.Ingrediente.Add(ingredienti);
                        }
                    }

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("Il post che volevi modificare non è stato trovato!");
                }

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(int id)
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizze PizzaToDelete = db.Pizza.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (PizzaToDelete != null)
                {
                    db.Pizza.Remove(PizzaToDelete);
                    db.SaveChanges();

                    return Index();
                }
                else
                {
                    return NotFound("La pizza da eliminare non è stata trovata!");
                }
            }
        }
    }
}