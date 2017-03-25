"use strict";

function showHidePublications() {
    $("#show-publications-user").addClass("hidden");
    $("#hide-publications-user").removeClass("hidden");
}

function showPublications() {
    $("#show-publications-user").removeClass("hidden");
    $("#hide-publications-user").addClass("hidden");
}

$(() => {
    $(".show-comments").on("click", (ev) => {
        let target = $(ev.target);
        let publicationId = target.attr("data-info");
        $(`#comments-${publicationId}`).children().removeClass("hidden");
        $(`#show-${publicationId}`).addClass("hidden");
        $(`#hide-${publicationId}`).removeClass("hidden");
    });

    $(".hide-comments").on("click", (ev) => {
        let target = $(ev.target);
        let publicationId = target.attr("data-info");
        let comments = $(`#comments-${publicationId}`).children();
        for (var i = 0; i < comments.length; i += 1) {
            if (i > 1) {
                $(comments[i]).addClass("hidden");
            }
        }

        $(`#hide-${publicationId}`).addClass("hidden");
        $(`#show-${publicationId}`).removeClass("hidden");
    });
});
