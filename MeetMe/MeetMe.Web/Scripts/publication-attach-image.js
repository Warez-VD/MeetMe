"use strict";

function handleFileSelect(ev) {
    var files = ev.target.files;
    for (var i = 0, f; f = files[i]; i++) {

        if (!f.type.match('image.*')) {
            continue;
        }

        var reader = new FileReader();
        reader.onload = (function (theFile) {
            return function (e) {
                let index = e.target.result.toString().indexOf(",");
                let result = e.target.result.toString().substring(index + 1);

                // Render thumbnail.
                let span = $("<span />");
                let imgToShow = $("<img />")
                    .addClass("thumb")
                    .attr("id", "publication-image")
                    .attr("src", e.target.result);
                span.append(imgToShow);

                $("#image-base").val(result);
                $("#add-publication-content").html(span);
            };
        })(f);

        reader.readAsDataURL(f);
    }
}

$(() => {
    $("#publication-picture").change(handleFileSelect);
});