using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Pacientes.Datos
{
    public class Enfermedades
    {
        public int ID {get; set;}
        public string Nombre { get; set;}
        private string ConnectionString = "Data Source=localhost; Initial Catalog=Proyecto; Integrated Security=true";


        public void Add(string nombre)
        {

            string query = "insert into Table_Enfermedades (nombre) values (@nombre)";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", nombre);
                

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Hay un error en la db" + ex.Message);
                }
            }

        }

        //Metodo para eliminar elementos
        public void Delete(int id)
        {

            string query = "delete from Table_Enfermedades" +
                " where id=@id";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Hay un error en la db" + ex.Message);
                }
            }

        }


        //Lista de datos
        public List<Enfermedades> GetEnfermedades()
        {
            List<Enfermedades> ListaEnfermedades = new List<Enfermedades>();
            string query = "select * from Table_Enfermedades";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    //este codigo lee los datos de la DB a la que nos conectamos
                    SqlDataReader reader = command.ExecuteReader();
                    //Este while lo que hace es leer todos los datos almacenados en la DB
                    while (reader.Read())
                    {
                        //Aca almacenamos los datos de la DB en la lista que vamos a mostrar
                        Enfermedades DEnfermedades = new Enfermedades();
                        DEnfermedades.ID = reader.GetInt32(0);
                        DEnfermedades.Nombre = reader.GetString(1);
                        
                        //Agregamos el objeto a la lista
                        ListaEnfermedades.Add(DEnfermedades);

                    }
                    reader.Close();
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Hay un error en la db" + ex.Message);
                }
            }
            return ListaEnfermedades;
        }



        public Enfermedades GetEnfermedad(int Id)
        {
            string query = "select id,nombre from Table_Enfermedades" +
                " where id=@Id";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);

                try
                {
                    connection.Open();
                    //este codigo lee los datos de la DB a la que nos conectamos
                    SqlDataReader reader = command.ExecuteReader();
                    //Este while lo que hace es leer todos los datos almacenados en la DB
                    reader.Read();
                    //PersonaDatos Dpersona = new PersonaDatos();
                    Enfermedades DEnfermedades = new Enfermedades();
                    DEnfermedades.ID = reader.GetInt32(0);
                    DEnfermedades.Nombre = reader.GetString(1);
                    reader.Close();
                    connection.Close();

                    return DEnfermedades ;

                }
                catch (SqlException ex)
                {
                    throw new Exception("Hay un error en la db" + ex.Message);
                }
            }
        }

    }
}
