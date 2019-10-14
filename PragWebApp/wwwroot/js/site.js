// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function setActive(element) {
    $(".menu-button > span.menu-button").removeClass("menu-button-selected");
    $(element).children("span.menu-button").addClass("menu-button-selected");
} 