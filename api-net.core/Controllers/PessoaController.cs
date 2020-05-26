using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apinode.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Apinode.Controllers
{
    [Route("api/pessoa/")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();

        [HttpGet]

        public async Task<IActionResult> get()
        {
            return Ok(pessoas);
        }
        [HttpPost]

        public async Task<IActionResult> Post(Pessoa pessoa)
        {
            pessoas.Add(pessoa);
            return Ok(pessoa);
        }

        [RequireHttps]
        public async Task<IActionResult> Put(Pessoa pessoa)
        {
            var index = pessoas.IndexOf(pessoas.Where(x => x.Id == pessoa.Id).First());
            pessoas.RemoveAt(index);
            pessoas.Add(pessoa);
            return Ok(pessoa);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(Pessoa pessoa)
        {
            var index = pessoas.IndexOf(pessoas.Where(x => x.Id == pessoa.Id).First());
            pessoas.RemoveAt(index);
            pessoas.Add(pessoa);
            return Ok(pessoa);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var index = pessoas.IndexOf(pessoas.Where(x => x.Id == id).First());
            pessoas.RemoveAt(index);
            return Ok("Pessoa removida com sucesso");
        }

    }
}