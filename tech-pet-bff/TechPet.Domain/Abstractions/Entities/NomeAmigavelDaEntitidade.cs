namespace TechPet.Domain.Abstractions.Entities
{
    public class NomeAmigavelDaEntitidade
    {
        public string Artigo { get; set; }
        public string ArtigoNoPlural { get; set; }
        public string Nome { get; set; }
        public string NomeNoPlural { get; set; }

        public NomeAmigavelDaEntitidade(string artigo, string artigoNoPlural, string nome, string nomeNoPlural)
        {
            Artigo = artigo;
            ArtigoNoPlural = artigoNoPlural;
            Nome = nome;
            NomeNoPlural = nomeNoPlural;
        }

        public string GetNomeComArtigo()
            => $"{Artigo} {Nome}";

        public string GetNomeComArtigoNoPlural()
            => $"{ArtigoNoPlural} {NomeNoPlural}";
    }
}
