function tb_quran_Search1() {
    var searching_word = document.getElementById("tb_quran_Search1").value;

    var xhr = new XMLHttpRequest();

    xhr.open("get", "ayah/SearchAyat/" + searching_word, true);
    xhr.setRequestHeader('Content-Type', 'application/json; charset=utf-8');

    xhr.onload = function () {
        if (xhr.response && xhr.responseText != null) {
            var quran_search_json = JSON.parse(xhr.response);
            var targetx = document.getElementById("quran_search_tree");
            var search_tree = new Array;
            search_tree[0] = "1|0|نتيجة|return false;";


            for (var i = 0; i < quran_search_json.length ; i++)
            {
                var surah = getpsr(quran_search_json[i]);

                var surahName = linq(psdata).first({ SurahNo: surah.SurahNo }, "==");   

                search_tree[i] = (i + 1) + "|" + 1 + "|" + surahName.Surah   + "|" + "GetAyah(" + quran_search_json[i] + ")";
            }

            createTree(search_tree, targetx, 1, 0);

            //var search = ['div', 'span'];

            //$.each(search, function (i) {
            //    var str = search[i];
            //    var orgText = $(str).text();

            //    orgText = orgText.replace(searching_word, function ($1) {
            //        return "<span style='background-color: red;'>" + $1 + "</span>"
            //    });

            //    $(str).html(orgText);
            //});
        }
    };

    xhr.send(null);

}
function load_quran_topics() {
    var targetx = document.getElementById("quran_topic_tree");

    if (targetx.innerHTML.length > 100)
        return false;

    var qt_data = window.localStorage.getItem('quran_topics');

    setTimeout(function () {

        if (qt_data != null && qt_data != '') {
            targetx.innerHTML = qt_data;
        }
        else {
            var xhr = new XMLHttpRequest();

            xhr.open("get", "Scripts/qtopics.js", true);
            xhr.setRequestHeader('Content-Type', 'application/json; charset=utf-8');

            xhr.onload = function () {
                if (xhr.response && xhr.responseText != null) {
                    var quran_topics_json = JSON.parse(xhr.response);
                    var topics_tree = new Array;

                    for (var i = 0; i < quran_topics_json.length ; i++) {

                        var ayah_arr = quran_topics_json[i].a.split(',');
                        var _str = "";

                        if (ayah_arr.length > 0 && ayah_arr[0] != "")
                            _str = "GetAyah(" + ayah_arr[0] + ")";
                        else
                            _str = "return false";

                        topics_tree[i] = (i + 1) + "|" + (i == 0 ? 0 : quran_topics_json[i].p) + "|" + quran_topics_json[i].t + "|" + _str;
                    }

                    createTree(topics_tree, targetx, 1, 7);
                    window.localStorage.setItem('quran_topics', targetx.innerHTML);
                }
            };

            xhr.send(null);
        }

    }, 50);

}
function GetAyah(ayahno) {
    var xhr = new XMLHttpRequest();

    xhr.open("get", "ayah/getayat/" + ayahno, true);
    xhr.setRequestHeader('Content-Type', 'application/json; charset=utf-8');

    xhr.onload = function () {
        if (xhr.response && xhr.responseText != null) {
            var json = JSON.parse(xhr.response);
            currentayah = parseInt(ayahno);
            setnavig(ayahno);

            $("#ddlayahs").val(json.AyatNo);

            $('#tbAyahNo').val(ayahno);
            $('#ayat-arabic').text(json.Ayat);
            $('#TarjumaMafhoomUlQuran-body').text(json.TarjumaMafhoomUlQuran);
            $('#TarjumaRohulQuran-body').text(json.TarjumaRohulQuran);
            $('#TarjumaMadni-body').text(json.TarjumaMadni);
            $('#TarjumaAnwarulbayan-body').text(json.TarjumaAnwarulbayan);
            $('#TarjumaAsanQuran-body').text(json.TarjumaAsanQuran);
            $('#TarjumaBayanUlQuranDrIsrar-body').text(json.TarjumaBayanUlQuranDrIsrar);
            $('#TarjumaBotvi-body').text(json.TarjumaBotvi);
            $('#TarjumaFawaidUlQuran-body').text(json.TarjumaFawaidUlQuran);
            $('#TarjumaFahmulQuran-body').text(json.TarjumaFahmulQuran);
            $('#TarjumaAlkitab-body').text(json.TarjumaAlkitab);
            $('#TarjumaTaiseerurRehman-body').text(json.TarjumaTaiseerurRehman);
            $('#TarjumaImdadulKaram-body').text(json.TarjumaImdadulKaram);
            $('#TarjumaZakhiratulJinan-body').text(json.TarjumaZakhiratulJinan);
            $('#TarjumaDawateQuran-body').text(json.TarjumaDawateQuran);
            $('#TarjumaTayseerulquran-body').text(json.TarjumaTayseerulquran);
            $('#TarjumaTibyanulQuran-body').text(json.TarjumaTibyanulQuran);
            $('#TarjumaMakkah-body').text(json.TarjumaMakkah);
            $('#TarjumaUrwatUlWasqa-body').text(json.TarjumaUrwatUlWasqa);
            $('#TarjumaIrfanulQuranUrdu-body').text(json.TarjumaIrfanulQuranUrdu);
            $('#TarjumaAhsanUlBayan-body').text(json.TarjumaAhsanUlBayan);
            $('#TarjumaNazarAhmad-body').text(json.TarjumaNazarAhmad);
            $('#TarjumaAsrarulTanzeel-body').text(json.TarjumaAsrarulTanzeel);
            $('#TarjumaMalimulIrfaan-body').text(json.TarjumaMalimulIrfaan);
            $('#TarjumaAsanTahreek-body').text(json.TarjumaAsanTahreek);
            $('#TarjumaWahiduddinKhan-body').text(json.TarjumaWahiduddinKhan);
            $('#TarjumaTadubbureQuran-body').text(json.TarjumaTadubbureQuran);
            $('#TarjumaBaseerateQuran-body').text(json.TarjumaBaseerateQuran);
            $('#TarjumaMajdi-body').text(json.TarjumaMajdi);
            $('#TarjumaJawahirulQuran-body').text(json.TarjumaJawahirulQuran);
            $('#TarjumaSirajUlBayan-body').text(json.TarjumaSirajUlBayan);
            $('#TarjumaMarifUlQuran-body').text(json.TarjumaMarifUlQuran);
            $('#TarjumaHaqqani-body').text(json.TarjumaHaqqani);
            $('#TarjumFizilalulQuran-body').text(json.TarjumFizilalulQuran);
            $('#TarjumaKashafuRehman-body').text(json.TarjumaKashafuRehman);
            $('#TarjumaAlHasnat-body').text(json.TarjumaAlHasnat);
            $('#TarjumaAhmadAliLahore-body').text(json.TarjumaAhmadAliLahore);
            $('#TarjumaAshrafi-body').text(json.TarjumaAshrafi);
            $('#TarjumaNoorulIrfan-body').text(json.TarjumaNoorulIrfan);
            $('#TarjumaMazharulQuran-body').text(json.TarjumaMazharulQuran);
            $('#TarjumaMudoodi-body').text(json.TarjumaMudoodi);
            $('#TarjumaKanzulIman-body').text(json.TarjumaKanzulIman);
            $('#TarjumaTasheelulQuran-body').text(json.TarjumaTasheelulQuran);
            $('#TarjumaUsmani-body').text(json.TarjumaUsmani);
            $('#TarjumaBayanUlQuran-body').text(json.TarjumaBayanUlQuran);
            $('#TarjumaTarjumanUlQuran-body').text(json.TarjumaTarjumanUlQuran);
            $('#TarjumaHallelQuran-body').text(json.TarjumaHallelQuran);
            $('#TarjumaZiaulQuran-body').text(json.TarjumaZiaulQuran);
            $('#TarjumaMozihulQuran-body').text(json.TarjumaMozihulQuran);
            $('#TarjumaAshrafulHawashi-body').text(json.TarjumaAshrafulHawashi);
            $('#TarjumaShahAbdulQadir-body').text(json.TarjumaShahAbdulQadir);
            $('#TarjumaDureeMansoor-body').text(json.TarjumaDureeMansoor);
            $('#TarjumaFatehMuhammad-body').text(json.TarjumaFatehMuhammad);

            ///////////////////////

            $('#TarjumaLafziNazarAhmad-body').text(json.TarjumaLafziNazarAhmad);
            $('#TarjumaLafziFahmulQuran-body').text(json.TarjumaLafziFahmulQuran);

            $('#TarjumaLafziDrFarhatHashmi-body').text(json.TarjumaLafziDrFarhatHashmi);
            $('#Anwarulbayan-body').text(json.Anwarulbayan);
            $('#MutalaQuran-body').text(json.MutalaQuran);
            $('#ColorTarjuma-body').html(json.ColorTarjuma);
            $('#ColorTarjuma2-body').html(json.ColorTarjuma);

            $('#Keywords-body').html(json.Keywords);
            $('#Keywords2-body').html(json.Keywords);

            $('#ColorAyat-body').html(json.ColorAyat);
            $('#ColorAyat2-body').html(json.ColorAyat);

            $('#ShaneNazool-body').text(json.ShaneNazool);
            $('#ShaneNazool2-body').text(json.ShaneNazool);
            $('#AsbabeNazool-body').text(json.AsbabeNazool);
            $('#AsbabeNazool2-body').text(json.AsbabeNazool);

            $('#TafseerMarifulFurqan-body').text(json.TafseerMarifulFurqan);
            $('#TarjumaRohulQuran-body').text(json.TarjumaRohulQuran);
            $('#TafseerRohulQuran-body').text(json.TafseerRohulQuran);
            $('#TarjumaMadni-body').text(json.TarjumaMadni);
            $('#TafseerMadni-body').text(json.TafseerMadni);
            $('#TafseerMadniKabeer-body').text(json.TafseerMadniKabeer);
            $('#TarjumaMafhoomUlQuran-body').text(json.TarjumaMafhoomUlQuran);
            $('#TafseerMafhoomUlQuran-body').text(json.TafseerMafhoomUlQuran);
            $('#KhulasaMazameenQuran-body').text(json.KhulasaMazameenQuran);
            $('#TarjumaBotvi-body').text(json.TarjumaBotvi);
            $('#TafseerUlQuranKarim-body').text(json.TafseerUlQuranKarim);
            $('#TafseerDawatulQuran-body').text(json.TafseerDawatulQuran);
            $('#TarjumaAnwarulbayan-body').text(json.TarjumaAnwarulbayan);
            $('#TafseerAnwarUlBayan-body').text(json.TafseerAnwarUlBayan);
            $('#TarjumaAsanQuran-body').text(json.TarjumaAsanQuran);
            $('#TafseerAsanQuran-body').text(json.TafseerAsanQuran);
            $('#TarjumaBayanUlQuranDrIsrar-body').text(json.TarjumaBayanUlQuranDrIsrar);
            $('#TafseerBayanUlQuranDrIsrar-body').text(json.TafseerBayanUlQuranDrIsrar);
            $('#TarjumaAlkitab-body').text(json.TarjumaAlkitab);
            $('#TafseerAlkitab-body').text(json.TafseerAlkitab);
            $('#TarjumaFawaidUlQuran-body').text(json.TarjumaFawaidUlQuran);
            $('#TafseerFawaidUlQuran-body').text(json.TafseerFawaidUlQuran);
            $('#TarjumaFahmulQuran-body').text(json.TarjumaFahmulQuran);
            $('#TafseerFahmulQuran-body').text(json.TafseerFahmulQuran);
            $('#MukhtasarTafseerAteeq-body').text(json.MukhtasarTafseerAteeq);
            $('#TarjumaTaiseerurRehman-body').text(json.TarjumaTaiseerurRehman);
            $('#TafseerTaiseerurRehman-body').text(json.TafseerTaiseerurRehman);
            $('#TarjumaImdadulKaram-body').text(json.TarjumaImdadulKaram);
            $('#TafseerImdadulKaram-body').text(json.TafseerImdadulKaram);

            $('#TarjumaZakhiratulJinan-body').text(json.TarjumaZakhiratulJinan);
            $('#TafseerZakhiratulJinan-body').text(json.TafseerZakhiratulJinan);
            $('#TarjumaTayseerulquran-body').text(json.TarjumaTayseerulquran);
            $('#TafseerTayseerulquran-body').text(json.TafseerTayseerulquran);
            $('#TarjumaDawateQuran-body').text(json.TarjumaDawateQuran);
            $('#TafseerDawateQuran-body').text(json.TafseerDawateQuran);
            $('#TarjumaTibyanulQuran-body').text(json.TarjumaTibyanulQuran);
            $('#TafseerTibyanulQuran-body').text(json.TafseerTibyanulQuran);
            $('#TarjumaUrwatUlWasqa-body').text(json.TarjumaUrwatUlWasqa);
            $('#TafseerUrwatUlWasqa-body').text(json.TafseerUrwatUlWasqa);
            $('#TarjumaBayanUlQuran-body').text(json.TarjumaBayanUlQuran);
            $('#TarjumaMakkah-body').text(json.TarjumaMakkah);
            $('#TafseerMakkah-body').text(json.TafseerMakkah);
            $('#TafseerAlManar-body').text(json.TafseerAlManar);
            $('#TafseerAnwarUlQuran-body').text(json.TafseerAnwarUlQuran);
            $('#TarjumaAlBayan_Ghamdi-body').text(json.TarjumaAlBayan_Ghamdi);
            $('#TafseerAlBayan_Ghamdi-body').text(json.TafseerAlBayan_Ghamdi);
            $('#TarjumaAlManar-body').text(json.TarjumaAlManar);
            $('#TarjumaAhsanUlBayan-body').text(json.TarjumaAhsanUlBayan);
            $('#TafseerAhsanUlBayan-body').text(json.TafseerAhsanUlBayan);
            $('#TarjumaAsrarulTanzeel-body').text(json.TarjumaAsrarulTanzeel);
            $('#TafseerAsrarulTanzeel-body').text(json.TafseerAsrarulTanzeel);
            $('#TafseerNikatulQuran-body').text(json.TafseerNikatulQuran);



            $('#TarjumaMalimulIrfaan-body').text(json.TarjumaMalimulIrfaan);
            $('#TafseerMalimulIrfaan-body').text(json.TafseerMalimulIrfaan);
            $('#TarjumaWahiduddinKhan-body').text(json.TarjumaWahiduddinKhan);
            $('#TafseerTazkirulQuran-body').text(json.TafseerTazkirulQuran);
            $('#TarjumaTadubbureQuran-body').text(json.TarjumaTadubbureQuran);
            $('#TafseerTadubbureQuran-body').text(json.TafseerTadubbureQuran);
            $('#TarjumaBaseerateQuran-body').text(json.TarjumaBaseerateQuran);
            $('#TafseerBaseerateQuran-body').text(json.TafseerBaseerateQuran);
            $('#TarjumaMajdi-body').text(json.TarjumaMajdi);
            $('#TafseerMajdi-body').text(json.TafseerMajdi);
            $('#TarjumaJawahirulQuran-body').text(json.TarjumaJawahirulQuran);
            $('#TafseerJawahirulQuran-body').text(json.TafseerJawahirulQuran);

            $('#TarjumaSirajUlBayan-body').text(json.TarjumaSirajUlBayan);
            $('#TafseerSirajUlBayan-body').text(json.TafseerSirajUlBayan);
            $('#TarjumaAhmadAliLahore-body').text(json.TarjumaAhmadAliLahore);
            $('#TafseerMehmood-body').text(json.TafseerMehmood);
            $('#TafseerMarifUlQuran-body').text(json.TafseerMarifUlQuran);
            $('#TarjumaHaqqani-body').text(json.TarjumaHaqqani);
            $('#TafseerHaqqani-body').text(json.TafseerHaqqani);
            $('#TafseerFuyoozUlQuran-body').text(json.TafseerFuyoozUlQuran);
            $('#TafseerFizilalulQuran-body').text(json.TafseerFizilalulQuran);
            $('#TarjumaShahAbdulQadir-body').text(json.TarjumaShahAbdulQadir);
            $('#TafseerMarifUlQuran_Idrees-body').text(json.TafseerMarifUlQuran_Idrees);



            $('#TarjumaKashafuRehman-body').text(json.TarjumaKashafuRehman);
            $('#TafseerKashafuRehman-body').text(json.TafseerKashafuRehman);
            $('#TarjumaAlHasnat-body').text(json.TarjumaAlHasnat);
            $('#TafseerAlHasnat-body').text(json.TafseerAlHasnat);
            $('#TarjumaAshrafi-body').text(json.TarjumaAshrafi);
            $('#TafseerAshrafi-body').text(json.TafseerAshrafi);
            $('#TarjumaNoorulIrfan-body').text(json.TarjumaNoorulIrfan);
            $('#TafseerNoorulIrfan-body').text(json.TafseerNoorulIrfan);
            $('#TarjumaMazharulQuran-body').text(json.TarjumaMazharulQuran);
            $('#TafseerMazharulQuran-body').text(json.TafseerMazharulQuran);
            $('#TarjumaMudoodi-body').text(json.TarjumaMudoodi);
            $('#TafseerMudoodi-body').text(json.TafseerMudoodi);
            $('#TafseerAlSaadi-body').text(json.TafseerAlSaadi);
            $('#TarjumaKanzulIman-body').text(json.TarjumaKanzulIman);
            $('#TafseerKhazainUlIrfan-body').text(json.TafseerKhazainUlIrfan);
            $('#TarjumaTasheelulQuran-body').text(json.TarjumaTasheelulQuran);
            $('#TafseerTasheelulQuran-body').text(json.TafseerTasheelulQuran);
            $('#TarjumaUsmani-body').text(json.TarjumaUsmani);
            $('#TafseerUsmani-body').text(json.TafseerUsmani);
            $('#TarjumaBayanUlQuran-body').text(json.TarjumaBayanUlQuran);
            $('#TafseerBayanUlQuran-body').text(json.TafseerBayanUlQuran);
            $('#TarjumaTarjumanUlQuran-body').text(json.TarjumaTarjumanUlQuran);
            $('#TafseerTarjumanUlQuran-body').text(json.TafseerTarjumanUlQuran);
            $('#TafseerAhsanUlTafaseer-body').text(json.TafseerAhsanUlTafaseer);
            $('#TafseerSanai-body').text(json.TafseerSanai);
            $('#TarjumaMozihulQuran-body').text(json.TarjumaMozihulQuran);
            $('#TafseerMozihulQuran-body').text(json.TafseerMozihulQuran);
            $('#TafseerMazhari-body').text(json.TafseerMazhari);
            $('#TafseerAshrafulHawashi-body').text(json.TafseerAshrafulHawashi);
            $('#TafseeratAhmadia-body').text(json.TafseeratAhmadia);
            $('#TarjumaDureeMansoor-body').text(json.TarjumaDureeMansoor);
            $('#TafseerDureeMansoor-body').text(json.TafseerDureeMansoor);
            $('#TafseerIbnAbbas-body').text(json.TafseerIbnAbbas);
            $('#TarjumaFatehMuhammad-body').text(json.TarjumaFatehMuhammad);
            $('#TafseerIbnKaseer-body').text(json.TafseerIbnKaseer);
            $('#TarjumaAnwarulbayan-body').text(json.TarjumaAnwarulbayan);
            $('#TafseerMadarikalTanzeel-body').text(json.TafseerMadarikalTanzeel);
            $('#TafseerQurtabi-body').text(json.TafseerQurtabi);
            $('#TafseerBaghvi-body').text(json.TafseerBaghvi);
            $('#TafseerMufradatulQuran-body').text(json.TafseerMufradatulQuran);
            $('#TafseerAhkamulQuran-body').text(json.TafseerAhkamulQuran);
            $('#TafseerIbneMasood-body').text(json.TafseerIbneMasood);

            $('#TafseerAlkousar_AT-body').text(json.TafseerAlkousar_AT);
            $('#TafseerBalaghulQuran_AT-body').text(json.TafseerBalaghulQuran_AT);
            $('#TafseerTafseerUlQuran_AT-body').text(json.TafseerTafseerUlQuran_AT);
            $('#TafseerRahnuma_AT-body').text(json.TafseerRahnuma_AT);
            $('#TafseerShawahidelQurani_AT-body').text(json.TafseerShawahidelQurani_AT);
            $('#TafseerUmdatulBayan_AT-body').text(json.TafseerUmdatulBayan_AT);
            $('#TafseerFurat_AT-body').text(json.TafseerFurat_AT);
            $('#TafseerFaslulkhitab_AT-body').text(json.TafseerFaslulkhitab_AT);
            $('#TafseerFaizanulRehman_AT-body').text(json.TafseerFaizanulRehman_AT);
            $('#TafseerNamoona_AT-body').text(json.TafseerNamoona_AT);
            //$('#-body').text(json.);
        }
    };

    xhr.send(null);
}

