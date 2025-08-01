namespace athenas_archive.ViewModels
{
    public class RespostaViewModel
    {
        public int Id { get; set; }
        public string? Conteudo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? EditadoEm { get; set; }
        public int UsuarioId { get; set; }
        public string? UsuarioNome { get; set; }
    }
}
