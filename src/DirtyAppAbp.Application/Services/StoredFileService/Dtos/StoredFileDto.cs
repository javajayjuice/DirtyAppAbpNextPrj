using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DirtyAppAbp.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.StoredFileService.Dtos
{
    [AutoMap(typeof(StoredFile))]
    public class StoredFileDto : EntityDto<Guid>
    {
        public IFormFile File { get; set; }
        public Byte[] Data { get; set; }
        public string Name { get; set; }
        public Guid ApplicantId { get; set; }
    }
}
