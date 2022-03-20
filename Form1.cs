namespace WinFormUppgift2
{                                                       //Den här blev stökig, tar jättegärna feedback. Men det var mycket kul att kringå alla hinder!
    public partial class Form1 : Form
    {
                                                        //sätter globala variabler, kan användas från alla metoder
        string[] nameString;                            //Enkel arr för att lägga till textboxes i .txt
        int x = 0;                                      //räknare för antal registreringar/session
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)  //Taget rakt av för att skapa känslan av kolumner "https://stackoverflow.com/questions/29465560/how-to-align-data-of-a-richtextbox-into-columns"
        {
            rtbResultat.Width = 460;
            rtbResultat.SelectAll();
            rtbResultat.SelectionTabs = new int[] { 200, 300, 380, 420, 530 };
            rtbResultat.AcceptsTab = true;
            rtbResultat.Select(0, 0);
        }
        private void btnRegistrera_Click(object sender, EventArgs e) //Registrerings event, skapar en arr av TextBox info
        {
            nameString = new[] { tbNamn.Text, tbPnr.Text, tbDistrikt.Text, tbAntal.Text };
            skrivFil(nameString);                                   //skickar arrayen till metoden skrivFil
            x++;                                                    //ökar räknaren så att användaren får feedback på registreringen
            btnUndo_Click(sender, e);                               //rensar för snygghetens skull
            rtbResultat.Text = x + " tillägg har skett.";
        }
        static void skrivFil(string[] arr)                          //Skriv till osorterad fil
        {
            string filNamn = @"Lista.txt";                          //deklarerar filnamnet till variabeln filNamn
            try
            {
                for (int i = 0; i < arr.Length; i++)                //för varje index i arr, tills 
                    File.AppendAllText(filNamn, arr[i] + "|");      //skriv till filen och lägg till ett '|' som delimiter
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Det blev något fel!"); ;
            }
            File.AppendAllText(filNamn, "\n");                      //lägg till ett newline tecken för att tala om att en rad är klar
        }
        private void btnVisa_Click(object sender, EventArgs e)      //stötte på problem med att lägga till ett tredje argument så denna blev lång!
        {
            rtbResultat.Clear();                                    //rensar ev. tidigare text

            List<string> nivåer = new List<string>() 
            { " under 50 artiklar", " 50-99 artiklar", " 100-199 artiklar", " 200 el. fler artiklar" };//Skapar en lista med nivåerna i stringform
            List<Säljare> sälj = new List<Säljare>();               //skapar listan sälj med klassen Säljare
            SortFrAntal sortList = new SortFrAntal();               //skapar sorteringlista, enkel array med strängar

            string filNamn = @"Lista.txt";                          //deklarerar filnamnet till variabeln filNamn
            var count = File.ReadLines(filNamn).Count();            //räknar antalet rader i Lista.txt
            try
            {                                                       //Här läser vi in från orginaldata i en 2d array 
                String input = File.ReadAllText(filNamn);           //läser in textfilen till en enda lång sträng
                string[,] res = new string[count, 4];               //skapar en 2d array, filens rader + 4 "kolumner"

                int i = 0, j = 0;                                   //nollar våra counters
                foreach (var row in input.Split(new Char[] { '\n' }))//skapar en rad av teckensträngen(input) till första radbrytningstecknet
                {
                    j = 0;                                          //nollar kolumn countern
                    foreach (var col in row.Trim('\r').Split(new Char[] { '|' },
                        StringSplitOptions.RemoveEmptyEntries))     //delar upp strängraden ovan fram till varje delimiter
                    {
                        res[i, j] = col.Trim();                     //stoppar in col (trimmat på ev. mellanslag) på rätt position i 2d arrayen
                        j++;                                        //nästa kolumn
                    }
                    i++;                                            //nästa rad
                }
                int b = 0;                                          //ny kolumnräknare som nollas
                for (int a = 0; a < count; a++)                     //for loop, radräknare a sätts till noll, sålänge a är mindre än antal räknade rader i .txt filen, öka a med ett
                {
                    sälj.Add(new Säljare()                          //lägg till en ny Säljare i listan sälj från klassen Säljare som populeras från 2d arrayen, rad a ,kolumn b, b+1,b+2
                    { namn = res[a, b], persnr = res[a, b + 1], distrikt = res[a, b + 2],
                        antal = Convert.ToInt32(res[a, b + 3]) });  //och slutligen convertera antal till en 32 bitars int.
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Det blev något fel!");
            }

            sälj.Sort(sortList);                                    //skicka på sortering, SortFrAntal längst ned! Publik klass
            rtbResultat.Text = "Namn" + '\t' + "Persnr" + '\t' + "Distrikt" + '\t' + "Antal" + '\n';//skriver dit radhuvuden
            int nivå = 50, nybotten = 0, c = 0;                     //start värde, högsta nivå. Bottenvärde för att ha något att jämföra mellan. Räknare, antalet säljare per nivå
     
            do                                                      //gör medans nivå är mindre än 201
                foreach (var item in nivåer)                        //nästlad foreachlopp (igen), för varje item i listan nivåer
                {
                    foreach (Säljare s in sälj)                     //för varje Klass.Säljare s i listan sälj
                        if (s.antal >= nybotten && s.antal < nivå)  //om säljarens antal är större eller lika med nybotten värdet OCH mindre än int nivå
                        {
                            c++;                                    //plus en säljare
                            rtbResultat.AppendText(s.namn + '\t' + s.persnr + '\t' + s.distrikt + '\t' + s.antal + '\n');//skriv ut säljarens uppgifter
                        }                                                                                               //och när ingen mer stämmer in på if kraven
                    rtbResultat.AppendText(c + " säljare har nått nivån:" + item + "." + '\n' + '\n');                //lägg till avräkningsfras för det säljintervallet
                    nybotten = nivå;                                //ny lägsta nivå är föregående högsta nivå
                    nivå = nivå * 2;                                //taket multipliceras med 2
                    c = 0;                                          //antalet säljare nollas
                } while (nivå < 201);                               //gör medans nivå är mindre än 201

            filNamn = @"Sorterad.txt";                              //byter filNamn till Sorterad.txt och skriver ut resultatet där för att spara på orginaldatat
            File.WriteAllText(filNamn, rtbResultat.Text);          //Här skriver vi över ev. tidigare data, bara senaste sorteringen ska sparas
        }
        private void btnUndo_Click(object sender, EventArgs e)      //rensa alla textrutor och ställ markören i namnrutan.
        {
            rtbResultat.Text = "";
            tbNamn.Text = "";
            tbPnr.Text = "";
            tbDistrikt.Text = "";
            tbAntal.Text = "";
            tbNamn.Focus();
        }
        private void btnClose_Click(object sender, EventArgs e)     //Stäng
        {
            Application.Exit();
        }
    }
}
    