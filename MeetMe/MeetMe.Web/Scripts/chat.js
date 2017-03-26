"use strict";

$(() => {
    $.connection.hub.start();

    var chat = $.connection.chat;

    $(document).on("click", "#btn-chat", () => {
        let messageInput = $("#btn-input");
        let message = messageInput.val();
        let id = +messageInput.attr("data-id");
        let userId = messageInput.attr("data-userid");
        let friendId = messageInput.attr("datafriend-id");
        chat.server.sendMessage(message, id, userId, friendId);
    });

    chat.client.addMessage = addMessage;
});

function addMessage(message) {
    if (message.IsCurrentUserAuthor) {
        templatesLoader.get("message-template-left")
            .then(function (html) {
                var compiledTemplate = Handlebars.compile(html);
                $("#chat-list").append(compiledTemplate(message));
                $("#btn-input").val("");
            });
    } else {
        templatesLoader.get("message-template-right")
            .then(function (html) {
                var compiledTemplate = Handlebars.compile(html);
                $("#chat-list").append(compiledTemplate(message));
                $("#btn-input").val("");
            });
    }

    $("#chat-content").scrollTop($("#chat-content").height() * 2);
}