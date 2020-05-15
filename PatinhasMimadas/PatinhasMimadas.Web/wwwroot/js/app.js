var App = /** @class */ (function () {
    function App() {
        this.initLanguageSelector();
        this.nextService();
        this.previousService();
    }
    App.prototype.initLanguageSelector = function () {
        $('#languageSelector').change(function () {
            $('#selectLanguage').submit();
        });
    };
    App.prototype.nextService = function () {
        $('#next').click(function () {
            if (!($('.dog-wash').is(':hidden'))) {
                $('.dog-wash').attr("hidden", "hidden");
                $('.dog-sitting').removeAttr("hidden");
                return;
            }
            if (!($('.dog-sitting').is(":hidden"))) {
                $('.dog-sitting').attr("hidden", "hidden");
                $('.dog-self-service').removeAttr("hidden");
                return;
            }
            if (!($('.dog-self-service').is(":hidden"))) {
                $('.dog-self-service').attr("hidden", "hidden");
                $('.dog-wash').removeAttr("hidden");
                return;
            }
        });
    };
    App.prototype.previousService = function () {
        $('#previous').click(function () {
            if (!($('.dog-wash').is(':hidden'))) {
                $('.dog-wash').attr("hidden", "hidden");
                $('.dog-self-service').removeAttr("hidden");
                return;
            }
            if (!($('.dog-sitting').is(":hidden"))) {
                $('.dog-sitting').attr("hidden", "hidden");
                $('.dog-wash').removeAttr("hidden");
                return;
            }
            if (!($('.dog-self-service').is(":hidden"))) {
                $('.dog-self-service').attr("hidden", "hidden");
                $('.dog-sitting').removeAttr("hidden");
                return;
            }
        });
    };
    return App;
}());
//# sourceMappingURL=app.js.map