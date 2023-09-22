using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Disco
    {
        public static ML.Result Add(ML.Disco disco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ESantiagoPruebaTecnicaEntities context = new DL.ESantiagoPruebaTecnicaEntities())
                {
                    var rowsAffected = context.DiscoAdd(
                        disco.Titulo,
                        disco.Artista,
                        disco.GeneroMusical,
                        disco.Duracion,
                        disco.Anio,
                        disco.Distribuidora);
                    if(rowsAffected > 0 )
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido agregar.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result ();
            try
            {
                using(DL.ESantiagoPruebaTecnicaEntities context = new DL.ESantiagoPruebaTecnicaEntities ())
                {
                    var query = context.DiscoGetAll();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var registro in query)
                        {
                            ML.Disco disco = new ML.Disco();
                            disco.IdDisco = registro.IdDisco;
                            disco.Titulo = registro.Titulo;
                            disco.Artista = registro.Artista;
                            disco.GeneroMusical = registro.GeneroMusical;
                            disco.Duracion = registro.GeneroMusical;
                            disco.Anio = registro.Anio;
                            disco.Distribuidora = registro.Distribuidora;
                            disco.Ventas = int.Parse(registro.Ventas.ToString());
                            disco.Disponibilidad = registro.Disponibilidad;
                            result.Objects.Add(disco);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al consultar los registros.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
