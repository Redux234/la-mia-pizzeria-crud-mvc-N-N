namespace la_mia_pizzeria_crud_mvc.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Pizze> Pizza { get; set; }

        public Categoria() { }
    }
}
