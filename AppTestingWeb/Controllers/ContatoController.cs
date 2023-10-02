using AppTestingWeb.Models;
using AppTestingWeb.Repositories.ContatoRepository;
using Microsoft.AspNetCore.Mvc;

namespace AppTestingWeb.Controllers;

public class ContatoController : Controller
{
    private readonly IContatoRepository _contatoRepository;

    public ContatoController(IContatoRepository contatoRepository)
    {
        _contatoRepository = contatoRepository;
    }

    public IActionResult Index()
    {
        var lstContato = _contatoRepository.GetContatoList();
        return View(lstContato);
    }

    public IActionResult AlterarContato(int id)
    {
        ContatoModel contato = _contatoRepository.GetContatoById(id);
        return View(contato);
    }

    public IActionResult AdicionarPage()
    {
        return View();
    }

    public IActionResult DeletarContato(int id)
    {
        ContatoModel contato = _contatoRepository.GetContatoById(id);
        return View(contato);
    }

    public IActionResult Deletar(int id)
    {
        try
        {
            bool apagado = _contatoRepository.Deletar(id);
            if (apagado)
            {
                TempData["MessageSuccess"] = "Contato deletado com sucesso!";
                return RedirectToAction("Index");
            }
            return View();
        }
        catch (Exception)
        {
            TempData["MessageFailed"] = "Ops!, não conseguimos deletar esse contato!";
            return RedirectToAction("Index");
        }
    }
    [HttpPost]
    public IActionResult AdicionarContato(ContatoModel model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _contatoRepository.AddContato(model);
                TempData["MessageSuccess"] = "Contato adicionado com sucesso!";
                return RedirectToAction("Index");
            }

            return View("AdicionarPage", model);
        }
        catch (Exception error)
        {
            TempData["MessageFailed"] = "Ops, não conseguimos adicionar esse contato!";
            return RedirectToAction("Index");
        }

    }

    [HttpPost]
    public IActionResult Alterar(ContatoModel model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _contatoRepository.Alterar(model);
                TempData["MessageSuccess"] = "Contato alterado com sucesso!";
                return RedirectToAction("Index");
            }

            return View("AdicionarPage", model);
        }
        catch (Exception error)
        {
            TempData["MessageFailed"] = "Ops, não conseguimos alterar esse contato!";
            return RedirectToAction("Index");
        }
    }
}