function ball(x, y, radius) {
    this.x = x;
    this.y = y;
    this.radius = radius;
    this.relocate = function move(newX, newY) {
        this.x += newX;
        this.y += newY;
    }
}

var startX = 200;
var startY = 100;
var speed = 20;
var speedX = speed;
var speedY = speed;
var radius = 10;
var refreshSpeed = 30;

var ball = new ball(startX + 5, startY, radius)

var canvas = document.getElementById("canvas");
var context = canvas.getContext("2d");

var maxX = context.canvas.width;
var maxY = context.canvas.height;

var interval = setInterval(function () { draw() }, refreshSpeed);
context.fillRect(0, 0, 900, 900);
function draw() {
    if (ball.x + ball.radius > maxX - ball.radius || ball.x - ball.radius < ball.radius) {
        speedX *= -1;
    }

    if (ball.y + ball.radius > maxY - ball.radius || ball.y - ball.radius < ball.radius) {
        speedY *= -1;
    }
    context.clearRect(5, 5, maxX - 10, maxY - 10);
    ball.relocate(speedX, speedY);

    context.beginPath();
    context.arc(ball.x, ball.y, ball.radius, 0, 2 * Math.PI, false);
    context.stroke();
}