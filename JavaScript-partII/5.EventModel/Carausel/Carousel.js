var wrapper = document.getElementById("wrapper");

var buttonNext = document.getElementById("next");
var buttonPrevious = document.getElementById("previous");

var previousImage = document.getElementById("previousImage");
var currentImage = document.getElementById("currentImage");
var nextImage = document.getElementById("nextImage");

setSizeForDisplay(previousImage);
setSizeForDisplay(currentImage);
setSizeForDisplay(nextImage);

nextImage.style.opacity = 0.50;
previousImage.style.opacity = 0.50;

function setSizeForDisplay(imageDisplayer) {
    var widthSize = 300 + "px";
    var heightSize = 150 + "px";
    imageDisplayer.style.width = widthSize;
    imageDisplayer.style.height = heightSize;
    imageDisplayer.style.backgroundSize = widthSize + " " + heightSize;
    imageDisplayer.style.backgroundRepeat = "no-repeat";
}

var jsCarausel = new carousel();
jsCarausel.Draw();

buttonNext.addEventListener("click", function () {
    jsCarausel.Next();
    jsCarausel.Draw();
}, false);

buttonPrevious.addEventListener("click", function () {
    jsCarausel.Previous();
    jsCarausel.Draw();
}, false);

function carousel() {
    var images = document.getElementsByTagName("img");
    for (var i = 0, length = images.length; i < length; i++) {
        images[i].style.display = "none";
    }

    var currentImageID = 0;

    this.Draw = function () {
        if (currentImageID > images.length - 2) {
            previousImage.style.backgroundImage = "url(" + images[currentImageID - 1].src + ")";
            currentImage.style.backgroundImage = "url(" + images[currentImageID].src + ")";
            nextImage.style.backgroundImage = "url(" + images[0].src + ")";
        }
        else if (currentImageID < 1) {
            previousImage.style.backgroundImage = "url(" + images[images.length - 1].src + ")";
            currentImage.style.backgroundImage = "url(" + images[currentImageID].src + ")";
            nextImage.style.backgroundImage = "url(" + images[currentImageID + 1].src + ")";
        }
        else {
            previousImage.style.backgroundImage = "url(" + images[currentImageID - 1].src + ")";
            currentImage.style.backgroundImage = "url(" + images[currentImageID].src + ")";
            nextImage.style.backgroundImage = "url(" + images[currentImageID + 1].src + ")";
        }
    }

    this.Next = function () {
        currentImageID += 1;
        if (currentImageID == images.length) {
            currentImageID = 0;
        }
    }

    this.Previous = function () {
        currentImageID -= 1;
        if (currentImageID < 0) {
            currentImageID = images.length - 1;
        }
    }
}