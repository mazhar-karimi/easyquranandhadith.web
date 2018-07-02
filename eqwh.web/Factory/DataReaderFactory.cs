using eqwh.web.DataReaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eqwh.web.Factory
{
    public class DataReaderFactory
    {
        public static IDataReader Get(bool hadith=false)
        {
            if (hadith)
            {
                return new DbReader();
            }
            else
            {
                return new LuceneReader();
            }
        }
    }
}


