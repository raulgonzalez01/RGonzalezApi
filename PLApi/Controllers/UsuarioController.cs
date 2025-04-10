using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PLApi.Controllers
{



    [EnableCors(origins: "http://localhost:3829/", headers: "*", methods: "*")]
    public class UsuarioController : ApiController
    {

        [HttpGet]
        [Route("api/Usuario/GetAll")]
        public async Task<IHttpActionResult> GetAll()
        {
            ML.Result result = await Task.Run(() => BL.Usuario.GetAll());


            ML.Usuario usuario = new ML.Usuario();

            if (result.Correct)
            {
                return Ok(result);
               
            }

            else
            {
                return BadRequest(result.ErrorMessage);

            }

        }



        [HttpGet]
        [Route("api/Usuario/GetById/{IdUsuario}")]

        public async Task<IHttpActionResult> GetById(int idUsuario)
        {
            ML.Result result = await Task.Run(() => BL.Usuario.GetById(idUsuario));



            if (result.Correct)
            {
                return Ok(result);
            }

            else
            { return BadRequest(result.ErrorMessage); }
        }



        [HttpPost]
        [Route("api/Usuario/Agregar")]
        public async Task<IHttpActionResult> Agregar([FromBody] ML.Usuario usuario)
        {
            ML.Result result = await Task.Run(() => BL.Usuario.Agregar(usuario));


            if (result.Correct)
            {
                return Ok(result);
            }
            else { return BadRequest(result.ErrorMessage); }

        }


        [HttpPut]
        [Route("api/Usuario/Actualizar")]
        public async Task<IHttpActionResult> Actualizar([FromBody] ML.Usuario usuario)
        {
            ML.Result result = await Task.Run(() => BL.Usuario.Actualizar(usuario));


            if (result.Correct)
            {
                return Ok(result);
            }
            else { return BadRequest(result.ErrorMessage); }


        }


        [HttpDelete]
        [Route("api/Usuario/Eliminar/{idUsuario}")]
        public async Task<IHttpActionResult> Eliminar(int idUsuario)
        {
            ML.Result result = await Task.Run(() => BL.Usuario.Eliminar(idUsuario));


            if (result.Correct)
            {
                return Ok(result);
            }
            else { return BadRequest(result.ErrorMessage); }


        }


    }
}
