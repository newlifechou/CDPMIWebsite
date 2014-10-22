$(function () {
    var index = 0;
    $(".num li").mouseover(function () {
        index = $(".num li").index(this);
        showImg(index);
    }).eq(0).mouseover();

    function showImg(index) {
        var adHeight = $("#ad").height();
        $(".slider").stop(true, false).animate({ top: -adHeight * index }, 1000
            );
        $(".num li").removeClass("selected")
            .eq(index).addClass("selected");
    }
});