$.validator.addMethod('startswithaorzandminlength', function (value, element, params) {
    if (!value || value === '') {
        return true;
    }

    // Kontrola minimálnej dĺžky
    const minLength = params[0];
    if (value.length < minLength) {
        return false;
    }

    // Získanie prvého písmena
    const firstLetter = value.charAt(0).toUpperCase(); // Zaručíme, že porovnávame s veľkými písmenami

    // Overenie, či prvé písmeno je medzi A a Z (bez ohľadu na malé/veľké písmená)
    if (firstLetter >= 'A' && firstLetter <= 'Z') {
        return true;
    }

    // Ak prvé písmeno nie je medzi A a Z, vrátiť false
    return false;
});

// Pridanie podpory pre jQuery Unobtrusive validáciu
$.validator.unobtrusive.adapters.add('startswithaorzandminlength', ['minlength'], function (options) {
    var element = $(options.form).find('#' + options.element.id)[0];
    options.rules['startswithaorzandminlength'] = [options.params.minlength];
    options.messages['startswithaorzandminlength'] = options.message;
});
