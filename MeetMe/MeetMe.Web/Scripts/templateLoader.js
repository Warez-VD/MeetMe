var templatesLoader = (function () {

    function get(templateName) {
        var url = `/Content/message-template/${templateName}.html`;
        return requester.get(url);
    }

    return {
        get: get
    };
}());