function getpsr(an) {
    var obj = null;
    for (var i = 0; i < psr.length; i++) {
        var item = psr[i];

        if (an >= item.mn && an <= item.mx) {
            obj = item;
            break;
        }
    }
    return obj;
}

function getrukus(sn) {
    var rno = 0;

    for (var i = 0; i < psr.length; i++) {
        var item = psr[i];

        if (item.SurahNo == sn) {
            if (item.mn == item.mx)
                continue;
            rno = rno + 1;
        }
        else if (rno > 0) {
            break;
        }
    }
    return rno;
}

function linq(arr) {

    linq.distinct = function (exp) {
        var tarr = [];
        var pred = "==";
        for (var i = 0; i < arr.length; i++) {
            // if (eval(eval("arr[i]." + Object.keys(exp)[0]) + pred + exp[Object.keys(exp)])) {
            var ov = eval("arr[i]." + exp);
            var o = JSON.parse("{\"" + exp + "\":\"" + ov + "\"}");
            if (!linq(tarr).contains(o))
                tarr.push(arr[i]);
        }
    }

    linq.contains = function (exp) {
        return linq(arr).first(exp, '==') == null ? false : true;
    };

    linq.skip = function (n) {
        var tarr = [];
        for (var i = 0; i < arr.length; i++) {
            if (i >= n) {
                tarr.push(arr[i]);
            }
        }
        return linq(tarr);
    };
    linq.take = function (n) {
        var tarr = [];
        for (var i = 0; i < arr.length && i < n; i++) {

            tarr.push(arr[i]);

        }
        return linq(tarr);
    }

    ///uc
    linq.orderby = function (exp) {
        for (var i = 0; i < arr.length; i++) {

            var si = arr[i];

            for (var j = 1; j < arr.length; j++) {

            }
        }
    };
    linq.where = function (exp, pred, async) {

        if (!pred || pred == '')
            pred = "==";

        var tarr = [];

        for (var i = 0; i < arr.length; i++) {

            if (eval(eval("arr[i]." + Object.keys(exp)[0]) + pred + exp[Object.keys(exp)])) {
                tarr.push(arr[i]);
            }
        }

        return linq(tarr);
    };

    linq.tolist = function () {
        return arr;
    };

    linq.first = function (exp, pred) {

        if (!exp) {
            if (arr.length > 0)
                return arr[0];
        }
        if (!pred || pred == '')
            pred = "==";

        for (var i = 0; i < arr.length; i++) {

            if (eval(eval("arr[i]." + Object.keys(exp)[0]) + pred + exp[Object.keys(exp)])) {
                return arr[i];
            }
        }
    };

    //linq.first = function () {
    //    if (arr.length > 0)
    //        return arr[0];
    //};

    linq.last = function (exp, pred) {
        for (var i = arr.length - 1; i >= 0; i--) {

            if (eval(eval("arr[i]." + Object.keys(exp)[0]) + pred + exp[Object.keys(exp)])) {
                return arr[i];
            }
        }
    };

    linq.last = function () {
        if (arr.length > 0)
            return arr[arr.length - 1];
    };

    linq.length = arr.length;

    return linq;
}

