using System.Threading.Tasks;
using CadeMedicoAPI.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CadeMedicoAPI.Data
{
  public class Repository : IRepository
  {
    private readonly DataContext _context;
    public Repository(DataContext context)
    {
      _context = context;
    }
    public void Add<T>(T entity) where T : class
    {
      _context.Add(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
      _context.Remove(entity);
    }
    public void Update<T>(T entity) where T : class
    {
      _context.Update(entity);
    }
    public async Task<bool> SaveChangesAsync()
    {
      return (await _context.SaveChangesAsync()) > 0;
    }

    public async Task<MedicoModel[]> GetAllMedicoModelAsync(bool includeMedico = false)
    {
      IQueryable<MedicoModel> query = _context.Medicos;
      if (includeMedico)
      {
        //ThenInclude = tabela do medicocidade 
        query = query.Include(mc => mc.MedicoCidade).ThenInclude(c => c.Cidade).Include(me => me.MedicoEspecialidades).ThenInclude(e=> e.Especialidade);
      }
      //acha a cidade a partir daqui 
      query = query.AsNoTracking().OrderBy(m => m.Id);
      return await query.ToArrayAsync();

    }
    public async Task<MedicoModel[]> GetMedicoModelsByEspecialidadeId(int EspecialidadeId, bool includeEspecialidade)
    {
      IQueryable<MedicoModel> query = _context.Medicos;
      if (includeEspecialidade)
      {
        query = query.Include(me => me.MedicoEspecialidades).ThenInclude(e => e.Especialidade);
      }
      query = query.AsNoTracking().OrderBy(medico => medico.Id).Where(medico => medico.MedicoEspecialidades.Any(me => me.EspecialidadeId == EspecialidadeId));
      return await query.ToArrayAsync();
    }

    public async Task<MedicoModel> GetMedicoModelById(int medicoId, bool includeCidade)
    {
      IQueryable<MedicoModel> query = _context.Medicos;
      if(includeCidade){
        query = query.AsNoTracking()
        .Include(c => c.MedicoCidade)
        .ThenInclude(mc => mc.Cidade)
        .Include(me=> me.MedicoEspecialidades)
        .ThenInclude(e=> e.Especialidade);

      }
      query = query.AsNoTracking().OrderBy(medico =>medico.Id).Where(medico =>medico.Id == medicoId);
      return await query.FirstOrDefaultAsync();
    }

    public async Task<CidadeModel[]> GetAllCidadeModelAsync(bool includeCidade = false){
    IQueryable<CidadeModel> query = _context.Cidades;
    if(includeCidade){
      query = query.Include(mc=> mc.MedicoCidade).ThenInclude(m => m.Medico)
      .ThenInclude(me => me.MedicoEspecialidades).ThenInclude(e => e.Especialidade);

    }
    query = query.AsNoTracking().OrderBy(c => c.Id);
    return await query.ToArrayAsync();
    }
    public async Task<CidadeModel> GetCidadeModelById(int cidadeId,bool includeMedico){
      IQueryable<CidadeModel> query = _context.Cidades;
      if(includeMedico){
        query = query.Include(mc => mc.MedicoCidade).ThenInclude(m => m.Medico).ThenInclude(me => me.MedicoEspecialidades).ThenInclude(e=> e.Especialidade);
      }
      query = query.AsNoTracking().OrderBy(c => c.Id).Where(c => c.Id == cidadeId);
      return await query.FirstOrDefaultAsync();
    }

//copiar


    //usuario
    
      public async Task<UsuarioModel[]> GetAllUsuarioModelAsync(bool includeUsuario = false)
        {
            IQueryable<UsuarioModel> query = _context.Usuarios;
 
            if(includeUsuario){
                query = query.Include(u => u.Usuario);
            }
            query = query.AsNoTracking().OrderBy(u =>u.Id);
 
            return await query.ToArrayAsync();
        }
      
        public async Task<UsuarioModel> GetUsuarioModelById(int usuarioId, bool includeUsuario)
        {
            IQueryable<UsuarioModel> query = _context.Usuarios;
            if(includeUsuario){
                query = query.Include(u => u.Usuario);
            }
 
            query = query.AsNoTracking().OrderBy(usuario => usuario.Id);
 
            return await query.FirstOrDefaultAsync();
        }
    



  }

}