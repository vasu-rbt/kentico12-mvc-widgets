$(document).ready(function () {
    $(".CommentsId").html($(".btnText").val());
});
$(".page-url").val(window.location.pathname);
function CommentOnSuccess() {
    $('.validation-text').text("");
    var checklogin = $(".cls-Test").attr('data-aunthenticationCheck');
    if (checklogin == "true") {
        $(this).find('.validation-text').css("color", "green");
        $(this).find('.validation-text').text("Successfully Submitted");
    } else {
        $(this).find('.validation-text').css("color", "red");
        $(this).find('.validation-text').text("Please Sign in/Register");
    }
    $(".txt-comment").val("");
}
function CommentOnFailure() {
    $('.validation-text').text("");
    $(this).find('.validation-text').css("color", "red");
    var checklogin = $(".cls-Test").attr('data-aunthenticationCheck');
    if (!checklogin == true) {

        $(this).find('.validation-text').text("Please Sign in/Register");
    }   
}
$('.CommentsId').click(function () {
    if ($(".txt-comment").val() == "") {
        $('.validation-text').text("");
    }
});