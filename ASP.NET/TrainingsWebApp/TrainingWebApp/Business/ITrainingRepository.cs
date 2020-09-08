using System;
using System.Collections.Generic;

namespace GW.AspNetTraining.TrainingsWebApp.Business
{
    public interface ITrainingRepository
    {
        void DeleteTraining(Guid id);
        IEnumerable<LocationEntity> GetLocations();
        TrainingEntity GetTrainingById(Guid id);
        List<TrainingEntity> GetTrainings();
        void SaveTraining(TrainingEntity entity);
    }
}