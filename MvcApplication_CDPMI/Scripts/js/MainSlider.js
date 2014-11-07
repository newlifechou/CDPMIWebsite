$(function () {
    var index = 0;
    //设置自动切换动画效果
    var adTimer;
    var len = $(".num>li").length;

    $(".num li").mouseover(function () {
        index = $(".num li").index(this);
        showImg(index);
    }).eq(0).mouseover();

    //滑入停止动画，滑出开始动画
    $("#ad").hover(function () {
        clearInterval(adTimer);
    }, function () {
        adTimer = setInterval(function () {
            showImg(index);
            index++;
            if (index == len) {
                index = 0;
            }
        }, 3000);
    }).trigger("mouseleave");

    function showImg(index) {
        var adHeight = $("#ad").height();
        $(".slider").stop(true, false).animate({ top: -adHeight * index }, 1000
            );
        $(".num li").removeClass("selected")
            .eq(index).addClass("selected");
    }


});