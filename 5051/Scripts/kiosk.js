// javascript for kiosk page

window.onload = function () {
    // initial image opacity
    var opacity = 0.4;

    var greetingNode = 1;
    var farewellNode = 3;
    var imgNode = 5;


    // gets student elements in an array
    var students = document.getElementsByClassName("student");

    // sets student image opacity as 'opacity' to start, then adds sign in/ out click function
    for (var i = 0; i < students.length; i++) {
        students[i].childNodes[imgNode].style.opacity = opacity;

        students[i].onclick = function () {
            // alternates brighten/ darken on click of student box
            if (this.childNodes[imgNode].style.opacity == opacity) {
                this.childNodes[imgNode].style.opacity = 1;
                showGreeting(this);
            } else {
                this.childNodes[imgNode].style.opacity = opacity;
                showFarewell(this);
            }
        } 
    }

    // displays greeting when student signs in
    function showGreeting(student) {
        student.childNodes[farewellNode].style.display = "none";
        student.childNodes[greetingNode].style.display = "block";

        setTimeout(
            function () {
                student.childNodes[greetingNode].style.display = "none";
            }, 3200);
    };

    // displays farwell when student signs out
    function showFarewell(student) {
        student.childNodes[greetingNode].style.display = "none";
        student.childNodes[farewellNode].style.display = "block";

        setTimeout(
            function () {
                student.childNodes[farewellNode].style.display = "none";
            }, 1300);
    };
    
};

// badge earn animation
$(document).ready(function () {
    $(".student").click(function () {
        var clicks = $(this).data('clicks');

        if (clicks) {
            // do nothing
        } else {
            $(".badge-earn", this).animate({
                opacity: '1',
                'margin-top': '0px'
            }).delay(2000).animate({
                opacity: '0',
                'margin-top': '30px'
            });
        }
        $(this).data("clicks", !clicks);    
    });
});

