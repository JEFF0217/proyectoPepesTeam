
using Domain.Aula;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Persistence.JSON
{
    public class RepositorioAulasJSON : IRepositorioAulas
    {
        private String path = @"";

        public RepositorioAulasJSON()
        {
            var main = ConfigurationManager.AppSettings["main"];
            if (main == "test")
            {
                path = @"..\..\..\..\CoreAMTest\repos\aulas.json";
            }
            else
            {
                path = @"..\CoreAMTest\repos\aulas.json";
            }
        }


        private List<Aula> leerAulas()
        {
            List<Aula> aulas;
            String jsonString = "";
            try
            {
                jsonString = File.ReadAllText(path);
                aulas = System.Text.Json.JsonSerializer.Deserialize<List<Aula>>(jsonString);
                return aulas;
            }
            catch (JsonException)

            {
                throw new Exception("El formato del archivo JSON es invalido.");
            }

            catch (Exception)

            {
                throw new Exception("Ocurrió un porblema al acceder al repositorio de conferencias.");
            }
        }

        private void guardarAulas(List<Aula> aulas)
        {
            try
            {
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(aulas,
                               Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, newJsonResult);
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un problema al guardar el Aula en el repositorio.");
            }
        }



        public List<Aula> GetAulas(int EventoId)
        {
            List<Aula> aulas = leerAulas();
            try
            {
                aulas = aulas
                    .FindAll(c =>
                    {
                        return c.EventoId == EventoId;
                    });

                return aulas;
            }
            catch (JsonException)
            {
                throw new Exception("El formato del archivo JSON es invalido.");
            }
            catch (Exception)
            {
                throw new Exception("Ocurrió un porblema al acceder al repositorio de Aulas.");
            }
        }

        public bool Eliminar(string id, int eventoId)
        {
            List<Aula> conferencias = leerAulas();
            Aula aula;
            aula = conferencias.Find(c => c.Id == id && c.EventoId == eventoId);

            if (aula == null)
            {
                throw new AulaNoEncontradaException($"el Aula  {id} y evento {eventoId} no fue encontrada.");
            }

            if (conferencias.Remove(aula))
            {
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(conferencias, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, output);
                return true;
            }
            else
            {
                throw new Exception("No se logró eliminar el Aula  del repositorio de datos.");
            }
        }




        public Aula Agregar(Aula aula)
        {
            List<Aula> aulas = leerAulas();

            Aula aulaValidar = aulas.Find((c) =>
            {
                return c.EventoId == aula.EventoId && c.Id == aula.Id;
            });

            if (aulaValidar != null)
            {
                throw new AulaDuplicadaException("Ya existe un Aula con ese nombre en este evento");
            }



            aulas.Add(aula);
            this.guardarAulas(aulas);
            return aula;
        }



        public Aula Editar(Aula aulaNew)
        {
            List<Aula> aulas = leerAulas();
            Aula aulaOld;


            try {
                aulaOld = aulas.Find(c => c.Id == aulaNew.Id);

                if (aulaOld == null)
                {
                    throw new AulaNoEncontradaException($"el Aula con el {aulaNew.Id} no fue encontrada.");
                }

                aulaOld.EventoId = (aulaNew.EventoId != 0) ? aulaNew.EventoId : aulaOld.EventoId;
                aulaOld.Capacidad = (aulaNew.Capacidad != 0) ? aulaNew.Capacidad : aulaOld.Capacidad;
            }
            catch (Exception)
            {

                throw new Exception("Ocurrio un problema en el repositorio de datos al editar el Aula.");
            }
            guardarAulas(aulas);
            return aulaOld;
            }


        public Aula GetAula(string id, int EventoId)
            {
                List<Aula> aulas = leerAulas();
                Aula aula = aulas.Find(c => c.Id == id && EventoId == c.EventoId);
                if (aula == null)
                {
                    throw new AulaNoEncontradaException($"el aula con el {id} no fue encontrada.");
                }
                else
                {
                    return aula;
                }


            }


        }
    }
