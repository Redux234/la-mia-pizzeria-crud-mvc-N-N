using Azure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_crud_mvc.Models
{
    public class Pizze
    {

        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Pizza { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Descrizione { get; set; }
        public double Prezzo { get; set; }
        public string Immagine { get; set; }
        public int CategoriaId { get; set; }
        public Categoria? Categorie{ get; set; }
        public List<Ingredienti>? Ingrediente { get; set; }

        public Pizze() { }
        public Pizze(int id, string pizza, string descrizione, double prezzo, string immagine)
        {
            Id = id;
            Pizza = pizza;
            Descrizione = descrizione;
            Prezzo = prezzo;
            Immagine = immagine;
        }
    }
}