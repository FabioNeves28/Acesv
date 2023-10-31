using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Acesv.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Acesv2.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Acesvv.Models;
using Acesvv.Data;

namespace Acesvv.Controllers
{
    public class DadosController : Controller
    {
        private readonly BD _context;
        public DadosController(BD dadosContext)
        {
            _context = dadosContext;

        }

        // GET: Dados
        public ActionResult DownloadRelatorio()
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Criação do documento PDF
                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                // Criação da tabela
                PdfPTable table = new PdfPTable(12); // Define o número de colunas da tabela (2 colunas neste exemplo)
                table.WidthPercentage = 111;
                // Adiciona os campos do modelo à tabela como colunas
                table.AddCell("Escola");
                table.AddCell("Prefixo");
                table.AddCell("Veiculo");
                table.AddCell("CNH");
                table.AddCell("Categoria");
                table.AddCell("Endereço");
                table.AddCell("Bairro");
                table.AddCell("CEP");
                table.AddCell("Número");
                table.AddCell("Complemento");
                table.AddCell("Apelido");
                table.AddCell("CPF");

                foreach (var dados in _context.Dados.Include(d => d.Escola).ToList())
                {
                    // Adiciona os valores dos campos como células na tabela
                    table.AddCell(dados.EscolasSelecionadas);
                    table.AddCell(dados.Prefixo);
                    table.AddCell(dados.Veiculo);
                    table.AddCell(dados.Cnh);

                    table.AddCell(dados.Endereco);
                    table.AddCell(dados.Bairro);
                    table.AddCell(dados.Cep);
                    table.AddCell(dados.Número);
                    table.AddCell(dados.Complemento);
                    table.AddCell(dados.Apelido);
                    table.AddCell(dados.Cpf);
                }

                // Adiciona a tabela ao documento
                document.Add(table);

                document.Close();

                // Converte o documento em bytes
                byte[] fileBytes = memoryStream.ToArray();

                // Retorna o arquivo PDF como resultado para download
                return File(fileBytes, "application/pdf", "relatorio.pdf");
            }
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.Dados.Include(d => d.Escola).ToListAsync();

            // Percorra a lista de dados
            foreach (var dado in dados)
            {
                // Verifique se a lista de EscolaId não está vazia
                if (dado.EscolaId != null && dado.EscolaId.Count > 0)
                {
                    // Crie uma lista para armazenar os nomes das escolas selecionadas
                    var escolasSelecionadas = new List<string>();

                    // Percorra os IDs das escolas selecionadas
                    foreach (var escolaId in dado.EscolaId)
                    {
                        // Encontre a escola correspondente com base no ID e adicione o nome à lista
                        var escola = await _context.Escolas.FindAsync(escolaId);
                        if (escola != null)
                        {
                            escolasSelecionadas.Add(escola.NomeEscola);
                        }
                    }

                    // Concatene os nomes das escolas separados por vírgula e defina a propriedade adicional no modelo
                    dado.EscolasSelecionadas = string.Join(", ", escolasSelecionadas);
                }
            }
            return View(dados);
        }

        // GET: Dados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dados == null)
            {
                return NotFound();
            }

            var dados = await _context.Dados
                .Include(d => d.Escola)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dados == null)
            {
                return NotFound();
            }

            return View(dados);
        }

        // GET: Dados/Create
        public IActionResult Create()
        {
            var categorias = Enum.GetValues(typeof(Categoria))
                     .Cast<Categoria>()
                     .Select(c => new SelectListItem
                     {
                         Value = c.ToString(),
                         Text = c.ToString()
                     })
                     .ToList();

            ViewData["Categorias"] = categorias;
            ViewBag.Escolas = new MultiSelectList(_context.Escolas, "Id", "NomeEscola");

            return View();
        }

        // POST: Dados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EscolaId,Apelido,Cpf,Data_Nascimento,Prefixo,Bairros,Veiculo,Ano,Cnh,Categoria,Validade,Endereco,Bairro,Cep,Número,Complemento")] Dados dados)
        {
            if (ModelState.IsValid)
            {

                _context.Add(dados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Escolas = new SelectList(_context.Escolas, "Id", "NomeEscola");

            return View(dados);
        }

        // GET: Dados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            // Obtenha o usuário com base no EditId

            if (id == null)
            {
                ViewBag.ErrorMessage = "Nenhum registro foi encontrado.";
                return View("Error");
            }

            var dados = await _context.Dados.FindAsync(id);
            if (dados == null)
            {


            }



            var escolas = _context.Escolas.ToList();
            ViewBag.Escolas = escolas.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.NomeEscola,
                Selected = dados.EscolasSelecionadas != null && dados.EscolasSelecionadas.Contains(e.Id.ToString())
            }).ToList();


            var categorias = Enum.GetValues(typeof(Categoria))
                  .Cast<Categoria>()
                  .Select(c => new SelectListItem
                  {
                      Value = c.ToString(),
                      Text = c.ToString()
                  })
                  .ToList();

            ViewData["Categorias"] = categorias;
            return View(dados);
        }






        // POST: Dados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EscolaId,EscolasSelecionadas,Apelido,Cpf,Data_Nascimento,Prefixo,Bairros,Veiculo,Ano,Cnh,CategoriaSelecionada,Validade,Endereco,Bairro,Cep,Número,Complemento")] Dados dados)
        {
            if (id != dados.Id)
            {

                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Obter as escolas selecionadas pelo usuário
                    var escolasSelecionadas = dados.EscolaId ?? new List<int>();

                    // Atualizar a lista de escolas selecionadas com base nas escolas marcadas
                    dados.EscolasSelecionadas = string.Join(",", escolasSelecionadas);

                    _context.Update(dados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DadosExists(dados.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            // Carregar todas as escolas
            var todasEscolas = await _context.Escolas.ToListAsync();

            // Criar uma lista de SelectListItem para as escolas
            var escolasSelecionaveis = todasEscolas.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.NomeEscola,
                Selected = dados.EscolasSelecionadas.Contains(e.NomeEscola)
            }).ToList();

            ViewData["EscolaId"] = escolasSelecionaveis;

            return View(dados);
        }

        // GET: Dados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dados == null)
            {
                ViewBag.ErrorMessage = "Nenhum ID de usuário foi fornecido para edição.";
                return NotFound();
            }

            var dados = await _context.Dados
                .Include(d => d.Escola)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dados == null)
            {
                return NotFound();
            }

            return View(dados);
        }

        // POST: Dados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dados == null)
            {
                return Problem("Entity set 'BD.Dados'  is null.");
            }
            var dados = await _context.Dados.FindAsync(id);
            if (dados != null)
            {
                _context.Dados.Remove(dados);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DadosExists(int id)
        {
            return _context.Dados.Any(e => e.Id == id);
        }
    }
}