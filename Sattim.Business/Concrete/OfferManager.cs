using Newtonsoft.Json.Linq;
using Sattim.Business.Abstract;
using Sattim.DataAccess.Abstract;
using Sattim.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sattim.Business.Concrete
{
    public class OfferManager : IOfferService
    {

        private IOfferRepository _offerRepository;

        public OfferManager(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }
        public Offer CreateOffer(Offer offer)
        {
            return _offerRepository.CreateOffer(offer);
        }

        public void DeleteOffer(int id)
        {
            _offerRepository.DeleteOffer(id);
        }

        public List<Offer> GetAllOffer()
        {
            return _offerRepository.GetAllOffer();
        }

        public List<Offer> GetLoseOffer(int id)
        {
            return _offerRepository.GetLoseOffer(id);
        }

        public Offer GetOfferById(int id)
        {
            return _offerRepository.GetOfferById(id);
        }

    
        public List<Offer> GetOffersByProUserId(JObject model)
        {
            return _offerRepository.GetOffersByProUserId(model);
        }

        public List<Offer> GetWonOffer(int id)
        {
            return _offerRepository.GetWonOffer(id);
        }

        public Offer UpdateOffer(Offer offer)
        {
            return _offerRepository.UpdateOffer(offer);
        }

        public bool checkUserBank(JObject model)
        {
            return _offerRepository.checkUserBank(model);
        }

    }
}
