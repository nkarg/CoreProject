using CoreDapper.Abstract;
using CoreDapper.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CoreDapper.Concrete
{
    public class JugadorManager : IJugadorManager
    {
        private readonly string _connectionString;
        private SqlConnection _sqlConnection { get { return new SqlConnection(_connectionString); } }

        public JugadorManager()
        {
            _connectionString = "Server=ARGDST0004;Database=DataFutsal;Trusted_Connection=True;";
        }

        public List<JugadorDapper> GetAll()
        {
            var result = new List<JugadorDapper>();
            var script = "SELECT * FROM [DataFutsal].[dbo].[Jugador]";

            try
            {
                using (SqlConnection sqlConnection = _sqlConnection)
                {
                    var query = SqlMapper.Query<JugadorDapper>(_sqlConnection, script).ToList();

                    if (query != null)
                    {
                        result.AddRange(query);
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }


            return result;
        }

        public JugadorDapper GetById(int id)
        {
            JugadorDapper result = null;
            var script = "SELECT * FROM [DataFutsal].[dbo].[Jugador] WHERE [Id] = @JugadorId";
            var param = new DynamicParameters();

            //QUERY PARAMETERS
            param.Add("@JugadorId", id);

            try
            {
                using (SqlConnection sqlConnection = _sqlConnection)
                {
                    var query = SqlMapper.Query<JugadorDapper>(_sqlConnection, script, param).FirstOrDefault();

                    if (query != null)
                    {
                        result = query;
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return result;
        }

        public string Add(JugadorDapper jugador)
        {
            var result = string.Empty;
            var script = "INSERT INTO [dbo].[Jugador]([Dni],[Nombres],[Apellidos],[FechaNacimiento],[Direccion],[Telefono],[TelefonoEmergencia],[FotoUrl],[IdPieHabil],[FechaAfiliacion],[Borrado]) VALUES (@Dni,@Nombres,@Apellidos,@FechaNacimiento,@Direccion,@Telefono,@TelefonoEmergencia,@FotoUrl,@IdPieHabil ,@FechaAfiliacion,@Borrado)";

            try
            {
                using (SqlConnection sqlConnection = _sqlConnection)
                {
                    var affectedRows = sqlConnection.Execute(script,
                        new
                        {
                            jugador.Dni,
                            jugador.Nombres,
                            jugador.Apellidos,
                            jugador.FechaNacimiento,
                            jugador.Direccion,
                            jugador.Telefono,
                            jugador.TelefonoEmergencia,
                            jugador.FotoUrl,
                            jugador.IdPieHabil,
                            jugador.FechaAfiliacion,
                            jugador.Borrado
                        });

                    result = $"{affectedRows} rows affected.";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public string Update(JugadorDapper jugador)
        {

            var result = string.Empty;
            var script = "UPDATE[dbo].[Jugador] SET [Dni] = @Dni, [Nombres] = @Nombres, [Apellidos] = @Apellidos, [FechaNacimiento] = @FechaNacimiento, [Direccion] = @Direccion, [Telefono] = @Telefono, [TelefonoEmergencia] = @TelefonoEmergencia, [FotoUrl] = @FotoUrl, [IdPieHabil] = @IdPieHabil, [FechaAfiliacion] = @FechaAfiliacion, [Borrado] = @Borrado WHERE[Id] = @JugadorId";

            try
            {
                using (SqlConnection sqlConnection = _sqlConnection)
                {
                    var affectedRows = sqlConnection.Execute(script,
                        new
                        {
                            JugadorId = jugador.Id,
                            jugador.Dni,
                            jugador.Nombres,
                            jugador.Apellidos,
                            jugador.FechaNacimiento,
                            jugador.Direccion,
                            jugador.Telefono,
                            jugador.TelefonoEmergencia,
                            jugador.FotoUrl,
                            jugador.IdPieHabil,
                            jugador.FechaAfiliacion,
                            jugador.Borrado
                        });

                    result = $"{affectedRows} rows affected.";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public string Delete(int id)
        {
            var result = string.Empty;
            var script = "DELETE FROM [dbo].[Jugador] WHERE [Id] = @JugadorId";

            try
            {
                using (SqlConnection sqlConnection = _sqlConnection)
                {
                    var affectedRows = sqlConnection.Execute(script,
                        new
                        {
                            JugadorId = id
                        });

                    result = $"{affectedRows} rows affected.";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
    }
}
