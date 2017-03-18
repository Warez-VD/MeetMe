$(() => {
    $.connection.hub.start();

    var notification = $.connection.notification;

    $(".btn-accept").on("click", (ev) => {
        let acceptBtn = $(ev.target);
        let userId = acceptBtn.attr("data-id");
        let receiverId = acceptBtn.attr("data-receiverId");
        notification.server.acceptFriendship(userId, receiverId);
    });
    
    notification.client.addNotification = addNotification;
    notification.client.removeOneNotification = removeOneNotification;
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

function removeOneNotification() {
    let element = $("#notificationCount");
    let currentCount = +element.text();
    let newCount = currentCount - 1;
    if (newCount == 0) {
        newCount = "";
    }
    
    element.text(newCount);
}

function hideShowMoreLink() {
    $("#showMoreResults").addClass("hidden");
}

function hideRemoveAllNotifications() {
    $("#removeAllNotifications").addClass("hidden");
}