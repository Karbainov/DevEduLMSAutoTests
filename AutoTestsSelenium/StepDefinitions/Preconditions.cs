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
        private TasksClient _tasksClient;
        private HomeworksClient _homeworksClient;
        private StudentHomeworksClient _studentHomeworksClient;
        private string _adminsToken;

        public Preconditions()
        {
            _authClient = new AuthenticationClient();
            _groupsClient = new GroupsClient();
            _usersClient = new UsersClient();
            _tasksClient = new TasksClient();
            _homeworksClient = new HomeworksClient();
            _studentHomeworksClient = new StudentHomeworksClient();
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

        [Given(@"Create new task for group ""([^""]*)""")]
        public void GivenCreateNewTasks(string groupName, Table table)
        {
            int groupId = GetGroupIdByName(groupName);
            List<AddTasksByTeacherRequest> tasks = table.CreateSet<AddTasksByTeacherRequest>().ToList();
            foreach (var task in tasks)
            {
                task.GroupId = groupId;
                _tasksClient.CreateTask(task, _adminsToken);
            }
        }

        [Given(@"Add new homeworks for group ""([^""]*)"" task ""([^""]*)""")]
        public void GivenAddNewHomeworks(string groupName, string taskName, Table table)
        {
            int groupId = GetGroupIdByName(groupName);
            int taskId = GetTaskIdByName(taskName);
            List<AddHomeworkRequest> homeworks = table.CreateSet<AddHomeworkRequest>().ToList();
            foreach (var homework in homeworks)
            {
                _homeworksClient.AddHomework(homework, groupId, taskId, _adminsToken);
            }
        }

        [Given(@"Students authorize and send homework for group ""([^""]*)"" task ""([^""]*)""")]
        public void GivenSendHomeworkByStudent(string groupName, string taskName, Table table)
        {
            int homeworkId = GetHomeworkIdByGroupNameAndTaskName(groupName, taskName);
            List<SignInModelWithStudentHomeworkRequest> studentsHomeworks = table.CreateSet<SignInModelWithStudentHomeworkRequest>().ToList();
            foreach (var student in studentsHomeworks)
            {
                SignInRequest studentSignIn = student.CreateSignInRequest(student);
                string token = _authClient.AuthorizeUser(studentSignIn);
                AddHomeworkByStudentRequest homeworkRequest = student.CreateAddHomeworkByStudentRequest(student);
                homeworkRequest.HomeworkId = homeworkId;
                _studentHomeworksClient.AddHomework(homeworkRequest, token);
            }
        }

        [Given(@"Check homeworks in group ""([^""]*)"" task ""([^""]*)""")]
        public void GivenCheckHomeworks(string groupName, string taskName, Table table)
        {
            int studentHomeworkId = 0;
            List<StudentsHomeworkResultModelWithSeparateName> students = table.CreateSet<StudentsHomeworkResultModelWithSeparateName>().ToList();
            for (int i=0; i < students.Count; i++)
            {
                if (students[i].Result == "Сдано")
                {
                    studentHomeworkId = GetStudentHomeworkIdByUserIdAndHomeworkId(groupName, taskName, students[i].FirstName, students[i].LastName);
                    _studentHomeworksClient.Approve(studentHomeworkId, _adminsToken);
                }
                else if (students[i].Result == "Не сдано")
                {
                    studentHomeworkId = GetStudentHomeworkIdByUserIdAndHomeworkId(groupName, taskName, students[i].FirstName, students[i].LastName);
                    _studentHomeworksClient.DeclineHomework(studentHomeworkId, _adminsToken);
                }
            }
        }
        
        private int GetStudentHomeworkIdByUserIdAndHomeworkId(string groupName, string taskName, string firstName, string lastName)
        {
            int homeworkId = GetHomeworkIdByGroupNameAndTaskName(groupName, taskName);
            int studentHomeworkId = 0;
            int userId = GetUsersIdByFullName(firstName, lastName);
            List<GetStudentHomeworkByUserIdResponse> studentsHomeworks = _studentHomeworksClient.GetStudentHomeworkByStudentId(userId, _adminsToken);
            foreach (var studentHomework in studentsHomeworks)
            {
                if (studentHomework.Homework.TaskInHW.Name == taskName && studentHomework.Homework.Id == homeworkId)
                {
                    studentHomeworkId = studentHomework.Id;
                }
            }
            if (studentHomeworkId == 0)
            {
                throw new ArgumentOutOfRangeException("There is no searching student homework");
            }
            else
            {
                return studentHomeworkId;
            }
        }
        private int GetHomeworkIdByGroupNameAndTaskName(string groupName, string taskName)
        {
            int homeworkId = 0;
            int groupId = GetGroupIdByName(groupName);
            List<GetHomeworkByGroupIdResponse> allHomeworks = _homeworksClient.GetAllHomeworksByGroupId(groupId, _adminsToken);
            foreach (var homework in allHomeworks)
            {
                if (homework.TaskInHW.Name == taskName)
                {
                    homeworkId = homework.Id;
                    break;
                }
            }
            if (homeworkId == 0)
            {
                throw new ArgumentOutOfRangeException("There is no task with this name");
            }
            else
            {
                return homeworkId;
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

        private int GetTaskIdByName(string taskName)
        {
            int taskId = 0;
            List<TaskResponse> tasks = _tasksClient.GetAllTasks(_adminsToken);
            foreach (var task in tasks)
            {
                if (task.Name == taskName)
                {
                    taskId = task.Id;
                    break;
                }
            }
            if (taskId == 0)
            {
                throw new ArgumentOutOfRangeException("There is no task with this name");
            }
            else
            {
                return taskId;
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