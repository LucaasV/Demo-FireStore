
using AutoMapper;
using DemoFireStore.API.ViewModel;
using DemoFireStore.Domain.Domain;
using DemoFireStore.Service.Interface;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DemoFireStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;
        private readonly IMapper _mapper;

        public PessoaController(IPessoaService pessoaService, IMapper mapper)
        {
            _pessoaService = pessoaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
          return Ok(await _pessoaService.GetAllAsync());

        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _pessoaService.GetAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post(PessoaCadastroViewModel view)
        {
            var pessoa = _mapper.Map<Pessoa>(view);
            return Ok(await _pessoaService.Create(pessoa));
        }

        [HttpPut]
        public async Task<IActionResult> Put(PessoaAtualizaViewModel view)
        {
            var pessoa = _mapper.Map<Pessoa>(view);
            return Ok(await _pessoaService.Update(pessoa));
        }

        [HttpDelete("pessoaId")]
        public async Task<IActionResult> Delete(string pessoaId)
        {
            await _pessoaService.RemoveAsync(pessoaId);
            return Ok(true);
        }

    }

   

}
