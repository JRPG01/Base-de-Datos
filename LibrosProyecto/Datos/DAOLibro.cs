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
    public class DAOLibro
    {

        public List<inventario> ObtenerTodos()
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"SELECT * FROM inventario");
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<inventario> lista = new List<inventario>();
                    inventario objLibro = null;

                    foreach (DataRow fila in resultado.Rows)
                    {
                        objLibro = new inventario();
                        objLibro.id= Convert.ToInt32(fila["id"]);
                        objLibro.NombreCorto= fila["NombreCorto"].ToString();
                        objLibro.Descripcion= fila["Descripcion"].ToString();
                        objLibro.Serie= fila["Serie"].ToString();
                        objLibro.Color= fila["Color"].ToString();
                        objLibro.FechaAdquision= fila["FechaAdquision"].ToString();
                        objLibro.TipoAdquision= fila["TipoAdquision"].ToString();
                        objLibro.Observaciones= fila["Observaciones"].ToString();
                        objLibro.AREAS_id= Convert.ToInt32(fila["AREAS_id"]);

                        lista.Add(objLibro);
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
                throw new Exception("No se pudo obtener la información del inventario");
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public inventario ObtenerUno(int id)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(@"SELECT * FROM inventario WHERE ID=@id");
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);

                    inventario objLibro = null;
                    if (resultado.Rows.Count > 0)
                    {
                        DataRow fila = resultado.Rows[0];
                        objLibro = new inventario();
                        objLibro.id = Convert.ToInt32(fila["id"]);
                        objLibro.NombreCorto = fila["NombreCorto"].ToString();
                        objLibro.Descripcion = fila["Descripcion"].ToString();
                        objLibro.Serie = fila["Serie"].ToString();
                        objLibro.Color = fila["Color"].ToString();
                        objLibro.FechaAdquision = fila["FechaAdquision"].ToString();
                        objLibro.TipoAdquision = fila["TipoAdquision"].ToString();
                        objLibro.Observaciones = fila["Observaciones"].ToString();
                        objLibro.AREAS_id = Convert.ToInt32(fila["AREAS_id"]);
                    }

                    return objLibro;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo obtener la información del libro");
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
                        @"DELETE FROM inventario
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
                if (ex.Number == 1451)
                {
                    throw new Exception("No se puede eliminar el libro porque tiene otros procesos relacionados");
                }
                else
                {
                    throw new Exception("Error al intentar eliminar al usuario");
                }

            }
            finally
            {
                Conexion.desconectar();
            }
        }
        public bool editar(inventario libro)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"UPDATE inventario SET 
                        `NombreCorto` = @nombre, 
                        `Descripcion` = @desc, 
                        `Serie` = @serie, 
                        `Color` = @color, 
                        `FechaAdquision` = @fecha, 
                        `TipoAdquision` = @tipo,
                        `Observaciones` = @obs,
                        `AREAS_id` = @ArId
                        WHERE (`id` = @id);");

                    comando.Parameters.AddWithValue("@id", libro.id);
                    comando.Parameters.AddWithValue("@nombre", libro.NombreCorto);
                    comando.Parameters.AddWithValue("@desc", libro.Descripcion);
                    comando.Parameters.AddWithValue("@serie", libro.Serie);
                    comando.Parameters.AddWithValue("@color", libro.Color);
                    comando.Parameters.AddWithValue("@fecha", libro.FechaAdquision);
                    comando.Parameters.AddWithValue("@tipo", libro.TipoAdquision);
                    comando.Parameters.AddWithValue("@obs", libro.Observaciones);
                    comando.Parameters.AddWithValue("@ArId", libro.AREAS_id);
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
                throw new Exception("No se pudo obtener la información del libro a editar");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        public int agregar(inventario libro)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"INSERT INTO `inventario` 
                        (`id`, `NombreCorto`, `Descripcion`, `Serie`, `Color`, `FechaAdquision`, `TipoAdquision`, `Observaciones`, `AREAS_id`) 
                        VALUES 
                        (null, @nombre, @desc, @serie, @color, @fecha, @tipo,@obs , @ArId);SELECT last_insert_id();");

                    comando.Parameters.AddWithValue("@nombre", libro.NombreCorto);
                    comando.Parameters.AddWithValue("@desc", libro.Descripcion);
                    comando.Parameters.AddWithValue("@serie", libro.Serie);
                    comando.Parameters.AddWithValue("@color", libro.Color);
                    comando.Parameters.AddWithValue("@fecha", libro.FechaAdquision);
                    comando.Parameters.AddWithValue("@tipo", libro.TipoAdquision);
                    comando.Parameters.AddWithValue("@obs", libro.Observaciones);
                    comando.Parameters.AddWithValue("@ArId", libro.AREAS_id);
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
