using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Domain.Enum;
using DirtyAppAbp.Services.PersonService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.ApplicantService.Dtos
{
    [AutoMap(typeof(Applicant))]
    public class ApplicantPostDto : PersonPostDto
    {
        public  ReflistActivity CurrentActivity { get; set; }
        public  ReflistActivity PreviousActivity { get; set; }
    }
}
