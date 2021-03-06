﻿using System;

namespace GW.AspNetTraining.TrainingsWebApp.Business
{
    public class TrainingEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Level { get; set; }

        // HH
        // HL
        // ECK
        // MD
        // HB

        public string Location { get; set; }
        public bool Approval { get; set; }

        public decimal Price { get; set; }
    }
}