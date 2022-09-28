namespace DevEduLMSAutoTests.API.Support.Mappers
{
    public class GroupMappers
    {
        public CreateGroupResponse MappGetGroupByIdResponseToGetAllGroupsResponse(GetGroupByIdResponse model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GetGroupByIdResponse, CreateGroupResponse>());
            Mapper mapper = new Mapper(config);
            var response = mapper.Map<CreateGroupResponse>(model);
            response.Timetable = null;
            response.PaymentPerMonth = 0;
            response.PaymentsCount = 0;
            return response;
        }
    }
}