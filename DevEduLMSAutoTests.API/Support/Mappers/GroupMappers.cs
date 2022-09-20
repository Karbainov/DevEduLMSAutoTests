namespace DevEduLMSAutoTests.API.Support.Mappers
{
    public class GroupMappers
    {
        public GetAllGroupsResponse MappGetGroupByIdResponseToGetAllGroupsResponse(GetGroupByIdResponse model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GetGroupByIdResponse, GetAllGroupsResponse>());
            Mapper mapper = new Mapper(config);
            var response = mapper.Map<GetAllGroupsResponse>(model);
            response.Timetable = null;
            response.PaymentPerMonth = 0;
            response.PaymentsCount = 0;
            return response;
        }
    }
}
