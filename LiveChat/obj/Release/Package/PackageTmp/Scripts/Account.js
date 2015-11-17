$(document).ready(function () {
    var loginID = $("#userID").val();

    var accountTable = $("#AccountTables").dataTable({
        "ajax": {
            "url": "/Admin/AccountDetails",
            "dataSrc": "lcUserList",
            "type": "Get"
        },
        "columns": [
            { "data": "UserID", "orderable": true },
            { "data": "UserName", "orderable": true },
            { "data": "Password", "orderable": true },
            { "data": "UserLevel", "orderable": true },
            { "data": "Dept", "orderable": true },
            { "data": "Status", "orderable": true },
            { "data": "UserID" }
        ],
        "aoColumnDefs": [
            {
                "aTargets": [-4],
                "mData": function (data, type, val) {
                    return data;
                },
                className: "dt-body-center",
                "mRender": function (data, type, full) {
                    var status = data.trim();
                    if (status == "AD") {
                        return "Administer";
                    } else {
                        return "Worker";
                    }
                }
            },
            {
                "aTargets": [-2],
                "mData": function (data, type, val) {
                    return data;
                },
                className: "dt-body-center",
                "mRender": function (data, type, full) {
                    var status = data.trim();
                    if (status == "A") {
                        return "Active";
                    } else {
                        return "Inactive";
                    }
                }
            },
            {
                "aTargets": [-1],
                "mData": function (data, type, val) {
                    return data;
                },
                className: "dt-body-center",
                "mRender": function (data, type, full) {
                    return '<a href="/Admin/AccountEdit?userID=' + loginID + '&accountID=' + data + '"><img src="/EmbededImages/edit.jpg" style="width: 60px;" /></a>';
                }
            }
        ]
    });

    $("#AccountTables tbody").on('click', '.Account-Delete-Button', function () {
        var accountID = $(this).parent().parent().find("td:nth(0)").text().trim();

        $.ajax({
            type: "Post",
            url: "/Admin/AccountDelete?accountID=" + accountID,
            success: function (result) {
                accountTable.fnReloadAjax('/Admin/AccountDetails');
            }
        });
    });

    $(".Create").click(function () {
        var accountID = "";
        $.ajax({
            type: "Post",
            url: '/Admin/AccountEdit?userID=' + loginID + '&accountID=' + accountID
        });
    });
});