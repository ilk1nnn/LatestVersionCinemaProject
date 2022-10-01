using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WPF_LoginForm
{
    public class SendRequest
    {
        public dynamic Data { get; set; }
        HttpClient http = new HttpClient();
        public string GetPoster(string source)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                response = http.GetAsync($@"http://www.omdbapi.com/?apikey=e4d8a8d9&s={source}&plot=full").Result;
                var str = response.Content.ReadAsStringAsync().Result;
                Data = JsonConvert.DeserializeObject(str);
                string poster = Data.Search[0].Poster;
                if (poster.Length <= 0)
                {
                    return $@"npa.jpg";
                }
                return poster;
            }
            catch (Exception)
            {
                return $@"npa.jpg";

            }
        }
        public string GetTitle(string source)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                response = http.GetAsync($@"http://www.omdbapi.com/?apikey=e4d8a8d9&s={source}&plot=full").Result;
                var str = response.Content.ReadAsStringAsync().Result;
                Data = JsonConvert.DeserializeObject(str);
                string title = Data.Search[0].Title;
                return title;
            }
            catch (Exception)
            {
                return "Title";
            }
        }
        public string GetGenre(string source)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                response = http.GetAsync($@"http://www.omdbapi.com/?apikey=e4d8a8d9&t={source}&plot=full").Result;
                var str = response.Content.ReadAsStringAsync().Result;
                Data = JsonConvert.DeserializeObject(str);
                string genre = Data.Genre;
                return genre;
            }
            catch (Exception)
            {
                return "Genre";
            }
        }
        public string GetYear(string source)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                response = http.GetAsync($@"http://www.omdbapi.com/?apikey=e4d8a8d9&s={source}&plot=full").Result;
                var str = response.Content.ReadAsStringAsync().Result;
                Data = JsonConvert.DeserializeObject(str);
                string year = Data.Search[0].Year;
                return year;
            }
            catch (Exception)
            {
                return "Year";
            }
        }
        public string GetPlot(string source)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                response = http.GetAsync($@"http://www.omdbapi.com/?apikey=e4d8a8d9&t={source}&plot=full").Result;
                var str = response.Content.ReadAsStringAsync().Result;
                Data = JsonConvert.DeserializeObject(str);
                string plot = Data.Plot;
                if (plot.Length <= 0)
                {
                    return "Not Found";
                }
                return plot;
            }
            catch (Exception)
            {
                return "Plot";
            }
        }
    }
}
