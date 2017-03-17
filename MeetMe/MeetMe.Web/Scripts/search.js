"use strict";

$(() => {
    $.connection.hub.start();

    var notification = $.connection.notification;
    $(".add-friend").on("click", (ev) => {
        let addFriendBtn = $(ev.target);
        let currentUserId = addFriendBtn.attr("current-id");
        let friendId = addFriendBtn.attr("data-id");
        notification.server.addFriend(currentUserId, friendId);
    });

    notification.client.addFriend = addFriend;
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

function addFriend(id) {
    let selector = `btn-friend-${id}`;
    $(`#${selector}`).attr("disabled", "disabled");
}

function hideShowMoreLink() {
    $("#showMoreResults").addClass("hidden");
}

function sendInvitation() {
    toastr.success("Successfully sent friendship invitation");
}