$(document).ready(function () {
    $("#WorkerDialog").dialog({
        autoOpen: false,
        title: "Live Chat",
        modal: true,
        dialogClass: 'no-close'
    });

    var userID = $("input[name=UserID]").val();
    $(document).on('click', '.ActMsg', function () {
        $("#WorkerDialog").dialog("open");
        $("input[name=MsgID]").val($(this).text());

        //var dialogUpInterval = setInterval("updateContent($('input[name=\"MsgID\"]').val())", 3000);
    });

    $(document).on('click', '#MsgSend', function () {
        var fName = $("#Worker-AgentName").text();
        var msgID = $("input[name=MsgID]").val();
        var msgContent = $("input[name=Worker-Msg-Content]").val();
        $.ajax({
            type: "Post",
            url: "/Worker/AppMsg",
            data: { msgID: msgID, fName: fName, msgContent: msgContent, userID: userID },
            success: function (data) {
                $("#WorkerMsgs").empty();
                var msg = data.msg;
                $("#WorkerMsgs").append(msg.MsgContent);
                $("input[name='Worker-Msg-Content']").val("");
            }
        });
    });
});

function updateContent(msgID) {
    $("#WorkerMsgs").empty();

    $.ajax({
        type: "Post",
        url: "/Worker/MsgUp",
        data: { msgId: msgID},
    });
}