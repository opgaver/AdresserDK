# AdresserDK

Simpel opgave i at finde og vise information om adresser i Danmark via [DAWA](https://dawadocs.dataforsyningen.dk/dok/faq).

Her er et par eksempler på brug gennem mit forslag til en C# løsning - det burde være selvforklarende.

```bash
Find adresser
-------------
Indtast adresse eller postnummer (eller del af - brug *)
Gregersensvej
Gregersensvej 2630 Taastrup (Høje-Taastrup kommune)
Gregersensvej 7080 Børkop (Vejle kommune)
```

```bash
Find adresser
-------------
Indtast adresse eller postnummer (eller del af - brug *)
dirch*
Dirchsvej 2300 København S (København, Tårnby kommune)
Dirch Passers Allé 2000 Frederiksberg (Frederiksberg kommune)
D B Dirchsens Alle 2791 Dragør (Dragør kommune)
Dirch Passers Gade 8000 Aarhus C (Aarhus kommune)
```

## Opgave

Adresserne kan du finde via [DAWA](https://dawadocs.dataforsyningen.dk/dok/faq), og du kan eksempelvis bruge API'et [Vejnavnpostnummerrelationer](https://dawadocs.dataforsyningen.dk/dok/api/vejnavnpostnummerrelation). Prøv eksempelvis i browseren at kalde [https://api.dataforsyningen.dk/vejnavnpostnummerrelationer?q=gregersensvej](https://api.dataforsyningen.dk/vejnavnpostnummerrelationer?q=gregersensvej) og se, hvad du får tilbage:

```json
[
{
  "betegnelse": "Gregersensvej, 2630 Taastrup",
  "href": "https://api.dataforsyningen.dk/vejnavnpostnummerrelationer/2630/Gregersensvej",
  "vejnavn": "Gregersensvej",
  "postnummer": {
    "href": "https://api.dataforsyningen.dk/postnumre/2630",
    "nr": "2630",
    "navn": "Taastrup"
  },
  "bbox": [
    12.26700982,
    55.65519537,
    12.27585133,
    55.66092412
  ],
  "visueltcenter": [
    12.27140414,
    55.65852305
  ],
  "kommuner": [
    {
      "href": "https://api.dataforsyningen.dk/kommuner/0169",
      "kode": "0169",
      "navn": "Høje-Taastrup"
    }
  ]
}, {
  "betegnelse": "Gregersensvej, 7080 Børkop",
  "href": "https://api.dataforsyningen.dk/vejnavnpostnummerrelationer/7080/Gregersensvej",
  "vejnavn": "Gregersensvej",
  "postnummer": {
    "href": "https://api.dataforsyningen.dk/postnumre/7080",
    "nr": "7080",
    "navn": "Børkop"
  },
  "bbox": [
    9.73982244,
    55.64211497,
    9.7407989,
    55.64410392
  ],
  "visueltcenter": [
    9.7400966,
    55.6431468
  ],
  "kommuner": [
    {
      "href": "https://api.dataforsyningen.dk/kommuner/0630",
      "kode": "0630",
      "navn": "Vejle"
    }
  ]
}
]
```

Det er den struktur (et array af objekter) du skal konvertere til en liste af dine objekter som repræsentere det du vil vise i din applikation. Så første skridt er at skabe en klasser som kan indeholde de informationer du vil vise. Herefter kan du bruge en instans af `HttpClient` og metoden `GetFromJsonAsync` (som er en extension metode i namespace `System.Net.Http.Json`) til at hente data fra API'et og konvertere det til en liste af dine objekter. Men du kan løse det på mange andre måder, så det er helt op til dig.

Se eventuelt min [løsning i C#](solution/mcronberg/cs/) som inspiration.

## Et par hints

- Du skal skabe klasser der matcher JSON strukturen fra DAWA. Visual Studio har en smart feature til at generere klasser fra JSON (Edit -> Paste Special -> Paste JSON as Classes).
- Du kan bruge `HttpClient` til at hente data fra API'et.
- Du kan bruge `GetFromJsonAsync` til at konvertere JSON til en liste af dine objekter.
- Du bør håndtere fejl og vise en passende besked til brugeren hvis der opstår en fejl (det mangler min løsning).
- Du kan bruge `Console.ReadLine` til at lade brugeren indtaste en adresse eller postnummer.
- Du kan bruge `Console.WriteLine` til at vise information til brugeren.
- Du bør skabe en løsning som er nem at teste og udvide - eksempelvis en solution med flere projekter - Adresse.Kerne og Adresse.ConsoleApp. Så er det nemt at benytte Adresse.Kerne i en anden applikation - eksempelvis en webapplikation eller en WPF applikation.
- Du bør tilføje [Meziantou.Analyzer](https://mcronberg.github.io/bogenomcsharp/level3/kodeanalyse.html#meziantouanalyzer) til dit projekt for at få en masse gode hints og tips til at skrive bedre kode - og måske også [AsyncFixer](https://mcronberg.github.io/bogenomcsharp/level3/kodeanalyse.html#asyncfixer) for at få hjælp til at skrive bedre asynkron kode.

Du er velkommen til at skabe en PR med din løsning, hvis du vil dele den. Du skal bare sørge for, at den ligger i Solution-mappen i en folder med dit navn.