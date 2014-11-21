$(function () {
    $("ul#slide li p").mouseover(function () {
        $(this).addClass("mo");
    }).mouseout(function () {
        $(this).removeClass("mo")
    });
});