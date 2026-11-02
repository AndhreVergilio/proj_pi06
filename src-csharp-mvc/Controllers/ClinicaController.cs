// Controllers/ClinicaController.cs — Controller Unificado do Escopo
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaMvc.Models;

namespace ClinicaMvc.Controllers;

public class ClinicaController(AppDbContext db) : Controller {

    // 4 & 5. Listagem de Histórico + Painel de Retornos na mesma View principal
    public IActionResult Index() {
        ViewBag.Clientes = db.Clientes.OrderBy(c => c.Nome).ToList();
        var historico = db.Procedimentos
                          .Include(p => p.Cliente)
                          .OrderByDescending(p => p.Id)
                          .ToList();
        return View(historico);
    }

    // 1. Criação de Cliente
    [HttpPost]
    public IActionResult CriarCliente(Cliente novo) {
        if (!string.IsNullOrWhiteSpace(novo.Nome) && !string.IsNullOrWhiteSpace(novo.Telefone)) {
            db.Clientes.Add(novo);
            db.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    // 2 & 3. Registro de Procedimento + Upload de Foto (salvo em Base64 no SQLite)
    [HttpPost]
    public async Task<IActionResult> RegistrarProcedimento(Procedimento proc, IFormFile? foto) {
        if (foto != null && foto.Length > 0) {
            using var ms = new MemoryStream();
            await foto.CopyToAsync(ms);
            proc.FotoBase64 = $"data:{foto.ContentType};base64,{Convert.ToBase64String(ms.ToArray())}";
        }
        db.Procedimentos.Add(proc);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    // 5. Marcar Retorno como Concluído / Pendente no Painel
    [HttpPost]
    public IActionResult AlternarRetorno(int id) {
        var proc = db.Procedimentos.Find(id);
        if (proc != null) {
            proc.RetornoConcluido = !proc.RetornoConcluido;
            db.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}
