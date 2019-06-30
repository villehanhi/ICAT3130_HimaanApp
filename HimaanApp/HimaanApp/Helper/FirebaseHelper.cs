using System;
using System.Collections.Generic;
using System.Text;
using HimaanApp.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HimaanApp.Helper
{
    /// <summary>
    /// Helper that connect app to firebase database
    /// </summary>
    class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://himaandatabase.firebaseio.com/");
        /// <summary>
        /// Add offered ride to database
        /// </summary>
        /// <param name="offerTo"></param>
        /// <param name="offerFrom"></param>
        /// <param name="offerDate"></param>
        /// <param name="offerFreeSeats"></param>
        /// <param name="offerDescription"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task AddOffer(string offerTo, string offerFrom, DateTime offerDate, int offerFreeSeats, string offerDescription, string userId)
        {
            await firebase
              .Child("Offers")
              .PostAsync(new Offer()
              {
                  offerTo = offerTo,
                  offerFrom = offerFrom,
                  offerDate = offerDate,
                  offerFreeSeats = offerFreeSeats,
                  offerDescription = offerDescription,
                  userId = userId });
        }
        /// <summary>
        /// Add asked ride to database
        /// </summary>
        /// <param name="needTo"></param>
        /// <param name="needFrom"></param>
        /// <param name="needDate"></param>
        /// <param name="NeededSeats"></param>
        /// <param name="needDescription"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task AddNeed(string needTo, string needFrom, DateTime needDate, int NeededSeats, string needDescription, string userId)
        {
            await firebase
              .Child("Needs")
              .PostAsync(new Need()
              {
                  needTo = needTo,
                  needFrom = needFrom,
                  needDate = needDate,
                  needFreeSeats = NeededSeats,
                  needDescription = needDescription,
                  userId = userId
              });
        }
        /// <summary>
        /// Return offered rides
        /// </summary>
        /// <returns></returns>
        public async Task<List<Offer>> SearchOffers()
        {

            return (await firebase
              .Child("Offers")
              .OnceAsync<Offer>()).Select(item => new Offer
              {
                  userId = item.Object.userId,
                  offerFrom = item.Object.offerFrom,
                  offerTo = item.Object.offerTo,
                  offerDate = item.Object.offerDate,
                  offerFreeSeats = item.Object.offerFreeSeats,
                  offerDescription = item.Object.offerDescription
              }).ToList();
        }
        /// <summary>
        /// Returns asked rides
        /// </summary>
        /// <returns></returns>
        public async Task<List<Need>> SearchNeeds()
        {

            return (await firebase
              .Child("Needs")
              .OnceAsync<Need>()).Select(item => new Need
              {
                  userId = item.Object.userId,
                  needFrom = item.Object.needFrom,
                  needTo = item.Object.needTo,
                  needDate = item.Object.needDate,
                  needFreeSeats = item.Object.needFreeSeats,
                  needDescription = item.Object.needDescription
              }).ToList();
        }
    }

}