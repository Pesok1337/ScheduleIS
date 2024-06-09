using AutoMapper;
using ScheduleIS.Core.Models;
using ScheduleIS.DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleIS.DataAccess.Mappings
{
    public class DataBaseMappings : Profile
    {
        public DataBaseMappings()
        {
            CreateMap<CourseEntity, Course>();
            CreateMap<ScheduleEntity, Schedule>();
            CreateMap<UserEntity, User>();
        }
    }
}
