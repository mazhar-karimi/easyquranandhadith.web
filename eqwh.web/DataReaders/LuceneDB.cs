using eqwh.web.Common;
using eqwh.web.Models;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.AR;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;


namespace eqwh.web.DataReaders
{
    public class LuceneDB
    {

        private static LuceneDB _instance;
        private static volatile object locker = new object();

        private const Lucene.Net.Util.Version Version = Lucene.Net.Util.Version.LUCENE_30;
        public static HashSet<string> CONST_COLS = new HashSet<string>();

        private IndexSearcher searcher;
        private PerFieldAnalyzerWrapper analyzer;

        public static LuceneDB Get
        {
            get
            {
                lock (locker)
                {
                    if (_instance == null)
                        _instance = new LuceneDB();

                    return _instance;
                }
            }
        }
        public Dictionary<string, AyatColumnAttribute> FieldInfo
        {
            get;
            set;
        }
        public int IndexLength
        {
            get
            {
                return this.searcher.MaxDoc;
            }
        }
        private LuceneDB()
        {
            LuceneDB.CONST_COLS.Add("ID");
            LuceneDB.CONST_COLS.Add("ParahNo");
            LuceneDB.CONST_COLS.Add("SurahNo");
            LuceneDB.CONST_COLS.Add("RukuParahNo");
            LuceneDB.CONST_COLS.Add("RukuSurahNo");
            LuceneDB.CONST_COLS.Add("AyatNo");
            var path = System.Configuration.ConfigurationManager.AppSettings["eqwhpath"]; //"EQWH";// 
            var directory = new SimpleFSDirectory(new DirectoryInfo(path));
            IndexReader r = IndexReader.Open(directory, true);
            this.FieldInfo = this.InitFieldInfo();
            this.searcher = new IndexSearcher(r);
            this.analyzer = AnalyzerBuilder.BuildAnalyzer(Lucene.Net.Util.Version.LUCENE_30, this.FieldInfo);
        }
        private Dictionary<string, AyatColumnAttribute> InitFieldInfo()
        {
            PropertyInfo[] properties = typeof(AyatRow).GetProperties();
            var dictionary = new Dictionary<string, AyatColumnAttribute>(properties.Length);
            PropertyInfo[] array = properties;
            for (int i = 0; i < array.Length; i++)
            {
                PropertyInfo propertyInfo = array[i];
                AyatColumnAttribute[] array2 = (AyatColumnAttribute[])propertyInfo.GetCustomAttributes(typeof(AyatColumnAttribute), false);
                array2[0].Property = propertyInfo;
                dictionary.Add(propertyInfo.Name, array2[0]);
            }
            return dictionary;
        }
        public string GetContent(int id, string field)
        {
            Document document = this.searcher.Doc(id - 1);
            if (LuceneDB.CONST_COLS.Contains(field))
            {
                return document.Get(field);
            }
            byte[] binaryValue = document.GetBinaryValue(field);
            if (binaryValue != null)
            {
                return DataAccess.gUnZip(DataAccess.gDecrypt(binaryValue, Encoding.UTF8.GetBytes("!234Qwer)987Poiu")));
            }
            return string.Empty;
        }
        public int[] Search(string searchText, string[] columnNames)
        {
            Query query = MultiFieldQueryParser.Parse(Lucene.Net.Util.Version.LUCENE_30, new List<string>(Enumerable.Repeat<string>(searchText, columnNames.Length)).ToArray(), columnNames, this.analyzer);
            TopFieldDocs topFieldDocs = this.searcher.Search(query, null, this.IndexLength, Sort.INDEXORDER);
            int[] array = new int[topFieldDocs.ScoreDocs.Length];
            for (int i = 0; i < topFieldDocs.ScoreDocs.Length; i++)
            {
                array[i] = topFieldDocs.ScoreDocs[i].Doc + 1;
            }
            return array;
        }
    }
    internal static class AnalyzerBuilder
    {
        internal static PerFieldAnalyzerWrapper BuildAnalyzer(Lucene.Net.Util.Version version, Dictionary<string, AyatColumnAttribute> fieldInfo)
        {
            var analyzer = new StandardAnalyzer(version);
            var analyzer2 = new ArabicAnalyzer(version);
            var whitespaceAnalyzer = new WhitespaceAnalyzer();
            var perFieldAnalyzerWrapper = new PerFieldAnalyzerWrapper(whitespaceAnalyzer);
            foreach (KeyValuePair<string, AyatColumnAttribute> current in fieldInfo)
            {
                switch (current.Value.Language)
                {
                    case Language.Arabic:
                    case Language.ArabicNoAraab:
                        perFieldAnalyzerWrapper.AddAnalyzer(current.Key, analyzer2);
                        continue;
                    case Language.English:
                        perFieldAnalyzerWrapper.AddAnalyzer(current.Key, analyzer);
                        continue;
                }
                perFieldAnalyzerWrapper.AddAnalyzer(current.Key, whitespaceAnalyzer);
            }
            return perFieldAnalyzerWrapper;
        }
    }
}