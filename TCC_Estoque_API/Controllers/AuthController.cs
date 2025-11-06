using Microsoft.AspNetCore.Mvc;
using TCC_Estoque_API.DTOs;
using TCC_Estoque_API.Services;

// Define que esta classe é um Controller de API e a rota base será /api/Auth
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    // Declaração do serviço de autenticação
    private readonly IAuthService _authService;

    // Construtor: Injeção de Dependência (O sistema ASP.NET Core fornecerá a instância de AuthService)
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    // Endpoint: POST api/Auth/cadastrar
    // Responsável por receber o formulário de cadastro do MAUI.
    [HttpPost("cadastrar")]
    public async Task<IActionResult> Cadastrar([FromBody] UsuarioCadastroDTO usuarioDto)
    {
        // 1. Verifica as validações definidas no DTO (ex: [Required], [Compare], [EmailAddress])
        if (!ModelState.IsValid)
        {
            // Retorna 400 Bad Request com os erros de validação
            return BadRequest(ModelState);
        }

        //  Faz o processamento da lógica (hash de senha e salvamento) para o serviço.
        // O serviço retornará true se o cadastro for bem-sucedido, e false se o usuário/e-mail já existe.
        var cadastroSucesso = await _authService.CadastrarUsuarioAsync(usuarioDto);

        if (cadastroSucesso)
        {
            // Se o serviço retornou true, retorna 200 OK.
            return Ok(new { Message = "Usuário cadastrado com sucesso!" });
        }
        else
        {
            // Se o serviço retornou false, retorna 400 Bad Request com a mensagem de erro.
            return BadRequest(new { Message = "Nome de usuário ou e-mail já estão em uso." });
        }
    }

    // O próximo endpoint que adicionaremos será o de Login, que virá aqui:
    // [HttpPost("login")] 
    // public async Task<IActionResult> Login([FromBody] UsuarioLoginDTO loginDto) { ... }
}