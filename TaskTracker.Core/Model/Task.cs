﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Core.Model
{
    public class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EstimatedCompletionDate { get; set; }
        public DateTime ActualCompletionDate { get; set; }
        public bool IsCompleted { get; set; }


    }
}