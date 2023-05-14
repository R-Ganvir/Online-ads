using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineAds.Models;

[Table("tbl_product")]
[Index("ProFkCat", Name = "IX_FK__tbl_produ__pro_f__2E1BDC42")]
[Index("ProFkUser", Name = "IX_FK__tbl_produ__pro_f__2F10007B")]
public partial class TblProduct
{
    [Key]
    [Column("pro_id")]
    public int ProId { get; set; }

    [Column("pro_name")]
    [StringLength(50)]
    public string ProName { get; set; } = null!;

    [Column("pro_image")]
    public string ProImage { get; set; } = null!;

    [Column("pro_des")]
    public string ProDes { get; set; } = null!;

    [Column("pro_price")]
    public int? ProPrice { get; set; }

    [Column("pro_fk_cat")]
    public int? ProFkCat { get; set; }

    [Column("pro_fk_user")]
    public int? ProFkUser { get; set; }

    [ForeignKey("ProFkCat")]
    [InverseProperty("TblProducts")]
    public virtual TblCategory? ProFkCatNavigation { get; set; }

    [ForeignKey("ProFkUser")]
    [InverseProperty("TblProducts")]
    public virtual TblUser? ProFkUserNavigation { get; set; }
}
