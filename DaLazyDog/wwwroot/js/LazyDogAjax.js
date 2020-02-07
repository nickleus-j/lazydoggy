var Ajaxes = {
    HomeInit: function () {
        $(".excuse-btn").click(function (e) {
            Ajaxes.GetExcuse(".excuse-panel .excuse");
        });
        
    },
    GetExcuse: function (resultSelector) {
        $.get("/Home/SampleExcuse", {}, function (data) {
            $(resultSelector).text(data);
        });
    }
}