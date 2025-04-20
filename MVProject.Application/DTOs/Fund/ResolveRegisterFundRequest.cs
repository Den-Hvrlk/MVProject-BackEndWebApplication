using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVProject.Application.DTOs.Fund
{
    public record ResolveRegisterFundRequest
    (
        [Required] Guid ID_RegisterFundRequest
    );
}
