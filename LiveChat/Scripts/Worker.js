$(document).ready(function () {
    $(document).on('click', ".ActMsg", function () {
        $("#WorkerDialog").empty();
        $("#WorkerDialog").dialog({
            title: "Live Chat",
            dialogClass: "no-close",
            click: function () {
                $(this).dialog("close");
            }
        });
    });


});