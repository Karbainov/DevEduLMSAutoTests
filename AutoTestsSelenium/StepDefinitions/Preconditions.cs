using DevEduLMSAutoTests.API.Clients;
using DevEduLMSAutoTests.API.Support.Models.Response;

namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class Preconditions
    {
        private AuthenticationClient _authClient;
        private GroupsClient _groupsClient;
        private UsersClient _usersClient;
        private string _adminsToken;

        public Preconditions()
        {
            _authClient = new AuthenticationClient();
            _groupsClient = new GroupsClient();
            _usersClient = new UsersClient();
            _adminsToken = _authClient.AuthorizeUser(OptionsSwagger.AdminSignIn);
        }

        [Given(@"Register new users with roles")]
        public void GivenAdministratorRegistersNewUsersWithRoles(Table table)
        {
            List<RegistationModelWithRole> newUsers = table.CreateSet<RegistationModelWithRole>().ToList();
            foreach (var user in newUsers)
            {
                RegisterRequest registerRequest = user.CreateRegisterRequest(user);
                int userId = _authClient.RegisterUser(registerRequest).Id;
                switch (user.Role)
                {
                    case OptionsSwagger.RoleTeacher:
                        {
                            _usersClient.AddNewRoleToUser(userId, user.Role, _adminsToken);
                            _usersClient.DeleteUsersRole(userId, OptionsSwagger.RoleStudent, _adminsToken);
                        }
                        break;
                    case OptionsSwagger.RoleTutor:
                        {
                            _usersClient.AddNewRoleToUser(userId, user.Role, _adminsToken);
                            _usersClient.DeleteUsersRole(userId, OptionsSwagger.RoleStudent, _adminsToken);
                        }
                        break;
                    case OptionsSwagger.RoleMethodist:
                        {
                            _usersClient.AddNewRoleToUser(userId, user.Role, _adminsToken);
                            _usersClient.DeleteUsersRole(userId, OptionsSwagger.RoleStudent, _adminsToken);
                        }
                        break;
                    case OptionsSwagger.RoleManager:
                        {
                            _usersClient.AddNewRoleToUser(userId, user.Role, _adminsToken);
                            _usersClient.DeleteUsersRole(userId, OptionsSwagger.RoleStudent, _adminsToken);
                        }
                        break;
                    case OptionsSwagger.RoleAdmin:
                        {
                            _usersClient.AddNewRoleToUser(userId, user.Role, _adminsToken);
                            _usersClient.DeleteUsersRole(userId, OptionsSwagger.RoleStudent, _adminsToken);
                        }
                        break;
                    case OptionsSwagger.RoleStudent:
                        {
                        }
                        break;
                    default:
                        {
                            throw new ArgumentOutOfRangeException("This role does not exist.");
                        }
                        break;
                }
            }
        }

        [Given(@"Create new groups")]
        public void GivenAdminCreateNewGroups(Table table)
        {
            List<CreateGroupRequest> groups = table.CreateSet<CreateGroupRequest>().ToList();
            foreach (var group in groups)
            {
                if (group.CourseName != null)
                {
                    group.CourseId = OptionsSwagger.Courses[group.CourseName];
                }
                _groupsClient.CreateNewGroup(group, _adminsToken);
            }
        }

        [Given(@"Add users to group ""([^""]*)""")]
        public void GivenAdminAddUsersToGroup(string groupName, Table table)
        {
            int groupId = GetGroupIdByName(groupName);
            List<RegistationModelWithRole> users = table.CreateSet<RegistationModelWithRole>().ToList();
            foreach (var user in users)
            {
                int userId = GetUsersIdByFullName(user.FirstName, user.LastName);
                _groupsClient.AddUserToGroup(groupId, userId, user.Role, _adminsToken);
            }
        }

        private int GetGroupIdByName(string groupName)
        {
            int groupId = 0;
            List<GetAllGroupsResponse> allGroups = _groupsClient.GetAllGroups(_adminsToken);
            foreach (var group in allGroups)
            {
                if (group.Name == groupName)
                {
                    groupId = group.Id;
                    break;
                }
            }
            if (groupId == 0)
            {
                throw new ArgumentOutOfRangeException("There is no group with this name");
            }
            else
            {
                return groupId;
            }
        }

        private int GetUsersIdByFullName(string usersFirstName, string usersLastName)
        {
            int userId = 0;
            List<GetAllUsersResponse> users = _usersClient.GetAllUsers(_adminsToken);
            foreach (var user in users)
            {
                if (user.FirstName == usersFirstName && user.LastName == usersLastName)
                {
                    userId = user.Id;
                }
            }
            if (userId == 0)
            {
                throw new ArgumentOutOfRangeException("No such user");
            }
            else
            {
                return userId;
            }
        }
    }
}