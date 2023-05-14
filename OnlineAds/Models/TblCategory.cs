using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineAds.Models;

[Table("tbl_category")]
[Index("CatFkAd", Name = "IX_FK__tbl_categ__cat_f__276EDEB3")]
public partial class TblCategory
{
    [Key]
    [Column("cat_id")]
    public int CatId { get; set; }

    [Column("cat_name")]
    [StringLength(50)]
    public string CatName { get; set; } = null!;

    [Column("cat_image")]
    public string CatImage { get; set; } = null!;
    [NotMapped]
    public IFormFile? CatImagefile { get; set; } = null!;

    [Column("cat_fk_ad")]
    public int? CatFkAd { get; set; }

    [Column("cat_status")]
    public int? CatStatus { get; set; }

    [Column("cat_subcatname")]
    [StringLength(20)]
    public string? CatSubcatname { get; set; }

    [ForeignKey("CatFkAd")]
    [InverseProperty("TblCategories")]
    public virtual TblAdmin? CatFkAdNavigation { get; set; }

    [InverseProperty("ProFkCatNavigation")]
    public virtual ICollection<TblProduct> TblProducts { get; } = new List<TblProduct>();
}
