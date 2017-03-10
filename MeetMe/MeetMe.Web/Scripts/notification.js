"use strict";

$(() => {
    $.connection.hub.start();

    var notification = $.connection.notification;

    $('#btn-publication').click(function () {
        let author = $("#username-addpublication").val();
        let message = `${author} created new publication`;
        let userId = $("#user-id").val();
        notification.server.sendNotification(message, userId);
    });

    notification.client.addNotification = addNotification;
});

function addNotification() {
    let notificationCount = $("#notificationCount");
    let currentCount = +notificationCount.html();
    console.log(typeof (currentCount))
    let newCount = currentCount + 1;
    notificationCount.html(newCount);

    // TODO: Toastr show others notification
}