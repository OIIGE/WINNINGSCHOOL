setTimeout(function () {
    $('.alert').alert('close');
}, 5000);


    // Automatically advance the carousel every 3 seconds
    $(document).ready(function () {
        $('#imageCarousel').carousel({
            interval: 3000 // Set the interval in milliseconds (adjust as needed)
        });
    });

