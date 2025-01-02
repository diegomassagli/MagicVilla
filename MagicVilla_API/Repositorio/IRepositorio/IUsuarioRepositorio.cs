using MagicVilla_API.Modelos;
using MagicVilla_API.Modelos.Dto;

namespace MagicVilla_API.Repositorio.IRepositorio
{
    public interface IUsuarioRepositorio
    {
        bool IsUsuarioUnico(string userName);  //metodo que recibe UserName y devuelve true o false si se repite
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO); //recibe un LoginRequestDTO y retorna un LoginResponseDTO
        Task<Usuario> Registrar(RegistroRequestDTO registroRequestDTO); //retorna modelo de tipo Usuario y recibe un RegistroRequestDTO
    }
}
