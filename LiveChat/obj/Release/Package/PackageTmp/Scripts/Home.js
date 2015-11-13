$(document).ready(function () {
    //login Panel
    var $loginPage = '<form id="loginForm" method="post" action="/">';
    //First Name
    $loginPage += '<p><label>First Name</label>';
    $loginPage += '<input type="text" name="FName" /></p>';
    //Last Name
    $loginPage += '<p><label>Last Name</label>';
    $loginPage += '<input type="text" name="LName" /></p>';
    $loginPage += '<button id="Home-Msg-Create" type="button" style="margin: auto; display: block; border-radius: 5px;">Submit</button></form>';

    //Live Chat Panel
    var $liveChat = '<form id="LiveChat" method="post" action="/">';
    $liveChat += '<label>MsgID</label>';
    $liveChat += '<input name="MsgID" style="border: none; margin-left: 5px;" readonly />';
    $liveChat += '<li class="one" style="max-height: 150px; background: white; overflow: scroll;">Waiting...';
    $liveChat += '<ul id="MsgContentArea" style="border: 1px solid white; height: 150px; background: white; padding-left: 0; ">';
    $liveChat += '</ul></li>';
    $liveChat += '<label for="FName"></label><input type="text" name="FName" hidden />'
    $liveChat += '<input type="text" name="MsgContent">';
    $liveChat += '<button id="Home-Msg-Send" type="button">Send</button>';
    $liveChat += '</form>';

    var fName = "";
    var lName = "";
    var msgID = "";

    $("#Home-Live-Chat-button").click(function () {
        $("#Home-Live-Chat-Panel").empty();
        $($loginPage).appendTo($("#Home-Live-Chat-Panel"));
        $("#Home-Live-Chat-Panel").dialog({
            title: "Live Chat",
            modal: true,
            dialogClass: 'no-close',
            click: function () {
                $(this).dialog("close");
            }
        });

    });

    $(document).on('click', "#Home-Msg-Create", function () {
        fName = $("#loginForm p:nth-child(1) input").val().trim();
        lName = $("#loginForm p:nth-child(2) input").val().trim();

        $.ajax({
            type: "Post",
            url: "/Home/CreateMsg",
            data: { fName: fName, lName: lName },
            success: function (data) {
                var msg = data.msg;
                $("#Home-Live-Chat-Panel").empty();
                if (msg != null) {
                    $($liveChat).appendTo($("#Home-Live-Chat-Panel"));
                    $("input[name='MsgID']").val(msg.MsgID);
                    $("label[for='FName']").text(msg.FName);
                    $("input[name='FName']").val(msg.FName);

                    msgID = $("input[name='MsgID']").val();
                    fName = $("input[name='FName']").val();
                } else {
                    $($loginPage).appendTo($("#Home-Live-Chat-Panel"));
                    $("#Home-Live-Chat-Panel").prepend('<ul><li>First Name or Last Name are required!</li></ul>');
                }
            }
        });

        var dialogUpInterval = setInterval("updateContent($('input[name=\"MsgID\"]').val())", 3000);

        $("#Home-Live-Chat-Panel").dialog({
            beforeClose: function (event, ui) {
                $.ajax({
                    type: "Post",
                    url: "/Home/AppMsg",
                    data: { msgID: msgID, fName: fName, msgContent: "Agent has left." }
                });
                clearInterval(dialogUpInterval);
            }
        });
    });

    $(document).on('click', "#Home-Msg-Send", function () {
        msgID = $("input[name='MsgID']").val();
        fName = $("input[name='FName']").val();
        var msgContent = $("input[name='MsgContent']").val();

        $.ajax({
            type: "Post",
            url: "/Home/AppMsg",
            data: { msgID: msgID, fName: fName, msgContent: msgContent },
            success: function (data) {
                $("#MsgContentArea").empty();
                var msg = data.msg;
                $("#MsgContentArea").append(msg.MsgContent);
                $("input[name='MsgContent']").val("");
            }
        });
    });
});

function updateContent(msgID) {
    $("#MsgContentArea").empty();

    $.ajax({
        type: "Post",
        url: "/Home/MsgUp",
        data: { msgID: msgID },
        success: function (data) {
            var msgContent = data.msgContent;
            $("#MsgContentArea").empty();
            $("#MsgContentArea").append(msgContent);

        }
    });
}
