//Thanks : http://stackoverflow.com/questions/2172798/how-to-draw-an-oval-in-html5-canvas
function drawEllipseByCenter(ctx, cx, cy, w, h, bgColor, borderColor) {
    drawEllipse(ctx, cx - w / 2.0, cy - h / 2.0, w, h, bgColor, borderColor);
}

function drawEllipse(ctx, x, y, w, h, bgColor, borderColor) {
    var kappa = .5522848,
    ox = (w / 2) * kappa, // control point offset horizontal
    oy = (h / 2) * kappa, // control point offset vertical
    xe = x + w, // x-end
    ye = y + h, // y-end
    xm = x + w / 2, // x-middle
    ym = y + h / 2; // y-middle

    ctx.beginPath();
    ctx.moveTo(x, ym);
    ctx.bezierCurveTo(x, ym - oy, xm - ox, y, xm, y);
    ctx.bezierCurveTo(xm + ox, y, xe, ym - oy, xe, ym);
    ctx.bezierCurveTo(xe, ym + oy, xm + ox, ye, xm, ye);
    ctx.bezierCurveTo(xm - ox, ye, x, ym + oy, x, ym);
    ctx.fillStyle = bgColor;
    ctx.fill();
    ctx.closePath();
    ctx.strokeStyle = borderColor;
    ctx.lineWidth = 2;
    ctx.stroke();
}
//End Thanks

var houseContext = document.getElementById("house").getContext("2d");

//Roof
houseContext.beginPath();
houseContext.moveTo(100, 150);
houseContext.lineTo(398, 146);
houseContext.lineTo(250, 10);
houseContext.lineTo(98, 150);
houseContext.fillStyle = "black";
houseContext.lineWidth = 5;
houseContext.stroke();
houseContext.fillStyle = "brown";
houseContext.fill();
houseContext.closePath();

//HouseBlock
houseContext.fillStyle = "black";
houseContext.fillRect(97, 147, 306, 306);
houseContext.fillStyle = "brown";
houseContext.fillRect(100, 150, 300, 300);

//Windows
var window1 = new houseWindow(120, 170, 120, 100);
window1.Draw();
var window2 = new houseWindow(260, 170, 120, 100);
window2.Draw();
var window2 = new houseWindow(260, 310, 120, 100);
window2.Draw();

//Door
var door = new houseDoor(120, 450);
door.Draw();

//Chimney
var chimney = new houseChimney(310, 20)
chimney.Draw();

function houseWindow(x, y, sizeX, sizeY) {
    this.Draw = function () {
        houseContext.fillStyle = "black";
        houseContext.fillRect(x, y, sizeX, sizeY);
        //Frame
        houseContext.fillStyle = "brown";
        houseContext.fillRect(x + sizeX / 2, y, 4, sizeY);
        houseContext.fillRect(x, y + sizeY / 2, sizeX, 4);
    }
}

function houseDoor(x, y) {
    this.Draw = function () {
        houseContext.beginPath();
        //Frame
        houseContext.moveTo(x, y);
        houseContext.lineTo(x, y - 100);
        houseContext.arcTo(x, 0, x + 100, y - 100, 50);
        houseContext.lineTo(x + 100, y);
        houseContext.lineWidth = 3;
        houseContext.stroke();
        houseContext.closePath();

        houseContext.beginPath();
        houseContext.moveTo(x + 50, y - 143);
        houseContext.lineTo(x + 50, y);
        houseContext.stroke();
        houseContext.closePath();
        //Handles
        houseContext.beginPath();
        houseContext.arc(x + 40, y - 50, 5, 0, 2 * Math.PI);
        houseContext.stroke();
        houseContext.closePath();
        houseContext.beginPath();
        houseContext.arc(x + 60, y - 50, 5, 0, 2 * Math.PI);
        houseContext.stroke();
        houseContext.closePath();
    }
}

