using FCG.Application.Services;
using FCG.Application.Requests.Jogos;
using FCG.Domain.Interfaces;
using FCG.Domain.Entities;
using FCG.Domain.Enums;
using FCG.Domain.Exceptions;
using FluentAssertions;
using Moq;
using Xunit;

namespace FCG.Application.Tests;

public class JogoServiceTests
{
        private readonly Mock<IJogoRepository> _jogoRepositoryMock;
        private readonly JogoService _service;

        public JogoServiceTests()
        {
            _jogoRepositoryMock = new Mock<IJogoRepository>();        
            _service = new JogoService(_jogoRepositoryMock.Object);

        }

        [Fact]
        public async Task CriarJogoAsync_DeveCriarJogoComSucesso ()
        {

            //Arrange
            var request = new CriarJogoRequest
            {
                
                Titulo = "The Witcher 3",
                Descricao = "RPG",
                Genero = JogoGeneroEnum.RPG,
                Preco = 199.90m,
                DataLancamento = new DateTime(2015, 5, 19)

            };

             _jogoRepositoryMock
                .Setup(repo => repo.ObterPorTituloAsync(request.Titulo))
                .ReturnsAsync((JogoEntity)null);
                
            //Act
            var result = await _service.CriarJogoAsync(request);

            //Assert
            result.Should().NotBeNull();
            result.Titulo.Should().Be(request.Titulo);

            _jogoRepositoryMock.Verify(
                r => r.AdicionarAsync(It.IsAny<JogoEntity>()),
                Times.Once);


        }

        [Fact]
        public async Task CriarJogoAsync_JogoComTituloExistente_DeveLancarConflictException()
        {
            //Arrange
            var request = new CriarJogoRequest
            {
                Titulo = "The Witcher 3",
                Descricao = "RPG",
                Genero = JogoGeneroEnum.RPG,
                Preco = 199.90m,
                DataLancamento = new DateTime(2015, 5, 19)
            };

            var jogoExistente = new JogoEntity
            {
                Titulo = request.Titulo,
                Descricao = "Outro RPG",
                Genero = JogoGeneroEnum.RPG,
                Preco = 149.90m,
                DataLancamento = new DateTime(2016, 1, 1)
            };

             _jogoRepositoryMock
                .Setup(repo => repo.ObterPorTituloAsync(request.Titulo))
                .ReturnsAsync(jogoExistente);

             //Act
            Func<Task> act = async () => await _service.CriarJogoAsync(request);

             //Assert
            await act.Should().ThrowAsync<ConflictException>()
                .WithMessage("Já existe um jogo com este título.");

        }

        [Fact]
        public async Task BuscarTodosOsJogos_DeveRetornarListaDeJogos()
        {
            // Arrange
            var jogos = new List<JogoEntity>
            {
                new JogoEntity { Titulo = "Jogo 1", Descricao = "Descrição 1", Genero = JogoGeneroEnum.Acao, Preco = 59.90m, DataLancamento = new DateTime(2020, 1, 1) },
                new JogoEntity { Titulo = "Jogo 2", Descricao = "Descrição 2", Genero = JogoGeneroEnum.Aventura, Preco = 79.90m, DataLancamento = new DateTime(2021, 1, 1) }
            };

            _jogoRepositoryMock
                .Setup(r => r.ObterTodosAsync())
                .ReturnsAsync(jogos);

            // Act
            var result = await _service.ObterTodosAsync();

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(2);
            result[0].Titulo.Should().Be("Jogo 1");
            result[1].Titulo.Should().Be("Jogo 2");

            _jogoRepositoryMock.Verify(
                r => r.ObterTodosAsync(),
                Times.Once);
        }

        [Fact]
        public async Task BuscarJogoPorTitulo_jogoExistente_DeveRetornarJogo()
        {
            // Arrange
            var titulo = "Jogo Existente";
            var jogoExistente = new JogoEntity
            {
                Titulo = titulo,
                Descricao = "Descrição do Jogo",
                Genero = JogoGeneroEnum.Acao,
                Preco = 59.90m,
                DataLancamento = new DateTime(2020, 1, 1)
            };

            _jogoRepositoryMock
                .Setup(r => r.ObterPorTituloAsync(titulo))
                .ReturnsAsync(jogoExistente);

            // Act
            var result = await _service.ObterJogoPorTituloAsync(titulo);

            // Assert
            result.Should().NotBeNull();
            result.Titulo.Should().Be(titulo);
            result.Descricao.Should().Be("Descrição do Jogo");
            result.Genero.Should().Be(JogoGeneroEnum.Acao.ToString());
            result.Preco.Should().Be(59.90m);
            result.DataLancamento.Should().Be(new DateTime(2020, 1, 1));

            _jogoRepositoryMock.Verify(
                r => r.ObterPorTituloAsync(titulo),
                Times.Once);
        }

