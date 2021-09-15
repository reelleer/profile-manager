using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pm.Api.Dal;
using Pm.Api.Dto;
using Pm.Api.helpers;
using Pm.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pm.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ProfilesController : ControllerBase
    {
        private readonly ILogger<ProfilesController> _logger;
        private readonly ErasmusContext _context;

        public ProfilesController(ILogger<ProfilesController> logger, ErasmusContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(string id)
        {
            Profile profile = GetProfle(id);

            if (profile is null) NotFound();

            var personalInfo = new PersonalInfoDto(
                profile.Name,
                profile.LastName,
                profile.BirthDate,
                profile.BirthPlace,
                profile.Country,
                profile.Address,
                profile.Phone,
                profile.Email,
                profile.Twitter,
                profile.Facebook,
                profile.Linkedin,
                profile.Instagram,
                profile.Working
            );

            var poll = new PollDto(
                profile.Poll.Opportunities,
                profile.Poll.Activities,
                profile.Poll.Contacts,
                profile.Poll.Follower
            );

            var stuides = GetStudiesDto(profile.Studies.ToList());

            var dto = new ProfileDto(profile.ProfileId.ToString(), personalInfo, poll, stuides);

            return new JsonResult(dto);
        }

        private Profile GetProfle(string id)
        {
            return _context.Profiles
                            .Include(p => p.Poll)
                            .Include(p => p.Studies)
                            .Where(p => p.ProfileId == Guid.Parse(id))
                            .FirstOrDefault();
        }

        [HttpPost]
        public ProfileDto Post([FromBody]ProfileCreateDto create)
        {
            var entity = new Profile()
            {
                Address = create.PersonalInfo.Address,
                BirthDate = create.PersonalInfo.BirthDate,
                BirthPlace = create.PersonalInfo.BirthPlace,
                Country = create.PersonalInfo.Country,
                Email = create.PersonalInfo.Email,
                Facebook = create.PersonalInfo.Facebook,
                Instagram = create.PersonalInfo.Instagram,
                LastName = create.PersonalInfo.LastName,
                Linkedin = create.PersonalInfo.Linkedin,
                Name = create.PersonalInfo.Name,
                Phone = create.PersonalInfo.Phone,
                Twitter = create.PersonalInfo.Twitter,
                Working = create.PersonalInfo.Working
            };

            entity.Poll = new()
            {
                Activities = create.Poll.Activities,
                Contacts = create.Poll.Contacts,
                Follower = create.Poll.Follower,
                Opportunities = create.Poll.Opportunities
            };

            List<StudyItem> studies =
                GetStudyItems(
                    create.Studies,
                    dto => DtoConveter.GetStudyItem(dto)
                );

            entity.Studies = studies;

            _context.Profiles.Add(entity);

            _context.SaveChanges();

            List<StudyItemEditDto> studiesDto = GetStudiesDto(entity.Studies.ToList());

            return new ProfileDto(
                entity.ProfileId.ToString(),
                create.PersonalInfo,
                create.Poll,
                studiesDto
            );
        }

        private static List<StudyItem> GetStudyItems<T>(IList<T> items, Func<T,StudyItem> create)
        {
            var studies = new List<StudyItem>();

            foreach (var item in items)
            {
                var study = create(item);

                studies.Add(study);
            }

            return studies;
        }

        private static List<StudyItemEditDto> GetStudiesDto(IList<StudyItem> studies)
        {
            var studiesDto = new List<StudyItemEditDto>();

            foreach (var item in studies)
            {
                var studyDto = new StudyItemEditDto(
                    item.Type,
                    item.Country,
                    item.University,
                    item.Study,
                    item.Begin,
                    item.End,
                    item.StudyId
                );

                studiesDto.Add(studyDto);
            }

            return studiesDto;
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(string id, ProfileDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var profile = GetProfle(id);

            if (profile is null) return NotFound();

            profile.Address = dto.PersonalInfo.Address;
            profile.BirthDate = dto.PersonalInfo.BirthDate;
            profile.BirthPlace = dto.PersonalInfo.BirthPlace;
            profile.Country = dto.PersonalInfo.Country;
            profile.Email = dto.PersonalInfo.Email;
            profile.Facebook = dto.PersonalInfo.Facebook;
            profile.Instagram = dto.PersonalInfo.Instagram;
            profile.LastName = dto.PersonalInfo.LastName;
            profile.Linkedin = dto.PersonalInfo.Linkedin;
            profile.Name = dto.PersonalInfo.Name;
            profile.Phone = dto.PersonalInfo.Phone;
            profile.Twitter = dto.PersonalInfo.Twitter;
            profile.Working = dto.PersonalInfo.Working;

            profile.Poll.Activities = dto.Poll.Activities;
            profile.Poll.Contacts = dto.Poll.Contacts;
            profile.Poll.Follower = dto.Poll.Follower;
            profile.Poll.Opportunities = dto.Poll.Opportunities;

            foreach(var item in profile.Studies)
            {
                var update = dto.Studies.FirstOrDefault(s => item.StudyId == s.Id);

                if (update is null)
                    profile.Studies.Remove(item);
                else
                {
                    item.Begin = update.Begin;
                    item.Country = update.Country;
                    item.End = update.End;
                    item.Study = update.Study;
                    item.University = update.University;

                    dto.Studies.Remove(update);
                }
            }

            var newStudies = GetStudyItems(
                dto.Studies,
                dto => DtoConveter.GetStudyItem(dto)
            );

            newStudies.ForEach(item => profile.Studies.Add(item));

            _context.SaveChanges();

            return NoContent();
        }
    }
}