function houseChimney(x, y) {
    this.Draw = function () {
        houseContext.lineWidth = 3;
        houseContext.fillStyle = "brown";
        houseContext.fillRect(x, y, 40, 100);

        //Outline
        houseContext.fillStyle = "black";
        houseContext.beginPath();
        houseContext.moveTo(x, y + 100);
        houseContext.lineTo(x, y);
        houseContext.stroke();
        houseContext.closePath();

        //Outline
        houseContext.beginPath();
        houseContext.moveTo(x + 40, y + 100);
        houseContext.lineTo(x + 40, y);
        houseContext.stroke();
        houseContext.closePath();

        //Outline
        houseContext.beginPath();
        houseContext.moveTo(x, y);
        drawEllipseByCenter(houseContext, x + 20, y, 40, 10, "brown", "black");
        houseContext.stroke();
        houseContext.closePath();
    }
}

var bikeContext = document.getElementById("bike").getContext("2d");
bikeContext.scale(2, 2);

var wheel1 = new bikeWheel(100, 200, 20);
wheel1.Draw();

var wheel2 = new bikeWheel(200, 200, 20);
wheel2.Draw();

bikeContext.lineWidth = 2;
bikeContext.beginPath();
bikeContext.strokeStyle = "blue";
//Upper part of triangle
bikeContext.moveTo(140, 150);
bikeContext.lineTo(170, 110);

//lower part of Triangle
bikeContext.moveTo(140, 150);
bikeContext.lineTo(180, 150);
bikeContext.lineTo(165, 90); // BikeSeat LongPart

//Bike Seat
bikeContext.moveTo(150, 90);
bikeContext.lineTo(180, 90);

//FrontTriangle
bikeContext.moveTo(180, 150);
bikeContext.lineTo(235, 120);
bikeContext.lineTo(170, 110);

//Bike control part ( FRONT PART )
bikeContext.moveTo(240, 150);
bikeContext.lineTo(225, 90);
bikeContext.lineTo(200, 100);
bikeContext.moveTo(225, 90);
bikeContext.lineTo(245, 70);

bikeContext.stroke();
bikeContext.closePath();
//Pedals part
bikeContext.beginPath();
bikeContext.arc(180, 150, 10, 0, 2 * Math.PI);

bikeContext.moveTo(187, 157);
bikeContext.lineTo(193, 163);

bikeContext.moveTo(173, 143);
bikeContext.lineTo(167, 137);
bikeContext.stroke();
bikeContext.closePath();
//MOST EPIC BIKE EVER :D:D:D

function bikeWheel(x, y, size) {
    this.Draw = function () {
        bikeContext.beginPath();
        bikeContext.arc(x + 40, y - 50, size, 0, 2 * Math.PI);
        bikeContext.strokeStyle = "darkBlue";
        bikeContext.stroke();
        bikeContext.fillStyle = "lightBlue";
        bikeContext.fill();
        bikeContext.closePath();
    }
}

var headContext = document.getElementById("head").getContext("2d");
headContext.scale(2, 2);
//Head
headContext.beginPath();
headContext.arc(100, 200, 40, 0, 2 * Math.PI);
headContext.strokeStyle = "darkBlue";
headContext.stroke();
headContext.fillStyle = "lightBlue";
headContext.fill();
headContext.closePath();
headContext.rotate(0.2);
//Mouth
headContext.beginPath();
drawEllipseByCenter(headContext, 135, 200, 35, 10, "lightBlue", "darkBlue");
headContext.closePath();
headContext.rotate(-0.2);
//Eyes
//Left
drawEllipseByCenter(headContext, 83, 190, 15, 12, "lightBlue", "darkBlue");
drawEllipseByCenter(headContext, 80, 190, 3, 7, "darkBlue", "darkBlue");
//Right
drawEllipseByCenter(headContext, 110, 190, 15, 12, "lightBlue", "darkBlue");
drawEllipseByCenter(headContext, 107, 190, 3, 7, "darkBlue", "darkBlue");
//Nose
headContext.beginPath();
headContext.moveTo(95, 190);
headContext.lineTo(90, 210);
headContext.lineTo(100, 210);
headContext.stroke();
headContext.closePath();
//Hat
headContext.fillStyle = "blue";
headContext.strokeStyle = "black";
drawEllipseByCenter(headContext, 100, 165, 90, 15, "blue", "black");
drawEllipseByCenter(headContext, 100, 158, 50, 15, "blue", "black");
headContext.fillStyle = "black";
headContext.fillRect(74, 160, 53, -63);
headContext.fillStyle = "blue";
headContext.fillRect(77, 160, 47, -60);
drawEllipseByCenter(headContext, 101, 98, 53, 15, "blue", "black");