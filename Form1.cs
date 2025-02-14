using ItemsMenage.Models;
namespace ItemsMenage
{
    public partial class Form1 : Form
    {
        List<Item> listaItemow = new List<Item>();
        private BindingSource bindingSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            //dataGridView1.DataSource = new BindingSource { DataSource = listaItemow };
            bindingSource.DataSource = listaItemow;
            dataGridView1.DataSource = bindingSource;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            string tytul = txtTytul.Text;
            string autor = txtAutor.Text;
            string typ = cmbTyp.SelectedItem?.ToString() ?? "Nieznany";
            int rok;

            if (!int.TryParse(txtRok.Text, out rok))
            {
                MessageBox.Show("Rok musi by� liczb�");
                return;
            }

            listaItemow.Add(new Item(tytul, autor, typ, rok));

            bindingSource.ResetBindings(false);
            //dataGridView1.DataSource = listaItemow;
            // Zabezpieczenie przed b��dem klikni�cia w pusty obszar tabeli
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true; // Zaznacz ostatnio dodany element
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Je�li lista jest pusta lub indeks jest -1, zako�cz metod�
            if (listaItemow.Count == 0 || e.RowIndex < 0 || e.RowIndex >= listaItemow.Count)
            {
                return;
            }

            // Pobranie zaznaczonego elementu
            Item zaznaczonyItem = listaItemow[e.RowIndex];

            // Aktualizacja p�l tekstowych
            txtTytul.Text = zaznaczonyItem.Tytul;
            txtAutor.Text = zaznaczonyItem.Autor;
            cmbTyp.SelectedItem = zaznaczonyItem.Typ;
            txtRok.Text = zaznaczonyItem.Rok.ToString();
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Tworzymy list� indeks�w, �eby unika� b��d�w podczas usuwania
                List<int> indexes = new List<int>();

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    indexes.Add(row.Index);
                }

                // Usuwamy elementy od ko�ca, �eby unikn�� problem�w z przesuwaj�cymi si� indeksami
                indexes.Sort();
                indexes.Reverse();

                foreach (int index in indexes)
                {
                    if (index >= 0 && index < listaItemow.Count)
                    {
                        listaItemow.RemoveAt(index);
                    }
                }
                bindingSource.ResetBindings(false);
                //dataGridView1.DataSource = null;
                //dataGridView1.DataSource = listaItemow;
            }
            else
            {
                MessageBox.Show("Najpierw wybierz wiersz do usuni�cia!");
            }
        }

        private void btnSzukaj_Click(object sender, EventArgs e)
        {
            string szukanyTekst = txtSzukaj.Text.ToLower().Trim(); // Upewnij si�, �e szukany tekst nie zawiera zb�dnych spacji

            List<Item> nowaLista = new List<Item>();

            foreach (Item item in listaItemow)
            {
                if (item.Tytul.ToLower().Contains(szukanyTekst))
                {
                    nowaLista.Add(item);
                }
            }

            // Sprawdzenie, czy znaleziono wyniki
            if (nowaLista.Count == 0)
            {
                MessageBox.Show("Nie znaleziono wynik�w dla: " + szukanyTekst);
                nowaLista = new List<Item>(listaItemow); // Przywr�cenie oryginalnej listy
            }

            bindingSource.DataSource = nowaLista;
            bindingSource.ResetBindings(false);
        }
    }
}
