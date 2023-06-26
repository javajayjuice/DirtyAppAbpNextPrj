using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.AddressService.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.AddressService
{
    public class AddressAppService : ApplicationService
    {
        private readonly IRepository<Address, Guid> _addressRepository;
        private readonly IRepository<Applicant, Guid> _applicantRepository;

        public AddressAppService(IRepository<Address, Guid> addressRepository, IRepository<Applicant, Guid> applicantRepository)
        {
            _addressRepository = addressRepository;
            _applicantRepository = applicantRepository; 
        }

        public async Task<Guid> CreateAddressForPerson(AddressDto input)
        {
            var person = await GetCurrentUserPerson();

            if (person == null)
            {
                throw new ApplicationException("Person not found!");
            }

            var address = new Address
            {
                Street = input.Street,
                Town = input.Town,
                City = input.City,
                Suburb = input.Suburb,
                Province = input.Province,
                PostalCode = input.PostalCode
            };

            person.Address = address;

            await _addressRepository.InsertAsync(address);
            await _applicantRepository.UpdateAsync(person);

            return address.Id;
        }

        public async Task<AddressDto> UpdateAddressForPerson( AddressDto input)
        {
            var person = await GetCurrentUserPerson();

            if (person == null)
            {
                throw new ApplicationException("Person not found!");
            }

            var addressIdNew = person.Address.Id;

            var address = await _addressRepository.GetAsync(addressIdNew);

            if (address == null)
            {
                throw new ApplicationException("Address not found!");
            }

            var x = ObjectMapper.Map<AddressDto>(input);

            address.Street = input.Street;
            address.Town = input.Town;
            address.City = input.City;
            address.Suburb = input.Suburb;
            address.Province = input.Province;
            address.PostalCode = input.PostalCode;

            var result = await _addressRepository.UpdateAsync(address);

            return ObjectMapper.Map<AddressDto>(result);
        }


        //get person from logged in user
        private async Task<Applicant> GetCurrentUserPerson()
        {
            var currentUserId = AbpSession.UserId;

            if (currentUserId == null)
            {
                throw new ApplicationException("User Invalid!!!");
            }

            var person = await _applicantRepository.GetAllIncluding(p => p.Address)
                    .FirstOrDefaultAsync(p => p.User.Id == currentUserId);

            if (person == null)
            {
                throw new ApplicationException("Person Not Found!!!");
            }

            return person;
        }


    }
}
