using fotbalTeam.Domain.Entities;
using System.Collections.Generic;

namespace fotbalTeam.Application.Abstraction
{
    public interface IPerformanceAppService
    {
        IList<Performance> Select(); // Get all performances
        void Create(Performance performance); // Create a new performance record
        bool Delete(int id); // Delete a performance by ID
        Performance GetById(int id); // Get performance by ID
        bool Update(Performance performance);
        
    }
}