function RegiterSuccess(data) {
    if (data.ErrorMessage != "") {
        var successUrl = $(this).find(".registration_success").attr('data-url');
        if (data.ErrorMessage == "Registered Successfully!") {
            $(".clearText").val("");
            window.location.href = successUrl;
        }
        else {
            $(this).find(".registration_success").text(data.ErrorMessage);
        }
    }
}
function RegisterFailure(data)
{
    if (data.ErrorMessage != "") {
        $(this).find(".registration_fail").text(data.ErrorMessage);
    }
}