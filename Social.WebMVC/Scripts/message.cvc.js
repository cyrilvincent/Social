function getMessages(param) {
    $.getJSON("/api/Message", param, function (data, status, jqXHR) {
        $('#pageStatus:first').text("JSON Received");
        if (data != null) {
            displayMessages(param, data);
        }
        $('#pageStatus:first').text("JSON Ended");
    });
}

function getComments(param) {
    $.getJSON("/api/Message", param, function (data, status, jqXHR) {
        $('#pageStatus:first').text("Comments Received");
        if (data != null) {
            displayComments(param, data);
        }
        $('#pageStatus:first').text("Comments Ended");
    });
}

function displayMessages(param, data) {
    $.each(data, function (index, value) {
        var template = cloneAndFillTemplate(value);
        if (param != null && param.mode == "before") {
            $('.pageletComposer:first').after(template.fadeIn("slow"));
        }
        else $('#moreMessageHolder').before(template.fadeIn("slow"));
        if (value.Comments != null)
            displayComments(null, value.Comments);
    });
    if (data.length > 0 && param != null && param.mode == "before" && param.disableToast == null)
        $().toastmessage('showNoticeToast', 'De nouveaux messages sont arrivés');
    if (data.length == 20)
        $('#moreMessageBtn').show();
    else if (data.length == 0 && param != null && param.mode == "after")
        $('#moreMessageBtn').hide();
}

function displayComments(param, comments) {
    $.each(comments, function (index, to) {
        var commentTemplate = cloneAndFillCommentTemplate(to);
        if (param != null && param.mode == "before")
            $("#CT" + to.ParentId + " .composerCommentTR:last").before(commentTemplate);
        else
            $("#CT" + to.ParentId).prepend(commentTemplate);
    });
}

function updateMessage(id, mode) {
    $.getJSON("/api/Message", { id: id }, function (data, status, jqXHR) {
        if (data != null) {
            var template = cloneAndFillTemplate(data);
            template.show();
            if(mode == "message")
                $('#M' + data.Id).find(":first").replaceWith(template.find(":first"));
            else if(mode == "toolbar")
                $('#M' + data.Id).find(".pageletToolbar:first").replaceWith(template.find(".pageletToolbar:first"));
        }
    });
}

function updateComment(parentId, id) {
    $.getJSON("/api/Message", { parentId : parentId, id: id }, function (data, status, jqXHR) {
        if (data != null) {
            var template = cloneAndFillCommentTemplate(data);
            template.show();
            $('#C' + data.Id).replaceWith(template);
        }
    });
}

function cloneAndFillTemplate(value) {
    var template = $('#pageletViewerTemplate .pageletViewer').clone();
    template.find(".Composer").html(value.Text);
    template.find(".nbLike:first").text(value.NbLike);
    template.find(".nbComment:first").text(value.NbComment);
    template.find(".composerDate:first").text(formatJSONDate(value.DateTime));
    template.find(".messageId:first").text(value.Id);
    template.find(".like:first").attr("id", "L" + value.Id);
    var s = "";
    if (value.LikeStrings.length == 1)
        var s = value.LikeStrings[0] + " aime ça";
    else if (value.LikeStrings.length > 1) {
        $.each(value.LikeStrings, function (index, value) {
            if (index != 0) s += ", ";
            s += value;
        });
        s += " et d'autres aiment ça";
    }
    template.find(".likeSpan:first").attr("title", s);
    if (value.Liked)
        template.find(".like:first").text("Je n'aime plus");
    template.attr("id", "M" + value.Id);
    template.find(".like:first").on("click", {id : value.Id}, like);
    template.find(".commentButton:first").attr("id", "CB" + value.Id);
    template.find(".composerComment:first").attr("id", "CM" + value.Id);
    template.find(".composerCommentTable:first").attr("id", "CT" + value.Id);
    //template.find(".commentButton:first").click(comment);
    template.find(".commentButton:first").on("click", { id: value.Id }, comment);
    template.find(".composerComment:first").keyup(function () {
        if (event.which == 13) this.rows++;
    });

    createScrapper(value, template);
    return template;
}


function cloneAndFillCommentTemplate(value) {
    var template = $('#commentletTemplate table tr').clone();
    template.attr("id", "C" + value.Id);
    template.find(".comment").html(value.Text);
    template.find(".commentDate").text(formatJSONDate(value.DateTime));
    template.find(".nbCommentLike").text(value.NbLike);
    template.find(".commentId").text(value.Id);
    return template;
}

function like(event) {
    $('#pageStatus:first').text("Liking");
    var id = event.data.id;
    $.getJSON("/api/Message", { id: id, mode: "like" }, function (data, status, jqXHR) {
        updateMessage(id,"toolbar");
        $('#pageStatus:first').text("Liked");
    });
    $('#M' + id).find(".like:first").text("Sending");
}

function comment(event) {
    $('#pageStatus:first').text("Comment");
    //var id = event.toElement.id.substring(2);
    var id = event.data.id;
    var text = $('#CM' + id).val();
    if (text != null && text != "") {
        text = text.replace(/\n/g, "<br/>");
        var to = { Text: text, ParentId: id };
        postMessage(to);
        $('#CM' + id).val("");
        $('#CM' + id)[0].rows = 1;
        var nbComment = $('#M' + id).find(".nbComment:first");
        nbComment.text(parseInt(nbComment.text()) + 1);
    }
}

function formatJSONDate(jsonDate) {
    var d = new Date(jsonDate);
    var interval = (Date.now() - d) / 1000;
    interval += 7200; //GMT+2
    var res = "";
    if (interval < 60) res = "Il y a quelques instants";
    else if (interval < 600) res = "Il y a quelques minutes";
    else if (interval < 3600) res = "Il y a moins d'une heure";
    else if (interval < (1.5 * 3600)) res = "Il y a une heure";
    else if (interval < (24 * 3600)) res = "Il y a " + Math.round(interval / 3600) + " heures";
    else res = "Le " + d.toLocaleString();
    return res;
}

function postMessage(to) {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "/api/Message/",
        data: to,
    }).fail(function (jqXHR, textStatus, err) {
        var error = $.parseJSON(jqXHR.responseText);
        template.find(".composerDate:first").text(error);
        $('#pageStatus:first').text("WebAPI error");
    }).done(function () {
        $('#pageStatus:first').text("Sended");
        if (to.ParentId == null) {
            var id = $(".messageId:first").text();
            getMessages({ id: id, mode: "before", disableToast: true });
        }
        else {
            var id = 0;
            var table = $("#CT" + to.ParentId);
            var tr = table.find("tr[id]:last");
            if (tr != null && tr.length > 0)
                id = tr.attr("id").substring(1);
            getComments({ id: id, mode: "before", parentId: to.ParentId, disableToast: true })
        }
        $("#scrapper").hide();
        $("#ComposerTB").val("");
        $("#ComposerTB")[0].rows = 2;
        imgArrayCounter = 0;
    });
}

$(document).ready(function () {
    $('#pageStatus:first').text("Waiting for JSON");

    getMessages(null);

    $('#composerButton').click(function () {
        $('#pageStatus:first').text("Composer submit");
        var text = $("#ComposerTB").val();
        if (text != null && text.trim() != '') {
            text = text.replace(/\n/g, "<br/>");
            var to = getTO(text, getScrapperImage());
            $('#pageStatus:first').text("Sending");
            postMessage(to);
        }

    });

    setInterval(function () {
        var id = $(".messageId:first").text();
        getMessages({ id: id, mode: "before" })
    }, 60000);

})