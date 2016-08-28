using eqwh.web.DataReaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eqwh.web.Factory
{
    public class DataReaderFactory
    {
        public static IDataReader Get
        {
            get
            {
                return new LuceneReader();
            }
        }
    }
}
//661460/68 muhammad anas ayub

