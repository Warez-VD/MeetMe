"use strict";

$(() => {
    if (window.location == window.parent.location) {
        $('#back-to-bootsnipp').removeClass('hide');
    }

    $('[data-toggle="tooltip"]').tooltip();

    $('[data-command="toggle-search"]').on('click', function (event) {
        event.preventDefault();
        $(this).toggleClass('hide-search');

        if ($(this).hasClass('hide-search')) {
            $('.c-search').closest('.row').slideUp(100);
        } else {
            $('.c-search').closest('.row').slideDown(100);
        }
    })

    $('#contact-list').searchable({
        searchField: '#contact-list-search',
        selector: 'li',
        childSelector: '.col-xs-12',
        show: function (elem) {
            elem.slideDown(100);
        },
        hide: function (elem) {
            elem.slideUp(100);
        }
    });

    $(".c-clickable").on("click", (ev) => {
        console.log($(ev.target).attr("data-id"));
    });
});