using AppTestingWeb.Models;

namespace AppTestingWeb.Repositories.ContatoRepository
{
    public interface IContatoRepository
    {
        ContatoModel AddContato(ContatoModel contato);
        List<ContatoModel> GetContatoList();

        ContatoModel GetContatoById(int id);
        ContatoModel Alterar(ContatoModel contato);
        bool Deletar(int id);
    }
}
