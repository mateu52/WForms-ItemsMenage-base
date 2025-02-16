using ItemsMenage.Models;
namespace ItemsMenage;
using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;


    public class Database
    {
        private static string dbFile = "items.db";
        private static string connectionString = $"Data Source={dbFile};Version=3;";

        // 🔹 Inicjalizacja bazy danych - tworzy plik i tabelę, jeśli nie istnieją
        public static void InitializeDatabase()
        {
            if (!File.Exists(dbFile))
            {
                SQLiteConnection.CreateFile(dbFile);
            }

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Items (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Tytul TEXT NOT NULL,
                        Autor TEXT,
                        Typ TEXT,
                        Rok INTEGER
                    );";

                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        // 🔹 Dodawanie nowego elementu
        public static void DodajItem(Item item)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Items (Tytul, Autor, Typ, Rok) VALUES (@Tytul, @Autor, @Typ, @Rok)";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Tytul", item.Tytul);
                    command.Parameters.AddWithValue("@Autor", item.Autor);
                    command.Parameters.AddWithValue("@Typ", item.Typ);
                    command.Parameters.AddWithValue("@Rok", item.Rok);
                    int rowsAffected = command.ExecuteNonQuery();
                MessageBox.Show($"DOdano {rowsAffected} rekordów");
            }
            }
        }

        // 🔹 Pobieranie wszystkich elementów
        public static List<Item> PobierzWszystkie()
        {
            List<Item> listaItemow = new List<Item>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Items";

                using (var command = new SQLiteCommand(selectQuery, connection))
                using (var reader = command.ExecuteReader())
                {
                while (reader.Read())
                {
                    var item = new Item
                    {
                        Id = reader.GetInt32(0),
                        Tytul = reader.GetString(1),
                        Autor = reader.IsDBNull(2) ? "Nieznany" : reader.GetString(2),
                        Typ = reader.IsDBNull(3) ? "Nieznany" : reader.GetString(3),
                        Rok = reader.GetInt32(4)
                    };

                    Console.WriteLine($"Pobrano: {item.Id}, {item.Tytul}, {item.Autor}, {item.Typ}, {item.Rok}"); // ✅ Logowanie
                    listaItemow.Add(item);
                }
            }
            }
            return listaItemow;
        }
    public static void UsunItem(int id)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string deleteQuery = "DELETE FROM Items WHERE Id = @Id";

            using (var command = new SQLiteCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }

}



public partial class Form1 : Form
{
    List<Item> listaItemow = new List<Item>();
    private BindingSource bindingSource = new BindingSource();
    private void WczytajDane()
    {
        listaItemow = Database.PobierzWszystkie();
        bindingSource.DataSource = listaItemow;
        bindingSource.ResetBindings(false);

        MessageBox.Show($"Lista po przypisaniu {((List<Item>)bindingSource.DataSource).Count}");
    }

    public Form1()
    {
        InitializeComponent();
        //dataGridView1.DataSource = new BindingSource { DataSource = listaItemow };
        //bindingSource.DataSource = listaItemow;
        //dataGridView1.DataSource = bindingSource;
        Database.InitializeDatabase();
        bindingSource = new BindingSource();
        dataGridView1.DataSource = bindingSource;
        WczytajDane();
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
            MessageBox.Show("Rok musi być liczbą");
            return;
        }

        Item nowyItem = new Item(tytul, autor, typ, rok);
        Database.DodajItem(nowyItem);
        WczytajDane();

        //bindingSource.DataSource = Database.PobierzWszystkie();
        //bindingSource.ResetBindings(false);
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        // Jeśli lista jest pusta lub indeks jest -1, zakończ metodę
        if (e.RowIndex < 0 || e.RowIndex >= listaItemow.Count)
        {
            return;
        }

        // Pobranie zaznaczonego elementu
        Item zaznaczonyItem = (Item)bindingSource[e.RowIndex];

        // Aktualizacja pól tekstowych
        txtTytul.Text = zaznaczonyItem.Tytul;
        txtAutor.Text = zaznaczonyItem.Autor;
        cmbTyp.SelectedItem = zaznaczonyItem.Typ;
        txtRok.Text = zaznaczonyItem.Rok.ToString();
    }

    private void btnUsun_Click(object sender, EventArgs e)
    {
        if (dataGridView1.SelectedRows.Count > 0)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                Item item = (Item)bindingSource[row.Index];
                Database.UsunItem(item.Id);
            }

            WczytajDane(); // ← Aktualizacja tabeli po usunięciu
        }
        else
        {
            MessageBox.Show("Najpierw wybierz wiersz do usunięcia!");
        }
    }

    private void btnSzukaj_Click(object sender, EventArgs e)
    {
        string szukanyTekst = txtSzukaj.Text.ToLower().Trim(); // Upewnij się, że szukany tekst nie zawiera zbędnych spacji

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
            MessageBox.Show("Nie znaleziono wyników dla: " + szukanyTekst);
            nowaLista = new List<Item>(listaItemow); // Przywrócenie oryginalnej listy
        }

        bindingSource.DataSource = nowaLista;
        bindingSource.ResetBindings(false);
    }
}
