﻿using System.Collections.Generic;
using NSC_TournamentGen.Core.Models;

namespace NSC_TournamentGen.Domain.IRepositories
{
    public interface IParticipantRepository
    {
        List<Participant> GetAll();
    }
}