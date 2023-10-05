// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('#carouselExampleIndicators').carousel();
});


$(document).ready(function () {
    $('#myCarousel').carousel();

    // Next düğmesi için
    $('.carousel-control-next').click(function () {
        $('#myCarousel').carousel('next');
    });

    // Previous düğmesi için
    $('.carousel-control-prev').click(function () {
        $('#myCarousel').carousel('prev');
    });
});