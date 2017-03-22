"use strict";

function ajaxSuccess() {
    $("#publication-content").val("");
    $("#publication-image").remove();
}

function updateSuccess() {
    toastr.success("Updated successfully");
}

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
    $("#user-publication-picture").change(handleFileSelect);

    $("#btn-edit").on("click", () => {
        $("#btn-edit").addClass("hidden");
        $(".editable").addClass("hidden");
        $(".editmode").removeClass("hidden");
    });

    $("#btn-save").on("click", () => {
        $("#btn-edit").removeClass("hidden");
        $(".editable").removeClass("hidden");
        $(".editmode").addClass("hidden");
    });

    $("#profile-image-change").change((e) => {
        var files = e.target.files;
        var userId = $("#label-change-picture").attr("data-id");
        if (files.length > 0) {
            if (window.FormData !== undefined) {
                var data = new FormData();
                for (var x = 0; x < files.length; x++) {
                    data.append("file" + x, files[x]);
                }

                $.ajax({
                    type: "POST",
                    url: '/profile/changeprofileimage?id=' + userId,
                    contentType: false,
                    processData: false,
                    data: data,
                    success: (result) => {
                        toastr.info(result);
                    },
                    error: () => {
                        toastr.info("Something went wrong, please try again");
                    }
                });
            } else {
                toastr.error("This browser doesn't support HTML5 file uploads!");
            }
        }
    });
});