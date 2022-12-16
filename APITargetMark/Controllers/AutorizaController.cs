using APITargetMark.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APITargetMark.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AutorizaController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        //instanciar IConfiguration, para acessar o json
        private readonly IConfiguration _configuration;
        //construtor

        public AutorizaController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }


        [HttpPost("/Registrar")]
        public async Task<ActionResult> PostUsuario(UsuarioDTO usuarioDTO)
        {
            var usuario = new IdentityUser
            {
                UserName = usuarioDTO.Email,
                Email = usuarioDTO.Email,
                EmailConfirmed = true
            };

            var resultado = await _userManager.CreateAsync(usuario, usuarioDTO.Senha);

            if (resultado.Succeeded)
            {
                await _signInManager.SignInAsync(usuario, isPersistent: false);
                return Ok(GeraToken(usuarioDTO));
            }
            else
            {
                return BadRequest(resultado.Errors);
            }
        }

        [HttpPost("/Login")]
        public async Task<ActionResult> Login(UsuarioDTO userInfo)
        {
            var resultado = await _signInManager.PasswordSignInAsync(userInfo.Email,
                  userInfo.Senha, isPersistent: false, lockoutOnFailure: false);


            if (resultado.Succeeded)
            {
                return Ok(GeraToken(userInfo));
            }
            else
            {
                return BadRequest(resultado);
            }
        }

        //Gerar Token
        private UsuarioToken GeraToken (UsuarioDTO userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

            };
            //gera a chave
            //aqui ele le a chave que ta la no json
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
            
            //aqui ele utiliza pra criar a senha baseado no hmac
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var exparation = _configuration["TokenConfiguration:ExpireHours"];

            var expiration = DateTime.UtcNow.AddHours(double.Parse(exparation));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["TokenConfiguration:Issuer"],
                audience: _configuration["TokenConfiguration:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            return new UsuarioToken()
            {
                Authenticated = true,
                Expiration = expiration,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Message = "OK"
            };
        }
        
    }
}
