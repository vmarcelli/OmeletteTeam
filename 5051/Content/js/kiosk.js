window.onload = function () {
    var daniel = document.getElementById("daniel");

    daniel.onclick = function () {
        // Get the modal
        var signin = document.getElementById('in');
        var signout = document.getElementById('out');
        var inSpan = document.getElementsByClassName("close")[0];
        var outSpan = document.getElementsByClassName("close")[1];

        if (this.style.opacity == 0.5) {
            this.style.opacity = 1;   
            signout.style.display = "block";
        } else {
            this.style.opacity = 0.5;
            signin.style.display = "block";
        }   

        // When the user clicks on <span> (x), close the modal
        inSpan.onclick = function () {
            signin.style.display = "none";
        }

        // When the user clicks on <span> (x), close the modal
        outSpan.onclick = function () {
            signout.style.display = "none";
        }



        // When the user clicks anywhere outside of the modal, close it
        window.onclick = function (event) {
            if (event.target == signin) {
                signin.style.display = "none";
            } else if (event.target == signout) {
                signout.style.display = "none";
            }
        }

    } 
};


