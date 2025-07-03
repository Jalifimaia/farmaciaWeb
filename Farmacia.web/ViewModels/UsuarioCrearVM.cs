using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Farmacia.Entidades;

public class UsuarioCrearVM
{
    public Usuario Usuario { get; set; } = new Usuario
    { 
        Rol= new Rol()  
    };
    public List<SelectListItem> Roles { get; set; }
}
