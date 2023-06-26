using Abp.Application.Services;
using DirtyAppAbp.Services.QualificationService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.QualificationService
{
    public interface IQualificationAppService: IApplicationService
    {
        public Task<QualificationPostDto> CreateAsync(QualificationPostDto input);
    }
}
