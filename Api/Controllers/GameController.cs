using Api.Atributes;
using Api.Models;
using Domain.Contracts.Services;
using Domain.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api.Controllers
{
    [RoutePrefix("api/games")]
    public class GameController : ApiController
    {
        private IGameService _service;

        public GameController(IGameService service)
        {
            _service = service;
        }
        [Authorize]
        [HttpPost]
        [Route("")]
        public Task<HttpResponseMessage> Cadastrar(GameModel model)
        {
            var response = new HttpResponseMessage();

            try
            {
                _service.Cadastrar(model.Nome, model.VideoGame);
                response = Request.CreateResponse(HttpStatusCode.OK, new { name = model.Nome, email = model.VideoGame });
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
        
        [Route("{id}/Delete")]
        [HttpPost]
        public Task<HttpResponseMessage> Delete(string id)
        {
            var response = new HttpResponseMessage();

            try
            {
                var game = _service.BuscaGamePorId(id);
                _service.DeletaPorNome(game.Nome);
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
        
        [Authorize]
        [Route("")]
        [HttpPut]
        [DeflateCompression]
        public Task<HttpResponseMessage> Alterar(GameModel gameDto)
        {
            var response = new HttpResponseMessage();

            try
            {
                var game = new Game(gameDto.Id, gameDto.Nome, gameDto.VideoGame);
                _service.Alterar(game);
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
        
        [Authorize]
        [HttpGet]
        [Route("")]
        [DeflateCompression]
        public Task<HttpResponseMessage> Get()
        {
            var response = new HttpResponseMessage();

            try
            {
                var result = _service.ListarGames();
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
        }
    }
}
