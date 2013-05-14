function position(x, y){
    this.x = x;
    this.y = y;
}

var centerX = screen.width / 2;
var radius = 200;

var centerY = radius ;

var move = true;
var circles = document.getElementsByClassName("Circle");
var timer = setInterval(moveDivs, 50);

var positions = [];

positions.push(new position(centerX, centerY - radius));

positions.push(new position(centerX + (radius / 2), centerY - ((5 / 6) * radius)));

positions.push(new position(centerX + ((5 / 6) * radius), centerY - (radius / 2)));

positions.push(new position(centerX + radius, centerY));

positions.push(new position(centerX + ((5 / 6) * radius), centerY + (radius / 2)))

positions.push(new position(centerX + (radius / 2), centerY + ((5 / 6) * radius)));

positions.push(new position(centerX, centerY + radius));

positions.push(new position(centerX - (radius / 2), centerY + ((5 / 6) * radius)));

positions.push(new position(centerX - ((5 / 6) * radius), centerY + (radius / 2)));

positions.push(new position(centerX - radius, centerY));

positions.push(new position(centerX - ((5 / 6) * radius), centerY - (radius / 2)));

positions.push(new position(centerX - (radius / 2), centerY - ((5 / 6) * radius)));

for (var i = 0; i < circles.length; i++) {
    circles[i].style.border = "solid";
    circles[i].style.borderWidth = 5 + "px";
    circles[i].style.borderRadius = 100 + "px";
    circles[i].style.position = "absolute";
    circles[i].style.width = 50 + "px";
    circles[i].style.height = 50 + "px";
};
var currentPosition = 0;
function moveDivs() {
    currentPosition += 1;
    if (currentPosition > positions.length) {
        currentPosition = 0;
    }

    for (var i = 0; i < circles.length; i += 1) {
        var newPosition = currentPosition + i;
        if (newPosition >= positions.length) {
            newPosition = 0 + (newPosition - positions.length);
        }
        console.log(newPosition);
        circles[i].style.top = positions[newPosition].y + "px";
        circles[i].style.left = positions[newPosition].x + "px";
    }
}