function gettotalayahs(sn) {
    var ano = 0;

    var temp_surah = linq(psr).where({ SurahNo: sn }, "==");

    var a = temp_surah.last().mx;
    var b = temp_surah.first().mn;
    ano = a - b;

    return ano;
}

function setnavig(an) {
    var obj = getpsr(an);
    document.getElementById("ddlSurah").value = obj.SurahNo;
    document.getElementById("ddlParah").value = obj.ParahNo;

    document.getElementById("nav_parah").innerText = obj.ParahNo;
    document.getElementById("nav_surah").innerText = obj.SurahNo;

    var totalrukus = getrukus(obj.SurahNo);

    var ddlrukh = document.getElementById("ddlRuku");

    document.getElementById("nav_ruk").innerText = totalrukus;

    ddlrukh.innerHTML = "";
    for (var i = 1; i <= totalrukus; i++) {

        var el = document.createElement("option");
        el.value = i;
        el.textContent = i;

        ddlrukh.appendChild(el);
    }

    ddlrukh.value = obj.RukhSurahNo;

    var totalayahs = gettotalayahs(obj.SurahNo);
    document.getElementById("nav_ayats").innerText = totalayahs;

    var ddlayahs = document.getElementById("ddlayahs");

    ddlayahs.innerHTML = "";
    for (var i = 1; i <= totalayahs; i++) {

        var el = document.createElement("option");
        el.value = i;
        el.textContent = i;

        ddlayahs.appendChild(el);
    }
}

