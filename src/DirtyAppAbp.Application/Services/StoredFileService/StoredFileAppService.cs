using Abp.Application.Services;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.UI;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.StoredFileService.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.StoredFileService
{
    public class StoredFileAppService: ApplicationService
    {
        private readonly IRepository<Applicant, Guid> _applicantRepository;
        private readonly IRepository<StoredFile, Guid> _storedFileRepository;
        public StoredFileAppService(IRepository<Applicant, Guid> applicantRepository, IRepository<StoredFile, Guid> storedFileRepository)
        {
            _applicantRepository = applicantRepository;
            _storedFileRepository = storedFileRepository;
        }

        public async Task<StoredFileDto> UploadFile([FromForm] StoredFileDto form)
        {
            var service = IocManager.Instance.Resolve<IRepository<StoredFile, Guid>>();
            byte[] fileBytes = null;
            using (var ms = new MemoryStream())
            {
                await form.File.CopyToAsync(ms);
                fileBytes = ms.ToArray();
            }

            var person = await GetCurrentUserPerson();

            var file = new StoredFile
            {
                Data = fileBytes,
                Name = form.File.FileName,
                FileType = form.File.ContentType,
            };

            file.Applicant = await _applicantRepository.GetAsync(person.Id);

            file = await service.InsertAsync(file);
            var result = ObjectMapper.Map<StoredFileDto>(file);
            return result;
        }
        [HttpGet]
        public async Task<IActionResult> DownloadFile(Guid fileId)
        {
            var service = IocManager.Instance.Resolve<IRepository<StoredFile, Guid>>();
            var file = await service.GetAsync(fileId);

            if (file == null)
            {
                throw new ApplicationException("File Invalid!!!");
            }

            var stream = new MemoryStream(file.Data);

            stream.Position = 0;

            var contentType = file.FileType;
            var fileExtension = Path.GetExtension(file.Name);

            return new FileStreamResult(stream, contentType) { FileDownloadName = file.Name };
        }

        //public async Task<IActionResult> DownloadFileNew(Guid fileId)
        //{
        //    var service = IocManager.Instance.Resolve<IRepository<StoredFile, Guid>>();
        //    var file = await service.GetAsync(fileId);

        //    if (file == null)
        //    {
        //        throw new ApplicationException("File Invalid!!!");
        //    }

        //    Determine the content type and file extension
        //   var contentType = file.FileType;
        //    var fileExtension = Path.GetExtension(file.Name);

        //    Return the file content as a blob - like response
        //    return File(file.Data, contentType, file.Name);
        //}
        public async Task<List<StoredFileDto>> GetFilesByApplicantId()
        {
            var person = await GetCurrentUserPerson();
            var files = await _storedFileRepository.GetAllListAsync(f => f.Applicant.Id == person.Id);
            var result = ObjectMapper.Map<List<StoredFileDto>>(files);
            return result;
        }

        public async Task<List<StoredFileDto>> GetAllFilesByApplicant()
        {
            var files = await _storedFileRepository.GetAllListAsync();
            var result = ObjectMapper.Map<List<StoredFileDto>>(files);
            return result;
        }

        //videos
        public async Task<StoredFileDto> UploadFileVideo([FromForm] StoredFileDto form)
        {
            var service = IocManager.Instance.Resolve<IRepository<StoredFile, Guid>>();

            // Read the video file data
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                await form.File.CopyToAsync(ms);
                fileBytes = ms.ToArray();
            }

            var person = await GetCurrentUserPerson();

            var file = new StoredFile
            {
                Data = fileBytes,
                Name = form.File.FileName,
                FileType = form.File.ContentType,
            };

            file.Applicant.Id = person.Id;

            file = await service.InsertAsync(file);
            var result = ObjectMapper.Map<StoredFileDto>(file);
            return result;
        }

        [HttpGet]
        public async Task<IActionResult> StreamVideo(Guid fileId)
        {
            var service = IocManager.Instance.Resolve<IRepository<StoredFile, Guid>>();
            var file = await service.GetAsync(fileId);

            if (file == null)
            {
                throw new ApplicationException("File Invalid!!!");
            }

            // Create a MemoryStream from the file's data
            var stream = new MemoryStream(file.Data);

            // Set the position of the stream to the beginning
            stream.Position = 0;

            // Determine the content type and file extension
            var contentType = file.FileType;
            var fileExtension = Path.GetExtension(file.Name);

            // Provide the file as a downloadable attachment
            return new FileStreamResult(stream, contentType);
        }

        public async Task Delete(Guid id)
        {
            await _storedFileRepository.DeleteAsync(id);
        }

        //get person from logged in user
        private async Task<Applicant> GetCurrentUserPerson()
        {
            var currentUserId = AbpSession.UserId;

            if (currentUserId == null)
            {
                throw new ApplicationException("User Invalid!!!");
            }

            var person = await _applicantRepository.FirstOrDefaultAsync(p => p.User.Id == currentUserId);

            if (person == null)
            {
                throw new ApplicationException("Person Not Found!!!");
            }

            return person;
        }
    }
}
