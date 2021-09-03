using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Contracts;
using Projeto.Application.Models.Usuarios;
using Projeto.Presentation.Api.Configurations;

namespace Projeto.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //atributo
        private readonly IUsuarioApplicationService usuarioApplicationService;
        private readonly TokenService tokenService;

        //construtor para injeção de dependência
        public LoginController(IUsuarioApplicationService usuarioApplicationService, TokenService tokenService)
        {
            this.usuarioApplicationService = usuarioApplicationService;
            this.tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Post(UsuarioAutenticacaoModel model)
        {
            try
            {
                //buscar o usuario pelo email e senha
                var usuario = usuarioApplicationService.GetByEmailAndSenha(model);

                //verificar se o usuário foi encontrado
                if(usuario != null)
                {
                    var token = tokenService.GenerateToken(model.Email);
                    return Ok(token);
                }
                else
                {
                    return StatusCode(403, "Usuário não encontrado. Acesso Negado.");
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
