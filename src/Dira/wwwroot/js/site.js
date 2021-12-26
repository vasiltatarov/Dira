// mouse hover effect on cards

let cards = document.getElementsByClassName("card");

for (var i = 0; i < cards.length; i++) {
    cards[i].addEventListener("mouseover", function (event) {
        // highlight the mouseover target
        var parent = event.target.parentNode;

        if (parent.classList.contains('card-body')) {
            parent = parent.parentNode;
        }

        parent.style.backgroundColor = "lightgray";
    }, false);

    cards[i].addEventListener("mouseout", function (event) {
        // highlight the mouseout target
        var parent = event.target.parentNode;
        parent.style.backgroundColor = "";
    }, false);
}