var currentayah = 0;
$(document).ready(function () {

    setTimeout(function () {
        GetAyah(1);
    },10);
   
    setTimeout(function () {
        CreateQTree();
    }, 10);

   // CreateQTree();

    setTimeout(function () {
        Init_SideBar();
    }, 10);
   // Init_SideBar();

    //incomplete work in function...
    setTimeout(function () {
        ddl_Parah();
    }, 10);
    // ddl_Parah();

    //incomplete work in function...
    setTimeout(function () {
        ddl_Surah();
    }, 10);

   // ddl_Surah();
});

function ddl_Surah() {
    var surahs = [];

    for (var i = 1; i <= 114; i++) {
        var surah = linq(psdata).first({ SurahNo: i }, "==");
        surahs.push({ Surah: surah.Surah, SurahNo: surah.SurahNo });
    }

    var ddlSurah = document.getElementById("ddlSurah");

    ddlSurah.innerHTML = "";
    for (var i = 0; i < surahs.length; i++) {

        var el = document.createElement("option");
        el.value = surahs[i].SurahNo;
        el.textContent = surahs[i].Surah;

        ddlSurah.appendChild(el);
    }


}

function ddl_Parah() {
    var parahs = [];

    for (var i = 1; i <= 30; i++) {
        var parah = linq(psdata).first({ ParahNo: i }, "==");
        parahs.push({ Parah: parah.Parah, ParahNo: parah.ParahNo });
    }

    //for (var j = 0; j < psdata.length; j++) {
    //    if (parahs.length == 0) {
    //        parahs.push({ Parah: psdata[j].Parah, ParahNo: psdata[j].ParahNo });
    //        continue;
    //    }

    //    for (var i = 0; i < parahs.length; i++) {

    //        if (parahs[i].Parah == psdata[j].Parah) {
    //            break;
    //        }
    //        else {
    //            parahs.push({ Parah: psdata[j].Parah, ParahNo: psdata[j].ParahNo });
    //            break;
    //        }
    //    }
    //}

    var ddlParah = document.getElementById("ddlParah");  

    ddlParah.innerHTML = "";
    for (var i = 0; i < parahs.length; i++) {

        var el = document.createElement("option");
        el.value = parahs[i].ParahNo;
        el.textContent = parahs[i].Parah;

        ddlParah.appendChild(el);
    }


}

