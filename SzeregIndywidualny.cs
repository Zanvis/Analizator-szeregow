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

namespace ProjektNr2_Piwowarski62024
{
    public partial class SzeregIndywidualny : Form
    {// deklaracja stałych określających granicę przedziału zbieżności "mojego" szeregu 
        const float apDgPrzedzialuX = -4.0f;
        const float apGgPrzedzaluX = 4.0f;

        // deklaracja zmiennej referencyjnej tablicy dwuwymiarowej
        float[,] apTWS;
        public SzeregIndywidualny()
        {
            InitializeComponent();
        }

        private void SzeregIndywidualny_FormClosing(object sender, FormClosingEventArgs e)
        {
            // utworzenie okna dialogowego dla potwierdzenia zamknięcia formularza głównego
            DialogResult apOknoMessage = MessageBox.Show("Czy na pewno chcesz zamknąć ten formularz i przejść do formularza głównego", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            // rozpoznanie wybranej odpowiedzi Użytkownika programu
            if (apOknoMessage == DialogResult.Yes)
            {
                e.Cancel = false;
                // odszukanie egzemplarza formularza głównego w kolekcji OpenForms 
                foreach (Form apFormularz in Application.OpenForms)
                    // sprawdzamy, czy został znaleziony formularz główny
                    if (apFormularz.Name == "KokpitProjektuNr2")
                    {// ukrycie bieżącego formularza 
                        this.Hide();
                        // odsłonięcie znalezionego głównego formularza
                        apFormularz.Show();
                        // wyjście z metody obsługi zdarzenia FormClosing
                        return;
                    }
                // gdy będziemy tutaj, to będzie to oznaczało, że ktoś skasował formularz główny
                // utworzenie nowego egzemplarza formularza głównego KokpitProjektuNr2
                KokpitProjektuNr2 apFormularzKokpitProjektuNr2 = new KokpitProjektuNr2();
                // ukrycie bieżącego formularza 
                this.Hide();
                // odsłonięcie nowego formularza głównego
                this.Show();
            }
            else // anulujemy zmaknięcie formularza
                e.Cancel = true;
        }

        private void btnObliczWartoscSzeregu_Click(object sender, EventArgs e)
        {
            // "zgaszenie" kontrolki errorProvider, która mogła zostać zapalona podczas pobierania danych
            errorProvider1.Dispose();
            // deklaracje zmiennych dla przechowania pobranych wejściowych
            float apX, apEps;
            if (!apPobranieDanych_X_Eps(out apX, out apEps))
            {
                // przerwanie pobierania kolejnych danych
                return;
            }
            // deklaracje zmiennych dla przechowania wyniku obliczeń
            float apSuma;
            ushort apLicznikZsumowanychWyrazow;
            // wywołanie metody obliczenia sumy szeregu
            apSuma = apObliczWartoscSzeregu(apX, apEps, out apLicznikZsumowanychWyrazow);
            // wpisanie wyników obliczeń do odpowiednich kontrolek na formularzu
            txtSumaSzeregu.Text = apSuma.ToString();
            txtLicznikWyrazow.Text = apLicznikZsumowanychWyrazow.ToString();
        }
        #region Deklaracje metod pomocniczych
        bool apPobranieDanych_X_Eps(out float apX, out float apEps)
        {
            // "techniczne" ustawienie wartości domyślnych dla parametru wyjściowego
            apX = apEps = 0.0f;
            // pobranie wartości zmiennej niezależnej X
            if (!float.TryParse(txtX.Text, out apX))
            {
                // był błąd, to go sygnalizujemy "zapaleniem" kontrolki errorProvider
                errorProvider1.SetError(txtX, "ERROR: w zapisie wartości zmiennej niezależnej X wystąpił niedozwolony znak");
                // przerwanie dalszego pobierania danych wejściowych
                return false;
            }
            // sprawdzenie czy dana wartość zmiennej X należy do przedziału zbieżności mojego szeregu
            if ((apX <= -4.0f) || (apX >= 4.0f))
            {
                // był błąd, to go sygnalizujemy "zapaleniem" kontrolki errorProvider
                errorProvider1.SetError(txtX, "ERROR: dana wartość zmiennej X nie należy do przedziału zbieżności szeregu indywidualnego: -4.0 < X < 4.0");
                // przerwanie dalszego pobierania danych wejściowych
                return false;
            }
            // ustawienie stanu braku aktywności dla kontrolki txtX
            txtX.Enabled = false;
            // pobranie dokładności obliczeń Eps
            if (!float.TryParse(txtEps.Text, out apEps))
            {
                // był błąd, to go sygnalizujemy "zapaleniem" kontrolki errorProvider
                errorProvider1.SetError(txtEps, "ERROR: w zapisie dokładności obliczeń Eps wystąpił niedozwolony znak");
                // przerwanie dalszego pobierania danych wejściowych
                return false;
            }
            // sprawdzenie warunku wejściowego dla Eps
            if ((apEps <= 0.0f) || (apEps >= 1.0f))
            {
                // był błąd, to go sygnalizujemy "zapaleniem" kontrolki errorProvider
                errorProvider1.SetError(txtEps, "ERROR: podana dokładność obliczeń Eps nie spełnia warunku wejściowego: 0.0 < Eps < 1.0");
                // przerwanie dalszego pobierania danych wejściowych
                return false;
            }
            // ustawienie stanu braku aktywności dla kontrolki txtEps
            txtEps.Enabled = false;
            return true;
        }
        float apObliczWartoscSzeregu(float apX, float apEps, out ushort apn)
        {
            // "techniczne" ustawienie wartości domyślnych dla parametru wyjściowego
            apn = 0;
            // ustalenie warunków brzegowych
            float apS = 0.0f;
            float apw = 1.0f;
            // iteracyjne obliczanie sumy szeregu
            do
            {
                apS = apS + apw;
                apn++;
                apw = apw * apn * apX / (4 * apn - 2);
            } while (Math.Abs(apw) > apEps);

            // zwrot wartości wynikowej (sumę szeregu)
            return apS;
        }
        bool apPobranieDanych_Xd_Xg_h_Eps(out float apXd, out float apXg, out float aph, out float apEps)
        {
            // przypisanie domyślnych wartości technicznych dla parametrów wyjściowych
            apXd = apXg = aph = apEps = 0.0f;
            // pobranie Xd
            if (!float.TryParse(txtXd.Text, out apXd))
            {// był błąd, to go sygnalizujemy zapaleniem kontrolki errorProvider
                errorProvider1.SetError(txtXd, "ERROR: w zapisie Xd wystąpił niedozwolony znak");
                // przerwanie pobrierania danych z formularza
                return false;
            }
            // sprawdzenie, czy Xd należy do przedziału zbieżności "mojego" szeregu
            if ((apXd < apDgPrzedzialuX) || (apXd > apGgPrzedzaluX))
            {// był błąd, to go sygnalizujemy zapaleniem kontrolki errorProvider
                errorProvider1.SetError(txtXd, "ERROR: podane Xd nie mieści się w przedziale zbieżności szeregu indywidualnego: -4.0 < Xd < 4.0");
                // przerwanie pobrierania danych z formularza
                return false;
            }
            // pobranie Xg
            if (!float.TryParse(txtXg.Text, out apXg))
            {// był błąd, to go sygnalizujemy zapaleniem kontrolki errorProvider
                errorProvider1.SetError(txtXg, "ERROR: w zapisie Xg wystąpił niedozwolony znak");
                // przerwanie pobrierania danych z formularza
                return false;
            }
            // sprawdzenie, czy Xg należy do przedziału zbieżności "mojego" szeregu
            if ((apXg < apDgPrzedzialuX) || (apXg > apGgPrzedzaluX))
            {// był błąd, to go sygnalizujemy zapaleniem kontrolki errorProvider
                errorProvider1.SetError(txtXg, "ERROR: podane Xg nie mieści się w przedziale zbieżności szeregu indywidualnego: -4.0 < Xg < 4.0");
                // przerwanie pobrierania danych z formularza
                return false;
            }
            // sprawdzenie poprawnej kolejności zapisu granicy przedziału: [Xd, Xg]
            if (apXd > apXg)
            {
                // był błąd, to go sygnalizujemy zapaleniem kontrolki errorProvider
                errorProvider1.SetError(txtXg, "ERROR: granice przedziału: [Xd, Xg] zostały podane w niepoprawnej kolejności");
                // przerwanie pobrierania danych z formularza
                return false;
            }
            // ustawienie stanu braku aktywności dla kontrolek: txtXd oraz txtXg
            txtXd.Enabled = false; txtXg.Enabled = false;
            // pobranie przyrostu 'h' zmian wartości zmiennej X
            if (!float.TryParse(txtH.Text, out aph))
            {// był błąd, to go sygnalizujemy 
                errorProvider1.SetError(txtH, "ERRROR: w zapisie przyrostu 'h' wystąpił niedozwolony znak");
                // przerwanie pobrierania danych z formularza
                return false;
            }
            // sprawdzenie warunku wejściowego dla h 
            if ((aph <= 0.0f) || (aph >= (apXg - apXd)))
            {// był błąd, to go sygnalizujemy 
                errorProvider1.SetError(txtH, "ERRROR: podana wartość przyrostu 'h' nie spełnia tzw. warunku wejściowego: (h > 0.0) && (h < (Xg - Xd))");
                // przerwanie pobrierania danych z formularza
                return false;
            }
            //ustawienie stanu braku aktywności dla kontrolki 'h'
            txtH.Enabled = false;
            // pobranie dokładności obliczeń Eps
            if (!float.TryParse(txtEps.Text, out apEps))
            {// był błąd, to go sygnalizujemy 
                errorProvider1.SetError(txtEps, "ERRROR: w zapisie dokładności obliczeń Eps wystąpił niedozwolony znak");
                // przerwanie pobrierania danych z formularza
                return false;
            }
            // sprawdzenie tzw. warunku wejściowego 
            if ((apEps <= 0.0f) || (apEps >= 1.0f))
            {// był błąd, to go sygnalizujemy 
                errorProvider1.SetError(txtEps, "ERRROR: podana dokładność obliczeń Eps nie spełnia tzw. warunku wejściowego: 0.0 < Eps < 1.0");
                // przerwanie pobrierania danych z formularza
                return false;
            }
            // zwrotne przekazanie "informacji", że nie było żadnego błędu
            return true;
        }
        void apTablicowanieWartosciSzeregu(float apXd, float apXg, float aph, float apEps, out float[,] apTWS)
        {// wyznaczenie liczby wierszy egzemplarza tablicy TWS
            int apn = (int)((apXg - apXd) / aph + 1);
            // utworzenie egzemplarza tablicy TWS
            apTWS = new float[apn, 3];
            // deklaracje pomocnicze
            float apX;
            int api; // numer podprzedziału przedziału [Xd, Xg]
            ushort apLicznikZsumowanychWyrazow;
            for (apX = apXd, api = 0; api < apTWS.GetLength(0); api++, apX = apXd + api * aph)
            {
                apTWS[api, 0] = apX;
                apTWS[api, 1] = apObliczWartoscSzeregu(apX, apEps, out apLicznikZsumowanychWyrazow);
                apTWS[api, 2] = apLicznikZsumowanychWyrazow;

            }

        }
        void apWpisanieWynikowDoKontrolkiDataGridView(float[,] apTWS, DataGridView apdgvTWS)
        {// wyczyszczenie kontrolki DataGridView
            apdgvTWS.Rows.Clear();
            // wpisywanie danych z tablicy TWS do kontrolki DataGridView
            for (int i = 0; i < apTWS.GetLength(0); i++)
            {// dodajemy do kontrolki DataGridView nowy (i pusty) wiersz
                apdgvTWS.Rows.Add();
                // wpisanie danych z TWS do kolejnych komórek do danego wiersza kontrolki DataGridView
                apdgvTWS.Rows[i].Cells[0].Value = string.Format("{0:0.00}", apTWS[i, 0]);
                apdgvTWS.Rows[i].Cells[1].Value = string.Format("{0:0.00}", apTWS[i, 1]);
                apdgvTWS.Rows[i].Cells[2].Value = string.Format("{0}", (ushort)apTWS[i, 2]);
            }
        }
        void apWpisanieWynikowDoKontrolkiChart(float[,] apTWS, Chart apchtWykresSzeregu)
        {
            // ustalenie atrybutów dla kontrolki chtWykresSzeregu
            // ustalenie atrybutów obramowania kontrolki chtWykresSzeregu
            apchtWykresSzeregu.BorderlineWidth = 3;
            apchtWykresSzeregu.BorderlineColor = Color.Green;
            apchtWykresSzeregu.BorderlineDashStyle = ChartDashStyle.DashDot;
            // sformatowanie kontrolki chtWykresSzeregu
            // ustalenie tytułu wykresu
            apchtWykresSzeregu.Titles.Add("Wykres zmian wartości szeregu S(X)");
            // umieszczenie legendy pod wykresem 
            apchtWykresSzeregu.Legends.FindByName("Legend1").Docking = Docking.Bottom;
            // ustalenie koloru tła dla kontrolki chtWykresSzeregu
            apchtWykresSzeregu.BackColor = Color.LightGreen;
            // opis osi układu współrzędnych wykresu
            apchtWykresSzeregu.ChartAreas[0].AxisX.Title = "Wartość zmiennej niezależnej X";
            apchtWykresSzeregu.ChartAreas[0].AxisY.Title = "Wartość szeregu S(X)";
            // ustalenie formatu opisu liczbowego osi układu współrzędnych
            apchtWykresSzeregu.ChartAreas[0].AxisX.LabelStyle.Format = "{0:F2}";
            apchtWykresSzeregu.ChartAreas[0].AxisY.LabelStyle.Format = "{0:F3}";
            // wyzerowanie serii danych kontrolki Chart
            apchtWykresSzeregu.Series.Clear();
            // dodajemy nową serię danych (dwie pierwsze kolumny z TWS, czyli: X oraz S(X)
            apchtWykresSzeregu.Series.Add("Seria 0");
            // ustalenie (sformatowanie) atrybutów dla dodanej serii danych
            apchtWykresSzeregu.Series[0].XValueMember = "X";
            apchtWykresSzeregu.Series[0].YValueMembers = "Y";
            // ustalenie widocznośći legendy
            apchtWykresSzeregu.Series[0].IsVisibleInLegend = true;
            // określenie nazwy tej serii danych
            apchtWykresSzeregu.Series[0].Name = "Wartość szeregu potęgowego S(X)";
            apchtWykresSzeregu.Series[0].ChartType = SeriesChartType.Line;
            apchtWykresSzeregu.Series[0].Color = Color.Red;
            apchtWykresSzeregu.Series[0].BorderDashStyle = ChartDashStyle.Solid;
            apchtWykresSzeregu.Series[0].BorderWidth = 2;
            // wpisanie do serii danych współrzędnych punktów z tablicy TWS
            for (int api = 0; api < apTWS.GetLength(0); api++)
                apchtWykresSzeregu.Series[0].Points.AddXY(apTWS[api, 0], apTWS[api, 1]);
        }
        #endregion

        private void btnResetuj_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnWizualizacjaTabelaryczna_Click(object sender, EventArgs e)
        {
            // deklaracje dla przechowania pobranych danych wejściowych 
            float apXd, apXg, aph, apEps;
            // pobranie danych wejściowych: Xd, Xg, h i Eps
            if (!apPobranieDanych_Xd_Xg_h_Eps(out apXd, out apXg, out aph, out apEps))
                // był błąd to przerwamy dalszą obsługę zdarzenia Click
                return;
            // Stablicowanie szeregu
            // sprawdzenie, czy został już utworzony egzemplarz tablicy TWS i szereg został stablicowany
            if (apTWS is null)
                apTablicowanieWartosciSzeregu(apXd, apXg, aph, apEps, out apTWS);
            // wpisanie wyników tablicowania wartości szeregu do kontrolki DataGridView
            apWpisanieWynikowDoKontrolkiDataGridView(apTWS, dgvTWS);
            // odsłonięcie kontrolki dgvTWS
            dgvTWS.Visible = true;
            // ustawienie stanu braku aktywności dla obsługiwanego przycisku poleceń
            btnWizualizacjaTabelaryczna.Enabled = false;
        }

        private void btnWizualizacjaGraficzna_Click(object sender, EventArgs e)
        {
            // "zgaszenie" kontrolki errorProvider, która mogła zostać zapalona podczas pobierania danych
            errorProvider1.Dispose();   
            
            // deklaracja zmiennych dla przechowania pobranych danych wejściowych
            float apXd, apXg, aph, apEps;
            // Pobranie danych wejściowych z formularza Xd, Xg, h, Eps
            if (!apPobranieDanych_Xd_Xg_h_Eps(out apXd, out apXg, out aph, out apEps))
            { // był błąd
                errorProvider1.SetError(btnWizualizacjaGraficzna, "ERROR: przy pobieraniu danych wejściowych wykryto błąd i dlatego ta funkcjonalność nie może być zrealizowana");
                // przerwanie obłsugi zdarzenia Click: btnWizualizacjaTabelaryczna_Click
                return;
            }
            // sprawdzenie czy egzemplarz tablicy TWS został już utworzony i szereg został stablicowany
            if (apTWS is null)
            {
                // egzempalrz tablicy TWS nie został jeszcze utworzony i szereg nie został stablicowany
                // utworzenie egzemplarza i stablicowanie szeregu
                apTablicowanieWartosciSzeregu(apXd, apXg, aph, apEps, out apTWS);
            }
            // Wpisanie wyników tablicowania do kontrolki Chart
            apWpisanieWynikowDoKontrolkiChart(apTWS, chtWykresSzeregu);
            // ukrycie i odsłonięcie kontrolek dla potrzeb obsłuigiwanego przycisku poleceń
            dgvTWS.Visible = false;
            chtWykresSzeregu.Visible = true;
            btnWizualizacjaGraficzna.Enabled = false;
        }

        private void zapisanieTablicyTWSWPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // zgaszenie kontrolki errorProvider, która mogła być zapalona
            errorProvider1.Dispose();
            // sprawdzenie, czy został już utworzony egzemplarz tablicy TWS
            if (apTWS is null)
            {// egzemplarz tablicy TWS nie został jeszcze utworzony, a to oznacza, że tutaj należy go utworzyć
                // pobranie danych z formularza 
                // deklaracje zmiennych dla przechowania danych wejściowych
                float apXd, apXg, aph, apEps;
                // wywołanie metody dla pobrania danych wejściowych
                if (!apPobranieDanych_Xd_Xg_h_Eps(out apXd, out apXg, out aph, out apEps))
                {// dodatkowe powiadomienie Użytkownika o wykrytym błędzie
                    MessageBox.Show("UWAGA: podczas pobierania danych wejściowych z formularza wystąpił niedozwolony znak! Popraw zapis ten danej i ponownie wybierz aktualnie obsługiwane polecenie z menu Plik");
                    // przerwanie dalszej obsługi polecenia wybranego z menu Plik
                    return;
                }
                // tutaj dane zostały już pobrane i możemy stablicować szereg
                apTablicowanieWartosciSzeregu(apXd, apXg, aph, apEps, out apTWS);
            }
            // tutaj jest egzemplarz TWS i szereg jest stablicowany, czyli możemy go zapisać do pliku
            // utworzenie okna dialogowego dla wyboru pliku do zapisu
            SaveFileDialog apOknoWyboruPlikuDoZapisu = new SaveFileDialog();
            // ustawienie filtru dla wyświetlanych plików
            apOknoWyboruPlikuDoZapisu.Filter = "txtfile (*.txt)|*.txt|All files(*.*)|*.*";
            // ustawienie filtru domyślnego
            apOknoWyboruPlikuDoZapisu.FilterIndex = 1;
            // przywrócenie folderu sprzed wyboru pliku do zapisu
            apOknoWyboruPlikuDoZapisu.RestoreDirectory = true;
            // ustawienie dysku domyślnego (który będzie "otwarty" w oknie OknoWyboruPlikuDoZapisu)
            apOknoWyboruPlikuDoZapisu.InitialDirectory = "C:\\";
            // ustalenie tytyły okna dialogowego do wyboru pliku do zpaisu
            apOknoWyboruPlikuDoZapisu.Title = "Wybór pliku do zapisu tablicy TWS (Tablica Wartośći Szeregu)";
            // wyświetlenie OknoWyboruPlikuDoZapisu i "odczytanie" dokonanego wyboru przez użytkownika
            if (apOknoWyboruPlikuDoZapisu.ShowDialog() == DialogResult.OK)
            {// zapisanie tablicy TWS w pliku
                System.IO.StreamWriter apPlikZnakowy = new System.IO.StreamWriter(apOknoWyboruPlikuDoZapisu.FileName);
                // wpisanie wierszy danych z tablicy TWS
                try
                {
                    for (int api = 0; api < apTWS.GetLength(0); api++)
                    {
                        apPlikZnakowy.Write(apTWS[api, 0].ToString()); // zapisanie wartości X
                        apPlikZnakowy.Write(";"); // znak ";" oddziela liczby od siebie
                        apPlikZnakowy.Write(apTWS[api, 1].ToString()); // zapisanie wartości S(X)
                        apPlikZnakowy.Write(";"); // znak ";" oddziela liczby od siebie
                        apPlikZnakowy.WriteLine(apTWS[api, 2].ToString()); // licznik zsumowanych wyrazów
                    }
                }
                catch (Exception ex)
                {
                    // wyświetlenie komunikatu
                    MessageBox.Show("UWAGA: podczas zapisu wierszy tablicy TWS wystąpił błąd: " + ex.Message + ", co oznacza, że tablica TWS nie została zapisana do pliku");
                }
                finally
                {
                    apPlikZnakowy.Close();
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
            if (!(apTWS is null))
            {// poinformowanie Użytkownika, że egzemplarz tablicy już jest utworzony i czy ma być skasowany dla elementów tablicy TWS z pliku ma być kontynuowane
                DialogResult apOknoMessage = MessageBox.Show("UWAGA: egzemplarz tablicy TWS już istnieje! \r\nCzy bieżący egzemplarz tablicy TWS ma być skasowany i w jego miejsce ma być utworzony nowy egzemplarz," +
                    " do którego mają zostać 'wczytane' elementy TWS z pliku? \r\n - kliknij przycisk poleceń 'Tak' dla potwierdzenia wczytania elementów tablicy TWS z pliku \r\n - kliknij przycisk poleceń 'Nie' " +
                    "dla skasowania polecenia wczytania elementów tablicy TWS z pliku ", "Okno ostrzeżenia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                // rozpoznanie wybranego przycisku poleceń w oknie dialogowym 'MessageBox'

                if (apOknoMessage == DialogResult.Yes)
                    // skasowanie obecnego egzemplarza tablicy TWS
                    apTWS = null;
                else
                { // czyli: if (OknoMessage == DialogResult. No)
                    MessageBox.Show("Polecenie odczytania (pobrania) elementów tablicy TWS z pliku zostało anulowane(skasowane!)");
                    // przerwanie obsługi polecenia odczytania (pobrania) elementów tablicy TWS z pliku
                    return;
                }
            }
            // utworzenie egzemplarza okna dialogowego dla wyboru (lub utworzenia) pliku do odczytu
            OpenFileDialog apOknowyboruPlikuDoOdczytu = new OpenFileDialog();
            // ustawienie filtru dla wyboru plików do wyświetlenia w oknie dialogowym
            apOknowyboruPlikuDoOdczytu.Filter = "txtfiles (*.txt) |*.txt | All files (*.*)|*.*";
            // ustawienie filtru domyślnego
            apOknowyboruPlikuDoOdczytu.FilterIndex = 1; // czyli filtru:*.text
            // przywrócenie bieżącego folderu po zamknięciu okna dialogowego wyboru pliku
            apOknowyboruPlikuDoOdczytu.RestoreDirectory = true;
            // ustawienie domyślnego dysku do zapisu
            apOknowyboruPlikuDoOdczytu.InitialDirectory = "C:\\";
            // ustalenie tytułu okna dialogowego wyboru pliku
            apOknowyboruPlikuDoOdczytu.Title = "Wybór pliku do odczytu TWS (Tabeli Wartości Szeregu)";
            // wyświetlenie okna dialogowego i sprawdzenie, czy Użytkownik wybrał plik do odczytu
            if (apOknowyboruPlikuDoOdczytu.ShowDialog() == DialogResult.OK)
            {
                // wczytanie wierszy pliku i ich wpisanie do tablicy TWS zrealizujemy w kilku "krokach", które ponumerujemy!
                // deklaracje pomocnicze
                string apWierszDanych; // dla przechowania wiersza danych (łańcucha znaków) wczytanych z pliku znakowego
                string[] apDaneWiersza; // dla podzielenia wiersza danych na pojedyncze dane (liczby), które są zapisane w tym wczytanym wierszu danych
                ushort apLicznikWierszy; // licznik wierszy pliku znakowego (zawierającego zapisane wiersze tablicy TWS) */
                // Krok 1: utworzenie i otwarcie egzemplarza pliku znakowego jako strumienia znaków, co umożliwi wykonywanie na nim operacji "podobnych" do operacji wykonywanych na oknie konsoli Console
                System.IO.StreamReader apPlikZnakowy = new System.IO.StreamReader(apOknowyboruPlikuDoOdczytu.FileName);
                // przy tworzeniu egzemplarza (będą w nim zapisane dane opisujące atrybuty otwieranego pliku znakowego) klasy StreamReader, musimy podać nazwę wybranego już wcześniej pliku do odczytu
                // Krok 2: policzenie liczby wierszy w pliku: PlikZnakowy, zliczając wczytywane wiersze pliku aż do napotkania znacznika końca pliku: null
                apLicznikWierszy = 0;
                while (!((apWierszDanych = apPlikZnakowy.ReadLine()) is null))
                    apLicznikWierszy++;
                // Krok 3: zamknięcie pliku (ale go nie zwalniamy, gdyż będziemy "zaraz" wczytywali wiersze tablicy TWS */
                apPlikZnakowy.Close();
                // Krok 4: utworzenie egzemplarza tablicy TWS (wiemy już ile musi mieć wierszy!!!)
                apTWS = new float[apLicznikWierszy, 3];
                // Krok 5: powtórne otwarcie pliku znakowego do odczytu
                apPlikZnakowy = new System.IO.StreamReader(apOknowyboruPlikuDoOdczytu.FileName);
                // Krok 6: odczytywanie pliku znakowego: "wiersz po wierszu"

                try
                { // ustalenie warunków brzegowych
                    int apNrWiersza = 0;
                    // wczytywanie kolejnych wierszy pliku znakowego, aż do napotkania znacznika końca pliku: null
                    while (!((apWierszDanych = apPlikZnakowy.ReadLine()) is null))
                    {
                        // wczytanie wiersza pliku znakowego i jego podział na "części", które są rozdzielone separatorem (znakiem) ';'
                        apDaneWiersza = apWierszDanych.Split(';');
                        // usunięcie 'spacji' z poszczególnych "części" wczytanego wiersza danych
                        apDaneWiersza[0].Trim(); apDaneWiersza[1].Trim();
                        apDaneWiersza[2].Trim();
                        // wpisanie danych ("części" zapisanych znakowo) do tablicy TWS, co wymaga ich konwersji na wartość typu 'float'
                        apTWS[apNrWiersza, 0] = float.Parse(apDaneWiersza[0]);
                        apTWS[apNrWiersza, 1] = float.Parse(apDaneWiersza[1]);
                        apTWS[apNrWiersza, 2] = float.Parse(apDaneWiersza[2]);
                        apNrWiersza++;
                    }
                    /* 7) przepisanie danych z tablicy TWS do kontrolki DataGridView umieszczonej na formularzu, co umożliwi nam wcześniej zaprojektowana
                    (przy obsłudze rzycisku poleceń: 'Wizualaizacja tabelaryczna zmian wartości szeregu metoda: WpisanieWynikówDoKontrolkiDataGridView */
                    apWpisanieWynikowDoKontrolkiDataGridView(apTWS, dgvTWS);
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
                    apPlikZnakowy.Close();
                    apPlikZnakowy.Dispose();
                }
            }
            else
                MessageBox.Show("Plik do odczytu tablicy TWS nie został wybrany i obsługa polecenia: 'Odczytanie stablicowanego szeregu z pliku' (z menu poziomego Plik) nie może być zrealizowana");
        }

        private void zmianaKoloruTłaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // otworzenie okna dialogowego z paletą kolorów
            ColorDialog apPaletaKolorow = new ColorDialog();
            // zaznaczenie w PalecieKolorow bieżącego koloru formularza
            apPaletaKolorow.Color = this.BackColor;
            // wyświetlenie palety kolorów i "odczytanie" wybranego koloru przez Użytkownika
            if (apPaletaKolorow.ShowDialog() == DialogResult.OK)
                // dokonujemy zmiany koloru tła formularza
                this.BackColor = apPaletaKolorow.Color;
            // zwolnienie egzemplarza apPaletyKolorow
            apPaletaKolorow.Dispose();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void zmianaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // utworzenie okna dialogowego dla zmiany czcionki
            FontDialog apOknoCzcionki = new FontDialog();
            // zaznaczenie w oknie OknoCzcionki bieżącego fontu
            apOknoCzcionki.Font = this.Font;
            // wyświetlenie okna dialogowego OknoCzcionki i "odczytanie" nowych ustawień dla fontów
            if (apOknoCzcionki.ShowDialog() == DialogResult.OK)
                // ustawienie nowego fontu da formularza
                this.Font = apOknoCzcionki.Font;
            // zwolnienie przydzielonego zasobu pamięci dla apOknoCzcionki
            apOknoCzcionki.Dispose();
        }
        private void zmianaKoloruCzcionkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // otworzenie okna dialogowego z paletą kolorów
            ColorDialog apPaletaKolorow = new ColorDialog();
            // zaznaczenie w PalecieKolorow bieżącego koloru tła wykresu
            apPaletaKolorow.Color = this.ForeColor;
            // wyświetlenie palety kolorów i "odczytanie" wybranego koloru przez Użytkownika
            if (apPaletaKolorow.ShowDialog() == DialogResult.OK)
                // dokonujemy zmiany koloru czcionki
                this.ForeColor = apPaletaKolorow.Color;
            // zwolnienie egzemplarza apPaletyKolorow
            apPaletaKolorow.Dispose();
        }
        private void exitZamknięcieFormularzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // wyświetlenie okna dialogowego z pytaniem: "Czy rzeczywiście ..." z ikoną pytajnika i trzema przyciskami: Yes, No, Cancel
            DialogResult apPytanieDoUzytkownika = MessageBox.Show("Czy na pewno chcesz zamknąć formularz (co może skutkować utratą danych zapisanych na formularzu)?", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            // rozpoznanie odpowiedzi użytkownika aplikacji i wykonanie stosownego działania; formularz możę być zamknięty gdy użytkownik wybrał (kliknął) przycisk poleceń Tak
            if (apPytanieDoUzytkownika == DialogResult.Yes)
                // formularz musi być zamknięty
                Close();
        }
        #region zmiana grubości linii wykresu
        
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            chtWykresSzeregu.Series[0].BorderWidth = 1;
        }
        
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            chtWykresSzeregu.Series[0].BorderWidth = 2;
        }
        
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            chtWykresSzeregu.Series[0].BorderWidth = 3;
        }
        
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            chtWykresSzeregu.Series[0].BorderWidth = 4;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            chtWykresSzeregu.Series[0].BorderWidth = 5;
        }
        #endregion
        #region zmiana stylu linii wykresu
        private void liniaKreskowaDashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chtWykresSzeregu.Series[0].BorderDashStyle = ChartDashStyle.Dash;
        }
        
        private void liniaKreskowoKropkowaDashDotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chtWykresSzeregu.Series[0].BorderDashStyle = ChartDashStyle.DashDot;
        }
        
        private void liniaKreskowoKropkowaKropkowaDashDotDotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chtWykresSzeregu.Series[0].BorderDashStyle = ChartDashStyle.DashDot;
        }
        
        private void liniaKropkowaDotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chtWykresSzeregu.Series[0].BorderDashStyle = ChartDashStyle.DashDotDot;
        }
        #endregion
        #region zmiana typu wykresu
        private void ciągłaSolidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chtWykresSzeregu.Series[0].BorderDashStyle = ChartDashStyle.Solid;
        }
        
        private void wykresLiniowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chtWykresSzeregu.Series[0].ChartType = SeriesChartType.Line;
        }
        
        private void wykresPunktowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chtWykresSzeregu.Series[0].ChartType = SeriesChartType.Point;
        }
        
        private void wykresKolumnowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chtWykresSzeregu.Series[0].ChartType = SeriesChartType.Column;
        }

        private void wykresSłupkowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chtWykresSzeregu.Series[0].ChartType = SeriesChartType.Bar;
        }
        #endregion
        // zmiana koloru tła wykresu
        private void kolorTłaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // otworzenie okna dialogowego z paletą kolorów
            ColorDialog apPaletaKolorow = new ColorDialog();
            // zaznaczenie w PalecieKolorow bieżącego koloru tła wykresu
            apPaletaKolorow.Color = this.chtWykresSzeregu.BackColor;
            // wyświetlenie palety kolorów i "odczytanie" wybranego koloru przez Użytkownika
            if (apPaletaKolorow.ShowDialog() == DialogResult.OK)
                // dokonujemy zmiany koloru tła wykresu
                this.chtWykresSzeregu.BackColor = apPaletaKolorow.Color;
            // zwolnienie egzemplarza apPaletyKolorow
            apPaletaKolorow.Dispose();
        }
        // zmiana koloru linii wykresu
        private void kolorLiniiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // otworzenie okna dialogowego z paletą kolorów
            ColorDialog apPaletaKolorow = new ColorDialog();
            // zaznaczenie w PalecieKolorow bieżącego koloru tła wykresu
            apPaletaKolorow.Color = this.chtWykresSzeregu.Series[0].Color;
            // wyświetlenie palety kolorów i "odczytanie" wybranego koloru przez Użytkownika
            if (apPaletaKolorow.ShowDialog() == DialogResult.OK)
                // dokonujemy zmiany koloru tła wykresu
                this.chtWykresSzeregu.Series[0].Color = apPaletaKolorow.Color;
            // zwolnienie egzemplarza apPaletyKolorow
            apPaletaKolorow.Dispose();
        }
        // zmiana koloru tabeli
        private void zmianaCzcionkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // utworzenie okna dialogowego dla zmiany czcionki
            FontDialog apOknoCzcionki = new FontDialog();
            // zaznaczenie w oknie OknoCzcionki bieżącego fontu
            apOknoCzcionki.Font = this.dgvTWS.Font;
            // wyświetlenie okna dialogowego OknoCzcionki i "odczytanie" nowych ustawień dla fontów
            if (apOknoCzcionki.ShowDialog() == DialogResult.OK)
                // ustawienie nowego fontu dla danych z tabeli
                this.dgvTWS.Font = apOknoCzcionki.Font;
            // zwolnienie przydzielonego zasobu pamięci dla apOknoCzcionki
            apOknoCzcionki.Dispose();
        }
        // zmiana koloru czcionki tabeli
        private void zmianaKoloruCzcionkiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // otworzenie okna dialogowego z paletą kolorów
            ColorDialog apPaletaKolorow = new ColorDialog();
            // zaznaczenie w PalecieKolorow bieżącego koloru tła wykresu
            apPaletaKolorow.Color = this.dgvTWS.ForeColor;
            // wyświetlenie palety kolorów i "odczytanie" wybranego koloru przez Użytkownika
            if (apPaletaKolorow.ShowDialog() == DialogResult.OK)
                // dokonujemy zmiany koloru czcionki dantcg z tabeli
                this.dgvTWS.ForeColor = apPaletaKolorow.Color;
            // zwolnienie egzemplarza apPaletyKolorow
            apPaletaKolorow.Dispose();
        }
        // zmiana koloru obramowania tabeli
        private void zmianaKoloruObramowaniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // otworzenie okna dialogowego z paletą kolorów
            ColorDialog apPaletaKolorow = new ColorDialog();
            // zaznaczenie w PalecieKolorow bieżącego koloru tła wykresu
            apPaletaKolorow.Color = this.dgvTWS.GridColor;
            // wyświetlenie palety kolorów i "odczytanie" wybranego koloru przez Użytkownika
            if (apPaletaKolorow.ShowDialog() == DialogResult.OK)
                // dokonujemy zmiany koloru obramowania tabeli
                this.dgvTWS.GridColor = apPaletaKolorow.Color;
            // zwolnienie egzemplarza apPaletyKolorow
            apPaletaKolorow.Dispose();
        }
        #region zmiana grubości liniii obramowania wykresu
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            chtWykresSzeregu.BorderlineWidth = 1;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            chtWykresSzeregu.BorderlineWidth = 2;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            chtWykresSzeregu.BorderlineWidth = 3;
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            chtWykresSzeregu.BorderlineWidth = 4;
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            chtWykresSzeregu.BorderlineWidth = 5;
        }
        #endregion
        #region zmiana wzoru obramowania wykresu
        private void kreskoweToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chtWykresSzeregu.BorderlineDashStyle = ChartDashStyle.Dash;
        }

        private void kreskowoKropkowyDashDotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chtWykresSzeregu.BorderlineDashStyle = ChartDashStyle.DashDot;
        }

        private void kreskowoKropkowoKropkowyDashDotDotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chtWykresSzeregu.BorderlineDashStyle = ChartDashStyle.DashDotDot;
        }

        private void kropkowyDotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chtWykresSzeregu.BorderlineDashStyle = ChartDashStyle.Dot;
        }

        private void ciągłySolidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chtWykresSzeregu.BorderlineDashStyle = ChartDashStyle.Solid;
        }
        #endregion
        // zmiana koloru obramowania wykresu
        private void kolorObramowaniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // otworzenie okna dialogowego z paletą kolorów
            ColorDialog apPaletaKolorow = new ColorDialog();
            // zaznaczenie w PalecieKolorow bieżącego koloru tła wykresu
            apPaletaKolorow.Color = this.chtWykresSzeregu.BorderlineColor;
            // wyświetlenie palety kolorów i "odczytanie" wybranego koloru przez Użytkownika
            if (apPaletaKolorow.ShowDialog() == DialogResult.OK)
                // dokonujemy zmiany koloru obramowania tabeli
                this.chtWykresSzeregu.BorderlineColor = apPaletaKolorow.Color;
            // zwolnienie egzemplarza apPaletyKolorow
            apPaletaKolorow.Dispose();
        }
    }
}
