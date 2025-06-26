using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectricalLearning.Repositories.Entities;

namespace ElectricalLearning.Services.ResponseModel
{
    public static class FormulaResponse
    {
        public record GetFormulasModel(
            int Id,
            string Name,
            string Expression,
            string Description,
            int CircuitModelId
        );
    }
}
