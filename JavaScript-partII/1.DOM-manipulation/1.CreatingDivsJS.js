var button = document.getElementById("Check");
var wrapper = document.getElementById("wrapper");

var colorPalette = 256;
var maxWidth = screen.width - 100;
var maxHeight = screen.height - 100;
var maxStretch = 100;
var minStretch = 20;
var maxBorderWidth = 20;
var minBorderWidth = 1;
var maxBorderRadius = 100;
var minBorderRadius = 0;
var divText = "div";

button.addEventListener('click', function(){
    var amountOfDivs = parseInt(prompt("Enter the amount of divs to create", 2));
    
	for (var i = 0; i < amountOfDivs; i++) {
	    var div = createDiv();
	    wrapper.appendChild(div);
	};
},false)

function createDiv(){
    var div = document.createElement("div");
    div.innerHTML = "<strong>" + divText + "</strong>";
    div.innerText = div.innerHTML;

	div.style.position = "absolute";
	var xPosition = parseInt(Math.random() * (maxWidth - 100));
	div.style.left = xPosition + "px";
	var yPosition = parseInt(Math.random() * (maxHeight - 100));
	div.style.top = yPosition + "px";
	
	div.style.backgroundColor = generateRandomColor();
	div.style.color = generateRandomColor();

	div.style.height = generateRandomFromTo(minStretch, maxStretch);
	div.style.width = generateRandomFromTo(minStretch, maxStretch);

	div.style.border = generateRandomBorderOutline();
	div.style.borderWidth = generateRandomFromTo(minBorderWidth, maxBorderWidth) + "px";
	div.style.borderColor = generateRandomColor();
	div.style.borderRadius = generateRandomFromTo(minBorderRadius, maxBorderRadius) +"px";
	return div;
}

function generateRandomColor() {
	var red = (Math.random() * colorPalette) | 0;
	var green = (Math.random() * colorPalette) | 0;
	var blue = (Math.random() * colorPalette) | 0;

	return "rgb(" + red + "," + green + "," + blue + ")";
}

function generateRandomFromTo(min, max) {
    if (min > max) {
        max = min;
    }
    return ((Math.random() * max) | 0) + min;
}

function generateRandomBorderOutline() {
    switch ((Math.random() * 5) | 0) {
        case 0:
            return "solid";
            break;
        case 1:
            return "ridge";
            break;
        case 2:
            return "dotted";
            break;
        case 3:
            return "dashed";
            break;
        case 4:
            return "double";
            break;
        case 5:
            return "groove";
            break;
        default:
            return "none";
            break;
    }
}