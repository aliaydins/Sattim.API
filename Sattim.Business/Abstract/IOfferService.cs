using Newtonsoft.Json.Linq;
using Sattim.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sattim.Business.Abstract
{
    public interface IOfferService
    {
        //Tüm ürünlerin listesi +
        List<Offer> GetAllOffer();
        //Offer kontrolü +
        Offer GetOfferById(int id);

        
        //Kazanılan ihale
        List<Offer> GetWonOffer(int id);
        //Kaybedilen İhale
        List<Offer> GetLoseOffer(int id);
        //Ürüne teklif yapma

        //Teklif  verirken kullanıcı bakiyesi kontrolu gerçekleştir. +
        Offer CreateOffer(Offer offer); 

        //Kullanıcıya ait ürüne verilen tekliflerin listesi //userId ve productId // büyükten küçüğe sırala
        List<Offer> GetOffersByProUserId(JObject model);

        Offer UpdateOffer(Offer offer);
        //OfferId ye göre ürünü silme
        void DeleteOffer(int id);

        //teklif veren kullanıcının kasasında para product ücretinden aşağıda mı kontrol ediyoruz.
        bool checkUserBank(JObject model);

    }
}
