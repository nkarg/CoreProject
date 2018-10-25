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
    public class EquipoManager : IEquipoManager
    {
        private readonly string _connectionString;
        private SqlConnection _sqlConnection { get { return new SqlConnection(_connectionString); } }

        public EquipoManager()
        {
            _connectionString = "Server=ARGDST0004;Database=DataFutsal;Trusted_Connection=True;";
        }

        public List<EquipoEntity> GetAll()
        {
            var result = new List<EquipoEntity>();
            var script = "SELECT * FROM [DataFutsal].[dbo].[Equipo]";

            try
            {
                using (SqlConnection sqlConnection = _sqlConnection)
                {
                    var query = SqlMapper.Query<EquipoEntity>(_sqlConnection, script).ToList();

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

        public EquipoEntity GetById(int id)
        {
            EquipoEntity result = null;
            var script = "SELECT * FROM [DataFutsal].[dbo].[Equipo] WHERE [Id] = @EquipoId";
            var param = new DynamicParameters();
            param.Add("@EquipoId", id);

            try
            {
                using (SqlConnection sqlConnection = _sqlConnection)
                {
                    var query = SqlMapper.Query<EquipoEntity>(_sqlConnection, script, param).FirstOrDefault();

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

        public string Add(EquipoEntity equipo)
        {
            var result = string.Empty;
            var script = "INSERT INTO [dbo].[Equipo]([NombreLargo],[NombreCorto],[EscudoUrl],[FechaAfiliacion],[Borrado]) VALUES (@NombreLargo,@NombreCorto,@EscudoUrl,@FechaAfiliacion,@Borrado)";

            try
            {
                using (SqlConnection sqlConnection = _sqlConnection)
                {
                    var affectedRows = sqlConnection.Execute(script,
                        new
                        {
                            equipo.NombreLargo,
                            equipo.NombreCorto,
                            equipo.EscudoUrl,
                            equipo.FechaAfiliacion,
                            equipo.Borrado
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

        public string Update(EquipoEntity equipo)
        {
            var result = string.Empty;
            var script = "UPDATE [dbo].[Equipo] SET [NombreLargo] = @NombreLargo, [NombreCorto] = @NombreCorto, [EscudoUrl] = @EscudoUrl, [FechaAfiliacion] = @FechaAfiliacion, [Borrado] = @Borrado WHERE [Id] = @EquipoId";

            try
            {
                using (SqlConnection sqlConnection = _sqlConnection)
                {
                    var affectedRows = sqlConnection.Execute(script,
                        new
                        {
                            EquipoId = equipo.Id,
                            equipo.NombreLargo,
                            equipo.NombreCorto,
                            equipo.EscudoUrl,
                            equipo.FechaAfiliacion,
                            equipo.Borrado
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
            var script = "DELETE FROM [dbo].[Equipo] WHERE [Id] = @EquipoId";

            try
            {
                using (SqlConnection sqlConnection = _sqlConnection)
                {
                    var affectedRows = sqlConnection.Execute(script,
                        new
                        {
                            EquipoId = id
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
