namespace DariaVarya.Web.App.Models
{
    public class Approval : BaseModel
    {
        public long? DocId { get; set; }
        public string DocNo { get; set; }
        public int Level { get; set; }
        public string ApproverUsername{ get; set; }
        public string ApproverName { get; set; }
        public string ApproverEmail { get; set; }
        public DateTime? ApproveDate { get; set; }
    }

}
