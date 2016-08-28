using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eqwh.web.Factory;
using eqwh.web.Models;
namespace eqwh.web.Controllers
{
    public class AyahController : ApiController
    {
        [Route("Ayah/GetAyat/{ayahno}")]
        [HttpGet]
        public AyatRow GetAyat(int ayahno)
        {
            if (ayahno > 6348)
                return null;

                return DataReaderFactory.Get.GetAyat(ayahno);
        }
    }
}
