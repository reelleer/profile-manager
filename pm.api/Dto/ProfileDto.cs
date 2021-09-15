using Pm.Api.Models;
using System;
using System.Collections.Generic;

namespace Pm.Api.Dto
{
	public record ProfileDto : ProfileBaseDto
	{
		public ProfileDto(
			string id,
			PersonalInfoDto personalInfo,
			PollDto poll,
			IList<StudyItemEditDto> studies
		) : base(personalInfo, poll)
		{
			Id = id;
			Studies = studies;
		}

		public string Id { get; init; }

		public IList<StudyItemEditDto> Studies { get; init; }

	}

	public abstract record ProfileBaseDto(PersonalInfoDto PersonalInfo, PollDto Poll);

	public record ProfileCreateDto : ProfileBaseDto {
		public ProfileCreateDto(
			PersonalInfoDto personalInfo,
			PollDto poll,
			IList<StudyItemCreateDto> studies
		) : base(personalInfo, poll)
		{
			Studies = studies;
		}

		public IList<StudyItemCreateDto> Studies { get; init; }
	}

	public record PersonalInfoDto(
		string Name,
		string LastName,
		DateTime? BirthDate,
		string BirthPlace,
		string Country,
		string Address,
		string Phone,
		string Email,
		string Twitter,
		string Facebook,
		string Linkedin,
		string Instagram,
		byte Working
	);

	public record PollDto(
		string Opportunities,
		string Activities,
		byte Contacts,
		bool Follower
	);

	public record StudyItemCreateDto(
		byte Type,
		string Country,
		string University,
		string Study,
		DateTime Begin,
		DateTime? End
	);

	public record StudyItemEditDto : StudyItemCreateDto {
		public StudyItemEditDto(
			byte type,
			string country,
			string university,
			string study,
			DateTime begin,
			DateTime? end,
			int id
		) : base(type, country, university, study, begin, end)
		{
			Id = id;
		}

		public int Id { get; init; }
	}

	public static class DtoConveter {
		public static StudyItem GetStudyItem(StudyItemCreateDto dto)
        {
			return new StudyItem()
			{
				Begin = dto.Begin,
				Country = dto.Country,
				End = dto.End,
				Study = dto.Study,
				Type = dto.Type,
				University = dto.University
			};
		}
		public static StudyItem GetStudyItem(StudyItemEditDto dto)
		{
			var study = GetStudyItem((StudyItemCreateDto)dto);
			study.StudyId = dto.Id;
			return study;
		}

	}
}

/*
 {
	"personalInfo": {
		"name": "Rolando",
		"lastName": "Espinosa",
		"birthDate": "2021-09-12",
		"birthPlace": "Managua",
		"country": "Nicaragua",
		"address": "Km 10 c. a Masaya 320 mts E.",
		"phone": "1234568",
		"email": "reel.leer@gmail.com",
		"twitter": "@reel.leer",
		"facebook": "",
		"linkedin": "",
		"instagram": "",
		"working": "2"
	},
	"poll": {
		"opportunities": "Todavía no me ha brindado ninguna oportunidad.",
		"activities": "Quisiera una variedad de actividades, pero no me ocurre ninguna.",
		"contacts": 0,
		"follower": false
	},
	"studies": [{
		"type": "1",
		"country": "Nicaragua",
		"university": "Universidad Católica Redemptoris Mater",
		"study": "Ingeniería en Sistemas de Información",
		"begin": "2021-09-11T00:00:00.000Z",
		"end": "2021-09-11T00:00:00.000Z",
		"id": -1631380476635
	}]
}
*/