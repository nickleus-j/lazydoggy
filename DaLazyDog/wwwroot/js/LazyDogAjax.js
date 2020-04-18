var Ajaxes = {
    listSelctor: "ul.history",
    UiTexts: {
        Loading: "load"
    },
    HomeInit: function () {
        $(".excuse-btn").click(function (e) {
            Ajaxes.GetAnExcuse(".excuse", "p.excuse-description", ".link-to-letter-maker");
        });

    },
    RecordExcuse: function (excuse) {
        var item = $("<li></li>");
        item.text(excuse);
        $(Ajaxes.listSelctor).prepend(item);
    },
    GetExcuse: function (resultSelector) {
        $(resultSelector).text(Ajaxes.UiTexts.Loading);
        $.get("/Home/GetRandomExcuse", {}, function (data) {
            $(resultSelector).text(data);
        });
    },
    GetAnExcuse: function (resultSelector, descriptionSelector, letterMakerDivSelector) {
        var resultDom = $(resultSelector);
        resultDom.text(Ajaxes.UiTexts.Loading);
        $.get("/Home/GetExcuse", {}, function (data) {
            resultDom.text(data.excuseTitle);
            Ajaxes.RecordExcuse(data.excuseTitle);
            $(descriptionSelector).text(data.excuseDescription);
            $(letterMakerDivSelector).removeClass("hidden");
            $(letterMakerDivSelector + " a").attr("href", "/LetterTemplate/MakeLetter/1?excuseName=" + data.excuseTitle);
        });
    }
};