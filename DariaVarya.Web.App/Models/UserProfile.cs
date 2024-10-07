namespace DariaVarya.Web.App.Models
{
    public class UserProfileModel : BaseModel
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ManagerUsername { get; set; }
        public string ManagerName { get; set; }
        public string ManagerEmail { get; set; }
        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Role { get; set; }
    }
}
