using FCG.Application.Requests.Jogos;
using FCG.Application.Responses.Jogos;
using FCG.Application.Interfaces;       
using FCG.Domain.Interfaces;
using FCG.Domain.Entities;
using FCG.Domain.Exceptions;
using FCG.Domain.Enums;


namespace  FCG.Application.Services
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        public async Task<JogoResponse> CriarJogoAsync(CriarJogoRequest request)
        {
            if (await _jogoRepository.ObterPorTituloAsync(request.Titulo) != null)
                throw new ConflictException("Já existe um jogo com este título.");

            var jogo = new JogoEntity
            {
                Titulo= request.Titulo,
                Descricao = request.Descricao,
                Genero = request.Genero,
                Preco = request.Preco,
                DataLancamento = request.DataLancamento,
                DataCriacao= DateTime.UtcNow
            };

            await _jogoRepository.AdicionarAsync(jogo);

            return new JogoResponse
            {
                Id = jogo.Id,
                Titulo = jogo.Titulo,
                Descricao = jogo.Descricao,
                Genero = jogo.Genero.ToString(),
                Preco = jogo.Preco,
                DataLancamento = jogo.DataLancamento,
                DataCriacao = jogo.DataCriacao
            };
        }

    // TODO: substituir por Guid usuarioId após implementar JWT
        public async Task<JogoResponse> AtualizarJogoAsync(AtualizarJogoRequest request)
        {
            var jogo = await _jogoRepository.ObterPorTituloAsync(request.Titulo);

            if (jogo == null)
                throw new NotFoundException("Jogo não encontrado.");

            jogo.Titulo = request.Titulo;
            jogo.Descricao = request.Descricao;

            if (request.Genero.HasValue)
                jogo.Genero = request.Genero.Value;

            await _jogoRepository.AtualizarAsync(jogo);

            return new JogoResponse
            {
                Id = jogo.Id,
                Titulo = jogo.Titulo,
                Descricao = jogo.Descricao,
                Genero = jogo.Genero.ToString(),
                Preco = jogo.Preco,
                DataLancamento = jogo.DataLancamento,
                DataCriacao = jogo.DataCriacao
            };
        }

        public async Task<List<JogoResponse>> ObterTodosAsync()
        {
            var jogos = await _jogoRepository.ObterTodosAsync();

            return jogos.Select(jogo => new JogoResponse
            {
                Id = jogo.Id,
                Titulo = jogo.Titulo,
                Descricao = jogo.Descricao,
                Genero = jogo.Genero.ToString(),
                Preco = jogo.Preco,
                DataLancamento = jogo.DataLancamento,
                DataCriacao = jogo.DataCriacao
            }).ToList();
        }

        public async Task<JogoResponse> ObterJogoPorIdAsync(Guid id)
        {
            var jogo = await _jogoRepository.ObterPorIdAsync(id);

            if (jogo == null)
                return null;

            return new JogoResponse
            {
                Id = jogo.Id,
                Titulo = jogo.Titulo,
                Descricao = jogo.Descricao,
                Genero = jogo.Genero.ToString(),
                Preco = jogo.Preco,
                DataLancamento = jogo.DataLancamento,
                DataCriacao = jogo.DataCriacao
            };
        }
        public async Task<JogoResponse> ObterJogoPorTituloAsync(string titulo)
        {
            var jogo = await _jogoRepository.ObterPorTituloAsync(titulo);

            if (jogo == null)
                return null;

            return new JogoResponse
            {
                Id = jogo.Id,
                Titulo = jogo.Titulo,
                Descricao = jogo.Descricao,
                Genero = jogo.Genero.ToString(),
                Preco = jogo.Preco,
                DataLancamento = jogo.DataLancamento,
                DataCriacao = jogo.DataCriacao
            };
        }
        //mudar para deletar por id após implementar JWT
        public async Task DeletarJogoAsync(string titulo)
        {
            var jogo = await _jogoRepository.ObterPorTituloAsync(titulo);

            if (jogo == null)
                throw new NotFoundException("Jogo não encontrado.");

            await _jogoRepository.DeletarAsync(jogo);
        }

        

    }
}