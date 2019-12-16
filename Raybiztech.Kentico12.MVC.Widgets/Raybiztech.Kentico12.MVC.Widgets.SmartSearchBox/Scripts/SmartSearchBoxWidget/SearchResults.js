
function SearchResultsData(data) {
    var text = data.previousElementSibling.value;
    var resultUrl = data.attributes[4].value;
    var Page = data.attributes[5].value;
    var PageSize = data.attributes[6].value;
    var Index = data.attributes[7].value;;
    var Size = data.attributes[8].value;
    var Url = data.attributes[9].value;
    SearchResult(text, resultUrl, Page, PageSize, Index, Size, Url)
}

function SearchInputData(event, data) {
    if (event.keyCode == 13) {
        var text = data.value;
        var resultUrl = data.attributes[4].value;
        var Page = data.attributes[5].value;
        var PageSize = data.attributes[6].value;
        var Index = data.attributes[7].value;
        var Size = data.attributes[8].value;
        var Url = data.attributes[9].value;
        SearchResult(text, resultUrl, Page, PageSize, Index, Size, Url)
    }
}
function SearchResult(text, resultUrl, Page, PageSize, Index, Size, Url) {
    $.ajax({
        type: "GET",
        url: Url,
        data: { index: Index, groupsize: Size, pagesize: PageSize },
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data) {
                if (text != "" && resultUrl != "") {
                    window.location.href = "/" + resultUrl + "?searchtext=" + text + "&page=" + Page;
                }
            }
        }

    });
}
$('.page-link').click(function () {
    var searchtext = $('#SearchText').val();
    var pageno = $(this).attr('data-page');
    var href = new URL(window.location.href.toString());
    href.searchParams.set('page', pageno);
    href.searchParams.set('searchtext', searchtext);
    window.location.href = href;
});
