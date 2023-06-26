using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DirtyAppAbp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.InstituteFacultyService.Dtos
{
    [AutoMap(typeof(InstituteFaculty))]
    public class InstituteFacultyDto:EntityDto<Guid>
    {
        public Guid CampusId { get; set; }
        public Guid FacultyId { get; set; }
    }
}
