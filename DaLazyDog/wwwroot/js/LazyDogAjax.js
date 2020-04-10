var Ajaxes = {
    UiTexts: {
        Loading:"load"
    },
    HomeInit: function () {
        $(".excuse-btn").click(function (e) {
            Ajaxes.GetAnExcuse(".excuse-panel .excuse", "p.excuse-description",".link-to-letter-maker");
        });
        
    },
    GetExcuse: function (resultSelector) {
        $(resultSelector).text(Ajaxes.UiTexts.Loading);
        $.get("/Home/GetRandomExcuse", {}, function (data) {
            $(resultSelector).text(data);
        });
    },
    GetAnExcuse: function (resultSelector,descriptionSelector,letterMakerDivSelector) {
        $(resultSelector).text(Ajaxes.UiTexts.Loading);
        $.get("/Home/GetExcuse", {}, function (data) {
            $(resultSelector).text(data.excuseTitle);
            $(descriptionSelector).text(data.excuseDescription);
            $(letterMakerDivSelector).removeClass("hidden");
            $(letterMakerDivSelector + " a").attr("href", "/LetterTemplate/MakeLetter/1?excuseName=" + data.excuseTitle);
        });
    }
}