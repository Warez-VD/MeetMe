"use strict";

$(() => {
    let usernames = requester.getJSON("/users/usernames")
    .then((response) => {
        $("#search-bar").autocomplete({
            source: response
        });
    });
});