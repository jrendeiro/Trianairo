using AutoMapper;

public class SaintProfile : Profile
{
	public SaintProfile()
	{
		CreateMap<Saint, SaintDto>()
			.ForMember(Dto => Dto.latestEvent, opt => opt.MapFrom(saint => saint.canonizedYear != null ? saint.canonizedYear : saint.beatifiedYear));
	}
}