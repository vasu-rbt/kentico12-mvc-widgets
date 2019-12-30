$(document).ready(function () {
    //automatic height
    $(window).on('load resize', function () {
        if ($(window).width() > 991) {
            var highestBox = 0;
            $('.category-widget .content-section').each(function () {
                if ($(this).height() > highestBox) {
                    highestBox = $(this).height();
                } else {
                    highestBox = highestBox;
                }
            });
            $('.category-widget .content-section').height(highestBox);
        }
    });
});