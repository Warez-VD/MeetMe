"use strict";

$(() => {
    let usernames = requester.getJSON("/users/usernames")
    .then((response) => {
        console.log(response);
        $("#search-bar").autocomplete({
            source: response
        });
    });
});