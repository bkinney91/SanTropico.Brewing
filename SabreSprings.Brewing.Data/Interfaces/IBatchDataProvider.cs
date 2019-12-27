﻿using SabreSprings.Brewing.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Data.Interfaces
{
    public interface IBatchDataProvider
    {
        Task<Batch> Get(int id);
        Task<List<Batch>> GetOnTap();
        Task<List<Batch>> GetAllBatches();
        Task SubtractPour(int batchId, decimal pour);
        Task<decimal> GetPintsRemaining(int batchId);
        Task<int> GetBatchOnTap(int tapNumber);
    }
}
