function CheckBoxRequired_ClientValidate(sender, e) {
    e.IsValid = jQuery(".checkboxTyC input:checkbox").is(':checked');
}

function recaptchaCallback(response) {
    document.getElementById("checkCaptcha").value = response;
}
