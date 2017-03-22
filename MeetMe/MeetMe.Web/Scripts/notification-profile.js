"use strict";

$(() => {
    $.connection.hub.start();

    var notification = $.connection.notification;

    $(".btn-comment").on("click", (ev) => {
        let commentBtn = $(ev.target);
        let publicationAuthorId = commentBtn.attr("data-author");
        let currentUserId = commentBtn.attr("data-userid");
        notification.server.addCommentNotification(publicationAuthorId, currentUserId);
    });

    $(".like-publication").on("click", (ev) => {
        let target = $(ev.target);
        let elementId = target.children().first().attr("id");
        let id = target.attr("data-id");
        let userId = target.attr("data-userid");
        let publicationAuthorId = target.attr("publication-author");
        notification.server.addLikeNotification(id, userId, publicationAuthorId, elementId);
    });

    $(".dislike-publication").on("click", (ev) => {
        let target = $(ev.target);
        let elementId = target.children().first().attr("id");
        let id = target.attr("data-id");
        notification.server.addDislikeNotification(id, elementId);
    });

    notification.client.likePublication = likePublication;
    notification.client.dislikePublication = dislikePublication;
    notification.client.addNotification = addNotification;
});

function likePublication(id) {
    let element = $(`#${id}`);
    let currentCount = +element.html();
    let newCount = currentCount + 1;
    element.html(newCount);
}

function dislikePublication(id) {
    let element = $(`#${id}`);
    let currentCount = +element.html();
    let newCount = currentCount + 1;
    element.html(newCount);
}

function addNotification(message) {
    let notificationCount = $("#notificationCount");
    let currentCount = +notificationCount.html();
    let newCount = currentCount + 1;
    notificationCount.html(newCount);

    if (message !== undefined) {
        toastr.info(message);
    }
}