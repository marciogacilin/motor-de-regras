using Microsoft.AspNetCore.Mvc;
using MotorDeRegras.Api.ViewModel;
using MotorDeRegras.Domain.Entity;
using MotorDeRegras.Domain.Interface.Service;
using MotorDeRegras.Domain.Interface.UOW;
using System.Threading.Tasks;

namespace MotorDeRegras.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContextoController : ControllerBase
    {
        private readonly IContextoPersistenceService _contextoPersistenceService;

        private readonly IUnitOfWork _unitOfWork;

        public ContextoController(IContextoPersistenceService contextoPersistenceService, IUnitOfWork uow)
        {
            _contextoPersistenceService = contextoPersistenceService;

            _unitOfWork = uow;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ContextoViewModel contexto)
        {
            Contexto _contexto = new Contexto(contexto.Codigo, contexto.Descricao);

            if (!_contexto.IsValid())
                return BadRequest(_contexto.Error());

            _contextoPersistenceService.Add(_contexto);

            await _unitOfWork.Commit();

            return Ok(_contexto);
        }
    }
}