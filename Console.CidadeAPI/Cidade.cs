﻿using WebAPI.Cidades;

namespace WebAPI.Cidades.Models;

internal class Cidade
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Estado { get; set;}
}
