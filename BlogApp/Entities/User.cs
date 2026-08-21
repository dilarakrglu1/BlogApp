namespace BlogApp.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Blog> Blogs { get; set; }
        
    }
}

//User (Kullanıcı) Tablosu: Id (int, Primary Key), Username (string), Email (string), Password (string), CreatedDate (DateTime).
