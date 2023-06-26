using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DirtyAppAbp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.ParentService.Dtos
{
    [AutoMap(typeof(Parent))]
    public class ParentPostDto : EntityDto<Guid>
    {
        public string Surname { get; set; }
        public string Initials { get; set; }
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
