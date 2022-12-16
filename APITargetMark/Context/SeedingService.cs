using APITargetMark.Models;

namespace APITargetMark.Context
{
    public class SeedingService
    {
        //banco de dados
        private readonly AppDbContext _context;
        //construtor
        public SeedingService(AppDbContext context)
        {
            _context = context;
        }

        //método para popular o banco de dados
        public void Seed()
        {

            //verificar se o banco de dados já foi populado
            //if (_context.Empresas.Any() || _context.Campanhas.Any() || _context.Relatorios.Any() || _context.Mensagens.Any())
            //{
            //    return; //banco de dados já foi populado
            //}

            //criar cliente
            var cliente = new Cliente
            {
                Nome = "Vanderson",
                Idade = 15,
                Genero = "Masculino",
                Regiao = "Norte"
            };

    


            

            //criar uma empresa
            var empresa = new Empresa
            {
               
                Nome = "TargetMark",
                Campanhas = new List<Campanha>()

            };

            //adicionar a empresa ao banco de dados
            _context.Empresas.Add(empresa);

            //criar uma campanha
            var campanha = new Campanha
            {
                
               
                Nome = "Campanha 1",
                Descricao = "Campanha de teste",
                QuantidadeMensagens = 10,
                Data = DateTime.Now,
                PublicoAlvo = "Todos",

            };

            //adicionar a campanha ao banco de dados
            _context.Campanhas.Add(campanha);

            //criar um relatório
            var relatorio = new Relatorio
            {
                
                Titulo = "Relatório 1",
                MensagensVisualizadas = 5,
                MensagensInteragidas = 3,
                TaxaConversao = 60,                
                CampanhaId = 0,
                EmpresaId = 0
            };


            //criar uma mensagem
            var mensagem = new Mensagem
            {

                Titulo = "Mensagem 1",
                Texto = "Texto da mensagem 1",
                Campanha = campanha
            };
            //adicionar a mensagem ao banco de dados
            _context.Mensagens.Add(mensagem);

            //adicionar o relatório ao banco de dados
            _context.Relatorios.Add(relatorio);

            //salvar as alterações no banco de dados
            _context.SaveChanges();
        }

    }
}
