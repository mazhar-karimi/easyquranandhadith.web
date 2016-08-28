using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace eqwh.web.Models
{
    public enum SearchCategory : byte
    {
        NotSet,
        Ayaat,
        Tarajum,
        Tafaseer,
        TafaseerAula,
        TafaseerWusta,
        TafaseerMojuda,
        English
    }
    public enum AQMode : byte
    {
        Basic,
        Advance,
        Research,
        NotSet = 4
    }
    public enum Kind : byte
    {
        Ayat,
        Tarjuma,
        Tafseer,
        ID,
        Info
    }
    public enum Language
    {
        Arabic,
        ArabicNoAraab,
        Urdu,
        English,
        Hindi,
        Sindhi,
        Bengali
    }
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class AyatColumnAttribute : System.Attribute
    {
        public string Caption
        {
            get;
            private set;
        }
        public string ShortCaption
        {
            get;
            private set;
        }
        public Language Language
        {
            get;
            private set;
        }
        public Kind Kind
        {
            get;
            private set;
        }
        public string Font
        {
            get;
            private set;
        }
        public int FontSize
        {
            get;
            private set;
        }
        public bool Html
        {
            get;
            set;
        }
        public SearchCategory Category
        {
            get;
            set;
        }
        public AQMode Version
        {
            get;
            set;
        }
        public PropertyInfo Property
        {
            get;
            set;
        }
        //public List<TextBoxBase> BoundControls
        //{
        //    get;
        //    private set;
        //}
        public AyatColumnAttribute(string shortCaption, string caption, Language language, Kind kind, string font, int fontSize, bool html = false, SearchCategory category = SearchCategory.NotSet, AQMode version = AQMode.NotSet)
        {
            this.ShortCaption = shortCaption;
            this.Caption = caption;
            this.Language = language;
            this.Kind = kind;
            this.Font = font;
            this.FontSize = fontSize;
            this.Html = html;
            this.Category = category;
            this.Version = version;
            // this.BoundControls = new List<TextBoxBase>();
        }
    }
    public class AyatRow
    {
        private const string arialFont = "Arial Font";
        private const string alviFont = "Alvi Nastaleeq";
        private const string muhammadiFont = "Muhammadi Bold Font";
        private const string muhammadi1Font = "1 Muhammadi Quranic";
        private const string UsmaniNaskhFont = "KFGQPC Uthmanic Script HAFS";
        private const string uighurFont = "Microsoft Uighur";
        private const string krutiFont = "Kruti Dev 010";
        private static Dictionary<string, AyatColumnAttribute> columnsInfo;
        private static List<string> aqBasicVersionColumns;
        private static List<string> aqAdvanceVersionColumns;
        private static List<string> aqResearchVersionColumns;
        [AyatColumn("ID", "ID", Language.English, Kind.ID, "Arial Font", 12, false, SearchCategory.NotSet, AQMode.NotSet)]
        public int ID
        {
            get;
            set;
        }
        [AyatColumn("پارہ نمبر", "پارہ نمبر", Language.English, Kind.Info, "Arial Font", 12, false, SearchCategory.NotSet, AQMode.NotSet)]
        public byte ParahNo
        {
            get;
            set;
        }
        [AyatColumn("سورہ نمبر", "سورہ نمبر", Language.English, Kind.Info, "Arial Font", 12, false, SearchCategory.NotSet, AQMode.NotSet)]
        public byte SurahNo
        {
            get;
            set;
        }
        [AyatColumn("پارہ رکوع نمبر", "پارہ رکوع نمبر", Language.English, Kind.Info, "Arial Font", 12, false, SearchCategory.NotSet, AQMode.NotSet)]
        public byte RukuParahNo
        {
            get;
            set;
        }
        [AyatColumn("سورہ رکوع نمبر", "سورہ رکوع نمبر", Language.English, Kind.Info, "Arial Font", 12, false, SearchCategory.NotSet, AQMode.NotSet)]
        public byte RukuSurahNo
        {
            get;
            set;
        }
        [AyatColumn("آیت نمبر", "آیت نمبر", Language.English, Kind.Info, "Arial Font", 12, false, SearchCategory.NotSet, AQMode.NotSet)]
        public short AyatNo
        {
            get;
            set;
        }
        [AyatColumn("آیت بمع اعراب", "آیت بمع اعراب", Language.Arabic, Kind.Ayat, "Muhammadi Bold Font", 18, false, SearchCategory.Ayaat, AQMode.Basic)]
        public string Ayat
        {
            get;
            set;
        }
        [AyatColumn("آیت بمع اعراب۔نیو", "آیت بمع اعراب۔نیو", Language.Arabic, Kind.Ayat, "1 Muhammadi Quranic", 24, false, SearchCategory.Ayaat, AQMode.Basic)]
        public string AyatNew
        {
            get;
            set;
        }
        [AyatColumn("آیت مصحف عثمانی", "آیت مصحف عثمانی", Language.Arabic, Kind.Tarjuma, "KFGQPC Uthmanic Script HAFS", 24, false, SearchCategory.Ayaat, AQMode.Basic)]
        public string AyatUsmani
        {
            get;
            set;
        }
        [AyatColumn("آیت بغیر اعراب", "آیت بغیر اعراب", Language.ArabicNoAraab, Kind.Ayat, "Muhammadi Bold Font", 18, false, SearchCategory.Ayaat, AQMode.Basic)]
        public string AyatNoAraab
        {
            get;
            set;
        }
        [AyatColumn("آیت بغیر اعراب اردو", "آیت بغیر اعراب اردو", Language.ArabicNoAraab, Kind.Ayat, "Microsoft Uighur", 24, false, SearchCategory.Ayaat, AQMode.Basic)]
        public string AyatNoArabUrdu
        {
            get;
            set;
        }
        [AyatColumn("آیت بمع ترجمہ", "آیت بمع ترجمہ", Language.Arabic, Kind.Ayat, "Microsoft Uighur", 24, true, SearchCategory.Ayaat, AQMode.Basic)]
        public string AyatAndTarjuma
        {
            get;
            set;
        }
        [AyatColumn("رنگین آیت", "رنگین آیت", Language.Arabic, Kind.Ayat, "Microsoft Uighur", 24, true, SearchCategory.Ayaat, AQMode.Basic)]
        public string ColorAyat
        {
            get;
            set;
        }
        [AyatColumn("ابن عباس ۔ تفسیر  mc", "mc (تفسیر ابن عباس پروفیسر محمد سعید احمد عاطف (817  ھ—1416ء ", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Basic)]
        public string TafseerIbnAbbas
        {
            get;
            set;
        }
        [AyatColumn("ابن کثیر ۔ تفسیر ma", "ma (تفسیر ابن کثیر حافظ عماد الدین ابوالفداء ابن کثیر صاحب (770ھ—1370ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Advance)]
        public string TafseerIbnKaseer
        {
            get;
            set;
        }
        [AyatColumn("ابن مسعود ۔ تفسیر mc", "mc (تفسیر ابن مسعود ۔ مترجم: مولانا شمس الدین  (300ھ - 913ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Basic)]
        public string TafseerIbneMasood
        {
            get;
            set;
        }
        [AyatColumn("احسن البیان ۔ ترجمہ   mc", "mc (ترجمہ احسن البیان ۔ مرتب سید فضل الرحمن   (1410ھ - 1990ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaAhsanUlBayan
        {
            get;
            set;
        }
        [AyatColumn("احسن البیان ۔ تفسیر   mc", "mc (تفسیر احسن البیان ۔ مرتب سید فضل الرحمن   (1410ھ - 1990ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerAhsanUlBayan
        {
            get;
            set;
        }
        [AyatColumn("احسن التفاسیر ۔ تفسیر  mc", "mc (تفسیر احسن التفاسیر ۔ حافظ محمد  سید احمد حسن ۔  (1315ھ—1897ء ", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Basic)]
        public string TafseerAhsanUlTafaseer
        {
            get;
            set;
        }
        [AyatColumn("احکام القرآن للجصاص۔ تفسیر mc", "mc (تفسیر احکام القرآن للجصاص۔ مفسر: ابو احمد بن علی الرازی  (365ھ - 975ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Basic)]
        public string TafseerAhkamulQuran
        {
            get;
            set;
        }
        [AyatColumn("احمد علی ۔ ترجمہ  mc", "mc (ترجمہ احمد علی مولانا احمد علی صاحب (1396ھ—1950ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaAhmadAliLahore
        {
            get;
            set;
        }
        [AyatColumn("آسان تحریک ۔ ترجمہ  mc", "mc (ترجمہ آسان تحریک ۔ محمد شبیر احمد  (1402ھ - 1982ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaAsanTahreek
        {
            get;
            set;
        }
        [AyatColumn("آسان قرآن ۔ ترجمہ  mc", "mc (ترجمہ آسان قرآن مفتی تقی عثمانی صاحب (1429ھ—2009ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaAsanQuran
        {
            get;
            set;
        }
        [AyatColumn("آسان قرآن ۔ تفسیر  mc", "mc (تفسیر آسان قرآن مفتی تقی عثمانی صاحب (1429ھ—2009ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerMojuda, AQMode.Basic)]
        public string TafseerAsanQuran
        {
            get;
            set;
        }
        [AyatColumn("اسباب نزول قرآن  mc", "mc (اسباب نزول قرآن  محمد علی نیشا پوری (465ھ—1065ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Basic)]
        public string AsbabeNazool
        {
            get;
            set;
        }
        [AyatColumn("اسرار التنزیل ۔ ترجمہ  mc", "mc (ترجمہ اسرار التنزیل  ۔ مولانا محمد اکرم اعوان  (1405ھ - 1985ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaAsrarulTanzeel
        {
            get;
            set;
        }
        [AyatColumn("اسرار التنزیل ۔ تفسیر ma", "ma (تفسیر اسرار التنزیل  ۔ مولانا محمد اکرم اعوان  (1405ھ - 1985ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Advance)]
        public string TafseerAsrarulTanzeel
        {
            get;
            set;
        }
        [AyatColumn("اشرف التفاسیر ۔ تفسیر  mc", "mc (تفسیر اشرف التفاسیر ۔ اشرف علی تھانوی صاحب ۔ (1368ھ - 1994ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerAshrafutTafaseer
        {
            get;
            set;
        }
        [AyatColumn("اشرف الحواشی ۔ ترجمہ  mc", "mc (ترجمہ اشرف الحواشی ۔ شاہ رفیع صاحب ۔ (1233ھ—1818ء ", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaAshrafulHawashi
        {
            get;
            set;
        }
        [AyatColumn("اشرف الحواشی ۔ تفسیر  mc", "mc (تفسیر اشرف الحواشی ۔ شیخ محمد عبدہ الفلاح ۔ (1233ھ—1818ء ", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Basic)]
        public string TafseerAshrafulHawashi
        {
            get;
            set;
        }
        [AyatColumn("اشرفی ۔ ترجمہ   mc", "mc (ترجمہ اشرفی  ۔ مرتب   (1369ھ - 1950ء ", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaAshrafi
        {
            get;
            set;
        }
        [AyatColumn("اشرفی ۔ تفسیر   mc", "mc (تفسیر اشرفی   ۔ مرتب   (1369ھ - 1950ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerAshrafi
        {
            get;
            set;
        }
        [AyatColumn("البیان الغامدی ۔ ترجمہ  mc", "mc (ترجمہ البیان (الغامدی)   ۔ جاوید احمد غامدی  (1412ھ - 1992ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaAlBayan_Ghamdi
        {
            get;
            set;
        }
        [AyatColumn("البیان الغامدی ۔ تفسیر  mc", "mc (تفسیر البیان (الغامدی)   ۔ جاوید احمد غامدی  (1412ھ - 1992ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Basic)]
        public string TafseerAlBayan_Ghamdi
        {
            get;
            set;
        }
        [AyatColumn("الحسنات ۔ ترجمہ mc", "mc (ترجمہ الحسنات   ۔ علامہ ابو الحسنات سید محمد احمد قادری  (1375ھ - 1956ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaAlHasnat
        {
            get;
            set;
        }
        [AyatColumn("الحسنات ۔ تفسیر) ma", "ma (تفسیر الحسنات   ۔ علامہ ابو الحسنات سید محمد احمد قادری  (1375ھ - 1956ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Advance)]
        public string TafseerAlHasnat
        {
            get;
            set;
        }
        [AyatColumn("السعدی ۔ تفسیر  mc", "mc (تفسیر السعدی  ۔ عبدالرحمن بن ناصر السعدی  ۔ (1366ھ—1947ء ", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerAlSaadi
        {
            get;
            set;
        }
        [AyatColumn("القرآن الکریم ۔ ترجمہ  mc", "mc (ترجمہ القرآن الکریم  حافظ عبدالسلام بھٹوی (1427ھ—2007ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaBotvi
        {
            get;
            set;
        }
        [AyatColumn("القرآن الکریم ۔ تفسیر ma", "ma (تفسیر القرآن الکریم  حافظ عبدالسلام بھٹوی (1427ھ—2007ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerMojuda, AQMode.Advance)]
        public string TafseerUlQuranKarim
        {
            get;
            set;
        }
        [AyatColumn("الکتاب ۔ ترجمہ  mc", "mc (ترجمہ الکتاب ڈاکٹر محمد عثمان صاحب (1425ھ—2005ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaAlkitab
        {
            get;
            set;
        }
        [AyatColumn("الکتاب ۔ تفسیر  mc", "mc (تفسیر الکتاب ڈاکٹر محمد عثمان صاحب (1425ھ—2005ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerMojuda, AQMode.Basic)]
        public string TafseerAlkitab
        {
            get;
            set;
        }
        [AyatColumn("المنار ۔ ترجمہ   mc", "mc (ترجمہ المنار  ۔ مرتب   (1411ھ - 1991ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaAlManar
        {
            get;
            set;
        }
        [AyatColumn("المنار ۔ تفسیر   mc", "mc (تفسیر المنار  ۔ مرتب   (1411ھ - 1991ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerAlManar
        {
            get;
            set;
        }
        [AyatColumn("امداد الکرم ۔ تفسیر ma", "ma (تفسیر امداد الکرم  ۔ محمد امداد حسین پیرزادہ  (1420ھ - 2000ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Research)]
        public string TafseerImdadulKaram
        {
            get;
            set;
        }
        [AyatColumn("امدادالکرم ۔ ترجمہ  mc", "mc (ترجمہ امدادالکرم  ۔ محمد امداد حسین پیرزادہ  (1420ھ - 2000ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaImdadulKaram
        {
            get;
            set;
        }
        [AyatColumn("انوار القرآن ۔ تفسیر   mc", "mc (تفسیر انوار القرآن  ۔ مرتب ڈاکٹر ملک غلام مرتضی   (1414ھ - 1994ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerAnwarUlQuran
        {
            get;
            set;
        }
        [AyatColumn("انوارالبیان (قرآن گرامر)  mc", "mc (انوارالبیان محمد علی پی سی ایس (1425ھ - 2005ء ", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerMojuda, AQMode.Basic)]
        public string Anwarulbayan
        {
            get;
            set;
        }
        [AyatColumn("انوارالبیان ۔ ترجمہ  mc", "mc (ترجمہ انوارالبیان مولانا عاشق الہٰی صاحب (1430ھ—2009ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaAnwarulbayan
        {
            get;
            set;
        }
        [AyatColumn("انوارالبیان ۔ تفسیر ma", "ma (تفسیر انوارالبیان مولانا عاشق الہٰی صاحب (1430ھ—2009ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerMojuda, AQMode.Advance)]
        public string TafseerAnwarUlBayan
        {
            get;
            set;
        }
        [AyatColumn("بصیرت قرآن ۔ ترجمہ   mc", "mc (ترجمہ بصیرت قرآن  ۔ مولانا محمد آصف قاسمی  (1400ھ - 1980ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaBaseerateQuran
        {
            get;
            set;
        }
        [AyatColumn("بصیرت قرآن ۔ تفسیر   mc", "mc (تفسیر بصیرت قرآن  ۔ مولانا محمد آصف قاسمی  (1400ھ - 1980ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerBaseerateQuran
        {
            get;
            set;
        }
        [AyatColumn("بغوی ۔ تفسیر ma", "ma (تفسیر بغوی  ۔ ابو محمد حسین بن مسعود الفراء بغوی  (516ھ - 1122ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Advance)]
        public string TafseerBaghvi
        {
            get;
            set;
        }
        [AyatColumn("بیان القرآن (اسرار) ۔ ترجمہ   mc", "mc (ترجمہ بیان القرآن ڈاکٹر اسرار احمد صاحب (1428ھ—2008ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaBayanUlQuranDrIsrar
        {
            get;
            set;
        }
        [AyatColumn("بیان القرآن (تھانوی) ۔ ترجمہ   mc", "mc (ترجمہ بیان القرآن مولانا اشرف علی تھانوی صاحب (1352ھ—1934ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaBayanUlQuran
        {
            get;
            set;
        }
        [AyatColumn("بیان القرآن (تھانوی) ۔ تفسیر   mc", "mc (تفسیر بیان القرآن مولانا اشرف علی تھانوی صاحب (1352ھ—1934ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerBayanUlQuran
        {
            get;
            set;
        }
        [AyatColumn("بیان القرآن(اسرار) ۔ تفسیر   mc", "mc (تفسیر بیان القرآن ڈاکٹر اسرار احمد صاحب (1428ھ—2008ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerMojuda, AQMode.Basic)]
        public string TafseerBayanUlQuranDrIsrar
        {
            get;
            set;
        }
        [AyatColumn("تبیان القرآن ۔ ترجمہ  mc", "mc (ترجمہ تبیان القرآن   ۔  مولانا غلام رسول سعیدی  صاحب ۔ (1416ھ—1995ء ", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaTibyanulQuran
        {
            get;
            set;
        }
        [AyatColumn("تبیان القرآن ۔ تفسیر ma", "ma (تفسیر تبیان القرآن   ۔  مولانا غلام رسول سعیدی  صاحب ۔ (1416ھ—1995ء ", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Advance)]
        public string TafseerTibyanulQuran
        {
            get;
            set;
        }
        [AyatColumn("تدبر قرآن ۔ ترجمہ  mc", "mc (ترجمہ تدبر قرآن  ۔  مولانا امین احسن اصلاحی صاحب ۔ (1400ھ—1980ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaTadubbureQuran
        {
            get;
            set;
        }
        [AyatColumn("تدبر قرآن۔تفسیر  ma", "ma (تفسیر تدبر قرآن  ۔  مولانا امین احسن اصلاحی صاحب ۔ (1400ھ—1980ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Advance)]
        public string TafseerTadubbureQuran
        {
            get;
            set;
        }
        [AyatColumn("تذکیر القرآن ۔ ترجمہ  mc", "mc (ترجمہ تذکیر القرآن  وحید الدین خان صاحب (1370ھ—1970ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaWahiduddinKhan
        {
            get;
            set;
        }
        [AyatColumn("تذکیر القرآن ۔ تفسیر  mc", "mc (تفسیر تذکیر القرآن ۔  وحید الدین خان صاحب ۔ (1401ھ—1981ء ", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerTazkirulQuran
        {
            get;
            set;
        }
        [AyatColumn("ترجمان القرآن ۔ ترجمہ  mc", "mc (ترجمہ ترجمان القرآن  ۔ مولانا ابوالکلام آزاد صاحب ۔ (1350ھ—1931ء ", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaTarjumanUlQuran
        {
            get;
            set;
        }
        [AyatColumn("ترجمان القرآن ۔ تفسیر  mc", "mc (تفسیر ترجمان القرآن  ۔ مولانا ابوالکلام آزاد صاحب ۔ (1350ھ—1931ء ", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerTarjumanUlQuran
        {
            get;
            set;
        }
        [AyatColumn("ترجمہ بنگالی mr ", "mr ترجمہ بنگالی", Language.Bengali, Kind.Tarjuma, "Microsoft Uighur", 24, false, SearchCategory.Tarajum, AQMode.Research)]
        public string TarjumaBangali
        {
            get;
            set;
        }
        [AyatColumn("ترجمہ سندھی mr", "mr ترجمہ سندھی ", Language.Sindhi, Kind.Tarjuma, "Microsoft Uighur", 24, false, SearchCategory.Tarajum, AQMode.Research)]
        public string TarjumaSindhi
        {
            get;
            set;
        }
        [AyatColumn("تسہیل القرآن ۔ ترجمہ  mc", "mc (ترجمہ تسہیل القران ۔ مرتب مولوی فیروزالدین صاحب  (1362ھ - 1943ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaTasheelulQuran
        {
            get;
            set;
        }
        [AyatColumn("تسہیل القرآن ۔ تفسیر  mc", "mc (تفسیر تسہیل القران ۔ مرتب مولوی فیروزالدین صاحب  (1362ھ - 1943ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerTasheelulQuran
        {
            get;
            set;
        }
        [AyatColumn("تفسیرات احمدیہ ۔ تفسیر   mc", "mc (تفسیرات احمدیہ  ۔ مرتب ملااحمد جیون  (1069ھ ۔ 1659ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Basic)]
        public string TafseeratAhmadia
        {
            get;
            set;
        }
        [AyatColumn("تفہیم القرآن ۔ ترجمہ  mc", "mc (ترجمہ تفہیم القرآن مولانا سید ابوالاعلی مودودی صاحب  (1368ھ—1949ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaMudoodi
        {
            get;
            set;
        }
        [AyatColumn("تفہیم القرآن ۔ تفسیر  mc", "mc (تفسیر تفہیم القرآن  مولانا سید ابوالاعلی مودودی صاحب  (1368ھ—1949ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerMudoodi
        {
            get;
            set;
        }
        [AyatColumn("تیسیر الرحمن لبیان القرآن ۔ ترجمہ  mc", "mc (ترجمہ تیسیر الرحمن لبیان القرآن   ۔ محمد لقمان سلفی صاحب ۔ (1421ھ—2000ء ", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaTaiseerurRehman
        {
            get;
            set;
        }
        [AyatColumn("تیسیر الرحمن لبیان القرآن ۔ تفسیر  mc", "mc (تفسیر تیسیر الرحمن لبیان القرآن   ۔ محمد لقمان سلفی صاحب ۔ (1421ھ—2000ء ", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerMojuda, AQMode.Basic)]
        public string TafseerTaiseerurRehman
        {
            get;
            set;
        }
        [AyatColumn("تیسیر القرآن ۔ ترجمہ  mc", "mc (ترجمہ تیسیر القرآن مولانا عبدالرحمن کیلانی صاحب (1416ھ—1996ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaTayseerulquran
        {
            get;
            set;
        }
        [AyatColumn("تیسیر القرآن ۔ تفسیر  mc", "mc (تفسیر تیسیر القرآن مولانا عبدالرحمن کیلانی صاحب (1416ھ—1996ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerTayseerulquran
        {
            get;
            set;
        }
        [AyatColumn("ثنائی ۔ تفسیر  mc", "mc (تفسیر ثنائی ۔ ثناء اللہ امرتسری ۔  (1313ھ—1895ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Basic)]
        public string TafseerSanai
        {
            get;
            set;
        }
        [AyatColumn("جلالین ۔ تفسیر  ma", "ma (تفسیر جلالین    ۔ جلال الدین سیوطی صاحب ۔ (911ھ—1505ء ", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Advance)]
        public string TafseerJalalainUrdu
        {
            get;
            set;
        }
        [AyatColumn("جواہر القرآن ۔ ترجمہ  mc", "mc (ترجمہ جواہر القرآن ۔ شاہ عبدالقادر (1392ھ - 1972ء ", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaJawahirulQuran
        {
            get;
            set;
        }
        [AyatColumn("جواہر القرآن ۔ تفسیر  mc", "mc (تفسیر جواہر القرآن ۔ مولانا غلام اللہ خان صاحب ۔ (1392ھ—1972ء ", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerJawahirulQuran
        {
            get;
            set;
        }
        [AyatColumn("حقانی ۔ ترجمہ  mc", "ترجمہ حقانی ابو محمد عبدالحق حقانی  (1389ھ—1969ء)", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaHaqqani
        {
            get;
            set;
        }
        [AyatColumn("حقانی ۔ تفسیر  mc", "mc (تفسیر حقانی ابو محمد عبدالحق حقانی  (1389ھ—1969ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerHaqqani
        {
            get;
            set;
        }
        [AyatColumn("حل القرآن ۔ ترجمہ   mc", "mc (ترجمہ حل القرآن  ۔  اشرف علی تھانوی صاحب   (1345ھ - 1926ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaHallelQuran
        {
            get;
            set;
        }
        [AyatColumn("حل القرآن ۔ تفسیر   mc", "mc (تفسیر حل القرآن  ۔  اشرف علی تھانوی صاحب   (1345ھ - 1926ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerHallelQuran
        {
            get;
            set;
        }
        [AyatColumn("خلاصہ مضامین قرآن  mc", "mc (خلاصہ مضامین قرآن انجینئر نوید احمد صاحب (1433ھ - 2012ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerMojuda, AQMode.Basic)]
        public string KhulasaMazameenQuran
        {
            get;
            set;
        }
        [AyatColumn("در منثور ۔ ترجمہ  mc", "mc (ترجمہ در منثور جلال الدین سیوطی (908ھ—1507ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaDureeMansoor
        {
            get;
            set;
        }
        [AyatColumn("در منثور ۔ تفسیر  ma", "ma (تفسیر در منثور جلال الدین سیوطی (908ھ—1507ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Advance)]
        public string TafseerDureeMansoor
        {
            get;
            set;
        }
        [AyatColumn("دعوۃ القرآن ۔ تفسیر  ma", "ma (تفسیر دعوۃ القرآن ابو نعمان سیف اللہ خالد صاحب (1431ھ—2010ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerMojuda, AQMode.Advance)]
        public string TafseerDawatulQuran
        {
            get;
            set;
        }
        [AyatColumn("دعوت قرآن ۔ ترجمہ  mc", "mc (ترجمہ دعوت قرآن شمس پیرزادہ صاحب (1416ھ - 1996ء ", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaDawateQuran
        {
            get;
            set;
        }
        [AyatColumn("دعوت قرآن۔تفسیر  mc", "mc  (تفسیر دعوت قرآن شمس پیرزادہ صاحب (1416ھ - 1996ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerDawateQuran
        {
            get;
            set;
        }
        [AyatColumn("ڈاکٹر فرحت ہاشمی ۔ ترجمہ لفظی  mc", "mc (ترجمہ لفظی ڈاکٹر فرحت ہاشمی (1425ھ - 2005ء ", Language.Urdu, Kind.Tarjuma, "Microsoft Uighur", 24, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaLafziDrFarhatHashmi
        {
            get;
            set;
        }
        [AyatColumn("ذخیرۃ الجنان۔ ترجمہ mc", "mc (ترجمہ ذخیرۃ الجنان ۔ مترجم مولانا سرفراز خان صفدر صاحب (1419ھ - 1998ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaZakhiratulJinan
        {
            get;
            set;
        }
        [AyatColumn("ذخیرۃ الجنان۔ تفسیر ma", "ma (تفسیر ذخیرۃ الجنان۔ مفسر:  مولانا سرفراز خان صفدر صاحب   (1419ھ - 1998ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerZakhiratulJinan
        {
            get;
            set;
        }
        [AyatColumn("روح القران ۔ تفسیر  ma", "ma (تفسیر روح القران  ۔ ڈاکٹر محمد اسلم صدیقی صاحب ۔ (1433ھ—2012ء ", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerMojuda, AQMode.Advance)]
        public string TafseerRohulQuran
        {
            get;
            set;
        }
        [AyatColumn("روح القران ۔ تفسیر  mc", "mc (ترجمہ روح القران   ۔ ڈاکٹر محمد اسلم صدیقی صاحب ۔ (1433ھ—2012ء ", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaRohulQuran
        {
            get;
            set;
        }
        [AyatColumn("سراج البیان ۔ ترجمہ   mc", "mc (ترجمہ سراج البیان  ۔ مرتب مولانا حنیف ندوی  (1390ھ - 1970ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaSirajUlBayan
        {
            get;
            set;
        }
        [AyatColumn("سراج البیان ۔ تفسیر   mc", "mc (تفسیر سراج البیان  ۔ مرتب مولانا حنیف ندوی  (1390ھ - 1970ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerSirajUlBayan
        {
            get;
            set;
        }
        [AyatColumn("سندھی  سرہندی ۔ ترجمہ mr", "mr ترجمہ سندھی سرہندی", Language.Sindhi, Kind.Tarjuma, "Microsoft Uighur", 24, false, SearchCategory.Tarajum, AQMode.Research)]
        public string TarjumaSindhiSirhindi
        {
            get;
            set;
        }
        [AyatColumn("شان نزول قرآن  mc", "mc شان نزول قرآن", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerMojuda, AQMode.Basic)]
        public string ShaneNazool
        {
            get;
            set;
        }
        [AyatColumn("شاہ عبدالقادر ۔ ترجمہ  mc", "mc (ترجمہ شاہ عبدالقادر شاہ عبدالقادر صاحب (1194ھ - 1780ء ", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaShahAbdulQadir
        {
            get;
            set;
        }
        [AyatColumn("ضیاء القرآن ۔ ترجمہ  mc", "mc (ترجمہ ضیاء القرآن  پیر کرم شاہ صاحب (1415ھ—1915ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaZiaulQuran
        {
            get;
            set;
        }
        [AyatColumn("ضیاء القرآن ۔ تفسیر  mc", "mc (تفسیر ضیاء القرآن پیر کرم شاہ صاحب (1415ھ—1915ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerZiaulQuran
        {
            get;
            set;
        }
        [AyatColumn("عبدالکریم ۔ ترجمہ  mc", "mc (ترجمہ عبدالکریم اثری عبدالکریم اثری صاحب (1414ھ—1994ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaAbdulKareemAsri
        {
            get;
            set;
        }
        [AyatColumn("عثمانی ۔ ترجمہ  mc", "mc (ترجمہ عثمانی مترجم مولانا محمود الحسن  (1356ھ—1938ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaUsmani
        {
            get;
            set;
        }
        [AyatColumn("عثمانی ۔ تفسیر  mc", "mc (تفسیر عثمانی مفسر مولانا شبیر احمد عثمانی صاحب (1356ھ—1938ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerUsmani
        {
            get;
            set;
        }
        [AyatColumn("عرفان القرآن ۔ ترجمہ  mc", "mc (ترجمہ عرفان القرآن ڈاکٹر طاہر القادری (1411ھ—1991ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaIrfanulQuranUrdu
        {
            get;
            set;
        }
        [AyatColumn("عروۃ الوثقی ۔ ترجمہ   mc", "mc (ترجمہ عروۃ الوثقی ۔ مرتب   (1414ھ - 1994ء ", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaUrwatUlWasqa
        {
            get;
            set;
        }
        [AyatColumn("عروۃ الوثقی ۔ تفسیر  ma", "ma (تفسیر عروۃ الوثقی  ۔ مرتب   (1414ھ - 1994ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Advance)]
        public string TafseerUrwatUlWasqa
        {
            get;
            set;
        }
        [AyatColumn("فتح محمد ابن کثیر ۔ ترجمہ  mc", "mc (ترجمہ ابن کثیر(فتح محمد", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaFatehMuhammad
        {
            get;
            set;
        }
        [AyatColumn("فہم القرآن ۔ ترجمہ  mc", "mc  (ترجمہ فہم القرآن میاں محمد جمیل  میاں محمد جمیل صاحب (1425ھ - 2005ء ", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaFahmulQuran
        {
            get;
            set;
        }
        [AyatColumn("فہم القرآن ۔ ترجمہ لفظی  mc", "mc  (ترجمہ لفظی فہم القرآن میاں محمد جمیل (1425ھ - 2005ء", Language.Urdu, Kind.Tarjuma, "Microsoft Uighur", 24, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaLafziFahmulQuran
        {
            get;
            set;
        }
        [AyatColumn("فہم القرآن ۔ تفسیر ma", "mc (تفسیر فہم القرآن میاں محمد جمیل میاں محمد جمیل صاحب (1425ھ - 2005ء  ", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerMojuda, AQMode.Advance)]
        public string TafseerFahmulQuran
        {
            get;
            set;
        }
        [AyatColumn("فوائد القران ۔ ترجمہ  mc", "mc (ترجمہ فوائد القران ۔ مرتب عبدالقیوم مہاجر مدنی صاحب  (1425ھ - 2005ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaFawaidUlQuran
        {
            get;
            set;
        }
        [AyatColumn("فوائد القران ۔ تفسیر  mc", "mc (تفسیر فوائد القران ۔ مرتب عبدالقیوم مہاجر مدنی صاحب ۔ (1425ھ - 2005ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerMojuda, AQMode.Basic)]
        public string TafseerFawaidUlQuran
        {
            get;
            set;
        }
        [AyatColumn("فی ظلال القرآن ۔ ترجمہ  mc", "mc (ترجمہ فی ظلال القرآن ۔ مرتب سید قطب شہید  (1382ھ - 1962ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumFizilalulQuran
        {
            get;
            set;
        }
        [AyatColumn("فی ظلال القرآن ۔ تفسیر ma", "ma (تفسیر فی ظلال القرآن ۔ مرتب سید قطب شہید  (1382ھ - 1962ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Advance)]
        public string TafseerFizilalulQuran
        {
            get;
            set;
        }
        [AyatColumn("فیوض القرآن ۔ تفسیر mc", "mc (تفسیر فیوض القرآن  ۔ ڈاکٹر سید حامد حسن بلگرامی  (1387ھ - 1967ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Basic)]
        public string TafseerFuyoozUlQuran
        {
            get;
            set;
        }
        [AyatColumn("قرطبی ۔ تفسیر ma", "ma (تفسیر قرطبی ۔  ابو عبداللہ محمد بن احمد بن ابوبکر قرطبی ۔ (671ھ—1273ء ", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Advance)]
        public string TafseerQurtabi
        {
            get;
            set;
        }
        [AyatColumn("کشف الرحمن ۔ ترجمہ mc", "mc (ترجمہ کشف الرحمن  ۔ مولانا احمد سعید دہلوی  (1381ھ - 1962ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaKashafuRehman
        {
            get;
            set;
        }
        [AyatColumn("کشف الرحمن ۔ تفسیر ma", "ma (تفسیر کشف الرحمن  ۔ مولانا احمد سعید دہلوی  (1381ھ - 1962ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Advance)]
        public string TafseerKashafuRehman
        {
            get;
            set;
        }
        [AyatColumn("کنزالایمان ۔ خزائن العرفان ۔ ترجمہ  mc", "mc (ترجمہ کنز الایمان مولانا احمد رضاخان  بریلوی  (1364ھ—1945ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaKanzulIman
        {
            get;
            set;
        }
        [AyatColumn("کنزالایمان ۔ خزائن العرفان ۔ تفسیر  mc", "mc (تفسیر خزائن العرفان علامہ نعیم الدین مراد آبادی (1364ھ—1945ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerKhazainUlIrfan
        {
            get;
            set;
        }
        [AyatColumn("ماجدی ۔ ترجمہ  mc", "mc (ترجمہ ماجدی عبدالماجد دریا آبادی (1395ھ—1975ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaMajdi
        {
            get;
            set;
        }
        [AyatColumn("ماجدی ۔ تفسیر  mc", "mc (تفسیر ماجدی عبدالماجد دریا آبادی (1395ھ—1975ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerMajdi
        {
            get;
            set;
        }
        [AyatColumn("محمود ۔ تفسیر  mc", "mc (تفسیر محمود ۔ مفتی محمود صاحب ۔ (1395ھ—1970ء ", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerMehmood
        {
            get;
            set;
        }
        [AyatColumn("مختصر تفسیر عتیق ۔ تفسیر mc", "mc (مختصر تفسیر عتیق  ۔ مفتی عتیق الرحمن شہید  (1423ھ - 2002ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerMojuda, AQMode.Research)]
        public string MukhtasarTafseerAteeq
        {
            get;
            set;
        }
        [AyatColumn("مدارک التنزیل ۔ تفسیر  mc", "mc (تفسیر مدارک التنزیل ۔ ابوالبرکات عبداللہ بن احمد محمد بن محمود النسفی ۔ (710ھ—1310ء ", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Basic)]
        public string TafseerMadarikalTanzeel
        {
            get;
            set;
        }
        [AyatColumn("مدنی ۔ ترجمہ  mc", "mc (ترجمہ مدنی   مولانا اسحاق مدنی صاحب  (آزاد کشمیر) (1432ھ—2012ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaMadni
        {
            get;
            set;
        }
        [AyatColumn("مدنی ۔ تفسیر  mc", "mc (تفسیر مدنی  مولانا اسحاق مدنی صاحب  (آزاد کشمیر) (1432ھ—2012ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerMojuda, AQMode.Basic)]
        public string TafseerMadni
        {
            get;
            set;
        }
        [AyatColumn("مدنی کبیر ۔ تفسیر ma", "ma (تفسیر مدنی کبیر  مولانا اسحاق مدنی صاحب  (آزاد کشمیر) (1432ھ—2012ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerMojuda, AQMode.Advance)]
        public string TafseerMadniKabeer
        {
            get;
            set;
        }
        [AyatColumn("مصباح القرآن رنگین ترجمہ  mc", "mc (رنگین ترجمہ (1436ھ - 2015ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, true, SearchCategory.Tarajum, AQMode.Basic)]
        public string ColorTarjuma
        {
            get;
            set;
        }
        [AyatColumn("مصباح القرآن مترادف الفاظ  mc", "mc  مصباح القرآن مترادف الفاظ", Language.Urdu, Kind.Tarjuma, "Microsoft Uighur", 24, true, SearchCategory.Tarajum, AQMode.Basic)]
        public string Keywords
        {
            get;
            set;
        }
        [AyatColumn("مطالعہ قرآن  mc", "mc (مطالعہ قرآن پروفیسر حافظ احمد یار (1368ھ - 1994ء ", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string MutalaQuran
        {
            get;
            set;
        }
        [AyatColumn("مظہر القرآن ۔ ترجمہ   mc", "mc (ترجمہ  مظہر القرآن  ۔ مرتب شاہ محمد مظہر اللہ دہلوی  (1369ھ - 1950ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaMazharulQuran
        {
            get;
            set;
        }
        [AyatColumn("مظہر القرآن ۔ تفسیر   mc", "mc (تفسیر مظہر القرآن  ۔ مرتب شاہ محمد مظہر اللہ دہلوی  (1369ھ - 1950ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerMazharulQuran
        {
            get;
            set;
        }
        [AyatColumn("مظہری ۔ تفسیر ma", "ma (تفسیر مظہری قاضی ثناءاللہ پانی پتی (1220ھ—1820ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Advance)]
        public string TafseerMazhari
        {
            get;
            set;
        }
        [AyatColumn("معارف الفرقان ۔ تفسیر ma", "ma (تفسیر معارف الفرقان۔ مفسر: مولانا عبدالقیوم قاسمی صاحب  (1437ھ - 2016ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerMojuda, AQMode.Basic)]
        public string TafseerMarifulFurqan
        {
            get;
            set;
        }
        [AyatColumn("معارف القرآن (شفیع ۔ ترجمہ   mc", "mc (ترجمہ معارف القرآن مفتی محمد شفیع صاحب (1389ھ—1969ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaMarifUlQuran
        {
            get;
            set;
        }
        [AyatColumn("معارف القرآن (شفیع ۔ تفسیر  ma", "ma (تفسیر معارف القرآن مفتی محمد شفیع صاحب (1389ھ—1969ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Advance)]
        public string TafseerMarifUlQuran
        {
            get;
            set;
        }
        [AyatColumn("معارف القرآن (کاندہلوی ۔ تفسیر  ma", "ma (تفسیر معارف القرآن مولاناادریس کاندہلوی صاحب (1382ھ—1962ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Advance)]
        public string TafseerMarifUlQuran_Idrees
        {
            get;
            set;
        }
        [AyatColumn("معالم العرفان ۔ ترجمہ mc", "mc (ترجمہ معالم العرفان  ۔ مولانا صوفی عبدالحمید سواتی  (1404ھ - 1984ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaMalimulIrfaan
        {
            get;
            set;
        }
        [AyatColumn("معالم العرفان ۔ تفسیر ma", "ma (تفسیر معالم العرفان  ۔ مولانا صوفی عبدالحمید سواتی  (1404ھ - 1984ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Advance)]
        public string TafseerMalimulIrfaan
        {
            get;
            set;
        }
        [AyatColumn("مفردات القرآن ۔ تفسیر mc", "mc (تفسیر مفردات القرآن  ۔ مولانا محمد عبدہٗ فیروز پوری  (502ھ - 1108ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Basic)]
        public string TafseerMufradatulQuran
        {
            get;
            set;
        }
        [AyatColumn("مفہوم القرآن ۔ ترجمہ  mc", "mc (ترجمہ مفہوم القرآن رفعت اعجاز صاحبہ (1433ھ—2012ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaMafhoomUlQuran
        {
            get;
            set;
        }
        [AyatColumn("مفہوم القرآن ۔ تفسیر  mc", "mc (تفسیر مفہوم القرآن  رفعت اعجاز صاحبہ (1429ھ—2012ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerMojuda, AQMode.Basic)]
        public string TafseerMafhoomUlQuran
        {
            get;
            set;
        }
        [AyatColumn("مکہ ۔ ترجمہ  mc", "mc (ترجمہ مکہ  مولانا جوناگڑھی صاحب   (مطبع  شاہ فہدقرآن کمپلیکس سعودی عرب) (1414ھ—1994ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaMakkah
        {
            get;
            set;
        }
        [AyatColumn("مکہ ۔ تفسیر  mc", "mc (تفسیر مکہ  مفسر مولانا صلاح الدین یوسف صاحب (مطبع  شاہ فہدقرآن کمپلیکس سعودی عرب) (1414ھ—1994ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerMojuda, AQMode.Basic)]
        public string TafseerMakkah
        {
            get;
            set;
        }
        [AyatColumn("موضح القرآن ۔ ترجمہ   mc", "mc (ترجمہ موضح القرآن  ۔ مرتب شاہ عبد القادر  (1256ھ - 1840ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaMozihulQuran
        {
            get;
            set;
        }
        [AyatColumn("موضح القرآن ۔ تفسیر   mc", "mc (تفسیر موضح القرآن  ۔ مرتب شاہ عبد القادر  (1256ھ - 1840ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Basic)]
        public string TafseerMozihulQuran
        {
            get;
            set;
        }
        [AyatColumn("نذر احمد ۔ ترجمہ  mc", "mc (ترجمہ حافظ نذر احمد (1408ھ - 1987ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaNazarAhmad
        {
            get;
            set;
        }
        [AyatColumn("نذر احمد ۔ ترجمہ لفظی  mc", "mc (ترجمہ لفظی حافظ نذر احمد (1408ھ - 1987ء", Language.Urdu, Kind.Tarjuma, "Microsoft Uighur", 24, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaLafziNazarAhmad
        {
            get;
            set;
        }
        [AyatColumn("نکات القرآن ۔ تفسیر mc", "mc (تفسیر نکات القرآن  ۔ مولانا عبدالرحمن اشرفی  (1405ھ - 1985ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Basic)]
        public string TafseerNikatulQuran
        {
            get;
            set;
        }
        [AyatColumn("نورالعرفان ۔ ترجمہ   mc", "mc (ترجمہ نورالعرفان(1369ھ—1950ء  ", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Basic)]
        public string TarjumaNoorulIrfan
        {
            get;
            set;
        }
        [AyatColumn("نورالعرفان ۔ تفسیر  mc", "mc (تفسیر نورالعرفان(1369ھ—1950ء  ", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Basic)]
        public string TafseerNoorulIrfan
        {
            get;
            set;
        }
        [AyatColumn("الکوثر ۔ ترجمہ (اہل تشیع mr", "mr (ترجمہ الکوثر (اہل تشیع)  ۔ محسن علی نجفی  (1432ھ - 2011ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Research)]
        public string TarjumaAlkousar_AT
        {
            get;
            set;
        }
        [AyatColumn("الکوثر ۔ تفسیر (اہل تشیع mr", "mr (تفسیر الکوثر (اہل تشیع)  ۔ محسن علی نجفی  (1432ھ - 2011ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerMojuda, AQMode.Research)]
        public string TafseerAlkousar_AT
        {
            get;
            set;
        }
        [AyatColumn("بلاغ القرآن ۔ تفسیر (اہل تشیع) mr", "mr (تفسیر بلاغ القرآن (اہل تشیع)  ۔ محسن علی نجفی  (1432ھ - 2011ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerMojuda, AQMode.Research)]
        public string TafseerBalaghulQuran_AT
        {
            get;
            set;
        }
        [AyatColumn("تفسیرالقرآن ۔ ترجمہ (اہل تشیع mr", "mr (ترجمہ تفسیرالقرآن  (اہل تشیع)  ۔ سید ظفر حسن امروہوی  (1397ھ - 1977ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Research)]
        public string TarjumaTafseerUlQuran_AT
        {
            get;
            set;
        }
        [AyatColumn("تفسیرالقرآن ۔ تفسیر (اہل تشیع mr", "mr (تفسیر تفسیرالقرآن  (اہل تشیع)  ۔ سید ظفر حسن امروہوی  (1397ھ - 1977ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Research)]
        public string TafseerTafseerUlQuran_AT
        {
            get;
            set;
        }
        [AyatColumn("جوادی ۔ ترجمہ (اہل تشیع mr", "ترجمہ جوادی (اہل تشیع) ۔ ذیشان حیدر جوادی صاحب(1380ھ—1980ء ", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Research)]
        public string TarjumaJawadi
        {
            get;
            set;
        }
        [AyatColumn("راہنما ۔ ترجمہ (اہل تشیع mr", "mr (ترجمہ راہنما (اہل تشیع)  ۔ آيت الله ہاشمى رفسنجاني   (1423ھ - 2002ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Research)]
        public string TarjumaRahnuma_AT
        {
            get;
            set;
        }
        [AyatColumn("راہنما ۔ تفسیر (اہل تشیع) mr", "mr (تفسیر راہنما (اہل تشیع)  ۔ آيت الله ہاشمى رفسنجاني  (1423ھ - 2002ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Research)]
        public string TafseerRahnuma_AT
        {
            get;
            set;
        }
        [AyatColumn("سید علی نقی ۔ ترجمہ (اہل تشیع mr", "mr (ترجمہ سید علی نقی (اہل تشیع)  ۔ سید صفدر حسین نجفی  (1406ھ - 1986ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Research)]
        public string TarjumaSyedAliNaqi_AT
        {
            get;
            set;
        }
        [AyatColumn("شواہد قرآنی ۔ تفسیر (اہل تشیع) mr", "mr (تفسیر شواہد قرآنی (اہل تشیع)  ۔ شیخ محمد علی توحیدی  (1436ھ - 2015ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Research)]
        public string TafseerShawahidelQurani_AT
        {
            get;
            set;
        }
        [AyatColumn("عمدۃ البیان ۔ تفسیر (اہل تشیع) mr", "mr (تفسیر عمدۃ البیان (اہل تشیع)  ۔ سید عمار علی  (1317ھ - 1900ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Research)]
        public string TafseerUmdatulBayan_AT
        {
            get;
            set;
        }
        [AyatColumn("فرات ۔ تفسیر (اہل تشیع) mr", "mr (تفسیر فرات (اہل تشیع)  ۔ فرت بن ابراہیم بن فرات کوفی  (300ھ - 913ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Research)]
        public string TafseerFurat_AT
        {
            get;
            set;
        }
        [AyatColumn("فصل الخطاب ۔ ترجمہ (اہل تشیع mr", "mr (ترجمہ فصل الخطاب (اہل تشیع)  ۔ علامہ سید علی نقی النقوی  (1408ھ - 1988ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Research)]
        public string TarjumaFaslulkhitab_AT
        {
            get;
            set;
        }
        [AyatColumn("فصل الخطاب ۔ تفسیر (اہل تشیع) mr", "mr (تفسیر فصل الخطاب (اہل تشیع)  ۔ علامہ سید علی نقی النقوی  (1408ھ - 1988ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Research)]
        public string TafseerFaslulkhitab_AT
        {
            get;
            set;
        }
        [AyatColumn("فیضان الرحمن ۔ تفسیر (اہل تشیع) mr", "mr (تفسیر فیضان الرحمن (اہل تشیع)  ۔ شیخ محمد حسین النجفی (1420ھ - 1999ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerAula, AQMode.Research)]
        public string TafseerFaizanulRehman_AT
        {
            get;
            set;
        }
        [AyatColumn("محمد حسین ۔ ترجمہ (اہل تشیع) mr", "ترجمہ محمد حسین (اہل تشیع) ۔   نجفی محمد حسین نجفی صاحب  (1378ھ—1978ء)", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.NotSet, AQMode.NotSet)]
        public string TarjumaMuhmmadHussainNajfi
        {
            get;
            set;
        }
        [AyatColumn("نمونہ ۔ ترجمہ (اہل تشیع mr", "mr (ترجمہ نمونہ  (اہل تشیع)  ۔ سید صفدر حسین نجفی  (1406ھ - 1986ء", Language.Urdu, Kind.Tarjuma, "Alvi Nastaleeq", 14, false, SearchCategory.Tarajum, AQMode.Research)]
        public string TarjumaNamoona_AT
        {
            get;
            set;
        }
        [AyatColumn("نمونہ ۔ تفسیر  (اہل تشیع) mr", "mr (تفسیر نمونہ  (اہل تشیع)  ۔ سید صفدر حسین نجفی  (1406ھ - 1986ء", Language.Urdu, Kind.Tafseer, "Alvi Nastaleeq", 14, false, SearchCategory.TafaseerWusta, AQMode.Research)]
        public string TafseerNamoona_AT
        {
            get;
            set;
        }
        [AyatColumn("Quran Tarnsliteration (mr)", "Quran Tarnsliteration (mr)", Language.English, Kind.Tarjuma, "Arial Font", 14, false, SearchCategory.English, AQMode.Research)]
        public string QuranTransletaration
        {
            get;
            set;
        }
        [AyatColumn("Tafseer Ibn Abbas (mr)", "Tafseer Ibn Abbas (mr)", Language.English, Kind.Tafseer, "Arial Font", 14, false, SearchCategory.English, AQMode.Research)]
        public string TafseerIbnAbbasEnglish
        {
            get;
            set;
        }
        [AyatColumn("Tafseer Jalalain (mr)", "Tafseer Jalalain (mr)", Language.English, Kind.Tafseer, "Arial Font", 14, false, SearchCategory.English, AQMode.Research)]
        public string TafseerJalalain
        {
            get;
            set;
        }
        [AyatColumn("Tafseer Marif Ul Quran (mr)", "Tafseer Marif Ul Quran (mr)", Language.English, Kind.Tafseer, "Arial Font", 14, false, SearchCategory.English, AQMode.Research)]
        public string TafseerMarifUlQuranEnglish
        {
            get;
            set;
        }
        [AyatColumn("Tafseer Tafheem (mr)", "Tafseer Tafheem (mr)", Language.English, Kind.Tafseer, "Arial Font", 14, false, SearchCategory.English, AQMode.Research)]
        public string TafseerTafheem
        {
            get;
            set;
        }
        [AyatColumn("Tarjuma Ahmad Raza Khan (mr)", "Tarjuma Ahmad Raza Khan (mr)", Language.English, Kind.Tarjuma, "Arial Font", 14, false, SearchCategory.English, AQMode.Research)]
        public string TarjumaAhmadRazaKhan
        {
            get;
            set;
        }
        [AyatColumn("Tarjuma Arberry (mr)", "Tarjuma Arberry  (mr)", Language.English, Kind.Tarjuma, "Arial Font", 14, false, SearchCategory.English, AQMode.Research)]
        public string TarjumaArberry
        {
            get;
            set;
        }
        [AyatColumn("Tarjuma Kanzul Iman (mr)", "Tarjuma Kanzul Iman (mr)", Language.English, Kind.Tarjuma, "Arial Font", 14, false, SearchCategory.English, AQMode.Research)]
        public string TarjumaKanzulImanEnglish
        {
            get;
            set;
        }
        [AyatColumn("Tarjuma Marif Ul Quran (mr)", "Tarjuma Marif Ul Quran (mr)", Language.English, Kind.Tarjuma, "Arial Font", 14, false, SearchCategory.English, AQMode.Research)]
        public string TarjumaMarifUlQuranEnglish
        {
            get;
            set;
        }
        [AyatColumn("Tarjuma Muhammad Ali (mr)", "Tarjuma Muhammad Ali (mr)", Language.English, Kind.Tarjuma, "Arial Font", 14, false, SearchCategory.English, AQMode.Research)]
        public string TarjumaAhmadAli
        {
            get;
            set;
        }
        [AyatColumn("Tarjuma Qaribullah & Darwish (mr)", "Tarjuma Qaribullah & Darwish  (mr)", Language.English, Kind.Tarjuma, "Arial Font", 14, false, SearchCategory.English, AQMode.Research)]
        public string TarjumaQribullahDarwish
        {
            get;
            set;
        }
        [AyatColumn("Tarjuma Sahih Intl (mr)", "Tarjuma Sahih Intl (mr)", Language.English, Kind.Tarjuma, "Arial Font", 14, false, SearchCategory.English, AQMode.Research)]
        public string TarjumaSahihInternationalEnglish
        {
            get;
            set;
        }
        [AyatColumn("Tarjuma Sarwar (mr)", "Tarjuma Sarwar (mr)", Language.English, Kind.Tarjuma, "Arial Font", 14, false, SearchCategory.English, AQMode.Research)]
        public string TarjumaSarwer
        {
            get;
            set;
        }
        [AyatColumn("Tarjuma Tafheem (mr)", "Tarjuma Tafheem (mr)", Language.English, Kind.Tarjuma, "Arial Font", 14, false, SearchCategory.English, AQMode.Research)]
        public string TarjumaTafheem
        {
            get;
            set;
        }
        [AyatColumn("Tarjuma Wahid Dudin (mr)", "Tarjuma Wahid Dudin (mr)", Language.English, Kind.Tarjuma, "Arial Font", 14, false, SearchCategory.English, AQMode.Research)]
        public string TarjumaWahiduddin
        {
            get;
            set;
        }
        [AyatColumn("Translation Daryabadi (mr)", "Translation Daryabadi (mr)", Language.English, Kind.Tarjuma, "Arial Font", 14, false, SearchCategory.English, AQMode.Research)]
        public string TarjumaDaryabadi
        {
            get;
            set;
        }
        [AyatColumn("Translation Hindi (mr)", "Translation Hindi (mr)", Language.Hindi, Kind.Tarjuma, "Kruti Dev 010", 14, false, SearchCategory.Tarajum, AQMode.Research)]
        public string TarjumaHindi
        {
            get;
            set;
        }
        [AyatColumn("Translation Irfan-ul-Quran (mr)", "Translation Irfan-ul-Quran (mr)", Language.English, Kind.Tarjuma, "Arial Font", 14, false, SearchCategory.English, AQMode.Research)]
        public string TarjumaIrfanulQuranEnglish
        {
            get;
            set;
        }
        [AyatColumn("Translation Muhsin & Hilali (mr)", "Translation Muhsin & Hilali  (mr)", Language.English, Kind.Tarjuma, "Arial Font", 14, false, SearchCategory.English, AQMode.Research)]
        public string TarjumaMuhsinAndHilali
        {
            get;
            set;
        }
        [AyatColumn("Translation Pikhtal (mr)", "Translation Pikhtal  (mr)", Language.English, Kind.Tarjuma, "Arial Font", 14, false, SearchCategory.English, AQMode.Research)]
        public string TarjumaPikhtal
        {
            get;
            set;
        }
        [AyatColumn("Translation Shakir (mr)", "Translation Shakir  (mr)", Language.English, Kind.Tarjuma, "Arial Font", 14, false, SearchCategory.English, AQMode.Research)]
        public string TarjumaShakir
        {
            get;
            set;
        }
        [AyatColumn("Translation Taqi Usmani (mr)", "Translation Taqi Usmani (mr)", Language.English, Kind.Tarjuma, "Arial Font", 14, false, SearchCategory.English, AQMode.Research)]
        public string TarjumaTaqiUsmani
        {
            get;
            set;
        }
        [AyatColumn("Translation Yousuf (mr)", "Translation Yousuf  (mr)", Language.English, Kind.Tarjuma, "Arial Font", 14, false, SearchCategory.English, AQMode.Research)]
        public string TarjumaYousuf
        {
            get;
            set;
        }
        internal static Dictionary<string, AyatColumnAttribute> ColumnsInfo
        {
            get
            {
                if (AyatRow.columnsInfo == null)
                {
                    PropertyInfo[] properties = typeof(AyatRow).GetProperties();
                    AyatRow.columnsInfo = new Dictionary<string, AyatColumnAttribute>(properties.Length);
                    PropertyInfo[] array = properties;
                    for (int i = 0; i < array.Length; i++)
                    {
                        PropertyInfo propertyInfo = array[i];
                        AyatColumnAttribute[] array2 = (AyatColumnAttribute[])propertyInfo.GetCustomAttributes(typeof(AyatColumnAttribute), false);
                        array2[0].Property = propertyInfo;
                        AyatRow.columnsInfo.Add(propertyInfo.Name, array2[0]);
                    }
                }
                return AyatRow.columnsInfo;
            }
        }
        internal static List<string> BasicVersionColumns
        {
            get
            {
                if (AyatRow.aqBasicVersionColumns == null)
                {
                    AyatRow.InitVersionInfo();
                }
                return AyatRow.aqBasicVersionColumns;
            }
        }
        internal static List<string> AdvanceVersionColumns
        {
            get
            {
                if (AyatRow.aqAdvanceVersionColumns == null)
                {
                    AyatRow.InitVersionInfo();
                }
                return AyatRow.aqAdvanceVersionColumns;
            }
        }
        internal static List<string> ResearchVersionColumns
        {
            get
            {
                if (AyatRow.aqResearchVersionColumns == null)
                {
                    AyatRow.InitVersionInfo();
                }
                return AyatRow.aqResearchVersionColumns;
            }
        }
        public override bool Equals(object obj)
        {
            AyatRow ayatRow = obj as AyatRow;
            return ayatRow != null && this.ID == ayatRow.ID;
        }
        private static void InitVersionInfo()
        {
            AyatRow.aqBasicVersionColumns = new List<string>(AyatRow.ColumnsInfo.Values.Count);
            AyatRow.aqAdvanceVersionColumns = new List<string>(AyatRow.ColumnsInfo.Values.Count);
            AyatRow.aqResearchVersionColumns = new List<string>(AyatRow.ColumnsInfo.Values.Count);
            foreach (AyatColumnAttribute current in AyatRow.ColumnsInfo.Values)
            {
                switch (current.Version)
                {
                    case AQMode.Basic:
                        AyatRow.aqBasicVersionColumns.Add(current.Property.Name);
                        break;
                    case AQMode.Advance:
                        AyatRow.aqAdvanceVersionColumns.Add(current.Property.Name);
                        break;
                    case AQMode.Research:
                        AyatRow.aqResearchVersionColumns.Add(current.Property.Name);
                        break;
                }
            }
        }
        public override int GetHashCode()
        {
            return this.ID;
        }
        public static bool operator ==(AyatRow o1, AyatRow o2)
        {
            return object.ReferenceEquals(o1, o2) || (o1 != null && o2 != null && o1.ID == o2.ID);
        }
        public static bool operator !=(AyatRow o1, AyatRow o2)
        {
            return !(o1 == o2);
        }
    }
}