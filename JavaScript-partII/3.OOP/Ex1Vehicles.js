var SLOWDOWNGAMESPEED = 50;

var timeOutAccel = setInterval(AccelerateVehicle, 100);
var timeOutDeAccel = setInterval(DeAccelerateVehicle, 100);

var SpeedOMeter = document.getElementById("SPEEDMETER");
var editButton = document.getElementById("editVehicle");
var accelerateButton = document.getElementById("accelerate");
var deaccelerateButton = document.getElementById("deaccelerate");
var specialFunctionButton = document.getElementById("Special");

var customVehicle = new vehicle(parseInt(parseNumber(-2, "Enter the max speed of the vehicle")), parsePropulsion("none"));

//Buttons
editButton.addEventListener('click', function () {
    customVehicle = new vehicle(parseInt(parseNumber(-2, "Enter the max speed of the vehicle")), parsePropulsion("none"));
}, false)

accelerateButton.addEventListener('click', function () {
    customVehicle.AllowAcceleration();
}, false)

deaccelerateButton.addEventListener('click', function () {
    customVehicle.DisAllowAcceleration();
}, false)

specialFunctionButton.addEventListener('click', function () {
    customVehicle.engine.propulsionSystem.ActivateSpecial();
}, false)
//Buttons

function vehicle(maxSpeed, propulsion) {
    var allowedAcceleration = false;
    var maxSpeed = maxSpeed;
    var currentSpeed = 0;
    this.engine = new propulsionUnit(propulsion);

    this.CurrentSpeed = function () {
        return currentSpeed;
    }

    this.accelerate = function () {
        if (allowedAcceleration) {
            if (!(currentSpeed >= maxSpeed)) {
                currentSpeed += this.engine.propulsionSystem.acceleration / SLOWDOWNGAMESPEED;
            }
            else {
                currentSpeed = maxSpeed;
            }
        }
    }

    this.deAccelerate = function () {
        if (!allowedAcceleration && currentSpeed > maxSpeed / 4 * -1) {
            currentSpeed -= this.engine.propulsionSystem.acceleration * 2 / SLOWDOWNGAMESPEED;
        }
    }

    this.AllowAcceleration = function () {
        allowedAcceleration = true;
    }

    this.DisAllowAcceleration = function () {
        allowedAcceleration = false;
    }
}

function propulsionUnit(propulsion) {
    this.propulsionSystem = new landVehicle(0);

    if (propulsion === "land") {
        this.propulsionSystem = new landVehicle(parseFloat(parseNumber(-2,"Input radius for the wheels")), propulsion);
    }
    else if (propulsion === "air") {
        this.propulsionSystem = new airVehicle(parseInt(parseNumber(-2, "Input nozzle's power")), propulsion);
    }
    else if (propulsion === "water") {
        this.propulsionSystem = new waterVehicle(parseFloat(parseNumber(-2, "Input amount of propellers")), propulsion);
    }
    else if (propulsion === "amphibious") {
        this.propulsionSystem = new amphibiousVehicle(parseFloat(parseNumber(-2,"Input amount of propellers")),
            parseFloat(parseNumber(-2, "Input radius for the wheels")),
            propulsion);
    }
}

function propelingSystem(acceleration, propulsionType) {
    this.acceleration = acceleration;

    var accelerationSaved = acceleration; // For Reset

    var specialActive = false;
    this.ActivateSpecial = function () {
        specialActive = !specialActive;
        if (propulsionType == "air") {
            if (specialActive) {
                this.acceleration *= 2;
            }
            else {
                this.acceleration = accelerationSaved;
            }
        }
        else if (propulsionType == "water") {
            if (specialActive) {
                this.acceleration *= 1;
            }
            else {
                this.acceleration *= -1;
            }
        }
        else if (propulsionType == "amphibious") {
            this.AmphibSpecialButton.style.display = "none";
            if (specialActive) {
                this.acceleration = this.radius;
                this.AmphibSpecialButton.textContent = "NO special Action";
            }
            else {
                this.acceleration = this.fins;
                this.AmphibSpecialButton.textContent = "Change fin spinning rotation";
                this.AmphibSpecialButton.addEventListener('click', function () {
                    customVehicle.engine.propulsionSystem.acceleration *= -1;
                }, false)
                this.AmphibSpecialButton.style.display = "inline-block";
            }
        }
    }
}

function landVehicle(radius, system) {
    specialFunctionButton.textContent = "NO special Action";
    propelingSystem.call(this, 2 * Math.PI * radius, system);
}

function airVehicle(power, system) {
    specialFunctionButton.textContent = "Turn ON/Off afterburners";
    propelingSystem.call(this, power, system);
}

function waterVehicle(finsAmount, system) {
    specialFunctionButton.textContent = "Change fin spinning rotation ( 2x click to confirm";
    propelingSystem.call(this, finsAmount, system);
}

function amphibiousVehicle(finsAmount, radius, system) {
    specialFunctionButton.textContent = "Change to Land or Water mode";

    this.AmphibSpecialButton = document.createElement("button");
    var wrapper = document.getElementById("wrapper");
    wrapper.appendChild(this.AmphibSpecialButton);

    propelingSystem.call(this, finsAmount, system);
    this.fins = finsAmount;
    this.radius = radius;
}

function parseNumber(number, forMessage) {
    do {
        number = prompt(forMessage + "\n" + "Enter a positive not 0 number.",5);
    } while (parseFloat(number) <= 0)
    return number;
}

function parsePropulsion(propulsion){
    do{
        propulsion = prompt("Enter a propulsion type. Valid are : Land ; Air ; Water ; Amphibious", "Land");
        propulsion = propulsion.toLowerCase();
    } while (propulsion !== "land" && propulsion !== "air" && propulsion !== "water" && propulsion !== "amphibious")
    return propulsion;
}

function AccelerateVehicle() {
    customVehicle.accelerate();
    SpeedOMeter.textContent = customVehicle.CurrentSpeed();
}

function DeAccelerateVehicle() {
    customVehicle.deAccelerate();
    SpeedOMeter.textContent = customVehicle.CurrentSpeed();
}