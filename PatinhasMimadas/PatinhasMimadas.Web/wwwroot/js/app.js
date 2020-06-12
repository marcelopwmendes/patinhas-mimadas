var App = /** @class */ (function () {
    function App() {
        this.initLanguageSelector();
    }
    App.prototype.initLanguageSelector = function () {
        $('#languageSelector').change(function () {
            $('#selectLanguage').submit();
        });
    };
    return App;
}());
//# sourceMappingURL=app.js.map