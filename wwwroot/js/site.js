// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.addEventListener("DOMContentLoaded", function() {
    var regionDiv = document.getElementById("region");
    if (regionDiv.innerHTML === "East" || regionDiv.innerHTML === "West") {
        var modal = document.getElementById("myModal");
        var closeButton = document.getElementsByClassName("sup-analysis-close")[0];
        modal.style.display = "block";
        closeButton.onclick = function() {
            modal.style.display = "none";
        }
        window.onclick = function(event) {
            if (event.target == modal) {
                modal.style.display = "none";
            }
        }
    }
});
