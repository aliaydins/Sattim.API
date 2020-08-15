using Newtonsoft.Json.Linq;
using Sattim.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sattim.DataAccess.Abstract
{
    public interface IOfferRepository
    {
        //Tüm ürünlerin listesi +
        List<Offer> GetAllOffer();
        //Offer kontrolü +
        Offer GetOfferById(int id);

        
        //Kazanılan ihale userId +
        List<Offer> GetWonOffer(int id);
        //Kaybedilen İhale userId +
        List<Offer> GetLoseOffer(int id);
        //Ürüne teklif yapma

        //Teklif  verirken kullanıcı bakiyesi kontrolu gerçekleştir. +
        Offer CreateOffer(Offer offer); 

        //Kullanıcıya ait ürüne verilen tekliflerin listesi //userId ve productId // büyükten küçüğe sırala
        List<Offer> GetOffersByProUserId(JObject model);
        //+
        Offer UpdateOffer(Offer offer);
        //OfferId ye göre ürünü silme +
        void DeleteOffer(int id);

        bool checkUserBank(JObject model);



    }
}
