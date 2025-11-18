using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Sistema_de_PersonagensDBFirst.Models;

[Table("TabelaPersonagem")]
public partial class TabelaPersonagem
{
    [Key]
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public int Nivel { get; set; }

    [StringLength(13)]
    public string Tipo { get; set; } = null!;
}
