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

        var dialogUpInterval = setInterval("updateContent($('input[name=\"MsgID\"]').val())", 3000);

        $("#WorkerDialog").dialog({
            beforeClose: function (event, ui) {
                $.ajax({
                    type: "Post",
                    url: "/Worker/AppMsg",
                    data: { msgID: $("input[name=MsgID]").val(), fName: $("#Worker-AgentName").text(), msgContent: "Dialog has been finished." }
                });
                clearInterval(dialogUpInterval);
            }
        });
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

    setInterval("upMsg()", 3000);
});

function updateContent(msgID) {
    $.ajax({
        type: "Post",
        url: "/Worker/MsgUp",
        data: { msgId: msgID },
        success: function (data) {
            var msgContent = data.msgContent;
            $("#WorkerMsgs").empty();
            $("#WorkerMsgs").append(msgContent);
        }
    });
}

function upMsg() {
    $.ajax({
        type: "Post",
        url: "/Worker/MsgListShow",
        success: function (data) {
            var msgArray = data.msgArray;
            $("#MsgList ul").empty();
            for (var i = 0; i < msgArray.length; i++) {
                $("#MsgList ul").append('<li class="ActMsg">' + msgArray[i] + '</li>');
            }
        }
    });
}