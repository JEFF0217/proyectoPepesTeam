using Domain.PersonalApoyo;
using Domain.Usuario;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Persistence.JSON
{
    public class RepositorioPersonalApoyoJSON : IRepositorioPersonalApoyo
    {
        public List<PersonalApoyo> GetPersonalApoyo()
        {
            List<PersonalApoyo> PersonalApoyo;

            String path = @".\..\..\..\repos\proyecto-del-curso-pepe-s-team\CoreAMTest\PersonalApoyo.json";
            String jsonString = File.ReadAllText(path);

            PersonalApoyo = System.Text.Json.JsonSerializer.Deserialize<List<PersonalApoyo>>(jsonString);

            foreach (PersonalApoyo c in PersonalApoyo)
            {
                IRepositorioUsuario repo = Persistence.Factory.FabricaRepositorioUsuarios.CrearRepositorioUsuarios();
                Usuario aux = repo.GetUsuario(c.IdUsuario);
                c.setUsuario(aux);
            }

            return PersonalApoyo;
        }
    }
}
