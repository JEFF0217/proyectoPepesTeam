using Application.AutorizarEvento;
using Application.GestionarConferencia;
using Application.TransmitirConferencia;
using Domain;
using Domain.Aula;
using Domain.Conferencia;
using Domain.Conferencista;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace CoreAMTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //CtrlTransmitirConferencia ctrl = new CtrlTransmitirConferencia();
            //var result = ctrl.AsignarUrl("midomio.fake.com", 3);

            // CtrlAutorizarEvento ctrl = new CtrlAutorizarEvento();
            //var result = ctrl.CambiarEstado(1, EstadoEvento.Rechazado);

            //CtrlGestionarConferencia ctrl = new CtrlGestionarConferencia();
            // CtrlAutorizarEvento ctrl = new CtrlAutorizarEvento();
            // var result = ctrl.CambiarEstado(1, EstadoEvento.Aceptado);
            // var result = ctrl.listarConferencias(12, "mente");
            //var result = ctrl.CambiarEstado(1, EstadoEvento.Rechazado);
            //var result = ctrl.listarConferencias(12,"");
            //var result = ctrl.eliminarConferencia(7);
            //var result = ctrl.agregarConferencia(10, "Nueva conferencia", "Que trin una conferencia", DateTime.Now, 12, "un archivo encode");
            //var result = ctrl.editarConferencia(1, Nombre: "La trin acabemos esto mejor conferencia",Hora: DateTime.Now);
            //var result = ctrl.editarConferencia(1, Nombre: "La conferencia mayor");
            //var options = new JsonSerializerOptions
            //{
             //   WriteIndented = true,
            //};
           // string salida = System.Text.Json.JsonSerializer.Serialize(result, options);
            //Console.WriteLine(salida);
            //var options = new JsonSerializerOptions
            //{
            //    WriteIndented = true,
            //};
            //string salida = System.Text.Json.JsonSerializer.Serialize(result, options);
            //Console.WriteLine(salida);
            string input = "una conferencia npi";
            string pattern = @"^[a-zA-Z0-9]{3,50}$";

            bool match = Regex.IsMatch(input, pattern);
            Console.WriteLine(match);
        }
    }
}
