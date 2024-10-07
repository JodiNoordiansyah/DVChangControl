using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DariaVarya.Web.App.Models
{

    public class ChangeControl : BaseModel
    {
        [Display(Name = "Document No")]
        public string? DocumentNo { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? Date { get; set; } 
        [Display(Name = "Departemen Creator / Inisiator")]
        public string? DepartemenCreator { get; set; } 
        public string? Pabrik { get; set; } 
        [Display(Name = "Nama Produk / Bahan Baku")]
        public string? ProductName { get; set; } 
        public string? Deskripsi { get; set; }
        public string? Status { get; set; }
        public string? Notes { get; set; }
        public List<Department> DepartemenLain { get; set; }
    }

    public class ChangeControlViewModel(ChangeControl cc) {
        public long? Id { get; set; } = cc.Id;
        [Display(Name = "Document No")]
        public string DocumentNo { get; set; } = cc.DocumentNo;
        public DateTime? Date { get; set; } = cc.Date;
        [Display(Name = "Departemen Creator / Inisiator")]
        public string? DepartemenCreator { get; set; } = cc.DepartemenCreator;
        public string? Pabrik { get; set; } = cc.Pabrik;
        [Display(Name = "Nama Produk / Bahan Baku")]
        public string? ProductName { get; set; } = cc.ProductName;
        public string? Deskripsi { get; set; } = cc.Deskripsi;
        public string? Status { get; set; } = cc.Status;
        public string? Role { get; set; }
        public List<Department> DepartemenLain { get; set; } = cc.DepartemenLain;
        public string CreatedBy { get; set; } = cc.CreatedBy;
        public DateTime CreatedDate { get; set; } = cc.CreatedDate;
        public string UpdatedBy { get; set; } = cc.UpdatedBy;
        public DateTime? UpdatedDate { get; set; } = cc.UpdatedDate;
        public bool IsDocumentApproval; 
        public bool IsCreator;
        public int Level;
        public string? Notes { get; set; } = cc.Notes;
    }

    public class Department : BaseModel
    {
        public long? DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        [ForeignKey("ChangeControlId")]
        public long? ChangeControlId { get; set; }

        public ChangeControl ChangeControl { get; set; }
    }
}
