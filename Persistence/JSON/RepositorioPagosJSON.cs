using Domain.Pago;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Persistence.JSON
{
    public class RepositorioPagosJSON : IRepositorioPagos
    {
        private String path = @"..\CoreAMTest\repos\conferencias.json";

        public RepositorioPagosJSON()
        {
            var main = ConfigurationManager.AppSettings["main"];
            if (main == "test")
            {
                path = @"..\..\..\..\CoreAMTest\repos\pagos.json";
            }
            else
            {
                path = @"..\CoreAMTest\repos\pagos.json";
            }
        }

        private List<Pago> leerPagos()
        {
            List<Pago> pagos;
            String jsonString = "";
            try
            {
                jsonString = File.ReadAllText(path);
                pagos = System.Text.Json.JsonSerializer.Deserialize<List<Pago>>(jsonString);
                return pagos;
            }
            catch (JsonException)
            {
                throw new Exception("El formato del archivo JSON es invalido.");
            }
            catch (Exception)
            {
                throw new Exception("Ocurrió un porblema al acceder al repositorio de pagos.");
            }
        }

        public Pago AgregarPagoEfectivo(Pago Pago)
        {
            List<Pago> pagos = leerPagos();
            int id = 1;
            if (pagos.Count > 0)
            {
                Pago aux = pagos[pagos.Count - 1];
                id = aux.IdPago + 1;
            }

            Pago.IdPago = id;
            pagos.Add(Pago);

            try
            {
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(pagos,
                               Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, newJsonResult);
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un problema al guardar el pago en el repositorio.");
            }

            return Pago;
        }

        public Pago AgregarPagoTarjeta(Pago Pago)
        {
            List<Pago> pagos = leerPagos();
            int id = 1;
            if (pagos.Count > 0)
            {
                Pago aux = pagos[pagos.Count - 1];
                id = aux.IdPago + 1;
            }

            Pago.IdPago = id;
            pagos.Add(Pago);

            try
            {
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(pagos,
                               Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, newJsonResult);
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un problema al guardar el pago en el repositorio.");
            }

            return Pago;
        }

        public List<Pago> GetPagos(int EventoId, int AsistenteId)
        {
            List<Pago> pagos = leerPagos();
            try
            {
                pagos = pagos
                    .FindAll(c =>
                    {
                        return c.EventoId == EventoId && c.AsistenteId == AsistenteId;
                    });

                return pagos;
            }
            catch (JsonException)
            {
                throw new Exception("El formato del archivo JSON es invalido.");
            }
            catch (Exception)
            {
                throw new Exception("Ocurrió un porblema al acceder al repositorio de pagos.");
            }
        }

        public Pago GetPago(int Id)
        {
            List<Pago> pagos = leerPagos();
            Pago pago = pagos.Find(c => c.IdPago == Id);
            if (pago == null)
            {
                //throw new ConferenciaNoEncontradaException($"La conferencia con el {id} no fue encontrada.");
                return null;
            }
            else
            {
                return pago;
            }
        }
    }
}
