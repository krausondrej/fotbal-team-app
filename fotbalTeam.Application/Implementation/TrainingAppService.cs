using fotbalTeam.Application.Abstraction;
using fotbalTeam.Domain.Entities;
using fotbalTeam.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace fotbalTeam.Application.Implementation
{
    public class TrainingAppService : ITrainingAppService
    {
        private readonly FotbalTeamDbContext _context;

        public TrainingAppService(FotbalTeamDbContext context)
        {
            _context = context;
        }

        // Get all trainings
        public IList<Training> Select()
        {
            return _context.Trainings.ToList();
        }

        // Create a new training session
        public void Create(Training training)
        {
            _context.Trainings.Add(training);
            _context.SaveChanges();
        }

        // Delete a training session by ID
        public bool Delete(int id)
        {
            bool deleted = false;
            var training = _context.Trainings.FirstOrDefault(t => t.Id == id);
            if (training != null)
            {
                _context.Trainings.Remove(training);
                _context.SaveChanges();
                deleted = true;
            }
            return deleted;
        }

        // Get a training session by ID
        public Training GetById(int id)
        {
            return _context.Trainings.FirstOrDefault(t => t.Id == id);
        }

        // Get trainings by date
        public IList<Training> GetTrainingsByDate(DateTime date)
        {
            return _context.Trainings.Where(t => t.Date.Date == date.Date).ToList();
        }

        // Update a training session
        public bool Update(Training training)
        {
            var existingTraining = _context.Trainings.FirstOrDefault(t => t.Id == training.Id);
            if (existingTraining != null)
            {
                existingTraining.Date = training.Date;
                existingTraining.Description = training.Description;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
