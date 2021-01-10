function KategoriSil() {
    var gelenID = $("#kategoriDelete").attr("data-id");
    $.ajax({
        url: "/Kategori/Sil/" + gelenID,
        type: "POST",
        dataType: "json",
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message, function () {
                    location.reload();
                });
            }
            else {
                bootbox.alert(response.Message, function () {
                    //geri dondugunde bir sye yaptırabilriz
                });
            }
        }
    })
}

//Kategori Sil
//$(document).on("click", "#kategoriDelete", function () {
//    var gelenID = $(this).attr("data-id");
//    var silTR = $(this).closest("tr");//tablodaki tr silmek icin
//    $.ajax({
//        url: "/Kategori/Sil/" + gelenID,
//        type: "POST",
//        dataType: "json",
//        success: function (response) {
//            if (response.Success) {
//                $.notify(response.Message, "success");
//                silTR.fadeOut(300, function () {
//                    silTR.remove();
//                })
//            }
//            else {
//                $.notify(response.Message, "error");
//            }
//        }
//    })
//})




