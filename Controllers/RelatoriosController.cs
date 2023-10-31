using Acesv2.Models;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using Rotativa;

namespace Acesvv.Controllers
{
    public class RelatoriosController : Controller
    {
        private readonly BD _context;
        public RelatoriosController(BD dadosContext)
        {
            _context = dadosContext;

        }
        public ActionResult RelatorioClientes()
        {
            var listaClientes = _context.Dados.OrderBy(c => c.Id).ToList();
            return View(listaClientes);
        }

        //public ActionResult GerarRelatorioPDF()
     //   {
      //      var listaClientes = _context.Dados.OrderBy(c => c.Id).ToList();

        //    var pdf = new ViewAsPdf("RelatorioClientes", listaClientes);
          //  var pdfBytes = pdf.BuildFile(_context);

          //  return File(pdfBytes, "application/pdf", "relatorio.pdf");
        }

    }
}
