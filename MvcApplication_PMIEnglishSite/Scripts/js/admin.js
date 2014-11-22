$(function () {
    $(".tblist tr:not(':first')").mouseover(function () {
        $(this).addClass("mo");
    }).mouseout(function () {
        $(this).removeClass("mo");
    });

    $("div.changewhere").mouseover(function () {
        $(this).addClass("changewheremo");
    }).mouseout(function () {
        $(this).removeClass("changewheremo");
    });
});