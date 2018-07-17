using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace chuck.api.Controllers
{
    [Route("api/[controller]")]
    public class QuotesController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            Random rnd = new Random();
            int index = rnd.Next(quoteList.Count());

            return quoteList[index];
        }

        List<string> quoteList = new List<string>(){
            "Chuck Norris' OSI network model has only one layer - Physical.",
            "Chuck Norris finished World of Warcraft.",
            "The Chuck Norris Eclipse plugin made alien contact.",
            "Chuck Norris' log statements are always at the FATAL level.",
            "Chuck Norris can solve the Towers of Hanoi in one move.",
            "Chuck Norris is the ultimate mutex, all threads fear him.",
            "To Chuck Norris, everything contains a vulnerability.",
            "Chuck Norris does not need try-catch blocks, exceptions are too afraid to raise.",
            "Chuck Norris doesn't have disk latency because the hard drive knows to hurry the hell up.",
            "Chuck Norris can't test for equality because he has no equal.",
            "Chuck Norris writes code that optimizes itself.",
            "Chuck Norris doesn't need to use AJAX because pages are too afraid to postback anyways.",
            "Chuck Norris can access the DB from the UI.",
            "Chuck Norris can overflow your stack just by looking at it.",
            "If you try to kill -9 Chuck Norris' programs, it backfires."
        };
    }
}