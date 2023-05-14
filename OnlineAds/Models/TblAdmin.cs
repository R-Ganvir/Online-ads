using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineAds.Models;

[Table("tbl_admin")]
public partial class TblAdmin
{
    [Key]
    [Column("ad_id")]
    public int AdId { get; set; }

    [Column("ad_username")]
    [StringLength(50)]
    public string AdUsername { get; set; } = null!;

    [Column("ad_password")]
    [StringLength(50)]
    public string AdPassword { get; set; } = null!;

    [InverseProperty("CatFkAdNavigation")]
    public virtual ICollection<TblCategory> TblCategories { get; } = new List<TblCategory>();
}
