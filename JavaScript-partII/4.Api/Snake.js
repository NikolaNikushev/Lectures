var canvas = document.getElementById("canvas");
var context = canvas.getContext("2d");

var gameWidthMax = 500;
var gameHeightMax = 500;

var sizeOfSquare = 10;

var travelDistance = 10;

var snake;
var food;
var keyCheck = setInterval(getKey, 100);
var Play = setInterval(Play, 100);

var score = 0;
var nickName;

var scores = [];
printScore();

//LOGIC
document.addEventListener('keypress', function (e) {
    getKey(e.charCode);
}, false);

newGame();

function newGame() {
    snake = new gameSnake();
    food = new gameFood(100, 100, "red");
    food.GenerateNew();
    score = 0;
    nickName = prompt("Enter your nickname:", "Pesho");
    context.fillRect(0, 0, 520, 520);
    snake.GoDown();
}

function getKey(code) {
    if (code == 97) { // A
        snake.GoLeft();
    }
    else if (code == 100) { // D
        snake.GoRight();
    }
    else if (code == 119) { // W
        snake.GoUp();
    }
    else if (code == 115) { // S
        snake.GoDown();
    }
    else {
        snake.RepeatLast();
    }
}

function Play() {
    if (gameInProgress()) {
        snake.Move();
        checkIfEatenFood();
        food.Draw();
    }
    else {
        localStorage.setItem(nickName, score);
        printScore();
        
        var answer = prompt("GAME OVER \nContinue? Yes / anything else", "Yes");
        if (answer.toLowerCase() === "yes") {
            newGame();
        }
        else{
            clearInterval(Play);
        }
    }
}

function printScore() {
    var storageArray = [];
    for (var i = 0; i < localStorage.length; i++) {
        storageArray.push(parseFloat(localStorage.key(i)));
    }
     storageArray = Object.keys(localStorage).sort(function (a, b) {
        return a - b;
    });

    var div = document.getElementById("winnerBoard");
    div.innerHTML = "<h1>WINNER BOARD:</h1> <br />";

    for (var j = 0; j < localStorage.length; j++) {

        var key = storageArray[j];
        var value = localStorage.getItem(key);
        div.innerHTML += key + " ->> ";
        div.innerHTML += value + "<br/>";
    }
}

function checkIfEatenFood() {
    if (snake.parts[0].xPos == food.xPos && snake.parts[0].yPos == food.yPos) {
        food.GenerateNew();
        score += 1;
        snake.IncreaseSize()
    }
}

function gameInProgress() {
    if (snake.parts[0].xPos < 10 || snake.parts[0].xPos > gameWidthMax ||
    snake.parts[0].yPos < 10 || snake.parts[0].yPos > gameHeightMax ||
    snake.interactsWithSelf()) {
        return false;
    }
    return true;
}

function shape(xPos, yPos, color) {
    this.color = color;
    if (this.color == undefined) {
        this.color = "black";
    }
    this.xPos = xPos;
    this.yPos = yPos;
    this.actions = [];
    this.currentAction = "";

    this.Move = function () {
        switch (this.currentAction) {
            case "up":
                this.yPos -= travelDistance;
                break;
            case "left":
                this.xPos -= travelDistance;
                break;
            case "down":
                this.yPos += travelDistance;
                break;
            case "right":
                this.xPos += travelDistance;
                break;
        }
        if (this.actions.length > 1) {
            for (var i = 0, length = this.actions.length - 1; i < length; i++) {
                this.actions[i] = this.actions[i + 1];
            }
            this.currentAction = this.actions[0];
        }
    }

    this.AddMove = function (direction) {
        if (this.actions.length > 1) {
            this.actions[this.actions.length - 1] = direction;
        }
        else {
            this.currentAction = direction;
        }
    }

    this.Draw = function () {
        context.fillStyle = this.color;
        context.fillRect(this.xPos, this.yPos, sizeOfSquare, sizeOfSquare);
        context.fillStyle = "black";
    }
}

function gameSnake() {
    this.parts = [];
    this.parts.push(new shape(100, 100, "green"));
    this.parts[0].actions = new Array(1);
    this.parts[0].AddMove("down");
    var lastAction = "";

    this.Move = function () {
        context.clearRect(10, 10, 500, 500);
        for (var i = 0, length = this.parts.length; i < length; i++) {
            this.parts[i].Move();
            this.parts[i].Draw();
        }
    }

    this.interactsWithSelf = function () {
        for (var i = 1, length = this.parts.length; i < length; i++) {
            if (this.parts[i].xPos == this.parts[0].xPos &&
            this.parts[i].yPos == this.parts[0].yPos) {
                return true;
            }
        }
        return false;
    }

    this.IncreaseSize = function () {
        var xLocation = travelDistance;
        var yLocation = travelDistance;
        var lastPartAction = this.parts[this.parts.length - 1].currentAction;
        if (lastPartAction == "down") {
            yLocation *= -1;
            xLocation = 0;
        }
        else if (lastPartAction == "up") {
            xLocation = 0;
        }
        if (lastPartAction == "right") {
            xLocation *= -1;
            yLocation = 0;
        }
        else if (lastPartAction == "left") {
            yLocation = 0;
        }
        this.parts.push(new shape(
        this.parts[this.parts.length - 1].xPos + xLocation,
        this.parts[this.parts.length - 1].yPos + yLocation));

        this.parts[this.parts.length - 1].actions = new Array(this.parts.length);
        this.parts[this.parts.length - 1].AddMove(this.parts[this.parts.length - 2].currentAction);
        for (var i = 0, length = this.parts.length - 1; i < length; i++) {
            this.parts[this.parts.length - 1].Move();
        }
    }

    this.RepeatLast = function () {
        for (var i = 0, length = this.parts.length; i < length; i++) {
            this.parts[i].AddMove(lastAction);
        }
    }

    this.GoUp = function () {
        for (var i = 0, length = this.parts.length; i < length; i++) {
            this.parts[i].AddMove("up");
        }
        lastAction = "up";
    }
    this.GoLeft = function () {
        for (var i = 0, length = this.parts.length; i < length; i++) {
            this.parts[i].AddMove("left");
        }
        lastAction = "left";
    }
    this.GoRight = function () {
        for (var i = 0, length = this.parts.length; i < length; i++) {
            this.parts[i].AddMove("right");
        }
        lastAction = "right";
    }
    this.GoDown = function () {
        for (var i = 0, length = this.parts.length; i < length; i++) {
            this.parts[i].AddMove("down");
        }
        lastAction = "down";
    }
}

function gameFood(xPos, yPos, color) {
    shape.call(this, xPos, yPos, color);

    this.GenerateNew = function () {
        this.xPos = parseInt(Math.random() * (gameWidthMax - 10) / 10) + 1;
        this.yPos = parseInt(Math.random() * (gameHeightMax - 10) / 10) + 1;
        this.xPos *= 10;
        this.yPos *= 10;
    }
}

//Small bug -> New parts do not " MOVE " to the required position... // 179 - 189 lines
// Sometimes it works sometimes it doesnt work properly