namespace athenas_archive.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
