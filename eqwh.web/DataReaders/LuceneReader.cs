using eqwh.web.Factory;
using eqwh.web.Models;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace eqwh.web.DataReaders
{
    public class LuceneReader : IDataReader
    {
        public AyatRow GetAyat(int ayahno)
        {
            AyatRow r = new AyatRow();
            var fields = LuceneDB.Get.FieldInfo;

            foreach (var item in fields)
            {
                var s = LuceneDB.Get.GetContent(ayahno, item.Key);
                r.GetType().GetProperty(item.Key).SetValue(r, Convert.ChangeType(s,
                    r.GetType().GetProperty(item.Key).PropertyType));
            }

            return r;
        }
        public int[] SearchAyat(string word)
        {
             var fields = LuceneDB.Get.FieldInfo.Keys.ToArray();
            
            var field_arr = "";

            for (int i = 0; i < fields.Length; i++)
			{
                if(i < fields.Length)
			  field_arr += fields[i] + ",";
                else
                    field_arr += fields[i] ;

			}
            return LuceneDB.Get.Search(word,)
        }
        //public static void SetValueFromString(this object target, string propertyName, string propertyValue)
        //{
        //    PropertyInfo oProp = target.GetType().GetProperty(propertyName);
        //    Type tProp = oProp.PropertyType;

        //    //Nullable properties have to be treated differently, since we 
        //    //  use their underlying property to set the value in the object
        //    if (tProp.IsGenericType
        //        && tProp.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
        //    {
        //        //if it's null, just set the value from the reserved word null, and return
        //        if (propertyValue == null)
        //        {
        //            oProp.SetValue(target, null, null);
        //            return;
        //        }

        //        //Get the underlying type property instead of the nullable generic
        //        tProp = new NullableConverter(oProp.PropertyType).UnderlyingType;
        //    }

        //    //use the converter to get the correct value
        //    oProp.SetValue(target, Convert.ChangeType(propertyValue, tProp), null);
        //}

        public string GetAyat(int ayahno, string colname)
        {
            return LuceneDB.Get.GetContent(ayahno, colname);
        }
    }
}