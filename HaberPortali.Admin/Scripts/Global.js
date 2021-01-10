function KategoriEkle() {
    Kategori = new Object();
    Kategori.KategoriAdi = $("#kategoriAdi").val();
    Kategori.URL = $("#kategoriURL").val();
    Kategori.AktifMi = $("#kategoriAktif").is(":checked");
    //noktadan sornasının model ile aynı olmas gerekiyor
    //eşittirden sonrasıda view sayfasındakilerle aynı oolmalı
    Kategori.ParentID = $("#ParentID").val();
    //bootbox.alert("1", function () {

    //})

    $.ajax({
        url: "/Kategori/Ekle",
        data: Kategori,
        type: "POST",
        dataType:"json",
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message, function () {
                    location.reload();
                });
            }
            else {
                boot.alert(response.Message, function () {
                    //geri dondugunde birşey yapılması isteniyorsa buraya yazılır
                });
            }
        }
    })
}
/*
 Ders 6
 Merhaba arkadaşlar , bu dersimizde kategori ekleme , kategori listeleme ve kategori silme işlemlerini gerçekleştirdik. Projemize bootboxjs kütüphanesini dahil ettik ve ajaxpost ile kayıt işlemi yaptıktan sonra bilgilendirme için json ile dönüş yaptık.
 */

function KategoriDuzenle() {

    Kategori = new Object();
    Kategori.KategoriAdi = $("#kategoriAdi").val();
    Kategori.URL = $("#kategoriURL").val();
    Kategori.AktifMi = $("#kategoriAktif").is(":checked");
    Kategori.ParentID = $("#ParentID").val();
    Kategori.ID = $("#ID").val();
    //buradaki id kıssmı viewda hidden olarak alındı
    //onun alınınp alınmama kontrolu ise:
    //var gelenID=$("#ID").val(); aler(gelenID);
    $.ajax({
        url: "/Kategori/Duzenle",
        data: Kategori,
        type: "POST",
        dataType: "json",
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message, function () {
                    location.reload();
                });
            }
            else {
                boot.alert(response.Message, function () {
                    //geri dondugunde birşey yapılması isteniyorsa buraya yazılır
                });
            }
        }
    })
}

