using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LibrosWeb.Modelos
{
    
    public class Libro
    {
        public int Agregado { get; set; }
        public int id { get; set; }
        public string isbn { get; set; }
        public string titulo { get; set; }
        public int edicion { get; set; }
        public string anio_publicacion { get; set;}
        public string nombre_autores { get; set;}
        public string pais_publicacion { get; set;}
        public string sinopsis { get; set; }
        public string carrera { get; set;}
        public string materia { get; set;}

        public Libro(int id, string isbn, string titulo, int edicion, string anio_publicacion, string nombre_autores, string pais_publicacion, string sinopsis, string carrera, string materia)
        {
            this.id = id;
            this.isbn = isbn;
            this.titulo = titulo;
            this.edicion = edicion;
            this.anio_publicacion = anio_publicacion;
            this.nombre_autores = nombre_autores;
            this.pais_publicacion = pais_publicacion;
            this.sinopsis = sinopsis;
            this.carrera = carrera;
            this.materia = materia;
        }
        public Libro() { }

        public void Guardar(Libro lib)
        {
            // Establecer la cadena de conexión

            string connectionString = "Data Source=WIN-ODSO932OM24;Initial Catalog=librosweb;Persist Security Info=True;User ID=Admin;Password=SQL_Server@123;";

            // Crear una conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crear una consulta SQL de inserción
                    string query = "insert into libros (isbn,titulo,edicion,anio_publicacion,nombre_autores,pais_publicacion,sinopsis,carrera,materia) values" +
                        "(@isbn,@name,@edi,@anio,@autors,@paisp,@sinop,@carrera,@materia);";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Añadir parámetros a la consulta SQL
                    command.Parameters.AddWithValue("@isbn", lib.isbn);
                    command.Parameters.AddWithValue("@name", lib.titulo);
                    command.Parameters.AddWithValue("@edi", lib.edicion);
                    command.Parameters.AddWithValue("@anio", lib.anio_publicacion);
                    command.Parameters.AddWithValue("@autors", lib.nombre_autores);
                    command.Parameters.AddWithValue("@paisp", lib.pais_publicacion);
                    command.Parameters.AddWithValue("@sinop", lib.sinopsis);
                    command.Parameters.AddWithValue("@carrera", lib.carrera);
                    command.Parameters.AddWithValue("@materia", lib.materia);

                    // Ejecutar la consulta SQL
                    int rowsAffected = command.ExecuteNonQuery();

                    // Verificar si se ha insertado alguna fila
                    if (rowsAffected > 0)
                    {
                        Agregado = 1;
                    }
                    else
                    {
                        Agregado = -1;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}