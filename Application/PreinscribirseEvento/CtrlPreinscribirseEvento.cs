using System;
using System.Collections.Generic;
using System.Text;
using Domain.Asistente;
using Domain.Evento;
using Persistence.Factory;
using Domain.Common;
using System.Runtime.InteropServices.WindowsRuntime;
using Domain.Inscripcion;
using Domain.Usuario;

namespace Application.PreinscribirseEvento
{
    public class CtrlPreinscribirseEvento
    {
        IRepositorioAsistente repoAsistente;
       IRepositorioUsuario repoususario;
        IRepositorioInscripcion repoInscripcion;
        IRepositorioEventos repoEventos;
        Inscripcion inscripcion;
    


        public CtrlPreinscribirseEvento() {

            repoAsistente = FabricaRepositorioAsistentes.CrearRepositorioAsistentess();
            repoususario = FabricaRepositorioUsuarios.CrearRepositorioUsuarios();
            repoInscripcion = FabricaRepositorioInscripcion.CrearRepositorioInscripcion();
            this.repoEventos = FabricaRepositorioEventos.CrearRepositorioEventos();
           
         
        }


        public Inscripcion agregarInscripcion(Asistente asistente,int EventoId)
        {

            repoEventos.GetEvento(EventoId);
            repoususario.GetUsuario(asistente.IdUsuario);

            Asistente asistente1 = buscarAsistente(asistente.IdUsuario);


            inscripcion = new Inscripcion();
            inscripcion.eventoId = EventoId;
            inscripcion.AsistenteId = asistente.IdUsuario;
            inscripcion.estado = estadoPago.noPagado;

            if (asistente1 != null)
            {
       
                return repoInscripcion.agregar(inscripcion);
            }
            else {

                repoAsistente.agregarAsistente(asistente);
                return repoInscripcion.agregar(inscripcion);
            }
        }

        public Asistente buscarAsistente(int id)
        {
            return repoAsistente.GetAsistenteprueba(id);
        }





    }
}
