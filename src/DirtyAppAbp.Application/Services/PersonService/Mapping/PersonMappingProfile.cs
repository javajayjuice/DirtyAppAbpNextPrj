using AutoMapper;
using DirtyAppAbp.Authorization.Users;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.Helpers;
using DirtyAppAbp.Services.PersonService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.PersonService.Mapping
{
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<Person, PersonGetDto>()
                .ForMember(x => x.UserId, m => m.MapFrom(x => x.User != null ? x.User.Id : (long?)null))
                .ForMember(x => x.AddessId, m => m.MapFrom(x => x.Address != null ? x.Address.Id : (Guid?)null))
                .ForMember(x => x.NatureOfDisability, m => m.MapFrom(x => x.NatureOfDisability.GetEnumDescription()))
                .ForMember(x => x.Gender, m => m.MapFrom(x => x.Gender.GetEnumDescription()))
                .ForMember(x => x.HomeLanguage, m => m.MapFrom(x => x.HomeLanguage.GetEnumDescription()))
                .ForMember(x => x.PopulationGroup, m => m.MapFrom(x => x.PopulationGroup.GetEnumDescription()))
                .ForMember(x => x.Title, m => m.MapFrom(x => x.Title.GetEnumDescription()))
                .ForMember(x => x.Address, m => m.MapFrom(x => x.Address != null ? x.Address : null));

            CreateMap<PersonPostDto, User>()
                .ForMember(x => x.Name, m => m.MapFrom(x => x.Name))
                .ForMember(x => x.PhoneNumber, m => m.MapFrom(x => x.PhoneNumber))
                .ForMember(x => x.EmailAddress, m => m.MapFrom(x => x.EmailAddress))
                .ForMember(x => x.FullName, m => m.MapFrom(x => x.Name + " " + x.Surname))
                .ForMember(x => x.Password, m => m.MapFrom(x => x.Password))
                .ForMember(x => x.Surname, m => m.MapFrom(x => x.Surname))
                .ForMember(x => x.UserName, m => m.MapFrom(x => x.Name + x.Surname.Substring(0, 4)));

            CreateMap<PersonPostDto, User>()
                .ForMember(e => e.Id, d => d.Ignore());

            CreateMap<PersonPostDto, Person>()
                .ForMember(e => e.Id, d => d.Ignore());

            CreateMap<PersonPostDto, Address>()
                .ForMember(e => e.Id, d => d.Ignore());

            CreateMap<PersonPostDto, Parent>()
                .ForMember(e => e.Id, d => d.Ignore());
        }
    }
}
