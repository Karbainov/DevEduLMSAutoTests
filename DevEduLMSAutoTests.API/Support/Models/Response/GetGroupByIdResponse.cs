namespace DevEduLMSAutoTests.API.Support.Models.Response
{
    public class GetGroupByIdResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("course")]
        public CourseInGetAllGroupsResponse Course { get; set; }

        [JsonPropertyName("groupStatus")]
        public string GroupStatus { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }

        [JsonPropertyName("timetable")]
        public string Timetable { get; set; }

        [JsonPropertyName("paymentPerMonth")]
        public decimal PaymentPerMonth { get; set; }

        [JsonPropertyName("paymentsCount")]
        public int PaymentsCount { get; set; }

        [JsonPropertyName("students")]
        public List<BriefUserInfoResponse> Students { get; set; }

        [JsonPropertyName("teachers")]
        public List<BriefUserInfoResponse> Teachers { get; set; }

        [JsonPropertyName("tutors")]
        public List<BriefUserInfoResponse> Tutors { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is GetGroupByIdResponse))
            {
                return false;
            }
            CourseInGetAllGroupsResponse course = ((CreateGroupResponse)obj).Course;
            if (!course.Id.Equals(this.Course.Id) || !course.Name.Equals(this.Course.Name) || !course.IsDeleted.Equals(this.Course.IsDeleted))
            {
                return false;
            }
            List<BriefUserInfoResponse> students = ((GetGroupByIdResponse)obj).Students;
            if (students.Count != this.Students.Count)
            {
                return false;
            }
            for (int i = 0; i < students.Count; i++)
            {
                if (!students[i].Equals(this.Students[i]))
                {
                    return false;
                }
            }
            List<BriefUserInfoResponse> teachers = ((GetGroupByIdResponse)obj).Teachers;
            if (teachers.Count != this.Teachers.Count)
            {
                return false;
            }
            for (int i = 0; i < teachers.Count; i++)
            {
                if (!teachers[i].Equals(this.Teachers[i]))
                {
                    return false;
                }
            }
            List<BriefUserInfoResponse> tutors = ((GetGroupByIdResponse)obj).Tutors;
            if (tutors.Count != this.Tutors.Count)
            {
                return false;
            }
            for (int i = 0; i < tutors.Count; i++)
            {
                if (!tutors[i].Equals(this.Tutors[i]))
                {
                    return false;
                }
            }
            return obj is GetGroupByIdResponse response &&
                   Id == response.Id &&
                   Name == response.Name &&
                   GroupStatus == response.GroupStatus &&
                   StartDate == response.StartDate &&
                   EndDate == response.EndDate &&
                   Timetable == response.Timetable &&
                   PaymentPerMonth == response.PaymentPerMonth &&
                   PaymentsCount == response.PaymentsCount;
        }
    }
}
