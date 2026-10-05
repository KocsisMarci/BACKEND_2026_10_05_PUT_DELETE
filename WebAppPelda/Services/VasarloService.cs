using WebAppPelda.Models;
using MySql.Data.MySqlClient;
namespace WebAppPelda.Services
{
    public class VasarloService
    {

        public string PostCustomer(Customer customer)
        {

            try
            {
                string connectionString = "SERVER = localhost;" +
                               "DATABASE= webapppeldadb;" +
                               "UID = root;" +
                               "PASSWORD =;";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();


                string sql = "INSERT INTO vasarlo(Nev, Cim, Email, Telefon, Pontszam) VALUES (@nev, @cim, @email, @telefon, @pontszam)";
                /*SELECT helyett INSEERT, @nev ez paraméter alapú adatátadas időközben teszünk be a helyére valódi adatot*/


                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@nev", customer.Nev);
                cmd.Parameters.AddWithValue("@cim", customer.Cim);
                cmd.Parameters.AddWithValue("@email", customer.Email);
                cmd.Parameters.AddWithValue("@telefon", customer.Telefon);
                cmd.Parameters.AddWithValue("@pontszam", customer.Pont);

                int sorokSzama = cmd.ExecuteNonQuery();
                //Itt adtuk át a paramétereket

                conn.Close();

                if (sorokSzama > 0)
                    return "Sikeres  beszúrás!";

                else return "Sikertelen  beszúrás!";

            }

            catch (Exception ex) {
                return "Hiba történt az adatok beszúrása során: " + ex.Message;
            }


        }

        

        public List<Customer> GetAllCustomer()
        {
          

                List<Customer> customers = new List<Customer>();
                string connectionString = "SERVER = localhost;" +
                               "DATABASE= webapppeldadb;" +
                               "UID = root;" +
                               "PASSWORD =;";

                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                string sql = "SELECT * FROM vasarlo";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.Id = reader.GetInt32("Id");
                    customer.Nev = reader.GetString("Nev");

                    customer.Cim = reader.GetString("Cim");
                    customer.Email = reader.GetString("Email");

                    customer.Telefon = reader.GetString("Telefon");
                    customer.Pont = reader.GetInt32("Pontszam");
                    customers.Add(customer);


                }
                conn.Close();


                return customers;
            }


        


        public Customer GetCustomerById(int id) {

            Customer result = new Customer();


            try
            {
                string connectionString = "SERVER = localhost;" +
                                   "DATABASE= webapppeldadb;" +
                                   "UID = root;" +
                                   "PASSWORD =;";

                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                string sql = "SELECT * FROM vasarlo Where Id=@id";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;

                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    result.Id = reader.GetInt32("Id");
                    result.Nev = reader.GetString("Nev");

                    result.Cim = reader.GetString("Cim");
                    result.Email = reader.GetString("Email");

                    result.Telefon = reader.GetString("Telefon");
                    result.Pont = reader.GetInt32("Pontszam");



                }

                else {
                    Console.WriteLine("Nincs ilyen vásárló!");
                }
                conn.Close();

                return result;
            }

            catch (Exception ex) {
                Console.WriteLine("Hiba történt az adatok frissítése során: " + ex.Message);
                return result;
            }

        }
        public string PutCustomer(Customer customer)
        {

            try
            {
                string connectionString = "SERVER = localhost;" +
                               "DATABASE= webapppeldadb;" +
                               "UID = root;" +
                               "PASSWORD =;";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();


                string sql = "UPDATE  vasarlo Set Nev=@nev, Cim=@cim, Email=@email, Telefon=@telefon, Pontszam=@pontszam WHERE Id=@id";
                /*SELECT helyett INSEERT, @nev ez paraméter alapú adatátadas időközben teszünk be a helyére valódi adatot*/


                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@nev", customer.Nev);
                cmd.Parameters.AddWithValue("@cim", customer.Cim);
                cmd.Parameters.AddWithValue("@email", customer.Email);
                cmd.Parameters.AddWithValue("@telefon", customer.Telefon);
                cmd.Parameters.AddWithValue("@pontszam", customer.Pont);
                cmd.Parameters.AddWithValue("@id", customer.Id);
                int sorokSzama = cmd.ExecuteNonQuery();
                //Itt adtuk át a paramétereket

                conn.Close();

                if (sorokSzama > 0)
                    return "Sikeres  frissítés!";

                else return "Ismeretlen vásároló!";

            }

            catch (Exception ex)
            {
                return "Hiba történt az adatok frissítése során: " + ex.Message;
            }





        }

        public string DeleteCustomer(Customer customer)
        {

            try
            {
                string connectionString = "SERVER = localhost;" +
                               "DATABASE= webapppeldadb;" +
                               "UID = root;" +
                               "PASSWORD =;";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();


                string sql = "DELETE FROM vasarlo WHERE Id=@id";
                /*SELECT helyett INSEERT, @nev ez paraméter alapú adatátadas időközben teszünk be a helyére valódi adatot*/


                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@id", customer.Id);
                

                int sorokSzama = cmd.ExecuteNonQuery();
                //Itt adtuk át a paramétereket

                conn.Close();

                if (sorokSzama > 0)
                    return "Sikeres  törlés!";

                else return "Sikertelen  törlés!";

            }

            catch (Exception ex)
            {
                return "Hiba történt az adatok beszúrása során: " + ex.Message;
            }






        }
    }
}
