using AppTestingWeb.DataContext;
using AppTestingWeb.Models;

namespace AppTestingWeb.Repositories.ContatoRepository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly AppDbContext _appDbContext;

        public ContatoRepository(AppDbContext appDbContext) { _appDbContext = appDbContext; }

        public ContatoModel AddContato(ContatoModel contato)
        {
            _appDbContext.Contatos.Add(contato);
            _appDbContext.SaveChanges();
            return contato;
        }

        public List<ContatoModel> GetContatoList()
        {
            return _appDbContext.Contatos.ToList();
        }

        public ContatoModel GetContatoById(int id)
        {
            return _appDbContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public ContatoModel Alterar(ContatoModel model)
        {
            ContatoModel contato = GetContatoById(model.Id);
            if (contato == null) throw new Exception("Erro ao alterar o contato!");

            contato.Nome= model.Nome;
            contato.Email = model.Email;
            contato.Celular = model.Celular;

            _appDbContext.Contatos.Update(contato);
            _appDbContext.SaveChanges();

            return contato;
        }

        public bool Deletar(int id)
        {
           ContatoModel model = GetContatoById(id);
            if (model == null) throw new Exception("Erro ao deletar o contato!");

            _appDbContext.Contatos.Remove(model);
            _appDbContext.SaveChanges();
            return true;
        }
    }
}