function Init_SideBar() {
    var sides = ["left"];
    //$("h1 span.version").text($.fn.sidebar.version);

    // Initialize sidebars
    for (var i = 0; i < sides.length; ++i) {
        var cSide = sides[i];
        $(".sidebar." + cSide).sidebar({ side: cSide });
    }
}

function CreateQTree() {
    var targetx = document.getElementById("tree");

    var Tree = [];

    Tree[0] = "1|0|القرآن المجيد|getsurah(1)\";\n";
    var nodeno = 2;
    var x = 1;
    for (var i = 1; i <= 30; i++) {
        var parah = linq(psdata).first({ ParahNo: i });
        var parahnodeno = nodeno;

        Tree[x] = nodeno + "|" + 1 + "|" + parah.Parah + "|gotoayat(" + parah.parah_ayatid + ")";

        var surahs = linq(psdata).where({ ParahNo: i }).tolist();

        for (var j = 0; j < surahs.length; j++) {
            nodeno++;
            x++;

            var item = surahs[j];

            Tree[x] = nodeno + "|" + parahnodeno + "|" + item.Surah + "|gotoayat(" + item.surah_ayatid + ")";
        }
        nodeno++;
        x++;
    }

    createTree(Tree, targetx, 1, 7);
}

function ShowSearchBar(obj) {
    var $this = $(obj);
    var action = $this.attr("data-action");
    var side = $this.attr("data-side");
    $(".sidebar." + side).trigger("sidebar:toggle");
    return false;
}

$(function () {
    $("#slider").slider({
        change: function (event, ui) {
            //console.log(ui.value);
        },
        min: 10,
        max: 100,
        value: 55
    });
});

function tbAyahNo_keyup(evt, obj) {
    if (evt.keyCode == 13) {
        GetAyah(obj);
    }
}

function opentab(evt, tabid, tabclassname, tablinks) {
    var i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName(tabclassname);
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    $("." + tablinks).removeClass("active");
    document.getElementById(tabid).style.display = "block";
    $(tablinks).addClass("active");
}