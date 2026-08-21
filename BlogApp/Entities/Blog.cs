namespace BlogApp.Entities
{
    public class Blog
    {
       public int Id { get; set; }
       public string Title  { get; set; }

       public string Content {  get; set; }
       public DateTime CreatedDate { get; set; }
       public int UserId { get; set; }
       public User User { get; set; }
    }
}
//BlogPost (Makale) Tablosu: Id (int, Primary Key), Title (string), Content (string), CreatedDate (DateTime), UserId (int, Foreign Key).
 