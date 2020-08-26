using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GW.AspNetTraining.TrainingsWebApp.Business
{
    public class DataStore
    {
        public List<TrainingEntity> Trainings { get; set; } = new List<TrainingEntity>();
    }
}