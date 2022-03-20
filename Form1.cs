namespace WinFormUppgift2
{                                                       //Den h�r blev st�kig, tar j�tteg�rna feedback. Men det var mycket kul att kring� alla hinder!
    public partial class Form1 : Form
    {
                                                        //s�tter globala variabler, kan anv�ndas fr�n alla metoder
        string[] nameString;                            //Enkel arr f�r att l�gga till textboxes i .txt
        int x = 0;                                      //r�knare f�r antal registreringar/session
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)  //Taget rakt av f�r att skapa k�nslan av kolumner "https://stackoverflow.com/questions/29465560/how-to-align-data-of-a-richtextbox-into-columns"
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
            x++;                                                    //�kar r�knaren s� att anv�ndaren f�r feedback p� registreringen
            btnUndo_Click(sender, e);                               //rensar f�r snygghetens skull
            rtbResultat.Text = x + " till�gg har skett.";
        }
        static void skrivFil(string[] arr)                          //Skriv till osorterad fil
        {
            string filNamn = @"Lista.txt";                          //deklarerar filnamnet till variabeln filNamn
            try
            {
                for (int i = 0; i < arr.Length; i++)                //f�r varje index i arr, tills 
                    File.AppendAllText(filNamn, arr[i] + "|");      //skriv till filen och l�gg till ett '|' som delimiter
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Det blev n�got fel!"); ;
            }
            File.AppendAllText(filNamn, "\n");                      //l�gg till ett newline tecken f�r att tala om att en rad �r klar
        }
        private void btnVisa_Click(object sender, EventArgs e)      //st�tte p� problem med att l�gga till ett tredje argument s� denna blev l�ng!
        {
            rtbResultat.Clear();                                    //rensar ev. tidigare text

            List<string> niv�er = new List<string>() 
            { " under 50 artiklar", " 50-99 artiklar", " 100-199 artiklar", " 200 el. fler artiklar" };//Skapar en lista med niv�erna i stringform
            List<S�ljare> s�lj = new List<S�ljare>();               //skapar listan s�lj med klassen S�ljare
            SortFrAntal sortList = new SortFrAntal();               //skapar sorteringlista, enkel array med str�ngar

            string filNamn = @"Lista.txt";                          //deklarerar filnamnet till variabeln filNamn
            var count = File.ReadLines(filNamn).Count();            //r�knar antalet rader i Lista.txt
            try
            {                                                       //H�r l�ser vi in fr�n orginaldata i en 2d array 
                String input = File.ReadAllText(filNamn);           //l�ser in textfilen till en enda l�ng str�ng
                string[,] res = new string[count, 4];               //skapar en 2d array, filens rader + 4 "kolumner"

                int i = 0, j = 0;                                   //nollar v�ra counters
                foreach (var row in input.Split(new Char[] { '\n' }))//skapar en rad av teckenstr�ngen(input) till f�rsta radbrytningstecknet
                {
                    j = 0;                                          //nollar kolumn countern
                    foreach (var col in row.Trim('\r').Split(new Char[] { '|' },
                        StringSplitOptions.RemoveEmptyEntries))     //delar upp str�ngraden ovan fram till varje delimiter
                    {
                        res[i, j] = col.Trim();                     //stoppar in col (trimmat p� ev. mellanslag) p� r�tt position i 2d arrayen
                        j++;                                        //n�sta kolumn
                    }
                    i++;                                            //n�sta rad
                }
                int b = 0;                                          //ny kolumnr�knare som nollas
                for (int a = 0; a < count; a++)                     //for loop, radr�knare a s�tts till noll, s�l�nge a �r mindre �n antal r�knade rader i .txt filen, �ka a med ett
                {
                    s�lj.Add(new S�ljare()                          //l�gg till en ny S�ljare i listan s�lj fr�n klassen S�ljare som populeras fr�n 2d arrayen, rad a ,kolumn b, b+1,b+2
                    { namn = res[a, b], persnr = res[a, b + 1], distrikt = res[a, b + 2],
                        antal = Convert.ToInt32(res[a, b + 3]) });  //och slutligen convertera antal till en 32 bitars int.
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Det blev n�got fel!");
            }

            s�lj.Sort(sortList);                                    //skicka p� sortering, SortFrAntal l�ngst ned! Publik klass
            rtbResultat.Text = "Namn" + '\t' + "Persnr" + '\t' + "Distrikt" + '\t' + "Antal" + '\n';//skriver dit radhuvuden
            int niv� = 50, nybotten = 0, c = 0;                     //start v�rde, h�gsta niv�. Bottenv�rde f�r att ha n�got att j�mf�ra mellan. R�knare, antalet s�ljare per niv�
     
            do                                                      //g�r medans niv� �r mindre �n 201
                foreach (var item in niv�er)                        //n�stlad foreachlopp (igen), f�r varje item i listan niv�er
                {
                    foreach (S�ljare s in s�lj)                     //f�r varje Klass.S�ljare s i listan s�lj
                        if (s.antal >= nybotten && s.antal < niv�)  //om s�ljarens antal �r st�rre eller lika med nybotten v�rdet OCH mindre �n int niv�
                        {
                            c++;                                    //plus en s�ljare
                            rtbResultat.AppendText(s.namn + '\t' + s.persnr + '\t' + s.distrikt + '\t' + s.antal + '\n');//skriv ut s�ljarens uppgifter
                        }                                                                                               //och n�r ingen mer st�mmer in p� if kraven
                    rtbResultat.AppendText(c + " s�ljare har n�tt niv�n:" + item + "." + '\n' + '\n');                //l�gg till avr�kningsfras f�r det s�ljintervallet
                    nybotten = niv�;                                //ny l�gsta niv� �r f�reg�ende h�gsta niv�
                    niv� = niv� * 2;                                //taket multipliceras med 2
                    c = 0;                                          //antalet s�ljare nollas
                } while (niv� < 201);                               //g�r medans niv� �r mindre �n 201

            filNamn = @"Sorterad.txt";                              //byter filNamn till Sorterad.txt och skriver ut resultatet d�r f�r att spara p� orginaldatat
            File.WriteAllText(filNamn, rtbResultat.Text);          //H�r skriver vi �ver ev. tidigare data, bara senaste sorteringen ska sparas
        }
        private void btnUndo_Click(object sender, EventArgs e)      //rensa alla textrutor och st�ll mark�ren i namnrutan.
        {
            rtbResultat.Text = "";
            tbNamn.Text = "";
            tbPnr.Text = "";
            tbDistrikt.Text = "";
            tbAntal.Text = "";
            tbNamn.Focus();
        }
        private void btnClose_Click(object sender, EventArgs e)     //St�ng
        {
            Application.Exit();
        }
    }
}
    