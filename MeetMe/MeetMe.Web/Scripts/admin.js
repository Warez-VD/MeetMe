"use strict";

$(() => {
    $(".ban-user").on("click", banUser);

    $(".unban-user").on("click", unbanUser);
});

function banUser(ev) {
    let target = $(ev.target);
    let userId = target.attr("data-id");
    let url = `/administration/dashboard/banuser/${userId}`;
    requester.postJSON(url)
        .then((result) => {
            target.val("Unban user");
            target.removeClass("btn-danger ban-user").addClass("btn-success unban-user");
            toastr.success(result);
            target.unbind("click", banUser);
            $(".unban-user").on("click", unbanUser);
        });
}

function unbanUser(ev) {
    let target = $(ev.target);
    let userId = target.attr("data-id");
    let url = `/administration/dashboard/unbanuser/${userId}`;
    requester.postJSON(url)
        .then((result) => {
            target.val("Ban user");
            target.removeClass("btn-success unban-user").addClass("btn-danger ban-user");
            toastr.success(result);
            target.unbind("click", unbanUser);
            $(".ban-user").on("click", banUser);
        });
}