using fotbalTeam.Domain.Entities;
using System.Collections.Generic;

namespace fotbalTeam.Infrastructure.Seeding
{
    internal class TrainingInit
    {
        public IList<Training> GetTrainings()
        {
            IList<Training> trainings = new List<Training>();

            trainings.Add(new Training
            {
                Id = 1,
                Date = new DateTime(2025, 1, 28),
                Description = "Morning fitness session"
            });

            trainings.Add(new Training
            {
                Id = 2,
                Date = new DateTime(2025, 1, 30),
                Description = "Tactical training"
            });

            trainings.Add(new Training
            {
                Id = 3,
                Date = new DateTime(2025, 2, 2),
                Description = "Match preparation"
            });

            return trainings;
        }
    }
}