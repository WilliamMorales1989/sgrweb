/// <autosync enabled="true" />
/// <reference path="modernizr-2.6.2.js" />
/// <reference path="jquery-1.10.2.js" />
/// <reference path="bootstrap.js" />
/// <reference path="respond.js" />
/// <reference path="jquery.validate.js" />
/// <reference path="jquery.validate.unobtrusive.js" />
/// <reference path="gridmvc.js" />
/// <reference path="gridmvc.lang.ru.js" />

$(document).keypress(function (e) {
    var usuario = $('usuario').val();
    if (e.which == 13) {
        alert(usuario);
    }
});