﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalLearning.Services.IServices
{
    public interface IAIService
    {
        Task<string> GetCircuitJsonFromDescriptionAsync(string description);
    }
}
