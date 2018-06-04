// javascript for kiosk page

window.onload = function () {
    // initial image opacity
    var opacity = 0.4;

    // gets student elements in an array
    var students = document.getElementsByClassName("student");

    // sets student image opacity as 'opacity' to start, then adds sign in/ out click function
    for (var i = 0; i < students.length; i++) {
        students[i].firstElementChild.style.opacity = opacity;

        students[i].onclick = function () {
            // alternates brighten/ darken on click of student box
            if (this.firstElementChild.style.opacity == opacity) {
                this.firstElementChild.style.opacity = 1;
            } else {
                this.firstElementChild.style.opacity = opacity;
            }
        } 
    }
    
};


