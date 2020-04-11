var LetterGenerator = {
    init: function () {
        (function (original) {
            jQuery.fn.clone = function () {
                var result = original.apply(this, arguments),
                    my_textareas = this.find('textarea').add(this.filter('textarea')),
                    result_textareas = result.find('textarea').add(result.filter('textarea')),
                    my_selects = this.find('select').add(this.filter('select')),
                    result_selects = result.find('select').add(result.filter('select'));

                for (var i = 0, l = my_textareas.length; i < l; ++i) $(result_textareas[i]).val($(my_textareas[i]).val());
                for (var i = 0, l = my_selects.length; i < l; ++i) result_selects[i].selectedIndex = my_selects[i].selectedIndex;

                return result;
            };
        })(jQuery.fn.clone);
        
        LetterGenerator.initAngularScripts();
    },
    initAngularScripts: function () {
        var app = angular.module('lazyDog', []);
        app.controller('Details', function ($scope) {

            $scope.generateLetter = function () {
                var contents, generated = $(".generatedText");
                contents = $("div dl .letter-content").clone();
                contents.find("br").each(function (index, elem) { elem.replaceWith("\n") });
                contents.find("select").each(function (index, elem) { elem.replaceWith(elem.value) });
                contents.find("input").each(function (index, elem) { elem.replaceWith(elem.value) });

                $scope.LetterContent = contents.html();
            }
            $scope.generateLetter();
        });
    }
}