class App {

    constructor() {
        this.initLanguageSelector();
    }

    private initLanguageSelector() {
        $('#languageSelector').change(() => {
            $('#selectLanguage').submit();
        });
    }

}