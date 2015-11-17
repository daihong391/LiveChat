$(document).ready(function () {
    $("#MessageTable").dataTable({
        "ajax": {
            "url": "/Admin/MessageDetails",
            "dataSrc": "msgList",
            "type": "Get"
        },
        "aoColumns": [
            { "data": "MsgID", "orderable": true },
            { "data": "MsgContent", "orderable": true },
            { "data": "UserID", "orderable": true },
            { "data": "PostTime", "orderable": true },
            { "data": "FName", "orderable": true },
            { "data": "LName", "orderable": true },
            { "data": "Status", "orderable": true }
        ],
        "aoColumnDefs": [
            {
                "aTargets": [-1],
                "mData": function (data, type, val) {
                    return data;
                },
                className: "dt-body-center",
                "mRender": function (data, type, full) {
                    var status = data.trim();
                    if (status == "A") {
                        return "Active";
                    } else if (status == "F") {
                        return "Finish";
                    }
                }
            }
        ]
    });
});