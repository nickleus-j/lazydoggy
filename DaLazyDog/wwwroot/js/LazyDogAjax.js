var Ajaxes = {
    HomeInit: function () {
        $(".excuse-btn").click(function (e) {
          //  Ajaxes.GetExcuse(".excuse-panel .excuse");
            Ajaxes.GetAnExcuse(".excuse-panel .excuse","p.excuse-description");
        });
        
    },
    GetExcuse: function (resultSelector) {
        $(resultSelector).text("Loading...");
        $.get("/Home/GetRandomExcuse", {}, function (data) {
            $(resultSelector).text(data);
        });
    },
    GetAnExcuse: function (resultSelector,descriptionSelector) {
        
        $.get("/Home/GetExcuse", {}, function (data) {
            $(resultSelector).text(data.excuseTitle);
            $(descriptionSelector).text(data.excuseDescription);
        });
    }
}