Pic$(function () {
   if (screen.width > 1024) {
        // if screen size is 1025px wide or larger
        $('#emblem').show();
        $('#pricing').addClass('pots');
        $('.Topmenu').css("margin-right", "130 px");
       $('.EApic:hover').css("opacity", "1");
       $('.EAtext:hover').css("opacity", "0");
    }
            else {
        // if screen size width is less than 1024px
        $('#emblem').hide();
        $('#pricing').removeClass('pots');
        $('.Topmenu').css("margin-right", "10px");
       $('.EApic .EAtext').css("opacity", "0.8");
    }
});
    