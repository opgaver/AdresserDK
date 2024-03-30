using System.Net.Http.Json;

namespace Adresse.Kerne
{
    public record VejnavnPostnummer(string Betegnelse, string Href, string Vejnavn, Postnummer Postnummer, Kommuner[] Kommuner)
    {
        static readonly HttpClient client = new();

        public override string ToString()
        {
            return $"{Vejnavn} {Postnummer.Nr} {Postnummer.Navn} ({String.Join(", ", Kommuner.Select(i=>i.Navn))} kommune)";
        }       

        public static Task<IEnumerable<VejnavnPostnummer>?> Find(string q)
        {
            return client.GetFromJsonAsync<IEnumerable<VejnavnPostnummer>>($"https://api.dataforsyningen.dk/vejnavnpostnummerrelationer?q={q}");
        }
    }
}
