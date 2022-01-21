using Connvert.API.Controllers;
using Connvert.Application.Interfaces;
using Connvert.Application.Model;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Connvert.Test
{
    public class NoticiasControllerTest
    {
        private readonly INoticiasAppService _mockAppService;

        public NoticiasControllerTest() => _mockAppService = Substitute.For<INoticiasAppService>();





        #region IncluirAsync

        [Fact]
        public async Task IncluirAsync_ReturnsCreated()
        {
            //Arrange
            var produto = new NoticiasModel();

            _mockAppService.IncluirAsync(produto).ReturnsForAnyArgs(produto);

            NoticiasController controller = new NoticiasController(_mockAppService);

            //Act
            var result = await controller.IncluirAsync(produto);

            //Assert
            var createdResult = Assert.IsType<ObjectResult>(result);
            Assert.IsType<NoticiasModel>(createdResult.Value);
        }

        [Fact]
        public async Task IncluirAsync_ReturnsBadRequest()
        {
            //Arrange
            NoticiasController controller = new NoticiasController(_mockAppService);
            controller.ModelState.AddModelError("Autor", "Favor informar um autor.");
            var produto = new NoticiasModel();
            //Act
            var result = await controller.IncluirAsync(produto);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        #endregion

        #region EditarAsync

        [Fact]
        public async Task EditarAsync_ReturnsCreated()
        {
            //Arrange
            var id = "";
            var produto = new NoticiasModel();

            _mockAppService.EditarAsync(id, produto).ReturnsForAnyArgs(produto);

            NoticiasController controller = new NoticiasController(_mockAppService);

            //Act
            var result = await controller.EditarAsync(id, produto);

            //Assert
            var createdResult = Assert.IsType<ObjectResult>(result);
            Assert.IsType<NoticiasModel>(createdResult.Value);
        }

        [Fact]
        public async Task EditarAsync_ReturnsBadRequest()
        {
            //Arrange
            NoticiasController controller = new NoticiasController(_mockAppService);
            controller.ModelState.AddModelError("Titulo", "O Titulo deve ser informado.");
            var produto = new NoticiasModel();
            var id = "";
            //Act
            var result = await controller.EditarAsync(id, produto);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }
        #endregion
        #region ListarAsync

        [Fact]
        public async Task ListarAsync_ReturnsOk()
        {
            //Arrange
            var vmConsulta = new ConsultaNoticiasModel();
            var produtos = new List<NoticiasModel>
            {
                new NoticiasModel()
            };

            _mockAppService.ListarAsync(vmConsulta).ReturnsForAnyArgs(produtos);

            NoticiasController controller = new NoticiasController(_mockAppService);

            //Act
            var result = await controller.ListarAsync(vmConsulta);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<NoticiasModel>>(okResult.Value);
        }

        [Fact]
        public async Task ListarAsync_ReturnsNoContent()
        {
            //Arrange
            var vmConsulta = new ConsultaNoticiasModel();
            var produtos = new List<NoticiasModel>();

            _mockAppService.ListarAsync(vmConsulta).ReturnsForAnyArgs(produtos);

            NoticiasController controller = new NoticiasController(_mockAppService);

            //Act
            var result = await controller.ListarAsync(vmConsulta);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        #endregion
    }
}
