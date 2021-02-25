using System.Threading.Tasks;
using CadeMedicoAPI.Models;

namespace CadeMedicoAPI.Data
{//interface não implementa metodos, apenas assinatura
    public interface IRepository
    {
         void Add<T>(T entity) where T : class; 
         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveChangesAsync();
         
         
         Task<MedicoModel[]> GetAllMedicoModelAsync(bool includeMedico);
         Task<MedicoModel[]> GetMedicoModelsByEspecialidadeId(int EspecialidadeId, bool includeEspecialidade);
         Task<MedicoModel> GetMedicoModelById(int medicoId,bool includeCidade);

         //Cidade
         Task<CidadeModel[]> GetAllCidadeModelAsync(bool includeCidade);
         Task<CidadeModel> GetCidadeModelById(int cidadeId,bool includeMedico);
        //Usuário 

        Task<UsuarioModel[]> GetAllUsuarioModelAsync(bool includeUsuario);
        Task<UsuarioModel> GetUsuarioModelById(int usuarioId, bool includeUsuario);
                          
    }
}