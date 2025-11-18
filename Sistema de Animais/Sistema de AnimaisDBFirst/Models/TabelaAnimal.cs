using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Sistema_de_AnimaisDBFirst.Models;

[Table("TabelaAnimal")]
public partial class TabelaAnimal
{
    [Key]
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    [StringLength(8)]
    public string Tipo { get; set; } = null!;
}
