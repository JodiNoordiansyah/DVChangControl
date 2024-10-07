using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DariaVarya.Web.App.Models
{
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username{ get; set; }
        public string Password{ get; set; }
        //public long? UserId { get; set; }

        //[ForeignKey("UserId")]
        //public UserProfileModel UserProfileModel { get; set; }
    }


}
