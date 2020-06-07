function appendCheckboxListItem(textValue, listSelector) {
    var item = $(`<li><input type="checkbox" class="checkbox" value="${textValue}"/><label>${textValue}</label><li>`);
    $(listSelector).append(item);
}
function checkWork() {
    var arr = [];

    $(".checkbox:checked").each(function (index, item) {
        arr.push(item.value);
    });
    if (arr.length > 0) {
        $(".labels-cell").parent().addClass("hidden");
    }
    else {
        $(".labels-cell").parent().removeClass("hidden");
    }
    $(".labels-cell").each(function (index, item) {
        for (var ctr = 0; ctr < arr.length; ctr++) {
            if (item.innerText.indexOf(arr[ctr]) >= 0) {
                $(item.parentElement).removeClass("hidden");
            }
        }
    });
}
function prepereFilterList(text) {
    var items = text.split(' ').filter(item => item.length > 0);
    var finalizedItems = [];
    for (var ctr = 0; ctr < items.length; ctr++) {
        var currentItem = items[ctr];
        if (finalizedItems.indexOf(currentItem) < 0) {
            finalizedItems.push(currentItem);
            appendCheckboxListItem(currentItem, ".filter-form ul");
        }
    }
    $(".checkbox").change(function () {
        checkWork();

    });
    return finalizedItems;
}
function initializeExcuseList() {
    $(".row .search-btn").click(function () {
        window.location.href = "../Excuse/Category?category=" + $("#searchTxt").val();
    });
    $(".labels-cell a").click(function () {
        var currentValue = $(this).text();
        $(`.checkbox[value="${currentValue}"]`).attr("checked", "checked");
        checkWork();
    });
    var filterArr = prepereFilterList(replaceAllSubstring($(".labels-cell").text().trim(), '\n', ''));
}