$(document).ready(function () {
    $('.slider').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        dots: !0,
        infinite: !0,
        autoplay: true,
        nextArrow: '<button class="slick-next slick-arrow"></button>',
        prevArrow: '<button class="slick-prev slick-arrow"></button>'
    });
    var showChar = 130;
    var moretext = "...";
    var lesstext = "...";
    $('.more').each(function () {
        var content = $(this).html();
        if (content.length > showChar) {
            var show_content = content.substr(0, showChar);
            var hide_content = content.substr(showChar, content.length - showChar);
            var html = show_content + '<span class="moreelipses">' +
                '</span><span class="remaining-content"><span>' + hide_content +
                '</span>&nbsp;&nbsp;<a href="" class="morelink">' + moretext +
                '</a></span>';
            $(this).html(html);
        }
    });
    $(".morelink").click(function () {
        if ($(this).hasClass("less")) {
            $(this).removeClass("less");
            $(this).html(moretext);
        } else {
            $(this).addClass("less");
            $(this).html(lesstext);
        }
        $(this).parent().prev().toggle();
        $(this).prev().toggle();
        return false;
    });
    $('.slick-arrow').on('click', function () {
        $('#myVideo')[0].contentWindow.postMessage('{"event":"command","func":"' + 'pauseVideo' + '","args":""}', '*');
    });
});