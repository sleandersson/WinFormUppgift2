namespace WinFormUppgift2
{
    public class Säljare                                            //Klassen säljare 3 strängar och endast antal behöver vara en int för 
    {
        public string namn { get; set; }
        public string persnr { get; set; }
        public string distrikt { get; set; }
        public int antal { get; set; }
    }
    public class SortFrAntal : IComparer<Säljare>                   //Använder IComparer för att sortera Klassen Säljare
    {                                                               //"https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1?view=net-6.0"
        public int Compare(Säljare e1, Säljare e2)                  //jämför nästa säljare mot föregående säljare
        {
            return e1.antal.CompareTo(e2.antal);                    //returnerar int 1 om e1.antal är större än e2.antal, annars -1 och 0 om värdena är samma
        }
    }
}
