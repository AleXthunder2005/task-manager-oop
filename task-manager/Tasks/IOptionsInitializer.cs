﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_manager.Tasks
{
    public interface IOptionsInitializer
    {
        void Initialize(fTaskCreator taskCreator);
    }
}
