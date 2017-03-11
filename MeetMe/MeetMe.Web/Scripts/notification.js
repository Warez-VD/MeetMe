"use strict";

$(() => {
    $.connection.hub.start();

    var notification = $.connection.notification;
    ajaxSuccess();

    

    notification.client.likePublication = likePublication;
    notification.client.dislikePublication = dislikePublication;
    notification.client.addNotification = addNotification;
});

function addNotification(message) {
    let notificationCount = $("#notificationCount");
    let currentCount = +notificationCount.html();
    let newCount = currentCount + 1;
    notificationCount.html(newCount);

    if (message !== undefined) {
        toastr.info(message);
    }
}

function ajaxSuccess() {
    bindEvents();
}

function bindEvents() {
    $.connection.hub.start();
    var notification = $.connection.notification;

    $('#btn-publication').click(function () {
        let author = $("#username-addpublication").val();
        let message = `${author} created new publication`;
        let userId = $("#user-id").val();
        notification.server.sendNotification(message, userId);
    });

    $(".like-publication").on("click", (ev) => {
        let target = $(ev.target);
        let elementId = target.children().first().attr("id");
        let id = target.attr("data-id");
        let userId = target.attr("data-userid");
        notification.server.addLikeNotification(id, userId, elementId);
    });

    $(".dislike-publication").on("click", (ev) => {
        let target = $(ev.target);
        let elementId = target.children().first().attr("id");
        let id = target.attr("data-id");
        notification.server.addDislikeNotification(id, elementId);
    });
}

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