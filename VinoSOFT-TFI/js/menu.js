//Disable the default MouseOver functionality of ASP.Net Menu control.
Sys.WebForms.Menu._elementObjectMapper.getMappedObject = function () {
    return false;
};
$(function () {
    //Remove the style attributes.
    $(".navbar-nav li, .navbar-nav a, .navbar-nav ul").removeAttr('style');

    //Apply the Bootstrap class to the SubMenu.
    $(".dropdown-menu").closest("li").removeClass().addClass("dropdown-toggle");

    //Apply the Bootstrap properties to the SubMenu.
    $(".dropdown-toggle").find("a").eq(0).attr("data-toggle", "dropdown").attr("aria-haspopup", "true").attr("aria-expanded", "false").append("<span class='caret'></span>");

    //Apply the Bootstrap "active" class to the selected Menu item.
    $("a.selected").closest("li").addClass("active");
    $("a.selected").closest(".dropdown-toggle").addClass("active");
});