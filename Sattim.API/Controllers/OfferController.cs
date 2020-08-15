using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Sattim.Business.Abstract;
using Sattim.Entities;

namespace Sattim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }


        /// <summary>
        /// Tüm teklifleri döndürür. /api/offer
        /// </summary>
        /// <returns></returns>

        [HttpGet]

        public IActionResult  Get()
        {
            var offers = _offerService.GetAllOffer();
            if (offers != null)
            {
                return Ok(offers);
            }
            return NotFound();
        }

        /// <summary>
        /// {offerId} parametresine göre değer döndürür 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var offers = _offerService.GetOfferById(id);
            if (offers != null)
            {
                return Ok(offers);
            }

            return NotFound();
        }
        /// <summary>
        /// Kullanıcının kazandığı ihaleleri döndürür parametre {userId} değeridir. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Won/{id}")]

        public IActionResult GetWonOffer(int id)

        {

            return Ok(_offerService.GetWonOffer(id));

        }

        /// <summary>
        /// Kullanıcının kaybettiği ihaleleri döndürür parametre {userId} değeridir. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Lose/{id}")]

        public IActionResult GetLoseOffer(int id)
        {

            return Ok(_offerService.GetLoseOffer(id));

        }
        /// <summary>
        /// Kullanıcıya ait ürünlerin listesini döndürür. Parametre olarak  {userId:int , productId:int} 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 

       
        [HttpPut("Desc")]

        public IActionResult GetOfferDesc(JObject model)
        {

            return Ok(_offerService.GetOffersByProUserId(model));

        }
        /// <summary>
        /// Teklif eklenir eğer kullanıcının bakiyesi teklifden küçük ise "bakiye yetersiz" bilgisi döner.
        /// </summary>
        /// <param name="offer"></param>
        /// <returns></returns>
        [HttpPost]

        public IActionResult Post([FromBody]Offer offer)
        {

            dynamic json = offer;
            int userId = json.userId;
            int proId = json.productId;
            var data = new JObject();
            data.Add("userId", userId);
            data.Add("productId", proId);

            if (ModelState.IsValid)
            {
                if (_offerService.checkUserBank(data) != false)
                {
                    return Ok(_offerService.CreateOffer(offer));
                }
                var ınfo = new JObject();
                ınfo.Add("info", "Bakiye yetersiz");
                return NotFound(ınfo);
            }

            return BadRequest(ModelState);
        }
        /// <summary>
        /// Teklif güncellenir /api/Offer
        /// </summary>
        /// <param name="offer"></param>
        /// <returns></returns>
        [HttpPut]

        public IActionResult Put ([FromBody]Offer offer)
        {
            if (_offerService.GetOfferById(offer.offerId) != null)
            {
                return Ok(_offerService.UpdateOffer(offer));
            }
            return BadRequest(offer);
        }
        /// <summary>
        /// Mevcut bir teklif id'ye göre silinir 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            if (_offerService.GetOfferById(id) != null)
            {
                _offerService.DeleteOffer(id);
                return Ok();
            }
            return NotFound();
        }

     


    }
}
