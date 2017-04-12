using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GetHotelMap.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: Home
        public async Task<ActionResult> Index()
        {
            // search place types =  hotel, restaurant

            // get location = lat, long from a address quận, huyện + tỉnh kiến xương, thái bình
            //https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key=YOUR_API_KEY


            // get các vị trí hotel gần kề
            // key api
            //AIzaSyDbPlt6KIq2B8bXNTvQkicY1wvbJD5VJD8

            //https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=-33.8670522,151.1957362&radius=50000&type=restaurant&key=AIzaSyDbPlt6KIq2B8bXNTvQkicY1wvbJD5VJD8
            //https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=-33.8670522,151.1957362&radius=50000&type=hotel&key=AIzaSyDbPlt6KIq2B8bXNTvQkicY1wvbJD5VJD8

            // get các vị trí restaurant gần kề

            // Lưu vào db
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=-33.8670522,151.1957362&radius=50000&type=restaurant&key=AIzaSyDbPlt6KIq2B8bXNTvQkicY1wvbJD5VJD8");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var stateInfo = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject(stateInfo);
                    Response.Write(data);
                }    
            }
            
            

            return View();
        }
    }
}