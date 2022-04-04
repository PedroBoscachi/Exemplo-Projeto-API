using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlunoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private static List<Aluno> alunos = new List<Aluno>
        {
                new Aluno
                {
                    Id = 1,
                    Nome = "Alisson",
                    Sobrenome = "Kauan",
                    Idade = 18
                },
                new Aluno
                {
                    Id = 2,
                    Nome = "Lucas",
                    Sobrenome = "Passos",
                    Idade = 21
                },
                new Aluno
                {
                    Id = 3,
                    Nome = "Pedro",
                    Sobrenome = "Farias",
                    Idade = 18
                }
        };

        [HttpGet]
        public async Task<ActionResult<List<Aluno>>> Get()
        {
            
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Aluno>>> Get(int id)
        {
            var aluno = alunos.Find(a => a.Id == id);
            if (aluno == null)
                return NotFound("Aluno não encontrado");
            return Ok(aluno);
        }

        [HttpPost]
        public async Task<ActionResult<List<Aluno>>> AddAluno(Aluno aluno)
        {
            alunos.Add(aluno);
            return Ok(alunos);
        }

        [HttpPut]
        public async Task<ActionResult<List<Aluno>>> UpdateAluno(Aluno request)
        {
            var aluno = alunos.Find(a => a.Id == request.Id);
            if (aluno == null)
                return NotFound("Aluno não encontrado");

            aluno.Nome = request.Nome;
            aluno.Sobrenome = request.Sobrenome;
            aluno.Idade = request.Idade;

            return Ok(alunos);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Aluno>>> Delete(int id)
        {
            var aluno = alunos.Find(a => a.Id == id);
            if (aluno == null)
                return NotFound("Aluno não encontrado");

            alunos.Remove(aluno);
            return Ok(alunos);
        }
    }
}
