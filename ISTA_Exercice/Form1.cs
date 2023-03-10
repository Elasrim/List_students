using Microsoft.VisualBasic.Devices;
using System;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Xml.Linq;

namespace ISTA_Exercice
{
    public partial class Form1 : Form
    {
        static int compteur = 1;
        public Form1()
        {
            InitializeComponent();
            cbFiliere.Items.AddRange(new String[] { "TSDI", "TSRI", "TSB" });
            cbFiliere.SelectedIndex = 0;



            List<etudiant> people = new List<etudiant>
                {
                    new etudiant { Nom = "Elasri",Prenom = "Mohammed", Age = 30, Filiere = "TSDI" },
                    new etudiant { Nom = "elmeraki",Prenom = "ayoub", Age = 25, Filiere = "TSRI" },
                    new etudiant { Nom = "boujalaba",Prenom = "yassine", Age = 40, Filiere = "TSB" },
                    new etudiant { Nom = "khalile",Prenom = "issa", Age = 21, Filiere = "TSB" },
                    new etudiant { Nom = "elyoussfi",Prenom = "walid", Age = 27, Filiere = "TSDI" },
                    new etudiant { Nom = "nafili",Prenom = "nourdin", Age = 19, Filiere = "TSB" },
                    new etudiant { Nom = "nafili",Prenom = "Mohammed", Age = 56, Filiere = "TSRI" }
                };



            // Loop through the list of objects and add them as ListView items
            foreach (etudiant person in people)
            {

                ListViewItem item = new ListViewItem(compteur.ToString());
                item.SubItems.Add(person.Nom.ToString());
                item.SubItems.Add(person.Prenom.ToString());
                item.SubItems.Add(person.Age.ToString());
                item.SubItems.Add(person.Filiere.ToString());
                Lv.Items.Add(item);
                compteur++;
            }

            TbNumero.Text = compteur.ToString();
        }

        public class etudiant
        {
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public int Age { get; set; }
            public string Filiere { get; set; }
        }
        private void btAjouter_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() != "" && tbPrenom.Text.Trim() != "" && tbAge.Text.Trim() != "" && cbFiliere.Text != "")
            {

                ListViewItem L = new ListViewItem(TbNumero.Text);
                L.SubItems.Add(tbName.Text);
                L.SubItems.Add(tbPrenom.Text);
                L.SubItems.Add(tbAge.Text);
                L.SubItems.Add(cbFiliere.Text);
                tbName.Focus();
                Lv.Items.Add(L);
                compteur++;
                TbNumero.Text = compteur.ToString();
                Clear();
                ArrierePlant();
            }

        }



        private void btSupprimer_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Lv.SelectedItems.Count; i++)
            {
                Lv.Items.Remove(Lv.SelectedItems[i]);
            }
            ArrierePlant();
        }

        int IndiceModifier = -1;
        private void btModifier_Click(object sender, EventArgs e)
        {
            
            if (IndiceModifier == -1)
            {
                
                if (Lv.SelectedIndices.Count == 1)
                {
                    int SelectedIndices = Lv.SelectedIndices[0]; 
                    IndiceModifier = SelectedIndices;

                    TbNumero.Text = Lv.Items[SelectedIndices].SubItems[0].Text;
                    tbName.Text = Lv.Items[SelectedIndices].SubItems[1].Text;
                    tbPrenom.Text = Lv.Items[SelectedIndices].SubItems[2].Text;
                    tbAge.Text = Lv.Items[SelectedIndices].SubItems[3].Text;
                    cbFiliere.SelectedItem = Lv.Items[SelectedIndices].SubItems[4].Text;

                    btAjouter.Enabled = false;
                    btRechercher.Enabled = false;
                    btSupprimer.Enabled = false;
                    btModifier.Text = "Valider";
                }

                else
                    MessageBox.Show("Selectionnez une ligne");

            }

            else
            {
                if (tbName.Text.Trim() != "" && tbPrenom.Text.Trim() != "" && tbAge.Text.Trim() != "" && cbFiliere.Text != "")
                {
                    Lv.Items[IndiceModifier].SubItems[0].Text = TbNumero.Text;
                    Lv.Items[IndiceModifier].SubItems[1].Text = tbName.Text;
                    Lv.Items[IndiceModifier].SubItems[2].Text = tbPrenom.Text;
                    Lv.Items[IndiceModifier].SubItems[3].Text = tbAge.Text;
                    Lv.Items[IndiceModifier].SubItems[4].Text = cbFiliere.Text;
                    Clear();

                    btAjouter.Enabled = true;
                    btRechercher.Enabled = true;
                    btSupprimer.Enabled = true;
                    btModifier.Text = "Modifier";


                    TbNumero.Text = compteur.ToString();
                    IndiceModifier = -1;
                    
                }
            }

            ArrierePlant();


        }



        private void btRechercher_Click(object sender, EventArgs e)
        {

            ArrierePlant();
            bool checkColor = false;
            if (tbRechercher.Text.Trim() != "")
            {
                foreach (ListViewItem i in Lv.Items)
                {
                    if (i.Text.Trim().ToLower() == tbRechercher.Text.Trim().ToLower() ||
                        i.SubItems[1].Text.Trim().ToLower() == tbRechercher.Text.Trim().ToLower() ||
                        i.SubItems[2].Text.Trim().ToLower() == tbRechercher.Text.Trim().ToLower() ||
                        i.SubItems[3].Text.Trim().ToLower() == tbRechercher.Text.Trim().ToLower() ||
                        i.SubItems[4].Text.Trim().ToLower() == tbRechercher.Text.Trim().ToLower())
                    {
                        i.BackColor = Color.Green;
                    }
                    
                }
                
            }

            foreach (ListViewItem i in Lv.Items)
            {
                if (i.BackColor == Color.Green) { checkColor = true; }
            }

            if (checkColor == false) { MessageBox.Show(tbRechercher.Text.ToString() + " n'a pas trouvé"); }

            Clear();
        }



        private void Clear()
        {
            tbName.Text = tbPrenom.Text = tbAge.Text = tbRechercher.Text = "";
        }
        private void ArrierePlant()
        {
            foreach (ListViewItem i in Lv.Items)
            {
                i.BackColor = Color.White;
            }
        }
    }
}
