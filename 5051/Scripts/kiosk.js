// javascript for kiosk page

window.onload = function () {
    var opacity = 0.4;

    // gets student kiosk box
    var students = document.getElementsByClassName("student");

    for (var i = 0; i < students.length; i++) {
        students[i].firstElementChild.style.opacity = opacity;

        students[i].onclick = function () {
            // sets opacity of photo and displays correct signin/signout message
            if (this.firstElementChild.style.opacity == opacity) {
                this.firstElementChild.style.opacity = 1;
            } else {
                this.firstElementChild.style.opacity = opacity;
            }
        } 
    }
    
};


