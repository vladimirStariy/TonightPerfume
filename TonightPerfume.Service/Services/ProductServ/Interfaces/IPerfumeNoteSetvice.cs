﻿using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;

namespace TonightPerfume.Service.Services.ProductServ.Interfaces
{
    public interface IPerfumeNoteService
    {
        Task<IBaseResponce<PerfumeNote>> Create(PerfumeNote model);
    }
}