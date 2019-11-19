using DependencyInjectionLesson.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionLesson.Services
{
    public class EntitySaverService : IEntitySaverService
    {
        public EntitySaverService() //  в параметрах мону быть зависимости 
        {

        }

        public Task SaveEntity(EntityDTO entity) {
            var jsonResult = JsonConvert.SerializeObject(entity);
           return System.IO.File.WriteAllTextAsync("1.json", jsonResult);
        }
    }
}