        [Fact]
        public async Task BuscarJogoPorTitulo_jogoNaoExistente_DeveRetornarNull()
        { 
            //Arrange
            var titulo = "Jogo Inexistente";
            _jogoRepositoryMock
                .Setup(r => r.ObterPorTituloAsync(titulo))
                .ReturnsAsync((JogoEntity)null);
            
            //Act
            var result = await _service.ObterJogoPorTituloAsync(titulo);
            //Assert
            result.Should().BeNull();

        }
        [Fact]
        public async Task AtualizarJogoAsync_AtualizacaoParcial_DeveAtualizarApenasCamposInformados()
        {
            // Arrange
            var jogoExistente = new JogoEntity
            {
                Titulo = "Título Original",
                Descricao = "Descrição Original",
                Preco = 99.90m,
                DataLancamento = new DateTime(2020, 1, 1)
            };

            var jogoId = jogoExistente.Id;

            var request = new AtualizarJogoRequest
            {
                Titulo = "Título Atualizado",
                Preco = 149.90m
            };

            _jogoRepositoryMock
                .Setup(r => r.ObterPorIdAsync(jogoId))
                .ReturnsAsync(jogoExistente);

            // Act
            var result = await _service.AtualizarJogoAsync(jogoId, request);

            // Assert
            result.Titulo.Should().Be("Título Atualizado");
            result.Descricao.Should().Be("Descrição Original");
            result.Preco.Should().Be(149.90m);
            result.DataLancamento.Should().Be(new DateTime(2020, 1, 1));

            _jogoRepositoryMock.Verify(
                r => r.AtualizarAsync(It.IsAny<JogoEntity>()),
                Times.Once);
        }
        
        [Fact]
        public async Task AtualizarJogoAsync_JogoNaoEncontrado_DeveLancarNotFoundException()
        {
            //Arrange 
            var jogoId = Guid.NewGuid();
            var request = new AtualizarJogoRequest
            {
                Titulo = "Título Atualizado",
                Preco = 149.90m
            };
            _jogoRepositoryMock
                .Setup(r => r.ObterPorIdAsync(jogoId))
                .ReturnsAsync((JogoEntity)null);

             //Act
            Func<Task> act = async () => await _service.AtualizarJogoAsync(jogoId, request);
            
            //Assert
            await act.Should().ThrowAsync<NotFoundException>()
                .WithMessage("Jogo não encontrado.");
        }

        [Fact]
        public async Task AtualizarJogoAsync_SemCamposParaAtualizar_DeveManterDadosInalterados()
        {
            // Arrange
            var jogoExistente = new JogoEntity
            {
                Titulo = "Título Original",
                Descricao = "Descrição Original",
                Preco = 99.90m,
                DataLancamento = new DateTime(2020, 1, 1)
            };

            var jogoId = jogoExistente.Id;

            var request = new AtualizarJogoRequest { };

            _jogoRepositoryMock
                .Setup(r => r.ObterPorIdAsync(jogoId))
                .ReturnsAsync(jogoExistente);

            // Act
            var result = await _service.AtualizarJogoAsync(jogoId, request);

            // Assert
            result.Titulo.Should().Be("Título Original");
            result.Descricao.Should().Be("Descrição Original");
            result.Preco.Should().Be(99.90m);
            result.DataLancamento.Should().Be(new DateTime(2020, 1, 1));

            _jogoRepositoryMock.Verify(
                r => r.AtualizarAsync(It.IsAny<JogoEntity>()),
                Times.Once);
        }

        [Fact]
        public async Task DeletarJogoAsync_JogoExistente_DeveDeletarJogoComSucesso()
        {
            // Arrange
            var jogoExistente = new JogoEntity
            {
                Titulo = "Título para Deletar",
                Descricao = "Descrição do Jogo",
                Preco = 59.90m,
                DataLancamento = new DateTime(2019, 1, 1)
            };

            var jogoId = jogoExistente.Id;

            _jogoRepositoryMock
                .Setup(r => r.ObterPorIdAsync(jogoId))
                .ReturnsAsync(jogoExistente);

            // Act
            await _service.DeletarJogoAsync(jogoId);

            // Assert
            _jogoRepositoryMock.Verify(
                r => r.DeletarAsync(It.Is<JogoEntity>(j => j.Id == jogoId)),
                Times.Once);
        }

        [Fact]
        public async Task DeletarJogoAsync_JogoNaoEncontrado_DeveLancarNotFoundException()
        {
            // Arrange
            var jogoId = Guid.NewGuid();

            _jogoRepositoryMock
                .Setup(r => r.ObterPorIdAsync(jogoId))
                .ReturnsAsync((JogoEntity)null);

            // Act
            Func<Task> act = async () => await _service.DeletarJogoAsync(jogoId);

            // Assert
            await act.Should().ThrowAsync<NotFoundException>()
                .WithMessage("Jogo não encontrado.");
        }
    }