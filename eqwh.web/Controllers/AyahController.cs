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
    public class AyahController : ApiController
    {
        [Route("Ayah/GetAyat/{ayahno}")]
        [HttpGet]
        [CacheFilter(TimeDuration = 1800)]
        public async Task<AyatRow> GetAyat(int ayahno)
        {
            if (ayahno > 6348)
                return null;

            AyatRow obj = null;
            var t = Task.Run(() => obj = DataReaderFactory.Get().GetAyat(ayahno));
            t.Wait();

            return obj;
        }

        [Route("Ayah/SearchAyat/{word}")]
        [HttpGet]
        [CacheFilter(TimeDuration = 1800)]
        public async Task<int[]> SearchAyat(string word)
        {
            if (String.IsNullOrEmpty(word))
                return null;
            int[] data = null;
            var t = Task.Run(() => data = DataReaderFactory.Get().SearchAyat(word));
            t.Wait();
            return data;
        }
    }
}
