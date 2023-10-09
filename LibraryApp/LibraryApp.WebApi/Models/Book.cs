namespace LibraryApp.WebApi.Models
{
    public class Book
    {

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Año_Publicacion { get; set; }
        public int Calificacion { get; set; }
        public string Reseña { get; set; }
        public int UserId { get; set; }
    }
}
