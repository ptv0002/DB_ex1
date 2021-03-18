/*!
    * Start Bootstrap - SB Admin v6.0.2 (https://startbootstrap.com/template/sb-admin)
    * Copyright 2013-2020 Start Bootstrap
    * Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-sb-admin/blob/master/LICENSE)
    */
(function ($) {
    "use strict";

    // Add active state to sidbar nav links
    var path = window.location.href; // because the 'href' property of the DOM element is the absolute path
    $("#layoutSidenav_nav .sb-sidenav a.nav-link").each(function () {
        if (this.href === path) {
            $(this).addClass("active");
        }
    });

    // Toggle the side navigation
    $("#sidebarToggle").on("click", function (e) {
        e.preventDefault();
        $("body").toggleClass("sb-sidenav-toggled");
    });

    //// Set up pagination for tables
    //var items = $("table tbody tr")
    //var numItems = items.length;
    //var perPage = $("#perPage").select;
    //// Only show the first 2 (or first `per_page`) items initially.
    //items.slice(perPage).hide();

    //// Now setup the pagination using the `.pagination-page` div.
    //$(".pagination").pagination({
    //    items: numItems,
    //    itemsOnPage: perPage,
        
    //    // This is the actual page changing functionality.
    //    onPageClick: function (pageNumber) {
    //        // We need to show and hide `tr`s appropriately.
    //        var showFrom = perPage * (pageNumber - 1);
    //        var showTo = showFrom + perPage;

    //        // We'll first hide everything...
    //        items.hide()
    //            // ... and then only show the appropriate rows.
    //            .slice(showFrom, showTo).show();
    //    }
    //});
})(jQuery);
