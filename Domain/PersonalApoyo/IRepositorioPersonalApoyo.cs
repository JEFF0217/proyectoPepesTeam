using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.PersonalApoyo
{
    public interface IRepositorioPersonalApoyo
    {
        List<PersonalApoyo> GetPersonalApoyo();
    }
}
