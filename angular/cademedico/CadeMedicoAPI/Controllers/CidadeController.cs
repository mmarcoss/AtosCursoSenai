using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CadeMedicoAPI.Models;
using CadeMedicoAPI.Data;
namespace CadeMedicoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CidadeController : ControllerBase
    {
        private readonly IRepository _repo;
        public CidadeController(IRepository repo){
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get(){
            try
            {
                var result = await _repo.GetAllCidadeModelAsync(true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                 return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpGet("{cidadeId}")]
    public async Task<IActionResult> GetCidadeModelById(int cidadeId)
    {
      try
      {
        var result = await _repo.GetCidadeModelById(cidadeId, true);
        return Ok(result);
      }
      catch (Exception ex)
      {
        return BadRequest($"Erro: {ex.Message}");
      }
    }

    [HttpPost]
    public async Task<IActionResult> post(CidadeModel model)
    {
      try
      {
        _repo.Add(model);
        if (await _repo.SaveChangesAsync())
        {
          return Ok(model);
        }
      }
      catch (Exception ex)
      {

        return BadRequest($"Erro: {ex.Message}");
      }
      return BadRequest();
    }


     [HttpDelete("{cidadeId}")]
    public async Task<IActionResult> delete(int cidadeId)
    {
      try
      {
        var cidade = await _repo.GetCidadeModelById(cidadeId, false);
        if (cidade == null) return NotFound();
        _repo.Delete(cidade);
        if (await _repo.SaveChangesAsync())
        {
          return Ok(new {message= "Cidade Deletada"});
        }
      }
      catch (Exception ex)
      {

        return BadRequest($"Erro: {ex.Message}");
      }
      return BadRequest();
    }

     [HttpPut("{cidadeId}")]
    public async Task<IActionResult> put(int cidadeId, CidadeModel model)
    {
      try
      {
        var cidade = await _repo.GetCidadeModelById(cidadeId, false);
        if (cidade == null)
        {
          return NotFound();
        }
        _repo.Update(model);
        if (await _repo.SaveChangesAsync())
        {
          return Ok("Cidade Alterada");
        }
      }
      catch (Exception ex)
      {
        return BadRequest($"Erro: {ex.Message}");
      }
      return BadRequest();
    }
            
    }
    
    
}