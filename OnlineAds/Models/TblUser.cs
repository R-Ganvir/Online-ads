using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineAds.Models;

[Table("tbl_user")]
public partial class TblUser
{
    [Key]
    [Column("u_id")]
    public int UId { get; set; }

    [Column("u_password")]
    [StringLength(9)]
    public string UPassword { get; set; } = null!;

    [Column("u_name")]
    [StringLength(15)]
    public string UName { get; set; } = null!;

    [Column("u_dateofbirth", TypeName = "date")]
    public DateTime UDateofbirth { get; set; }

    [Column("u_gender")]
    [StringLength(7)]
    public string UGender { get; set; } = null!;

    [Column("u_city")]
    [StringLength(10)]
    public string UCity { get; set; } = null!;

    [Column("u_state")]
    [StringLength(15)]
    public string UState { get; set; } = null!;

    [Column("u_email")]
    [StringLength(30)]
    public string UEmail { get; set; } = null!;

    [Column("u_image")]
    public string UImage { get; set; } = null!;

    [Column("u_contact")]
    [StringLength(10)]
    public string UContact { get; set; } = null!;

    [InverseProperty("ProFkUserNavigation")]
    public virtual ICollection<TblProduct> TblProducts { get; } = new List<TblProduct>();
}
