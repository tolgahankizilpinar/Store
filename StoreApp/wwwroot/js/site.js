
document.addEventListener("DOMContentLoaded", function() {
    var btn = document.getElementById("btnScrollToTop");

   
    window.addEventListener("scroll", function() {
        if (window.scrollY > 100) {
            btn.style.display = "block";
        } else {
            btn.style.display = "none";
        }
    });


    btn.addEventListener("click", function() {
        window.scrollTo({
            top: 0,
            behavior: "smooth"
        });
    });
});
