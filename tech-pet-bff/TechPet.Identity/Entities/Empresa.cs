namespace TechPet.Identity.Entities
{
    public class Empresa
    {
        public string Codigo { get; }
        public string Nome { get; }
        public string NomeFantasia { get; }
        public string Cnpj { get; }

        public IEnumerable<User> Users { get; set; }

        public Empresa(string codigo, string nome, string nomeFantasia, string cnpj, IEnumerable<User> users)
        {
            Codigo = codigo;
            Nome = nome;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            Users = users;
        }
    }
}