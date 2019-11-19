using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionLesson.DTOs;

namespace DependencyInjectionLesson.Services
{
    interface IEntitySaverService
    {
        Task SaveEntity(EntityDTO entity);
    }
}
