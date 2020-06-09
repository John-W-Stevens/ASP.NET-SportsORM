using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;
using Microsoft.EntityFrameworkCore;

namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context context;

        public HomeController(Context DBContext)
        {
            context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = context.Leagues
                .Where(l => l.Sport.Contains("Baseball"));
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {

            // Using ViewBag:

            // All women's leagues
            ViewBag.WomensLeagues = context.Leagues.Where(l => l.Name.Contains("Women"));

            // All leagues where sport is any type of Hockey:
            ViewBag.HockeyLeagues = context.Leagues.Where(l => l.Sport.Contains("Hockey"));

            // All leagyes where sport is something OTHER THAN football
            ViewBag.LeagueOtherThanFootball = context.Leagues.Where(l => !l.Sport.Contains("Football"));

            // All leagues that call themselves "conferences"
            ViewBag.ConferenceLeagues = context.Leagues.Where(l => l.Name.Contains("Conference"));

            // All leagues in the Atlantic region
            ViewBag.AtlanticLeagues = context.Leagues.Where(l => l.Name.Contains("Atlantic"));

            // All teams based in Dallas
            ViewBag.DallasTeams = context.Teams.Where(t => t.Location.Contains("Dallas"));

            // All teams named the Raptors
            ViewBag.RaptorTeams = context.Teams.Where(t => t.TeamName.Contains("Raptors"));

            // All teams whose location includes "City"
            ViewBag.CityTeams = context.Teams.Where(t => t.Location.Contains("City"));

            // All teams whone names begin with "T"
            ViewBag.TeamsBeginningWithT = context.Teams.Where(t => t.TeamName.StartsWith("T"));

            // All teams, ordered alphabetically by location
            ViewBag.AllTeamsOrderedByLocation = context.Teams.OrderBy(t => t.Location);

            // All teams, ordered by team name in reverse alphabetical order
            ViewBag.AllTeamsOrderedByTeamNameReversed = context.Teams.OrderByDescending(t => t.TeamName);

            // Every player with the last name of Cooper
            ViewBag.PlayersWithLastNameOfCooper = context.Players.Where(p => p.LastName == "Cooper");

            // Every player with the first name of Joshua
            ViewBag.PlayersWithFirstNameOfJoshua = context.Players.Where(p => p.FirstName == "Joshua");

            // Every player with the last name "Cooper" EXCEPT those with "Joshua" as the first name
            ViewBag.PlayersWithLastNameOfCooperFirstNameNotJoshua = context.Players.Where(p => p.LastName == "Cooper" && p.FirstName != "Joshua");

            // All players with the first name "Alexander" OR the first name "Wyatt"
            ViewBag.PlayersWithFirstNameIsAlexanderOrWyatt = context.Players.Where(p => p.FirstName == "Alexander" || p.FirstName == "Wyatt");

            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}