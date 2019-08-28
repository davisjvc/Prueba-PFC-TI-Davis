using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Servicios.Models;

namespace Servicios.DataAccess
{
    public class ClienteDataAccess
    {
        public List<Cliente> ConsultarClientes()
        {
            List<Cliente> lstCientes = new List<Cliente>();

            using (SqlConnection connection = DataBase.GetSqlConnection())
            {
                string sqlQuery = "";
                sqlQuery = sqlQuery + "SELECT [ClienteId] " + "\n";
                sqlQuery = sqlQuery + "      ,[Nombre] " + "\n";
                sqlQuery = sqlQuery + "      ,[Telefono] " + "\n";
                sqlQuery = sqlQuery + "      ,[Direccion] " + "\n";
                sqlQuery = sqlQuery + "      ,[FechaNac] " + "\n";
                sqlQuery = sqlQuery + "      ,[Email] " + "\n";
                sqlQuery = sqlQuery + "  FROM [dbo].[Cliente] ";

                try
                {
                    SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Cliente cliente = new Cliente();

                        cliente.ClienteId = Convert.ToInt32(rdr["ClienteId"]);
                        cliente.Nombre = rdr["Nombre"].ToString();
                        cliente.Telefono = rdr["Telefono"].ToString();
                        cliente.Direccion = rdr["Direccion"].ToString();
                        cliente.FechaNac = Convert.ToDateTime(rdr["FechaNac"].ToString());
                        cliente.Email = rdr["Email"].ToString();

                        lstCientes.Add(cliente);
                    }
                }
                catch(Exception ex)
                {
                    connection.Close();
                    throw ex;                    
                }
                
            }
            return lstCientes;
        }


        public Cliente ConsultarCliente(int clienteId)
        {
            Cliente cliente = new Cliente();

            using (var connection = DataBase.GetSqlConnection())
            {
                var dataTable = new DataTable();

                String sqlQuery = "";
                sqlQuery = sqlQuery + "SELECT [ClienteId] " + "\n";
                sqlQuery = sqlQuery + "      ,[Nombre] " + "\n";
                sqlQuery = sqlQuery + "      ,[Telefono] " + "\n";
                sqlQuery = sqlQuery + "      ,[Direccion] " + "\n";
                sqlQuery = sqlQuery + "      ,[FechaNac] " + "\n";
                sqlQuery = sqlQuery + "      ,[Email] " + "\n";
                sqlQuery = sqlQuery + "  FROM [dbo].[Cliente] " + "\n";
                sqlQuery = sqlQuery + "  WHERE ClienteId = @clienteId";

                try
                {
                    SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                    cmd.Parameters.AddWithValue("clienteId", clienteId);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        cliente.ClienteId = Convert.ToInt32(rdr["ClienteId"]);
                        cliente.Nombre = rdr["Nombre"].ToString();
                        cliente.Telefono = rdr["Telefono"].ToString();
                        cliente.Direccion = rdr["Direccion"].ToString();
                        cliente.FechaNac = Convert.ToDateTime(rdr["FechaNac"].ToString());
                        cliente.Email = rdr["Email"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw ex;
                }

                return cliente;                
            }
        }


        public int ActualizarCliente(Cliente cliente)
        {
            int counter = 0;
            using (SqlConnection connection = DataBase.GetSqlConnection())
            {
                String storeProc = "procActualizarCliente";                

                using (SqlCommand command = new SqlCommand(storeProc, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("ClienteId", cliente.ClienteId);
                    command.Parameters.AddWithValue("Nombre", cliente.Nombre);
                    command.Parameters.AddWithValue("Telefono", cliente.Telefono);
                    command.Parameters.AddWithValue("Direccion", (cliente.Direccion ?? String.Empty));
                    command.Parameters.AddWithValue("FechaNac", cliente.FechaNac);
                    command.Parameters.AddWithValue("Email", (cliente.Email ?? String.Empty));

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.UpdateCommand = command;
                        counter = adapter.UpdateCommand.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        connection.Close();
                        throw;
                    }

                    return counter;
                }
            }
        }
        
    }
}