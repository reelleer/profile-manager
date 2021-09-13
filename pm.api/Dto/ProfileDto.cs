using System;
using System.Collections.Generic;

namespace Pm.Api.Dto
{
	public record ProfileDto : ProfileNewDto
	{
		public ProfileDto(
			string id,
			PersonalInfoDto personalInfo,
			PollDto poll,
			IList<StudyItemDto> studies
		) : base(personalInfo, poll, studies)
		{
			Id = id;
		}

		public string Id { get; init; }
	}

	public record ProfileNewDto (
		PersonalInfoDto PersonalInfo,
		PollDto Poll,
		IList<StudyItemDto> Studies
	);

	public record PersonalInfoDto (
		string Name,
		string LastName,
		DateTime BirthDate,
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

	public record PollDto (
		string Opportunities,
		string Activities,
		byte Contacts,
		bool Follower
	);

	public record StudyItemDto (
		byte Type,
		string Country,
		string University,
		string Study,
		DateTime Begin,
		DateTime? End,
		int Id
	);
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