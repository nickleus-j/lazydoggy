var Ajaxes = {
    HomeInit: function () {
        $(".excuse-btn").click(function (e) {
            Ajaxes.GetExcuse(".excuse-panel .excuse");
        });
        
    },
    GetExcuse: function (resultSelector) {
        $(resultSelector).text("Loading...");
        $.get("/Home/GetRandomExcuse", {}, function (data) {
            $(resultSelector).text(data);
        });
    }
}