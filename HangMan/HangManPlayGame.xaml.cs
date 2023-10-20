using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace HangMan
{
    /// <summary>
    /// Interaction logic for HangmanPlayGame.xaml
    /// </summary>
    public partial class HangManPlayGame : Page
    {
        //Declaratie levens, masking, ingavecode, geheimwoord, fout/goed geraden woord,...
        public int levens = 10;
        public string secret;
        public string foutGeraden;
        public string goedGeraden;
        public bool herstartSpel = false;
        public char[] ingaveCode;
        public string sterren;
        public bool letterAlGeraden = false;
        public bool valideren = false;
        public string naamDeelnemers;
        List<string> historiekLijst = new List<string>();
        int x = 0;
        public bool hintaanvraag = false;
        int index = 0;

        //Als het scherm inlaadt worden de knoppen en de lijst onzichtbaar. Erwordt ook een textblock getoond.
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LstHistorieklijst.Visibility = Visibility.Hidden;
            BtnRaad.Visibility = Visibility.Hidden;
            BtnNieuwSpel.Visibility = Visibility.Hidden;
            BtnHint.Visibility = Visibility.Hidden;
            TxtWoord.Visibility = Visibility.Hidden;
            TxtBlInfo.Text = $"Klik op Spel Starten om het spel te starten";
        }

        //Declaratie Timer.
        DispatcherTimer TmrInfo;
        int TimerSec;
        int TimerSecOptie = 10;


        //Timer verspringt per seconde.
        public HangManPlayGame()
        {
            InitializeComponent();
            TmrInfo = new DispatcherTimer();
            TmrInfo.Interval = new TimeSpan(0, 0, 1);
            TmrInfo.Tick += TmrInfo_Tick;
        }

        //Bij het starten van het spel begint de teller  van 10 sec naar 0 sec af te tellen.
        private void TmrInfo_Tick(object sender, EventArgs e)
        {
            //De teller van de timer telt af --> getoond in een label.
            LblInfo.Content = --TimerSec;

            //Als de teller van de timer 0 is gaat er een leven af + er wordt ook stap voor stap een image getoond van het galgje. Er wordt ook een textblock getoond.
            if (TimerSec == 0)
            {
                levens--;
                HangmanImages();
                TimerSec = TimerSecOptie + 1;
                TxtBlInfo.Text = $"Levens {levens}\nFout geraden: {foutGeraden}\nJuist geraden: {goedGeraden}\nGeheimeCode: {sterren} ";
            }
            //Als de levens gelijk zijn aan nul dan stopt mijn timer en de tekstbox wordt verborgen.
            else if (levens == 0)
            {
                TmrInfo.Stop();
                TxtWoord.Visibility = Visibility.Hidden;
            }


            //De kleur van de teller van de timer wordt rood van zodra het 3 seconden is.
            //Dus 3 t.e.m. 0 seconden. Al de rest wordt wit. Dus 20 t.e.m. 4 seconden.
            switch (TimerSec)
            {
                case 20:
                    TxtBlInfo.Background = Brushes.White;
                    LblInfo.Foreground = Brushes.White;
                    LblInfo.FontSize = 16;
                    break;
                case 19:
                    TxtBlInfo.Background = Brushes.White;
                    LblInfo.Foreground = Brushes.White;
                    LblInfo.FontSize = 16;
                    break;
                case 18:
                    TxtBlInfo.Background = Brushes.White;
                    LblInfo.Foreground = Brushes.White;
                    LblInfo.FontSize = 16;
                    break;
                case 17:
                    TxtBlInfo.Background = Brushes.White;
                    LblInfo.Foreground = Brushes.White;
                    LblInfo.FontSize = 16;
                    break;
                case 16:
                    TxtBlInfo.Background = Brushes.White;
                    LblInfo.Foreground = Brushes.White;
                    LblInfo.FontSize = 16;
                    break;
                case 15:
                    TxtBlInfo.Background = Brushes.White;
                    LblInfo.Foreground = Brushes.White;
                    LblInfo.FontSize = 16;
                    break;
                case 14:
                    TxtBlInfo.Background = Brushes.White;
                    LblInfo.Foreground = Brushes.White;
                    LblInfo.FontSize = 16;
                    break;
                case 13:
                    TxtBlInfo.Background = Brushes.White;
                    LblInfo.Foreground = Brushes.White;
                    LblInfo.FontSize = 16;
                    break;
                case 12:
                    TxtBlInfo.Background = Brushes.White;
                    LblInfo.Foreground = Brushes.White;
                    LblInfo.FontSize = 16;
                    break;
                case 11:
                    TxtBlInfo.Background = Brushes.White;
                    LblInfo.Foreground = Brushes.White;
                    LblInfo.FontSize = 16;
                    break;
                case 10:
                    TxtBlInfo.Background = Brushes.White;
                    LblInfo.Foreground = Brushes.White;
                    LblInfo.FontSize = 16;
                    break;
                case 9:
                    TxtBlInfo.Background = Brushes.White;
                    LblInfo.Foreground = Brushes.White;
                    LblInfo.FontSize = 16;
                    break;
                case 8:
                    TxtBlInfo.Background = Brushes.White;
                    LblInfo.Foreground = Brushes.White;
                    LblInfo.FontSize = 16;
                    break;
                case 7:
                    TxtBlInfo.Background = Brushes.White;
                    LblInfo.Foreground = Brushes.White;
                    LblInfo.FontSize = 16;
                    break;
                case 6:
                    TxtBlInfo.Background = Brushes.White;
                    LblInfo.Foreground = Brushes.White;
                    LblInfo.FontSize = 16;
                    break;
                case 5:
                    TxtBlInfo.Background = Brushes.White;
                    LblInfo.Foreground = Brushes.White;
                    LblInfo.FontSize = 16;
                    break;
                case 4:
                    TxtBlInfo.Background = Brushes.White;
                    LblInfo.Foreground = Brushes.White;
                    LblInfo.FontSize = 16;
                    break;
                case 3:
                    LblInfo.Foreground = Brushes.Red;
                    TxtBlInfo.Background = Brushes.Red;
                    LblInfo.FontSize = 25;
                    break;
                case 2:
                    LblInfo.Foreground = Brushes.Red;
                    TxtBlInfo.Background = Brushes.Red;
                    LblInfo.FontSize = 25;
                    break;
                case 1:
                    LblInfo.Foreground = Brushes.Red;
                    TxtBlInfo.Background = Brushes.Red;
                    LblInfo.FontSize = 25;
                    break;
                case 0:
                    LblInfo.Foreground = Brushes.Red;
                    TxtBlInfo.Background = Brushes.Red;
                    LblInfo.FontSize = 25;
                    break;
            }

        }

        //Hier worden de letters geraden van het spel.
        private void BtnRaad_Click(object sender, RoutedEventArgs e)
        {
            string geradenWoord = TxtWoord.Text;
            //De methode LetterKomtAlVoor zorgt ervoor als het letter al geraden dan het niet meer voorkomt.
            LetterKomtAlVoor();
            //Als je tekstbox leeg is of je typt een cijfer dan gebeurt dan vangt die op in je else statement.
            if (!string.IsNullOrWhiteSpace(TxtWoord.Text) && (valideren = IsAlleenLetters(TxtWoord.Text)))
            {
                //Zolang de letter niet geraden is kan je nog de letter raden. Als je de letter wel raadt, dan heb je gewonnen <-> Als je de letter niet raadt, dan heb je verloren.
                while (!letterAlGeraden)
                {   //Als je leven groter is dan 0 dan kan je het woord of letter nog raden.
                    if (levens > 0)
                    {   //Als je geradenWoord verschillend is van het secret woord --> dan wordt het letter getoond in textblock juistgeraden of foutgeraden (meer uitleg bij LetterZoekenInWoord).
                        //Het woord of letter wordt ook gecleard in een tekstbox + er wordt focus gelegd in het tekstbox.
                        if (geradenWoord != secret)
                        {
                            LetterZoekenInWoord();
                            TxtWoord.Clear();
                            TxtWoord.Focus();
                        }
                        //geradenWoord is gelijk aan secret woord --> Timer stopt + het woord wordt gecleard.
                        //De textblock geeft je aan hoeveel levens je nog hebt + welke letter fout of goed zijn + het tonen van het geheimewoord.
                        //De methode strafpunten zorgt ervoor dat de highscore niet getoond wordt in de historieklijst.
                        //Een messagebox toont je aan dat je gewonnen hebt.
                        //De tekstbox wordt onzichtbaar.
                        else if (geradenWoord == secret)
                        {
                            TmrInfo.Stop();
                            TxtWoord.Clear();
                            TxtBlInfo.Text = $"Levens {levens}\nFout geraden: {foutGeraden}\nJuist geraden: {goedGeraden}\nGeheimeCode: {secret}";
                            MessageBox.Show("Proficiat, Je hebt gewonnen", "Gewonnen");
                            StrafPunten();
                            TxtWoord.Visibility = Visibility.Hidden;
                        }

                    }
                    //Als je leven gelijk is aan 0 dan stopt de timer met tellen en toont een messagebox dat je verloren hebt.
                    //De tekstbox wordt onzichtbaar.
                    if (levens == 0)
                    {
                        TmrInfo.Stop();
                        MessageBox.Show("Helaas, Je hebt verloren", "Verloren");
                        TxtWoord.Visibility = Visibility.Hidden;
                    }
                    //Wanneer je op de knop raad klikt, word er een tekstblock getoond waarin je levens, het fout of juist geraden woord of letter en de maskering van het woord wordt getoond.
                    //De methode WoordRaden is nodig als je het geheimewoord in één keer raadt.
                    TxtBlInfo.Text = $"Levens {levens}\nFout geraden: {foutGeraden}\nJuist geraden: {goedGeraden}\nGeheimeCode: {sterren}";
                    WoordRaden();
                    break;
                }

            }
            //Als je tekstbox leeg is of je typt een cijfer dan loopt de timer gewoon verder en er wordt focus gelegd in de tekstbox.
            else
            {
                TmrInfo.Start();
                TxtWoord.Focus();
            }
            //Het cijfer wordt vervolgens gecleared.
            TxtWoord.Clear();
        }

        //Wanneer je op de knop nieuwspel klikt timer wordt gereset naar 10 en je label wordt leeggemaakt + je achtergrond van je tekstblock wordt wit + de afbeeeldingen worden gerest naar 10 levens.
        //Methode initspel wordt hieronder uitgelegd.
        private void BtnNieuwSpel_Click(object sender, RoutedEventArgs e)
        {
            Initspel();
            LblInfo.Content = "";
            TxtBlInfo.Background = Brushes.White;
            TmrInfo.Stop();
            HangMan.Source = ImgSource(levens);
            TimerSec = TimerSecOptie + 1;
        }

        //Bij initspel wordt timermenu enable, nieuwspelstart menu en hintvragen menu wordt disabeld + tekstblock getoond, fout en goed geraden woord wordt gereset en je levens wordt ook gerest.
        //Bij hintaanvraag wordt je historieklijst gereset.
        //De knoppen Raad, Hint en Tekstbox worden verborgen en Startspel wordt zichtbaar.
        private void Initspel()
        {
            index = 0;
            TimerInstellen.IsEnabled = true;
            NieuwSpelStarten.IsEnabled = false;
            HintVragen.IsEnabled = false;
            TxtBlInfo.Text = $"Klik op Spel Starten om het spel te starten";
            hintaanvraag = false;
            BtnRaad.Visibility = Visibility.Hidden;
            BtnStartSpel.Visibility = Visibility.Visible;
            BtnHint.Visibility = Visibility.Hidden;
            TxtWoord.Visibility = Visibility.Hidden;
            foutGeraden = "";
            goedGeraden = "";
            levens = 10;
        }

        //Wanneer je op de knop Startspel klikt dan begint het spel.
        //Er wordt een inputbox getoond waarin je je naam kan geven als deelnemer.
        //Timer begint te starten + de knoppen worden zichtbaar of onzichtbaar.
        //Je kan het letter raden of het woord raden.
        //...
        private void BtnStartSpel_Click(object sender, RoutedEventArgs e)
        {
            index = 0;
            TimerSec = TimerSecOptie + 1;
            naamDeelnemers = Interaction.InputBox($"Vul hier je naam in", "NaamSpelers", "", 500);
            TimerInstellen.IsEnabled = false;
            NieuwSpelStarten.IsEnabled = true;
            HintVragen.IsEnabled = true;
            valideren = IsAlleenLetters(naamDeelnemers);
            //Als je testbox leeg is of je voert een cijfer in dan wordt het spel niet gestart.
            if (valideren && !string.IsNullOrWhiteSpace(naamDeelnemers))
            {
                TxtWoord.Visibility = Visibility.Visible;
                TxtWoord.Focus();
                RandomWoord();
                //Hierin wordt het geheimeWoord gevuld met sterretjes.
                TxtBlInfo.Text = secret;
                int lengteWoord = secret.Length;
                ingaveCode = new char[lengteWoord];
                for (int i = 0; i < lengteWoord; i++)
                {
                    ingaveCode[i] = '*';
                }
                sterren = new string(ingaveCode);

                //De knopen worden zichtbaar of onzichtbaar + textblock wordt getoond + timer start.
                BtnStartSpel.Visibility = Visibility.Hidden;
                BtnRaad.Visibility = Visibility.Visible;
                BtnNieuwSpel.Visibility = Visibility.Visible;
                BtnHint.Visibility = Visibility.Visible;
                LstHistorieklijst.Visibility = Visibility.Hidden;
                TxtBlInfo.Text = $"Levens {levens}\nFout geraden: {foutGeraden}\nJuist geraden: {goedGeraden}\nGeheimeCode: {sterren}";
                TmrInfo.Start();
            }
            //Als je testbox leeg is of je voert een cijfer in dan wordt het spel niet gestart --> hierin toont een messagebox.
            else
            {
                MessageBox.Show("Je ingave is fout, geef mij een naam en geen cijfers of een lege tekstvak!!!", "Controle IngaveWoord");
            }
        }

        //Als je op de knop hint klik, dan toont een letter dan niet voorkomt in het woord d.m.v een messagebox + toont ook dat je maximaal 3 hints kan gebruiken.
        private void BtnHint_Click(object sender, RoutedEventArgs e)
        {
            HintAanvragen();
            hintaanvraag = true;
        }

        //In deze methode gaat die random een letterzoeken in de methode alfabetlijst dan niet voorkomt in het geheime woord.
        //Er is ook een limiet aangelegd om maxiamaal 3 keer een hint te vragen.
        private void HintAanvragen()
        {
            //Maximale aantal hints.
            const int maxAantalHints = 3;
            //Random letterzoeken in het alfabetlijst.
            Random rndLetters = new Random();
            int letterLijst = rndLetters.Next(1, alfabetLijst.Length);
            string hintLetter = alfabetLijst[letterLijst];
            //Als je 3 of meerdere keren op de knop hint klikt, dan toont die een messagebox waarin het limiet is bereikt.
            if (index >= maxAantalHints)
            {
                MessageBox.Show("Maximaal aantal hints bereikt!!!");
            }
            //Als het limiet niet bereikt is, dan kun je nog op de knop hint klikken om te zien welke letter er niet voorkomt.
            else
            {
                //De letter komt niet voor in het woord.
                while (secret.Contains(hintLetter))
                {
                    letterLijst = rndLetters.Next(1, alfabetLijst.Length);
                    hintLetter = alfabetLijst[letterLijst];

                }
                //Toont een messsagebox, welke letters er niet voorkomen in het woord. Dit wordt vervolgens in een textblock getoond bij fout geraden.
                MessageBox.Show($"Hint:{hintLetter}");
                foutGeraden += hintLetter;
                TxtBlInfo.Text = $"Levens {levens}\nFout geraden: {foutGeraden}\nJuist geraden: {goedGeraden}\nGeheimeCode: {sterren}";
            }
            index++;
        }

        //In historiekwinnaars wordt een lijst getoond waarin de naam van de speler, het aantal levens en de tijd waarin hij gestopt is.
        //Elke keer als een speler het spel wilt spelen wordt de speler telkens toegevoegd in je hiestorieklijst.
        private void Historiekwinnaars()
        {
            string winnaarLijstIngave = $"\t{naamDeelnemers} - {levens} levens - ({DateTime.Now})";
            historiekLijst.Add(winnaarLijstIngave);
        }

        //Je krijgt strafpunten als je op de hint knop klik dan wordt je highscore niet toegevoegd in historieklijst.
        //Als je geen hints gebruikt dan krijg je geen strafpunten en wordt je wel toegevoegd in de historieklijst.
        private void StrafPunten()
        {
            if (hintaanvraag)
            {

            }
            else
            {
                Historiekwinnaars();
                LstHistorieklijst.Items.Add(historiekLijst[x]);
                x++;
            }
        }

        //Bij letter zoeken in een woord gaat men de letter zoeken in het geheimewoord.
        //Als de letter juist is gaat er geen leven af <-> als de letter fout is gaat er wel een leven af.
        private void LetterZoekenInWoord()
        {
            Boolean result = false;
            char[] characters = secret.ToCharArray();
            if (TxtWoord.Text.Length == 1)
            {
                char ingave = Char.Parse(TxtWoord.Text);
                for (int i = 0; i < ingaveCode.Length; i++)
                {
                    if (characters[i].Equals(ingave))
                    {
                        ingaveCode[i] = ingave;
                    }
                }
                sterren = new string(ingaveCode);
            }

            result = secret.Contains(TxtWoord.Text);

            if (result == false)
            {
                levens--;
                HangmanImages();
                foutGeraden += TxtWoord.Text;
            }
            else if (result == true)
            {
                goedGeraden += TxtWoord.Text;
            }
        }

        //In deze methode kijkt het programma als de lettervoorkomt of niet.
        private void LetterKomtAlVoor()
        {
            //Als de letter voorkomt in het geheimewoord dan loopt de timer gewoon verder en gebeurt er verder niets.
            if (sterren.Contains(TxtWoord.Text))
            {
                letterAlGeraden = true;
            }
            //Als de letter niet voorkomt in het geheimewoord dan stopt de timer en wordt de timer gerest en start de timer weer met het tellen.
            else
            {
                letterAlGeraden = false;
                TmrInfo.Stop();
                TmrInfo.Start();
                TimerSec = TimerSecOptie + 1;
            }
        }
        //Als je het woord in een keer raadt dan wordt er een messagebox getoond dat je gewonnen hebt.
        //De tekstbox wordt onzichtbaar.
        private void WoordRaden()
        {
            if (!sterren.Contains('*'))
            {
                MessageBox.Show("Proficiat, Je hebt gewonnen", "Gewonnen");
                TmrInfo.Stop();
                TxtWoord.Visibility = Visibility.Hidden;
            }

        }

        //In deze methode kijkt die alleen als er een letter voorkomt, zoniet dan gaat die false zijn.
        private bool IsAlleenLetters(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsLetter(c))
                    return false;
            }
            return true;
        }

        //In randomwoord wordt er een random woord gekozen door het programma. (computer)
        private void RandomWoord()
        {
            Random rndWoorden = new Random();
            int woordenLijst = rndWoorden.Next(1, galgjeWoorden.Length);
            secret = galgjeWoorden[woordenLijst];
        }

        //Er is een alfabetlijst aangemaakt om de letter te zoeken in het geheimewoord.
        private string[] alfabetLijst = new string[]
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
        };

        //Lijst met random woorden.
        private string[] galgjeWoorden = new string[]
        {
            "grafeem",
            "tjiftjaf",
            "maquette",
            "kitsch",
            "pochet",
            "convocaat",
            "jakkeren",
            "collaps",
            "zuivel",
            "cesium",
            "voyant",
            "spitten",
            "pancake",
            "gietlepel",
            "karwats",
            "dehydreren",
            "viswijf",
            "flater",
            "cretonne",
            "sennhut",
            "tichel",
            "wijten",
            "cadeau",
            "trotyl",
            "chopper",
            "pielen",
            "vigeren",
            "vrijuit",
            "dimorf",
            "kolchoz",
            "janhen",
            "plexus",
            "borium",
            "ontweien",
            "quiche",
            "ijverig",
            "mecenaat",
            "falset",
            "telexen",
            "hieruit",
            "femelaar",
            "cohesie",
            "exogeen",
            "plebejer",
            "opbouw",
            "zodiak",
            "volder",
            "vrezen",
            "convex",
            "verzenden",
            "ijstijd",
            "fetisj",
            "gerekt",
            "necrose",
            "conclaaf",
            "clipper",
            "poppetjes",
            "looikuip",
            "hinten",
            "inbreng",
            "arbitraal",
            "dewijl",
            "kapzaag",
            "welletjes",
            "bissen",
            "catgut",
            "oxymoron",
            "heerschaar",
            "ureter",
            "kijkbuis",
            "dryade",
            "grofweg",
            "laudanum",
            "excitatie",
            "revolte",
            "heugel",
            "geroerd",
            "hierbij",
            "glazig",
            "pussen",
            "liquide",
            "aquarium",
            "formol",
            "kwelder",
            "zwager",
            "vuldop",
            "halfaap",
            "hansop",
            "windvaan",
            "bewogen",
            "vulstuk",
            "efemeer",
            "decisief",
            "omslag",
            "prairie",
            "schuit",
            "weivlies",
            "ontzeggen",
            "schijn",
            "sousafoon"
        };

        // In deze methode wordt een source link aangemaakt voor het image paneel binnenin het XAML.
        private BitmapImage ImgSource(int imgNummer)
        {
            return new BitmapImage(new Uri($@"/Images Hangman/Hangman leven {imgNummer}.png", UriKind.Relative));
        }

        // In deze methode wordt gebruikt om verschillende images te tonen van de persoon die opgehangen wordt.
        // Er wordt gekeken naar het aantal levens en hiermee wordt bepaald welke afbeeldingen van het ophanging wordt getoond.
        private void HangmanImages()
        {
            switch (levens)
            {
                case 10:
                    HangMan.Source = ImgSource(levens);
                    break;
                case 9:
                    HangMan.Source = ImgSource(levens);
                    break;
                case 8:
                    HangMan.Source = ImgSource(levens);
                    break;
                case 7:
                    HangMan.Source = ImgSource(levens);
                    break;
                case 6:
                    HangMan.Source = ImgSource(levens);
                    break;
                case 5:
                    HangMan.Source = ImgSource(levens);
                    break;
                case 4:
                    HangMan.Source = ImgSource(levens);
                    break;
                case 3:
                    HangMan.Source = ImgSource(levens);
                    break;
                case 2:
                    HangMan.Source = ImgSource(levens);
                    break;
                case 1:
                    HangMan.Source = ImgSource(levens);
                    break;
                case 0:
                    HangMan.Source = ImgSource(levens);
                    break;
                default:
                    break;
            }
        }

        //In deze menuitem wordt het spel afgesloten.
        private void MenuItem_Click1(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            if (menuItem.Header.ToString().Equals("Spel Afsluiten"))
            {
                Application.Current.MainWindow.Close();
            }
        }

        //In deze menuitem wordt de historieklijst getoond.
        private void MenuItem_Click2(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            if (menuItem.Header.ToString().Equals("Highscores Opvragen"))
            {
                LstHistorieklijst.Visibility = Visibility.Visible;
            }
        }

        //In deze menuitem wordt het spel opnieuw opgestart.
        private void MenuItem_Click3(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            if (menuItem.Header.ToString().Equals("Nieuw Spel Starten"))
            {
                BtnNieuwSpel_Click(sender, e);
            }
        }

        //In deze menuitem kan je een hint vragen.
        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            if (menuItem.Header.ToString().Equals("Een Hint Vragen"))
            {
                HintAanvragen();
            }
        }

        //In deze menuitem kan je de timer instellen.
        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            if (menuItem.Header.ToString().Equals("Timer Instellen"))
            {
                //Als je ingave verkeerd is dan wordt deze opgevangen in een try catch en toont een messagebox dat je ingave verkeerd is.
                try
                {
                    //Hierin toont een messagebox dat je de waarde van de timer kan instellen tussen 5 en 20 seconden.
                    TimerSecOptie = int.Parse(Interaction.InputBox($"Geef een mij een timerwaarde", "Tijdinstelllen", "", 500));
                    //Als je de waarde van je timer kleiner is dan 5 of groter is dan 20, toont die een messagebox dat je een waarde moet geven tussen 5 en 20. 
                    //Als de waarde  van de timer verkeerd is. Wordt dit standaard ingesteld op 10 seconden.
                    if (TimerSecOptie < 5 || TimerSecOptie > 20)
                    {
                        MessageBox.Show("U moet een waarde ingeven tussen 5 en 20");
                        TimerSecOptie = 10;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Je ingave is verkeerd!!!");
                }


            }
        }
    }
}




