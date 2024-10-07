$('#search-button').click(function () {
    var pabrik = $('#pabrik-input').val();
    var dtFr = $('#dateFr-input').val();
    var dtTo = $('#dateTo-input').val();
    $.ajax({
        url: "/ChangeControls/Search/",
        type: 'GET',
        data: {
            pabrik: pabrik,
            dateFrom: dtFr,
            dateTo: dtTo,
        },
        success: function (data) {
            $('#search-results').html(data);
        },
        error: function () {
            $('#search-results').html('<p>An error occurred while searching.</p>');
        }
    });
});

//$('#download-button').click(function () {
//    var pabrik = $('#pabrik-input').val();
//    var dtFr = $('#dateFr-input').val();
//    var dtTo = $('#dateTo-input').val();
//    var url = "/ChangeControls/DownloadPdf/" + '?pabrik=' + pabrik + '&dateFrom=' + dtFr + '&dateTo=' + dtTo;
//    window.location.href = url;
//});

//$('#download-button').click(function () {
//    var pabrik = $('#pabrik-input').val();
//    var dtFr = $('#dateFr-input').val();
//    var dtTo = $('#dateTo-input').val();
//    $.ajax({
//        url: "/ChangeControls/DownloadPdf/",
//        type: 'GET',
//        data: {
//            pabrik: pabrik,
//            dateFrom: dtFr,
//            dateTo: dtTo,
//        },
//        success: function (data) {
//            //$('#search-results').html(data);
//        },
//        error: function () {
//            //$('#search-results').html('<p>An error occurred while searching.</p>');
//        }
//    });
//});