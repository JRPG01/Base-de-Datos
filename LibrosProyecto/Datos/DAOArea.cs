using Modelos;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DAOArea
    {
        public List<Area> ObtenerTodos()
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"SELECT * FROM areas");
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Area> lista = new List<Area>();
                    Area objArea = null;

                    foreach (DataRow fila in resultado.Rows)
                    {
                        objArea = new Area();
                        objArea.id = Convert.ToInt32(fila["id"]);
                        objArea.Nombre = fila["Nombre"].ToString();
                        objArea.Ubicacion = fila["Ubicacion"].ToString();
                        lista.Add(objArea);
                    }

                    return lista;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo obtener la información de las areas");
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public Area ObtenerUno(int id)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(@"SELECT * FROM areas WHERE ID=@id");
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);

                    Area objArea = null;
                    if (resultado.Rows.Count > 0)
                    {
                        DataRow fila = resultado.Rows[0];
                        objArea = new Area();
                        objArea.id = Convert.ToInt32(fila["id"]);
                        objArea.Nombre = fila["Nombre"].ToString();
                        objArea.Ubicacion = fila["Ubicacion"].ToString();
                    }
                    return objArea;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo obtener la información de la area");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        public bool eliminar(int id)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"DELETE FROM areas
                        WHERE id=@id");

                    comando.Parameters.AddWithValue("@id", id);
                    comando.Connection = Conexion.conexion;
                    int filasBorradas = comando.ExecuteNonQuery();
                    return (filasBorradas > 0);
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                Conexion.desconectar();
            }
        }
        public bool editar(Area area)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"UPDATE areas SET 
                        Nombre= @nombre,
                        Ubicacion= @ubi
                        
                        WHERE (`id` = @id);");

                    comando.Parameters.AddWithValue("@nombre", area.Nombre);
                    comando.Parameters.AddWithValue("@ubi", area.Ubicacion);
                    comando.Parameters.AddWithValue("@id", area.id);


                    comando.Connection = Conexion.conexion;

                    int filasModifi = comando.ExecuteNonQuery();

                    return (filasModifi > 0);
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo obtener la información del libro a editar");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        public int agregar(Area area)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"INSERT INTO `areas` values
                        (null,@nombre,@ubi) 
                        ;SELECT last_insert_id();");

                    comando.Parameters.AddWithValue("@nombre", area.Nombre);
                    comando.Parameters.AddWithValue("@ubi", area.Ubicacion);
                    comando.Connection = Conexion.conexion;

                    int filasAgregadas = Convert.ToInt32(comando.ExecuteScalar());

                    return filasAgregadas;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo agregar, intentelo de nuevo o comuniquese con el administrador");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
    }
}
