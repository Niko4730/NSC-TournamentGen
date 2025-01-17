﻿using System.Collections.Generic;
using System.Linq;
using NSC_TournamentGen.Core.IServices;
using NSC_TournamentGen.Core.Models;
using NSC_TournamentGen.Domain.IRepositories;

namespace NSC_TournamentGen.Domain.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly TournamentManager _tournamentManager;

        public TournamentService(ITournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
            _tournamentManager = new TournamentManager(this, tournamentRepository);
        }

        public List<Tournament> GetAllTournaments()
        {
            return _tournamentRepository.ReadAllTournaments();
        }

        public Tournament DeleteTournament(int id)
        {
            return _tournamentRepository.DeleteTournament(id);
        }

        public Tournament UpdateTournament(int id, Tournament tournament)
        {
            return _tournamentRepository.UpdateTournament(id, tournament);
        }

        public Tournament CreateTournament(TournamentInput tournamentInput)
        {
            var tournament = _tournamentManager.MakeTournament(tournamentInput);
            return _tournamentRepository.CreateTournament(tournament);
        }

        public Tournament GetTournament(int id)
        {
            return _tournamentRepository.ReadTournament(id);
        }

        public Tournament MakeWinner(int tournamentId, int roundId, int bracketId, int participantId)
        {
            _tournamentRepository.MakeWinner(tournamentId, roundId, bracketId, participantId);
            return _tournamentRepository.AssignWinnersForNextRound(tournamentId, roundId);
        }
    }
}