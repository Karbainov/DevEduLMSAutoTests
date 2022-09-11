namespace AutoTestsSelenium.Support.Mappers
{
    public class UserMappers
    {
        public SwaggerSignInRequest MappRegistationModelWithRoleToSwaggerSignInRequest(RegistationModelWithRole model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RegistationModelWithRole, SwaggerSignInRequest>());
            Mapper mapper = new Mapper(config);
            var response = mapper.Map<SwaggerSignInRequest>(model);
            return response;
        }
    }
}
