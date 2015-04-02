function abortTimer(tid) {
    if (null != tid) clearTimeout(tid)
}

function getUrl(prefix, urlText) {
    var urlString = '';
    var startIndex = urlText.indexOf(prefix);
    for (var i = startIndex; i < urlText.length; i++) {
        if (urlText[i] == ' ' || urlText[i] == '\n') break;
        else urlString += urlText[i]
    }
    return urlString
}

function createScrapper(to, template) {
    if (to.Url != null) {
        template.find(".scrapper").show();
        if (to.VideoUrl != null) {
            template.find(".scrapperIFrame").attr("src", to.VideoUrl);
            template.find(".scrapperIFrame").show();
        }
        else if (to.ImageUrl != null) {
            template.find(".scrapperImage").css('backgroundImage', 'url(' + to.ImageUrl + ')');
            template.find(".scrapperImage").show();
        }
        if(to.Title != null)
            template.find(".scrapperTitle").html(to.Title);
        if(to.Description != null)
            template.find(".scrapperText").html(to.Description);
        template.find(".scrapperUrl").html(to.Url);
        template.find(".scrapperA").attr("href", to.Url);
    }
    return template;
}

function getTO(text, imgSrc) {
    var to = { Text: text };
    if ($("#scrapper").is(':visible')) {
        if ($(".scrapperImage:first").is(':visible')) 
            to.ImageUrl = imgSrc;
        else if ($(".scrapperIFrame:first").is(':visible'))
            to.VideoUrl = $(".scrapperIFrame:first").attr("src");
        to.Title = $(".scrapperTitle:first").html();
        to.Description = $(".scrapperText:first").html();
        to.Url = $(".scrapperUrl:first").html();
    }
    return to;
}

var imgSrcArray = [];
var imgArrayCounter = 0;

function getScrapperImage() {
    return imgSrcArray[imgArrayCounter];
}

$(document).ready(function () {

    $("#scrapperClose").click(function () {
        $("#scrapper").hide("slow");
    });

    var tid;

    $("#ComposerTB").keyup(function (event) {
        urlText = this.value;
        abortTimer(tid);
        tid = setTimeout(function () { scrapeURL(urlText) }, 1000);
        if (event.which == 13) { this.rows++ }
    });



    function scrapeURL(urlText) {
        var urlString;
        if (urlText.indexOf('http://') >= 0) {
            urlString = getUrl('http://', urlText);
            getUrlData(urlString);
        }
        else if (urlText.indexOf('https://') >= 0) {
            urlString = getUrl('https://', urlText);
            getUrlData(urlString);
        }
        else if (urlText.indexOf('www.') >= 0) {
            urlString = getUrl('www', urlText);
            getUrlData('http://' + urlString);
        }
        else { $('#scrapper').hide() }
    }

    function getUrlData(urlString) {
        try { $('#pageStatus:first').text("Found " + urlString) } catch (err) { };
        $.post("/api/Preview", { '': urlString }, function (data, status, jqXHR) {
            if (data == null) {
                $('#scrapper').hide();
            }
            else {
                if (data.Title != null) $('.scrapperTitle:first').html(data.Title);
                $('.scrapperUrl:first').text(data.Url);
                if (data.Summary != null) $('.scrapperText:first').html(data.Summary)
                if (data.IFrameUrl != null) {
                    iframeSrc = data.IFrameUrl;
                    $('.scrapperIFrame:first').attr("src", data.IFrameUrl);
                    $('.scrapperImage:first').hide();
                    $('.scrapperButtonsText:first').hide();
                    $('.scrapperButtons:first').hide();
                    $('.scrapperIFrame:first').show();
                }
                else {
                    if (data.ComputeImageUrls.length > 0) {
                        $('.scrapperImage:first').css('backgroundImage', 'url(' + data.ComputeImageUrls[0] + ')');
                        $('.scrapperImage:first').show();
                        imgSrcArray = data.ComputeImageUrls;
                        if (data.ComputeImageUrls.length > 1) {
                            $('.scrapperButtonsText:first').text('1 / ' + data.ComputeImageUrls.length);
                            $('.scrapperButtonsText:first').show();
                            $('.scrapperButtons:first').show();
                        }
                        else {
                            $('.scrapperButtonsText:first').hide();
                            $('.scrapperButtons:first').hide();
                        }
                    }
                    else {
                        $('.scrapperImage:first').hide();
                        $('.scrapperButtonsText:first').hide();
                        $('.scrapperButtons:first').hide();

                    }
                    $('.scrapperIFrame:first').hide();
                }
                $('#scrapper').show("slow")
            }
        })
    }

    $("#scrapperNextButton").click(function () {
        imgArrayCounter++;
        if (imgArrayCounter >= imgSrcArray.length) imgArrayCounter = 0;
        $('.scrapperImage:first').css('backgroundImage', 'url(' + imgSrcArray[imgArrayCounter] + ')');
        $('.scrapperButtonsText:first').text((imgArrayCounter + 1) + ' / ' + imgSrcArray.length)
    });

    $("#scrapperPrevButton").click(function () {
        imgArrayCounter--;
        if (imgArrayCounter < 0) imgArrayCounter = imgSrcArray.length - 1;
        $('.scrapperImage:first').css('backgroundImage', 'url(' + imgSrcArray[imgArrayCounter] + ')');
        $('.scrapperButtonsText:first').text((imgArrayCounter + 1) + ' / ' + imgSrcArray.length)
    });

    $("#moreMessageBtn").click(function () {
        if ($(".messageId").length > 1) {
            var id = $(".messageId").eq($(".messageId").length - 2).text();
            getMessages({ id: id, mode: "after" })
        }
    });

});