// javascript for kiosk page

window.onload = function () {
    // gets student kiosk box
    var students = document.getElementsByClassName("box");

    for (var i = 0; i < students.length; i++) {
        students[i].onclick = function () {
            // gets signin/signout modal
            var signin = document.getElementById('in');
            var signout = document.getElementById('out');

            // gets signin/ signout close buttons
            var inSpan = document.getElementsByClassName("close")[0];
            var outSpan = document.getElementsByClassName("close")[1];

            // gets the photo element of the student box
            var photo = this.firstElementChild;

            // sets opacity of photo and displays correct signin/signout message
            if (photo.style.opacity == 0.5) {
                photo.style.opacity = 1;
                signout.style.display = "block";
            } else {
                photo.style.opacity = 0.5;
                signin.style.display = "block";
            }

            // closes when user clicks the signin or signout 'x'
            inSpan.onclick = function () {
                signin.style.display = "none";
            }

            outSpan.onclick = function () {
                signout.style.display = "none";
            }



            // closes modal if user clicks anywhere outside of modal
            window.onclick = function (event) {
                if (event.target == signin) {
                    signin.style.display = "none";
                } else if (event.target == signout) {
                    signout.style.display = "none";
                }
            }
        } 
    }
};


