using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace ProjektNr2_Piwowarski62024
{
    public partial class SzeregLaboratoryjny : Form
    {// deklaracja stałych określających granicę przedziału zbieżności "mojego" szeregu 
        const float DgPrzedzialuX = float.MinValue;
        const float GgPrzedzaluX = float.MaxValue;

        // deklaracja zmiennej referencyjnej tablicy dwuwymiarowej
        float[,] TWS;

        public SzeregLaboratoryjny()
        {
            InitializeComponent();
        }

        private void SzeregLaboratoryjny_FormClosing(object sender, FormClosingEventArgs e)
        {
            // utworzenie okna dialogowego dla potwierdzenia zamknięcia formularza głównego
            DialogResult OknoMessage = MessageBox.Show("Czy na pewno chcesz zamknąć ten formularz i przejść do formularza głównego", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            // rozpoznanie wybranej odpowiedzi Użytkownika programu
            if (OknoMessage == DialogResult.Yes)
            {
                e.Cancel = false;
                // odszukanie egzemplarza formularza głównego w kolekcji OpenForms 
                foreach (Form Formularz in Application.OpenForms)
                    // sprawdzamy, czy został znaleziony formularz główny
                    if (Formularz.Name == "KokpitProjektuNr2")
                    {// ukrycie bieżącego formularza 
                        this.Hide();
                        // odsłonięcie znalezionego głównego formularza
                        Formularz.Show();
                        // potwierdzenie skasowania bieżącego formularza
                        //e.Cancel = true;
                        // wyjście z metody obsługi zdarzenia FormClosing
                        return;
                    }
                // gdy będziemy tutaj, to będzie to oznaczało, że ktoś skasował formularz główny
                // utworzenie nowego egzemplarza formularza głównego KokpitProjektuNr2
                KokpitProjektuNr2 FormularzKokpitProjektuNr2 = new KokpitProjektuNr2();
                // ukrycie bieżącego formularza 
                this.Hide();
                // odsłonięcie nowego formularza głównego
                //FormularzKokpitProjektuNr2.Show();
                this.Show();
            }
            else // anulujemy zmaknięcie formularza
                e.Cancel = true;
        }

        private void btnObliczWartoscSzeregu_Click(object sender, EventArgs e)
        {
            // "zgaszenie" kontrolki errorProvider, która mogła zostać zapalona podczas pobierania danych
            errorProvider1.Dispose();
            // 1) Pobranie danych wejściowych z formularza
            // deklaracje zmiennych dla przechowania pobranych wejściowych
            float X, Eps;
            if (!PobranieDanych_X_Eps(out X, out Eps))
            { // był błąd, to go sygnalizujemy zapaleniem kontrolki errorProvider
                //errorProvider1.SetError(txtX, "ERROR: w zapisie wartośći zmiennej X wystąpił niedozwolony znak");
                // przerwanie pobierania kolejnych danych
                return;
            }
            // 2) obliczenie wartości szeregu
            // deklaracje zmiennych dla przechowania wyniku obliczeń
            float Suma;
            ushort LicznikZsumowanychWyrazow;
            // wywołanie metody obliczenia sumy szeregu
            Suma = ObliczWartoscSzeregu(X, Eps, out LicznikZsumowanychWyrazow);
            // 3) wpisanie wyników obliczeń do odpowiednich kontrolek na formularzu
            txtSumaSzeregu.Text = Suma.ToString();
            txtLicznikWyrazow.Text = LicznikZsumowanychWyrazow.ToString();
        }
        #region Deklaracje metod pomocniczych
        bool PobranieDanych_X_Eps(out float X, out float Eps)
        {
            // "techniczne" ustawienie wartości domyślnych dla parametru wyjściowego
            X = Eps = 0.0f;
            // pobranie wartości zmiennej niezależnej X
            if (!float.TryParse(txtX.Text, out X))
            {
                // był błąd, to go sygnalizujemy "zapaleniem" kontrolki errorProvider
                errorProvider1.SetError(txtX, "ERROR: w zapisie wartości zmiennej niezależnej X wystąpił niedozwolony znak");
                // przerwanie dalszego pobierania danych wejściowych
                return false;
            }
            // sprawdzenie czy dana wartość zmiennej X należy do przedziału zbieżności mojego szeregu
            // ustawienie stanu braku aktywności dla kontrolki txtX
            txtX.Enabled = false;
            // pobranie dokładności obliczeń Eps
            if (!float.TryParse(txtEps.Text, out Eps))
            {
                // był błąd, to go sygnalizujemy "zapaleniem" kontrolki errorProvider
                errorProvider1.SetError(txtEps, "ERROR: w zapisie dokładności obliczeń Eps wystąpił niedozwolony znak");
                // przerwanie dalszego pobierania danych wejściowych
                return false;
            }
            // sprawdzenie warunku wejściowego dla Eps
            if ((Eps <= 0.0f) || (Eps >= 1.0f))
            {
                // był błąd, to go sygnalizujemy "zapaleniem" kontrolki errorProvider
                errorProvider1.SetError(txtEps, "ERROR: podana dokładność obliczeń Eps nie spełnia warunku wejściowego: 0.0 < Eps < 1.0");
                // przerwanie dalszego pobierania danych wejściowych
                return false;
            }
            // ustawienie stanu braku aktywności dla kontrolki txtEps
            txtEps.Enabled = false;
            // "techniczne" ustawienie wartości wynikowej (czy był błąd)
            return true;
        }
        float ObliczWartoscSzeregu(float X, float Eps, out ushort n)
        {
            // "techniczne" ustawienie wartości domyślnych dla parametru wyjściowego
            n = 0;
            // ustalenie warunków brzegowych
            float S = 0.0f;
            float w = 1.0f;
            // iteracyjne obliczanie sumy szeregu
            do
            {
                S = S + w;
                n++;
                w = w * (-1) * X / n;
            } while (Math.Abs(w) > Eps);

            // zwrot wartości wynikowej (sumę szeregu)
            return S;
        }
        bool PobranieDanych_Xd_Xg_h_Eps(out float Xd, out float Xg, out float h, out float Eps)
        {
            // przypisanie domyślnych wartości technicznych dla parametrów wyjściowych
            Xd = Xg = h = Eps = 0.0f;
            // pobranie Xd
            if (!float.TryParse(txtXd.Text, out Xd))
            {// był błąd, to go sygnalizujemy zapaleniem kontrolki errorProvider
                errorProvider1.SetError(txtXd, "ERROR: w zapisie Xd wystąpił niedozwolony znak");
                // przerwanie pobrierania danych z formularza
                return false;
            }
            // sprawdzenie, czy Xd należy do przedziału zbieżności "mojego" szeregu
            if ((Xd < DgPrzedzialuX) || (Xd > GgPrzedzaluX))
            {// był błąd, to go sygnalizujemy zapaleniem kontrolki errorProvider
                errorProvider1.SetError(txtXd, "ERROR: podane Xd nie mieści się w przedziale zbieżności 'mojego' szeregu");
                // przerwanie pobrierania danych z formularza
                return false;
            }
            // pobranie Xg
            if (!float.TryParse(txtXg.Text, out Xg))
            {// był błąd, to go sygnalizujemy zapaleniem kontrolki errorProvider
                errorProvider1.SetError(txtXg, "ERROR: w zapisie Xg wystąpił niedozwolony znak");
                // przerwanie pobrierania danych z formularza
                return false;
            }
            // sprawdzenie, czy Xg należy do przedziału zbieżności "mojego" szeregu
            if ((Xg < DgPrzedzialuX) || (Xg > GgPrzedzaluX))
            {// był błąd, to go sygnalizujemy zapaleniem kontrolki errorProvider
                errorProvider1.SetError(txtXg, "ERROR: podane Xg nie mieści się w przedziale zbieżności 'mojego' szeregu");
                // przerwanie pobrierania danych z formularza
                return false;
            }
            // sprawdzenie poprawnej kolejności zapisu granicy przedziału: [Xd, Xg]
            if (Xd > Xg)
            {
                // był błąd, to go sygnalizujemy zapaleniem kontrolki errorProvider
                errorProvider1.SetError(txtXg, "ERROR: granice przedziału: [Xd, Xg] zostały podane w niepoprawnej kolejności");
                // przerwanie pobrierania danych z formularza
                return false;
            }
            // tutaj jest OK!
            // ustawienie stanu braku aktywności dla kontrolek: txtXd oraz txtXg
            txtXd.Enabled = false; txtXg.Enabled = false;
            // pobranie przyrostu 'h' zmian wartości zmiennej X
            if (!float.TryParse(txtH.Text, out h))
            {// był błąd, to go sygnalizujemy 
                errorProvider1.SetError(txtH, "ERRROR: w zapisie przyrostu 'h' wystąpił niedozwolony znak");
                // przerwanie pobrierania danych z formularza
                return false;
            }
            // sprawdzenie warunku wejściowego dla h 
            if ((h <= 0.0f) || (h >= (Xg - Xd)))
            {// był błąd, to go sygnalizujemy 
                errorProvider1.SetError(txtH, "ERRROR: podana wartość przyrostu 'h' nie spełnia tzw. warunku wejściowego: (h > 0.0) && (h < (Xg - Xd))");
                // przerwanie pobrierania danych z formularza
                return false;
            }
            txtH.Enabled = false;
            // pobranie dokładności obliczeń Eps
            if (!float.TryParse(txtEps.Text, out Eps))
            {// był błąd, to go sygnalizujemy 
                errorProvider1.SetError(txtEps, "ERRROR: w zapisie dokładności obliczeń Eps wystąpił niedozwolony znak");
                // przerwanie pobrierania danych z formularza
                return false;
            }
            // sprawdzenie tzw. warunku wejściowego 
            if ((Eps <= 0.0f) || (Eps >= 1.0f))
            {// był błąd, to go sygnalizujemy 
                errorProvider1.SetError(txtEps, "ERRROR: podana dokładność obliczeń Eps nie spełnia tzw. warunku wejściowego: 0.0 < Eps < 1.0");
                // przerwanie pobrierania danych z formularza
                return false;
            }
            txtEps.Enabled = false;
            // zwrotne przekazanie "informacji", że nie było żadnego błędu
            return true;
        }
        void TablicowanieWartosciSzeregu(float Xd, float Xg, float h, float Eps, out float[,] TWS)
        {// wyznaczenie liczby wierszy egzemplarza tablicy TWS
            int n = (int)((Xg - Xd) / h + 1);
            // utworzenie egzemplarza tablicy TWS
            TWS = new float[n, 3];
            // tablicowanie wartości szeregu w przedziale [Xd, Xg]
            // deklaracje pomocnicze
            float X;
            int i; // numer podprzedziału przedziału [Xd, Xg]
            ushort LicznikZsumowanychWyrazow;
            for (X = Xd, i = 0; i < TWS.GetLength(0); i++, X = Xd + i * h) // nie piszemy tak: X = X+h
            {
                TWS[i, 0] = X;
                TWS[i, 1] = ObliczWartoscSzeregu(X, Eps, out LicznikZsumowanychWyrazow);
                TWS[i, 2] = LicznikZsumowanychWyrazow;

            }

        }
        void WpisanieWynikowDoKontrolkiDataGridView(float[,] TWS, DataGridView dgvTWS)
        {// wyczyszczenie kontrolki DataGridView
            dgvTWS.Rows.Clear();
            // wpisywanie danych z tablicy TWS do kontrolki DataGridView
            for (int i = 0; i < TWS.GetLength(0); i++)
            {// dodajemy do kontrolki DataGridView nowy (i pusty) wiersz
                dgvTWS.Rows.Add();
                // wpisanie danych z TWS do kolejnych komórek do danego wiersza kontrolki DataGridView
                dgvTWS.Rows[i].Cells[0].Value = string.Format("{0:0.00}", TWS[i, 0]);
                dgvTWS.Rows[i].Cells[1].Value = string.Format("{0:0.00}", TWS[i, 1]);
                dgvTWS.Rows[i].Cells[2].Value = string.Format("{0}", (ushort)TWS[i, 2]);
            }
        }
        void WpisanieWynikowDoKontrolkiChart(float[,] TWS, Chart chtWykresSzeregu)
        {
            // ustalenie atrybutów dla kontrolki chtWykresSzeregu
            // ustalenie atrybutów obramowania kontrolki chtWykresSzeregu
            chtWykresSzeregu.BorderlineWidth = 2;
            chtWykresSzeregu.BorderlineColor = Color.Red;
            chtWykresSzeregu.BorderlineDashStyle = ChartDashStyle.DashDotDot;
            // sformatowanie kontrolki chtWykresSzeregu
            // ustalenie tytułu wykresu
            chtWykresSzeregu.Titles.Add("Wykres zmian wartości szeregu S(X)");
            // umieszczenie legendy pod wykresem 
            chtWykresSzeregu.Legends.FindByName("Legend1").Docking = Docking.Bottom;
            // ustalenie koloru tła dla kontrolki chtWykresSzeregu
            chtWykresSzeregu.BackColor = Color.LightBlue;
            // opis osi układu współrzędnych wykresu
            chtWykresSzeregu.ChartAreas[0].AxisX.Title = "Wartość zmiennej niezależnej X";
            chtWykresSzeregu.ChartAreas[0].AxisY.Title = "Wartość szeregu S(X)";
            // ustalenie formatu opisu liczbowego osi układu współrzędnych
            chtWykresSzeregu.ChartAreas[0].AxisX.LabelStyle.Format = "{0:F2}";
            chtWykresSzeregu.ChartAreas[0].AxisY.LabelStyle.Format = "{0:F3}";
            // wyzerowanie serii danych kontrolki Chart
            chtWykresSzeregu.Series.Clear();
            // dodajemy nową serię danych (dwie pierwsze kolumny z TWS, czyli: X oraz S(X)
            chtWykresSzeregu.Series.Add("Seria 0");
            // ustalenie (sformatowanie) atrybutów dla dodanej serii danych
            chtWykresSzeregu.Series[0].XValueMember = "X";
            chtWykresSzeregu.Series[0].YValueMembers = "Y";
            // ustalenie widocznośći legendy
            chtWykresSzeregu.Series[0].IsVisibleInLegend = true;
            // określenie nazwy tej serii danych
            chtWykresSzeregu.Series[0].Name = "Wartość szeregu potęgowego S(X)";
            chtWykresSzeregu.Series[0].ChartType = SeriesChartType.Line;
            chtWykresSzeregu.Series[0].Color = Color.Black;
            chtWykresSzeregu.Series[0].BorderDashStyle = ChartDashStyle.Solid;
            chtWykresSzeregu.Series[0].BorderWidth = 2;
            // wpisanie do serii danych współrzędnych punktów z tablicy TWS
            for (int i = 0; i < TWS.GetLength(0); i++)
                chtWykresSzeregu.Series[0].Points.AddXY(TWS[i, 0], TWS[i, 1]);
        }
        #endregion

        private void btnResetuj_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnWizualizacjaTabelaryczna_Click(object sender, EventArgs e)
        {
            // dekomponujemy obsługę tego zdarzenia Click na trzy działania:
            // 1) pobranie danych wejściowych: Xd, Xg, h i Eps
            // deklaracje dla przechowania pobranych danych wejściowych 
            float Xd, Xg, h, Eps;
            if (!PobranieDanych_Xd_Xg_h_Eps(out Xd, out Xg, out h, out Eps))
                // był błąd to przerwamy dalszą obsługę zdarzenia Click
                return;
            // 2) Stablicowanie szeregu
            // sprawdzenie, czy został już utworzony egzemplarz tablicy TWS i szereg został stablicowany
            if (TWS is null) // nie piszemy tak: TWS == null
                TablicowanieWartosciSzeregu(Xd, Xg, h, Eps, out TWS);
            // 3) wpisanie wyników tablicowania wartości szeregu do kontrolki DataGridView
            WpisanieWynikowDoKontrolkiDataGridView(TWS, dgvTWS);
            // odsłonięcie kontrolki dgvTWS
            dgvTWS.Visible = true;
            // ustawienie stanu braku aktywności dla obsługiwanego przycisku poleceń
            btnWizualizacjaTabelaryczna.Enabled = false;
        }

        private void btnWizualizacjaGraficzna_Click(object sender, EventArgs e)
        {
            // "zgaszenie" kontrolki errorProvider, która mogła zostać zapalona podczas pobierania danych
            errorProvider1.Dispose();

            // 1) Pobranie danych wejściowych z formularza Xd, Xg, h, Eps
            // deklaracja zmiennych dla przechowania pobranych danych wejściowych
            float Xd, Xg, h, Eps;
            if (!PobranieDanych_Xd_Xg_h_Eps(out Xd, out Xg, out h, out Eps))
            { // był błąd
                errorProvider1.SetError(btnWizualizacjaGraficzna, "ERROR: przy pobieraniu danych wejściowych wykryto błąd i dlatego ta funkcjonalność nie może być zrealizowana");
                // przerwanie obłsugi zdarzenia Click: btnWizualizacjaTabelaryczna_Click
                return;
            }
            // 2) Tablicowanie wartości szeregu w przedziale: [Xd, Xg]
            // sprawdzenie czy egzemplarz tablicy TWS został już utworzony i szereg został stablicowany
            if (TWS is null)
            {
                // egzempalrz tablicy TWS nie został jeszcze utworzony i szereg nie został stablicowany
                // utworzenie egzemplarza i stablicowanie szeregu
                TablicowanieWartosciSzeregu(Xd, Xg, h, Eps, out TWS);
            }
            // 3) Wpisanie wyników tablicowania do kontrolki Chart
            WpisanieWynikowDoKontrolkiChart(TWS, chtWykresSzeregu);
            // 4) ukrycie i odsłonięcie kontrolek dla potrzeb obsłuigiwanego przycisku poleceń
            dgvTWS.Visible = false;
            chtWykresSzeregu.Visible = true;
            btnWizualizacjaGraficzna.Enabled = false;
        }

        private void zapisanieTablicyTWSWPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {// zgaszenie kontrolki errorProvider, która mogła być zapalona
            errorProvider1.Dispose();
            // sprawdzenie, czy został już utworzony egzemplarz tablicy TWS
            if (TWS is null)
            {// egzemplarz tablicy TWS nie został jeszcze utworzony, a to oznacza, że tutaj należy go utworzyć
                // pobranie danych z formularza 
                // deklaracje zmiennych dla przechowania danych wejściowych
                float Xd, Xg, h, Eps;
                // wywołanie metody dla pobrania danych wejściowych
                if (!PobranieDanych_Xd_Xg_h_Eps(out Xd, out Xg, out h, out Eps))
                {// dodatkowe powiadomienie Użytkownika o wykrytym błędzie
                    MessageBox.Show("UWAGA: podczas pobierania danych wejściowych z formularza wystąpił niedozwolony znak! Popraw zapis ten danej i ponownie wybierz aktualnie obsługiwane polecenie z menu Plik");
                    // przerwanie dalszej obsługi polecenia wybranego z menu Plik
                    return;
                }
                // tutaj dane zostały już pobrane i możemy stablicować szereg
                TablicowanieWartosciSzeregu(Xd, Xg, h, Eps, out TWS);
            }
            // tutaj jest egzemplarz TWS i szereg jest stablicowany, czyli możemy go zapisać do pliku
            // utworzenie okna dialogowego dla wyboru pliku do zapisu
            SaveFileDialog OknoWyboruPlikuDoZapisu = new SaveFileDialog();
            // ustawienie filtru dla wyświetlanych plików
            OknoWyboruPlikuDoZapisu.Filter = "txtfile (*.txt)|*.txt|All files(*.*)|*.*";
            // ustawienie filtru domyślnego
            OknoWyboruPlikuDoZapisu.FilterIndex = 1;
            // przywrócenie folderu sprzed wyboru pliku do zapisu
            OknoWyboruPlikuDoZapisu.RestoreDirectory = true;
            // ustawienie dysku domyślnego (który będzie "otwarty" w oknie OknoWyboruPlikuDoZapisu)
            OknoWyboruPlikuDoZapisu.InitialDirectory = "C:\\";
            // ustalenie tytyły okna dialogowego do wyboru pliku do zpaisu
            OknoWyboruPlikuDoZapisu.Title = "Wybór pliku do zapisu tablicy TWS (Tablica Wartośći Szeregu)";
            // wyświetlenie OknoWyboruPlikuDoZapisu i "odczytanie" dokonanego wyboru przez użytkownika
            if (OknoWyboruPlikuDoZapisu.ShowDialog() == DialogResult.OK)
            {// zapisanie tablicy TWS w pliku
                System.IO.StreamWriter PlikZnakowy = new System.IO.StreamWriter(OknoWyboruPlikuDoZapisu.FileName);
                // wpisanie wierszy danych z tablicy TWS
                try
                {
                    for (int i = 0; i < TWS.GetLength(0); i++)
                    {
                        PlikZnakowy.Write(TWS[i, 0].ToString()); // zapisanie wartości X
                        PlikZnakowy.Write(";"); // znak ";" oddziela liczby od siebie
                        PlikZnakowy.Write(TWS[i, 1].ToString()); // zapisanie wartości S(X)
                        PlikZnakowy.Write(";"); // znak ";" oddziela liczby od siebie
                        PlikZnakowy.WriteLine(TWS[i, 2].ToString()); // licznik zsumowanych wyrazów
                    }
                }
                catch (Exception ex)
                {
                    // wyświetlenie komunikatu
                    MessageBox.Show("UWAGA: podczas zapisu wierszy tablicy TWS wystąpił błąd: " + ex.Message + ", co oznacza, że tablica TWS nie została zapisana do pliku");
                }
                finally
                {
                    PlikZnakowy.Close();
                }
            }
            else
                // wypisanie komunikatu
                MessageBox.Show("UWAGA: nie został wybrany żaden plik i tablica TWS nie została zapisana w żadnym pliku");
        }

        private void dToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // "zgaszenie" kontrolki errorProvider, któw mogła zostać zapalona podczas pobierania danych
            errorProvider1.Dispose();
            // sprawdzenie, czy zmienna referencyjna ma wartość null (tzw. Pusta refencja do egzemplarza tablicy
            if (!(TWS is null))
            {// poinformowanie Użytkownika, że egzemplarz tablicy już jest utworzony i czy ma być skasowany dla elementów tablicy TWS z pliku ma być kontynuowane
                DialogResult OknoMessage = MessageBox.Show("UWAGA: egzemplarz tablicy TWS już istnieje! \r\nCzy bieżący egzemplarz tablicy TWS ma być skasowany i w jego miejsce ma być utworzony nowy egzemplarz," +
                    " do którego mają zostać 'wczytane' elementy TWS z pliku? \r\n - kliknij przycisk poleceń 'Tak' dla potwierdzenia wczytania elementów tablicy TWS z pliku \r\n - kliknij przycisk poleceń 'Nie' " +
                    "dla skasowania polecenia wczytania elementów tablicy TWS z pliku ", "Okno ostrzeżenia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                // rozpoznanie wybranego przycisku poleceń w oknie dialogowym 'MessageBox'

                if (OknoMessage == DialogResult.Yes)
                    // skasowanie obecnego egzemplarza tablicy TWS
                    TWS = null; /* przypisanie wartości 'null' zmiennej referencyjnej jest sygnałem dla CLR (Language Runtime: wspólne uruchomieniowe dla platformy .NET), egzemplarz tablicy przypisany referencyjnej TWS 
                                jest już niepotrzebny może być zwolniony automatycznie przez (Garbage Collector): tzw. "odśmiecaczktórego zadaniem jest usuwanie 'martwych(niepotrzebnych) egzemplarzy tablic obiektów */
                else
                { // czyli: if (OknoMessage == DialogResult. No)
                    MessageBox.Show("Polecenie odczytania (pobrania) elementów tablicy TWS z pliku zostało anulowane(skasowane!)");
                    // przerwanie obsługi polecenia odczytania (pobrania) elementów tablicy TWS z pliku
                    return;
                }
            }
            // utworzenie egzemplarza okna dialogowego dla wyboru (lub utworzenia) pliku do odczytu
            OpenFileDialog OknowyboruPlikuDoOdczytu = new OpenFileDialog();
            // ustawienie filtru dla wyboru plików do wyświetlenia w oknie dialogowym
            OknowyboruPlikuDoOdczytu.Filter = "txtfiles (*.txt) |*.txt | All files (*.*)|*.*";
            // ustawienie filtru domyślnego
            OknowyboruPlikuDoOdczytu.FilterIndex = 1; // czyli filtru:*.text
            // przywrócenie bieżącego folderu po zamknięciu okna dialogowego wyboru pliku
            OknowyboruPlikuDoOdczytu.RestoreDirectory = true;
            // ustawienie domyślnego dysku do zapisu
            OknowyboruPlikuDoOdczytu.InitialDirectory = "C:\\";
            // ustalenie tytułu okna dialogowego wyboru pliku
            OknowyboruPlikuDoOdczytu.Title = "Wybór pliku do odczytu TWS (Tabeli Wartości Szeregu)";
            // wyświetlenie okna dialogowego i sprawdzenie, czy Użytkownik wybrał plik do odczytu
            if (OknowyboruPlikuDoOdczytu.ShowDialog() == DialogResult.OK)
            {
                // wczytanie wierszy pliku i ich wpisanie do tablicy TWS zrealizujemy w kilku "krokach", które ponumerujemy!
                // deklaracje pomocnicze
                string WierszDanych; // dla przechowania wiersza danych (łańcucha znaków) wczytanych z pliku znakowego
                string[] DaneWiersza; // dla podzielenia wiersza danych na pojedyncze dane (liczby), które są zapisane w tym wczytanym wierszu danych
                ushort LicznikWierszy; // licznik wierszy pliku znakowego (zawierającego zapisane wiersze tablicy TWS) */
                // Krok 1: utworzenie i otwarcie egzemplarza pliku znakowego jako strumienia znaków, co umożliwi wykonywanie na nim operacji "podobnych" do operacji wykonywanych na oknie konsoli Console, co poznaliśmy podczas realizacji Projektu Nr1
                System.IO.StreamReader PlikZnakowy = new System.IO.StreamReader(OknowyboruPlikuDoOdczytu.FileName);
                //lub: new System.IO.StreamReader (OknoOdczytuPliku.OpenFile());
                // przy tworzeniu egzemplarza (będą w nim zapisane dane opisujące atrybuty otwieranego pliku znakowego) klasy StreamReader, musimy podać nazwę wybranego już wcześniej pliku do odczytu
                // Krok 2: policzenie liczby wierszy w pliku: PlikZnakowy, zliczając wczytywane wiersze pliku aż do napotkania znacznika końca pliku: null
                LicznikWierszy = 0;
                while (!((WierszDanych = PlikZnakowy.ReadLine()) is null))
                    LicznikWierszy++;
                // Krok 3: zamknięcie pliku (ale go nie zwalniamy, gdyż będziemy "zaraz" wczytywali wiersze tablicy TWS */
                PlikZnakowy.Close();
                // Krok 4: utworzenie egzemplarza tablicy TWS (wiemy już ile musi mieć wierszy!!!)
                TWS = new float[LicznikWierszy, 3];
                // Krok 5: powtórne otwarcie pliku znakowego do odczytu
                PlikZnakowy = new System.IO.StreamReader(OknowyboruPlikuDoOdczytu.FileName);
                // Krok 6: odczytywanie pliku znakowego: "wiersz po wierszu"

                try
                // instrukcja 'try' umożliwia zapis sekwencji instrukcji w której mogą wystąpić wyjątki (błędy!) i może zawierać jedną lub więcej sekcji 'catch', w których zapisujemy działania w "odpowiedzi" na "zgłoszony" wyjątek
                { // ustalenie warunków brzegowych
                    int NrWiersza = 0;
                    // wczytywanie kolejnych wierszy pliku znakowego, aż do napotkania znacznika końca pliku: null
                    while (!((WierszDanych = PlikZnakowy.ReadLine()) is null))
                    {
                        // wczytanie wiersza pliku znakowego i jego podział na "części", które są rozdzielone separatorem (znakiem) ';'
                        DaneWiersza = WierszDanych.Split(';');
                        // usunięcie 'spacji' z poszczególnych "części" wczytanego wiersza danych
                        DaneWiersza[0].Trim(); DaneWiersza[1].Trim();
                        DaneWiersza[2].Trim();
                        // wpisanie danych ("części" zapisanych znakowo) do tablicy TWS, co wymaga ich konwersji na wartość typu 'float'
                        TWS[NrWiersza, 0] = float.Parse(DaneWiersza[0]);
                        TWS[NrWiersza, 1] = float.Parse(DaneWiersza[1]);
                        TWS[NrWiersza, 2] = float.Parse(DaneWiersza[2]);
                        NrWiersza++;
                    }
                    /* Klasa String udostępnia metodę Split ('separator'), która zwraca tablicę łańcuchów znaków DaneWiersza (jako wynik swojego działania) utworzoną z podzielenia WierszaDanych na pojedyncze "części" każdorazowo, 
                    gdy w WierszuDanych wystąpi podany 'separator' (znak: ";") danych. Gdy parametr 'separator' metody Split(...) jest listą separatorów (podanych jako tablica typu char: 
                    WierszaDanych.Split(new char[]{ ';', ':', 'I'})), to zwracana jest tablica (DaneWiersza) łańcucha znaków (typu: string), w której zanjdują się wydzielone podłańcuchy znaków (substringi) rozdzielone od siebie jednym z podanych separatorów */


                    /* 7) przepisanie danych z tablicy TWS do kontrolki DataGridView umieszczonej na formularzu, co umożliwi nam wcześniej zaprojektowana
                    (przy obsłudze rzycisku poleceń: 'Wizualaizacja tabelaryczna zmian wartości szeregu metoda: WpisanieWynikówDoKontrolkiDataGridView */
                    WpisanieWynikowDoKontrolkiDataGridView(TWS, dgvTWS);
                    // wczytane wiersze tablicy TWS wpisujemy do kontrolki DataGridView dla "wzrokowego" potwierdzenia wykonania operacji odczytania wiersz danych tablicy TWS z pliku
                    // 8) odsłonięcie i ukrycie kontrolek odpowiednich kontrolek oraz ustawienie stanu braku aktywności kontrolek
                    // ukrycie kontrolki Chart
                    chtWykresSzeregu.Visible = false;
                    // odsłonięcie kontrolki DataGridView
                    dgvTWS.Visible = true;
                }
                catch (Exception ex) // obsługi wyjątku (wykrytego błędu) podczas wykonywania operacji na pliku, który został "zgłoszony" w sekcji try
                {
                    MessageBox.Show("ERROR: błąd operacji (działania) na pliku (wyświetlony komunikat): --> " + ex.Message);
                }
                finally /* sekcja 'finally' jest stosowana do zapisu sekwencji jednego lub więcej instrukcji kończących wykonywanie działań na pliku (niezależnie od tego, czy wyjątek został "zgłoszony" czy nie!).
                        Dla przykładu, jeżeli został otwarty plik musi on zostać zamknięty i zwolniony, niezależnie od faktu, czy błąd został "zgłoszony" czy nie */
                {
                    // zamknięcie pliku i zwolnienie zasobów z nim związanych
                    PlikZnakowy.Close();
                    PlikZnakowy.Dispose();
                }
            }
            else
                MessageBox.Show("Plik do odczytu tablicy TWS nie został wybrany i obsługa polecenia: 'Odczytanie stablicowanego szeregu z pliku' (z menu poziomego Plik) nie może być zrealizowana");
        }

        private void zmianaKoloruTłaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // otworzenie okna dialogowego z paletą kolorów
            ColorDialog PaletaKolorow = new ColorDialog();
            // zaznaczenie w PalecieKolorow bieżącego koloru formularza
            PaletaKolorow.Color = this.BackColor;
            // wyświetlenie palety kolorów i "odczytanie" wybranego koloru przez Użytkownika
            if (PaletaKolorow.ShowDialog() == DialogResult.OK)
                // dokonujemy zmiany koloru tła formularza
                this.BackColor = PaletaKolorow.Color;
            // zwolnienie egzemplarza PaletyKolorow
            PaletaKolorow.Dispose();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void zmianaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // utworzenie okna dialogowego dla zmiany czcionki
            FontDialog OknoCzcionki = new FontDialog();
            // zaznaczenie w oknie OknoCzcionki bieżącego fontu
            OknoCzcionki.Font = this.Font;
            // wyświetlenie okna dialogowego OknoCzcionki i "odczytanie" nowych ustawień dla fontów
            if (OknoCzcionki.ShowDialog() == DialogResult.OK)
                // ustawienie nowego fontu da formularza
                this.Font = OknoCzcionki.Font;
            // zwolnienie przydzielonego zasobu pamięci dla OknoCzcionki
            OknoCzcionki.Dispose();
        }

        private void exitZamknięcieFormularzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // wyświetlenie okna dialogowego z pytaniem: "Czy rzeczywiście ..." z ikoną pytajnika i trzema przyciskami: Yes, No, Cancel
            DialogResult PytanieDoUzytkownika = MessageBox.Show("Czy na pewno chcesz zamknąć formularz (co może skutkować utratą danych zapisanych na formularzu)?", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            // rozpoznanie odpowiedzi użytkownika aplikacji i wykonanie stosownego działania; formularz możę być zamknięty gdy użytkownik wybrał (kliknął) przycisk poleceń Tak
            if (PytanieDoUzytkownika == DialogResult.Yes)
                // formularz musi być zamknięty
                Close();
        }
    }
}
