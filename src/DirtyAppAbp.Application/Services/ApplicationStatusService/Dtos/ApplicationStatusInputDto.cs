using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.ApplicationStatusService.Dtos
{
    [AutoMap(typeof(ApplicationStatus))]
    public class ApplicationStatusInputDto : EntityDto<Guid>
    {
        public Guid ApplicationId { get; set; }
        public ReflistStatus Status { get; set; } = 0;
        public string Reason { get; set; } = "Successfully Submitted";
    }
}
