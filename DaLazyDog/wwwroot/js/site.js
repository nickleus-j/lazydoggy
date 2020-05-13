// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function replaceAllSubstring (oldText, substringToReplace, replacement) {
    if (replacement === void 0) { replacement = ""; }
    if (oldText.indexOf(substringToReplace) >= 0) {
        return replaceAllSubstring(oldText.replace(substringToReplace, replacement), substringToReplace, replacement);
    }
    return oldText;
}