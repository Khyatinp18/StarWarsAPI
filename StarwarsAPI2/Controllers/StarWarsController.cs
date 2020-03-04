using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarwarsAPI2.Models;

namespace StarwarsAPI2.Controllers
{
   
    public class StarWarsController : Controller
    {



        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetPeopleById(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://swapi.co/api/");

            var response = await client.GetAsync($"people/{id}");
            var people = await response.Content.ReadAsAsync<Result>();

            return View(people);
        }


        public async Task<IActionResult> GetPlanetById(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://swapi.co/api/");

            var response = await client.GetAsync($"planets/{id}");
            var planet = await response.Content.ReadAsAsync<Planet>();

            return View(planet);
        }

        public async Task<IActionResult> GetPeopleList(int id)

        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://swapi.co/api/");

            var response = await client.GetAsync("people");
            var people = await response.Content.ReadAsAsync<PeopleRootObject>();

            return View(people);
        }



    }
}