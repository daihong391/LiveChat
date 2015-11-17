$(document).ready(function () {
    //$('select').selectBoxIt({ 'autoWidth': false });
    //var userLevel = $("#Account-Edit-Level").val();

    //$('#Account-Level-Select').selectBoxIt().data("selectBoxIt");
    //if ($("#Account-Edit-Level").val() != null && $("#Account-Edit-Level").val() != "") {
    //    $("#Account-Level-Select").val(userLevel);
    //} else {
    //    $("#Account-Level-Select").val("GU");
    //}
    //$("#Account-Level-Select").data("selectBox-selectBoxIt").refresh();

    var userLevel = $("#Account-Edit-Level").val();
    if ($("#Account-Edit-Level").val() != null && $("#Account-Edit-Level").val() != "") {
        $("#Account-Level-Select option:selected").val(userLevel);
    } else {
        $("#Account-Level-Select option:selected").val("AD");
    }
});