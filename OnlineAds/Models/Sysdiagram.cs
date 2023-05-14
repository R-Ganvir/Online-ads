using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineAds.Models;

[Table("sysdiagrams")]
public partial class Sysdiagram
{
    [Column("name")]
    [StringLength(128)]
    public string Name { get; set; } = null!;

    [Column("principal_id")]
    public int PrincipalId { get; set; }

    [Key]
    [Column("diagram_id")]
    public int DiagramId { get; set; }

    [Column("version")]
    public int? Version { get; set; }

    [Column("definition")]
    public byte[]? Definition { get; set; }
}
