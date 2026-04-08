using FCG.Application.Requests.Usuarios;
using FCG.Application.Responses.Usuarios;

namespace FCG.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioResponse> CriarAsync(CriarUsuarioRequest request);
    }
}

