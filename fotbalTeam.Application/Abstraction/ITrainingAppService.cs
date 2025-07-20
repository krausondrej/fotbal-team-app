using fotbalTeam.Domain.Entities;
using System.Collections.Generic;

namespace fotbalTeam.Application.Abstraction
{
    public interface ITrainingAppService
    {
        IList<Training> Select(); // Get all trainings
        void Create(Training training); // Create a new training session
        bool Delete(int id); // Delete a training session by ID
        Training GetById(int id); // Get training by ID
        bool Update(Training training);
    }
}