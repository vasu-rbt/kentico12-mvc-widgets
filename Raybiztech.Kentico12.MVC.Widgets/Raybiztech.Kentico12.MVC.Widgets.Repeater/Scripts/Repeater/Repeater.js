$('.page-link').click(function () {
    var page = $(this).attr('data-page');
    var dataID = $(this).attr('data-dataID');
    var Url = $('.pagination_' + dataID).attr('data-request-Url');
    $.ajax({
        type: "GET",
        url: Url,
        data: { page: page, dataID: dataID },
        dataType: 'html',
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('.pagination_' + dataID).html("");
            $('.pagination_' + dataID).html(data);
        },
        error: function () {
            alert("An error has occured!!!");
        }
    });
});