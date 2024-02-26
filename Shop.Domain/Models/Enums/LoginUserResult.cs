using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Models.Enums
{
    public enum LoginUserResult
    {
        NotFound,
        NotActive,
        Success,
        IsBlocked
    }
}
