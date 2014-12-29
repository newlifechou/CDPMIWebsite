$(function () {
    $("#categorylist ul li").mouseover(function () {
        $(this).addClass("plistitem");
    }).mouseout(function () {
        $(this).removeClass("plistitem");
    });
});