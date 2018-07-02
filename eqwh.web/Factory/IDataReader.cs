using eqwh.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eqwh.web.Factory
{
    public interface IDataReader
    {
        AyatRow GetAyat(int ayahno);

        string GetAyat(int ayahno, string colname);

        int[] SearchAyat(string word);

        Ahadith GetHadith(int hadithno);
    }
}