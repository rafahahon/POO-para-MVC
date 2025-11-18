using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Sistema_de_VeiculosDBFirst.Models;

[Table("TabelaVeiculo")]
public partial class TabelaVeiculo
{
    [Key]
    public int Id { get; set; }

    public string Modelo { get; set; } = null!;

    public int Ano { get; set; }

    [StringLength(8)]
    public string TipoVeiculo { get; set; } = null!;
}
