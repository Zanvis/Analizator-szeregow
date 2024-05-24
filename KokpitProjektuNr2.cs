using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektNr2_Piwowarski62024
{
    public partial class KokpitProjektuNr2 : Form
    {
        public KokpitProjektuNr2()
        {
            InitializeComponent();
        }

        private void btnSzeregLaboratoryjny_Click(object sender, EventArgs e)
        {
            // sprawdzenie, czy w kolekcji OpenForms jest już egzemplarz formularze SzeregLaboratoryjny
            foreach (Form Formularz in Application.OpenForms)

                // sprawdzenie czy zidentyfikowany formularz w kolekcji OpenForms jest egzemplarzem formularza SzeregLaboratoryjny
                if (Formularz.Name == "SzeregLaboratoryjny")
                {
                    // ukrycie bieżącego formularza, którego referencję udostępnia this
                    this.Hide();
                    // odsłonięcie formularza SzeregLaboratoryjny
                    Formularz.Show();
                    // zakończenie (wyjście z) obsługi zdazenia Click dla przycisku poleceń btnSzeregLaboratoryjny
                    return;
                }
            // gdy będziemy tutaj, to bęedzie to oznaczało, że formularz SzeregLaboratoryjny nie był jeszcze nigdy otworzony
            // tworzymy egzemplarz formularza SzeregLaboratoryjny
            SzeregLaboratoryjny AnaizatorSzeregu = new SzeregLaboratoryjny();
            // ukrycie bieżącego formularza, czyli formularza głównego
            this.Hide();
            // odsłonięcie nowego formularza
            AnaizatorSzeregu.Show();
        }

        private void btnSzeregIndywidualny_Click(object sender, EventArgs e)
        {
            // sprawdzenie, czy w kolekcji OpenForms jest już egzemplarz formularze SzeregLaboratoryjny
            foreach (Form Formularz in Application.OpenForms)

                // sprawdzenie czy zidentyfikowany formularz w kolekcji OpenForms jest egzemplarzem formularza SzeregLaboratoryjny
                if (Formularz.Name == "SzeregIndywidualny")
                {
                    // ukrycie bieżącego formularza, którego referencję udostępnia this
                    this.Hide();
                    // odsłonięcie formularza SzeregLaboratoryjny
                    Formularz.Show();
                    // zakończenie (wyjście z) obsługi zdazenia Click dla przycisku poleceń btnSzeregLaboratoryjny
                    return;
                }
            // gdy będziemy tutaj, to bęedzie to oznaczało, że formularz SzeregIndywidualny nie był jeszcze nigdy otworzony
            // tworzymy egzemplarz formularza SzeregLaboratoryjny
            SzeregIndywidualny AnaizatorSzeregu = new SzeregIndywidualny();
            // ukrycie bieżącego formularza, czyli formularza głównego
            this.Hide();
            // odsłonięcie nowego formularza
            AnaizatorSzeregu.Show();
        }

        private void KokpitProjektuNr2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // utworzenie okna dialogowego dla potwierdzenia zamknięcia formularza głównego
            DialogResult OknoMessage = MessageBox.Show("Czy na pewno chcesz zamknąć formularz główny i zakończyć działanie programu", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            // rozpoznanie wybranej odpowiedzi Użytkownika programu
            if (OknoMessage == DialogResult.Yes)
            {
                // potwierdzenie zamknięcia formularza
                e.Cancel = false;
                // zakończenie programu 
                Application.ExitThread();
            }
            e.Cancel = true;
        }
    }
}
