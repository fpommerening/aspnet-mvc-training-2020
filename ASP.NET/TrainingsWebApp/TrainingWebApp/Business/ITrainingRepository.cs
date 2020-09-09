using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GW.AspNetTraining.TrainingsWebApp.Business
{
    public interface ITrainingRepository
    {
        Task DeleteTraining(Guid id);
        IEnumerable<LocationEntity> GetLocations();
        Task<TrainingEntity> GetTrainingById(Guid id);
        Task<List<TrainingEntity>> GetTrainings();
        Task SaveTraining(TrainingEntity entity);
        Task<List<OrderEntity>> GetOrders();

        Task SaveOrder(OrderEntity entity);

    }
}