using Newtonsoft.Json.Linq;
using Sattim.DataAccess.Abstract;
using Sattim.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sattim.DataAccess.Concrete
{
    public class OfferRepository : IOfferRepository
    {
        UserDbContext offerDbContext = new UserDbContext();

        public Offer CreateOffer(Offer offer)
        {
            using (var offerDbContext = new UserDbContext())
            {
                var findUser = offerDbContext.Users.Where(x => x.userId == offer.userId).FirstOrDefault();
             
                 findUser.userBank = findUser.userBank - offer.offer;
                 offerDbContext.Offers.Add(offer);
                 offerDbContext.SaveChanges();
                 return offer;
                
  
            }
        }

        public void DeleteOffer(int id)
        {
            using (var offerDbContext = new UserDbContext())
            {
                var deletedOffer = GetOfferById(id);
                offerDbContext.Remove(deletedOffer);
                offerDbContext.SaveChanges();
              
            }
        }

        public List<Offer> GetAllOffer()
        {
            return offerDbContext.Offers.ToList();
        }

        public List<Offer> GetLoseOffer(int id)
        {
            using (var offerDbContext = new UserDbContext())
            {
                return offerDbContext.Offers.Where(x => x.userId == id && x.isDone == false).ToList();
            }
        }

        public Offer GetOfferById(int id)
        {
            return offerDbContext.Offers.Find(id);
        }

        public List<Offer> GetOffersByProUserId(JObject model)
        {
            dynamic json = model;
            int userId = json.userId;
            int proId = json.productId;

            using (var offerDbContext = new UserDbContext())
            {
                return offerDbContext.Offers.Where(x => x.userId == userId && x.productId == proId).OrderByDescending(x => x.offer).ToList();
            }
        }

        public List<Offer> GetWonOffer(int id)
        {
            using (var offerDbContext = new UserDbContext())
            {
                
                return offerDbContext.Offers.Where(x => x.userId == id && x.isDone == true).ToList();
            }
        }

        public Offer UpdateOffer(Offer offer)
        {
            using (var offerDbContext = new UserDbContext())
            {
                offerDbContext.Offers.Update(offer);
                offerDbContext.SaveChanges();
                return offer;
            }
        }

        public bool checkUserBank(JObject model)
        {
            dynamic json = model;
            int userId = json.userId;
            int proId = json.productId;


            using (var offerDbContext = new UserDbContext())
            {
                var findUser = offerDbContext.Users.Where(x => x.userId == userId).FirstOrDefault();
                var findProduct = offerDbContext.Products.Where(x => x.productId == proId).FirstOrDefault();

                if (findUser.userBank >= findProduct.productPrice)
                {
                    return true;
                }
                return false;

            }
        }


    }
}
