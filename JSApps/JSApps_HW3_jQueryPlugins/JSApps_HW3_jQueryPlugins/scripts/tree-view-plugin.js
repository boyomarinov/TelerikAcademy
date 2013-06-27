(function ($) {
    'use strict';

    $.fn.treeView = function (options) {
        var speed = options.speed || 'fast';

        $(this).on('click', 'li', function (ev) {
            var degree = 0;
            var subList = $(ev.target).find('>ul');
            var arrow = $(ev.target).find('>img');
            if (subList.length != 0) {
                if (subList.css('display') == 'none') {
                    degree = 90;
                } else {
                    degree = 0;
                }
            }

            ev.stopPropagation();
            rotate(degree);
            subList.toggle(speed);
            
            function rotate(deg) {
                arrow.css({
                    '-webkit-transform': 'rotate(' + deg + 'deg)',
                    '-moz-transform': 'rotate(' + deg + 'deg)',
                    '-ms-transform': 'rotate(' + deg + 'deg)',
                    '-o-transform': 'rotate(' + deg + 'deg)',
                    'transform': 'rotate(' + deg + 'deg)',
                    'zoom': 1
                }, 1000);
            }
        });

        return this;
    };
}(jQuery))