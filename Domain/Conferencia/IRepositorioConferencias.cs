using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Conferencia
{
    public interface IRepositorioConferencias
    {
        /// <summary>
        /// Obtiene la lista de conferencias de un evento en especifico
        /// filtrado a través de un nombre si se desea
        /// </summary>
        /// <param name="EventoId">Id del evento</param>
        /// <param name="queryNombre">Filtro para buscar por nombre</param>
        /// <returns></returns>
        List<Conferencia> GetConferencias(int EventoId,string queryNombre = "");

        /// <summary>
        /// Devuelve la información de una conferencia
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Conferencia GetConferencia(int id);

        /// <summary>
        /// Cambia la información del atributo <b>Url</b> de una conferencia.
        /// </summary>
        /// <param name="url">Nueva url</param>
        /// <param name="id">id de la conferencia</param>
        /// <returns>Devuelve la conferencia con el cambio de la url</returns>
        Conferencia SetUrlConferencia(string url,int id);

        /// <summary>
        /// Agrega una conferencia al repositorio de datos, no es necesario que 
        /// la conferencia tenga un Id, este sera generado automáticamente
        /// </summary>
        /// <param name="conferencia">Objeto con la información de la conferencia</param>
        /// <returns>Devuelve la conferencia que ha sido almacenada</returns>
        Conferencia Agregar(Conferencia conferencia);

        /// <summary>
        /// Edita una conferencia de acuerdo a un objeto conferencia que contiene la 
        /// información que se desea cambiar y el <b>Id</b> de la conferencia.
        /// </summary>
        /// <param name="conferencia"></param>
        /// <returns></returns>
        Conferencia Editar(Conferencia conferencia);

        /// <summary>
        /// Elimina un conferencia respecto a su Id
        /// </summary>
        /// <param name="id">Id de la conferencia</param>
        /// <returns><b>true</b> en caso de eliminar correctamente la conferencia</returns>
        bool Eliminar(int id);
    }

}
