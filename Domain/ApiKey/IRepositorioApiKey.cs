using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ApiKey
{
    public interface IRepositorioApiKey
    {
        ApiKey crear(int usuarioId);

        ApiKey consultar(string api_key);
    }
}
