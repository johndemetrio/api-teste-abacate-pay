using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using teste_abacate_pay.Models;
using teste_abacate_pay.Services;

namespace teste_abacate_pay.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PixController : ControllerBase
    {
        private readonly IAbacatePayService _abacatePayService;
        public PixController(IAbacatePayService abacatePayService)
        {
            _abacatePayService = abacatePayService;
        }

        [HttpPost("pixQrCode/create")]
        public ActionResult CreatePix([FromBody] RequestApi requestApi)
        {
            var request = _abacatePayService.CreatePixQrCode(requestApi);
            if (request.Result.error != null)
            {
                return BadRequest(request.Result);
            }
            if (request.Result.statusCode == HttpStatusCode.Unauthorized)
            {
                return Unauthorized(request.Result);
            }
            return Ok(request.Result);
        }

        [HttpPost("pixQrCode/simulate-payment")]
        public ActionResult SimulatePaymentPix([FromQuery] string id)
        {
            var request = _abacatePayService.SimulatePayment(id);
            if (request.Result.error != null)
            {
                return BadRequest(request.Result);
            }
            if (request.Result.statusCode == HttpStatusCode.Unauthorized)
            {
                return Unauthorized(request.Result);
            }
            return Ok(request.Result);
        }

        [HttpGet("pixQrCode/check")]
        public ActionResult CheckStatusPix([FromQuery]string id)
        {
            var request = _abacatePayService.CheckStatus(id);
            if (request.Result.error != null)
            {
                return BadRequest(request.Result);
            }
            if (request.Result.statusCode == HttpStatusCode.Unauthorized)
            {
                return Unauthorized(request.Result);
            }
            return Ok(request.Result);
        }
    }
}
