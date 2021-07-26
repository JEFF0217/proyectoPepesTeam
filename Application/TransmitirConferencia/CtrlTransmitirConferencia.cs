using Application.GestionarConferencia;
using Domain.Common;
using Domain.Conferencia;
using Persistence.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.TransmitirConferencia
{
    public class CtrlTransmitirConferencia
    {
        public Conferencia AsignarUrl(string url,int conferenciaId)
        {
            if (url.Equals(""))
            {
                throw new ValorIncorrectoException("La url no puede ser vacia.");
            }

            if(conferenciaId <=0)
            {
                throw new ValorIncorrectoException("EL id de conferencia es invalido.");
            }

            IRepositorioConferencias repoConferencias = FabricaRepositoriosConferencias.CrearRepositorioConferencias();
            Conferencia conferencia = repoConferencias.SetUrlConferencia(url, conferenciaId);
            return conferencia;
        }
    }
}
