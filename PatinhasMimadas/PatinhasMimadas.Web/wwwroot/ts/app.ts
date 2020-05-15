
class App {

    constructor() {
        this.initLanguageSelector();
        this.nextService();
        this.previousService();
    }

    private initLanguageSelector() {
        $('#languageSelector').change(() => {
            $('#selectLanguage').submit();
        });
    }

    private nextService() {
        $('#next').click(() => {
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
    }

    private previousService() {
        $('#previous').click(() => {
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
    }
}