"use strict";

$(() => {
    $.connection.hub.start();

    var chat = $.connection.chat;

    $(document).on("click", "#btn-chat", () => {
        let messageBtn = $("#btn-input");
        let message = messageBtn.val();
        let userId = messageBtn.attr("data-userid");
        let friendId = messageBtn.attr("datafriend-id");
        chat.server.sendMessage(message, userId, friendId);
    });

    chat.client.addMessage = addMessage;
});

function addMessage(message) {
    console.log(message);
}