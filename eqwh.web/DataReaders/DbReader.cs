using eqwh.web.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eqwh.web.DataReaders
{
    public class DbReader : IDataReader
    {

        public Models.AyatRow GetAyat(int ayahno)
        {
            throw new NotImplementedException();
        }

        public string GetAyat(int ayahno, string colname)
        {
            throw new NotImplementedException();
        }

        public int[] SearchAyat(string word)
        {
            throw new NotImplementedException();
        }

        public Ahadith GetHadith(int hadithno)
        {
            var db = new EQ_Hadith_6Entities();

            var hadith = db.Ahadiths.FirstOrDefault(f => f.Id == hadithno);
            return hadith;
        }
    }
}