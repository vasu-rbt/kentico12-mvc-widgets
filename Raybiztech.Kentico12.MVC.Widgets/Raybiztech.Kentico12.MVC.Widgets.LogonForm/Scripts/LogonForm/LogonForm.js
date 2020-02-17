function Success(data) {
    $("#Invalid").remove();
    if (data.success == true) {
        var redirectUrl = $(this).find(".logon-url").attr('data-Url');
        window.location.href = redirectUrl;
    }
    else {
        var failureText = $(this).find(".logon-fail").attr('data-Erromsg');
        $(this).find(".logon-fail").text(failureText);
    }
}
