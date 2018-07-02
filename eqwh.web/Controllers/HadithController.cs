using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eqwh.web.Factory;
using eqwh.web.Models;
using System.Threading.Tasks;
using eqwh.web.Common;

namespace eqwh.web.Controllers
{
    public class HadithController : ApiController
    {

        [Route("Hadith/GetHadith/{hadithno}")]
        [HttpGet]
        [CacheFilter(TimeDuration = 1800)]
        public async Task<Ahadith> GetHadith(int hadithno)
        {
            Ahadith obj = null;
            var t = Task.Run(() => obj = DataReaderFactory.Get(true).GetHadith(hadithno));
            t.Wait();

            return obj;
        }

    }
}
