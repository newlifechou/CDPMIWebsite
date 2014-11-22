$(function () {
    //get the number of pictures
    var len = $("#slide>li").length;
    var index = 0;
    var adTimer;

    $("#slidenav li").mouseover(function () {
        index = $("#slidenav li").index(this);
        showImg(index);
    }).eq(0).mouseover();

    $("#mainslide").hover(function () {
        clearInterval(adTimer);
    }, function () {
        adTimer = setInterval(function () {
            showImg(index)
            index++;
            if (index == len) {
                index = 0;
            }
        }, 4000);

    }).trigger("mouseleave");

    //mouseover and change of the product background-color
    $(".pcategory").mouseover(function () {
        $(this).addClass("bgchange");
    }).mouseout(function () {
        $(this).removeClass("bgchange");
    });

});

function showImg(index) {
    var adHeight = $("#mainslide").height();
    $("#slide").stop(true, false).animate({ top: -adHeight * index }, 1000);
    $("#slidenav li").removeClass("selected").eq(index).addClass("selected");
}