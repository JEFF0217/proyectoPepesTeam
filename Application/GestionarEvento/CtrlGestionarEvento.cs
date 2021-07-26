using Domain.Common;
using Domain.Evento;
using Domain.Usuario;
using Infrastructure.Sistema;
using Persistence.Factory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Application.GestionarEvento
{
    public class CtrlGestionarEvento
    {
        private IRepositorioEventos repoEventos;
        public CtrlGestionarEvento()
        {
            this.repoEventos = FabricaRepositorioEventos.CrearRepositorioEventos();
        }

        public List<Evento> listarEventos(string api_value)
        {
            Usuario user = Login.GetUsuario(api_value);

            if (user == null)
            {

                throw new Exception("La api key usada no es valida");

            }
            return this.repoEventos.GetEventos();
        }

        public Evento agregarEvento(Evento evento,string api_value)
        {
            Usuario user = Login.GetUsuario(api_value);

            if (user == null)
            {

                throw new Exception("La api key usada no es valida");

            }
            if (evento == null)
            {
                throw new ValorIncorrectoException("Debe de ingresar valores en el formato del evento");
            }
            if (evento.Id <= 0)
            {
                throw new ValorIncorrectoException("Debe ingresar un id  valido para el evento.");
            }
            if (evento.Fecha == null)
            {
                throw new ValorIncorrectoException("Debe ingresar una fecha valida para el evento.");
            }
            if (evento.Fecha == null)
            {
                throw new ValorIncorrectoException("Debe ingresar una fecha valida para el evento.");
            }
            if (evento.MinimoAsistentes <= 0)
            {
                throw new ValorIncorrectoException("Debe ingresar un valor valido para el minimo de asistentes del evento.");
            }
            if (evento.MaximoAsistentes <= 0)
            {
                throw new ValorIncorrectoException("Debe ingresar un valor valido para el maximo de asistentes del evento.");
            }
            if (evento.MaximoAsistentes < evento.MinimoAsistentes)
            {
                throw new ValorIncorrectoException("no puede ser que el maximo de asistentes sea menor que el minimo de asistentes");
            }
            return this.repoEventos.Agregar(evento);
            
        }
        public Evento editarEvento(Evento evento,string api_value)
        {
            Usuario user = Login.GetUsuario(api_value);

            if (user == null)
            {

                throw new Exception("La api key usada no es valida");

            }
            if (evento == null)
            {
                throw new ValorIncorrectoException("Debe de ingresar valores en el formato del evento");
            }
            if (evento.Id <= 0)
            {
                throw new ValorIncorrectoException("Debe ingresar un id  valido para el evento.");
            }
            if (evento.Fecha == null)
            {
                throw new ValorIncorrectoException("Debe ingresar una fecha valida para el evento.");
            }
            if (evento.Fecha == null)
            {
                throw new ValorIncorrectoException("Debe ingresar una fecha valida para el evento.");
            }
            if (evento.MinimoAsistentes <= 0)
            {
                throw new ValorIncorrectoException("Debe ingresar un valor valido para el minimo de asistentes del evento.");
            }
            if (evento.MaximoAsistentes <= 0)
            {
                throw new ValorIncorrectoException("Debe ingresar un valor valido para el maximo de asistentes del evento.");
            }
            if (evento.MaximoAsistentes < evento.MinimoAsistentes)
            {
                throw new ValorIncorrectoException("no puede ser que el maximo de asistentes sea menor que el minimo de asistentes");
            }
            return this.repoEventos.Editar(evento);
            
        }

        public bool eliminarEvento(int eventoId,string api_value)
        {
            Usuario user = Login.GetUsuario(api_value);

            if (user == null)
            {

                throw new Exception("La api key usada no es valida");

            }
            if (eventoId <= 0)
            {
                throw new ValorIncorrectoException("El id del evento es invalido.");
            }
            return this.repoEventos.Eliminar(eventoId);
            
            
        }

        public Evento ObtenerEvento(int eventoId,string api_value)
        {
            Usuario user = Login.GetUsuario(api_value);

            if (user == null)
            {

                throw new Exception("La api key usada no es valida");

            }
            if (eventoId <= 0)
            {
                throw new ValorIncorrectoException("El id del evento es invalido.");
            }
            return this.repoEventos.GetEvento(eventoId);
        
        }
      
    }
}
