"use strict";

var requester = (function () {
    function get(url) {
        let promise = new Promise((resolve, reject) => {
            $.ajax({
                url,
                method: "GET",
                success (response) {
                    resolve(response);
                },
                error (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    function putJSON(url, body, options) {
        options = options || {};
        let promise = new Promise((resolve, reject) => {
            let headers = options.headers || {};
            $.ajax({
                url,
                headers,
                method: "PUT",
                contentType: "application/json",
                data: JSON.stringify(body),
                success (response) {
                    resolve(response);
                },
                error (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    function postJSON(url, body, options) {
        options = options || {};

        let promise = new Promise((resolve, reject) => {
            let headers = options.headers || {};

            $.ajax({
                url,
                headers,
                method: "POST",
                contentType: "application/json",
                data: JSON.stringify(body),
                success (response) {
                    resolve(response);
                },
                error (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    function getJSON(url, options) {
        options = options || {};

        let promise = new Promise((resolve, reject) => {
            let headers = options.headers || {};

            $.ajax({
                url,
                headers,
                method: "GET",
                contentType: "application/json",
                success (response) {
                    resolve(response);
                },
                error (err) {
                    if (err.status === 401) {
                        // toastr.error("You have to be logged-in!");
                    }

                    reject(err);
                }
            });
        });

        return promise;
    }

    function deleteJSON(url, options) {
        options = options || {};

        let promise = new Promise((resolve, reject) => {
            let headers = options.headers || {};

            $.ajax({
                url,
                headers,
                method: "DELETE",
                contentType: "application/json",
                success(response) {
                    resolve(response);
                },
                error(err) {
                    reject(err);
                }
            });
        });

        return promise;
    }

    return {
        get: get,
        putJSON: putJSON,
        postJSON: postJSON,
        getJSON: getJSON,
        deleteJSON: deleteJSON
    };
}());