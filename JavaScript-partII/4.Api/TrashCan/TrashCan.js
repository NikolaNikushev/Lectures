//Exercise 3, polyfill  the localStorage and sessionStorage
//Thanks to https://github.com/inexorabletash/polyfill/
window.onload = CheckStorageCompabity;

function CheckStorageCompabity () {

	if (!window.localStorage || !window.sessionStorage) (function() {
	

	    var Storage = function(type) {
	        function createCookie(name, value, days) {
	            var date, expires;


	            if (days) {
	                date = new Date();
	                date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
	                expires = "; expires=" + date.toGMTString();
	            } else {
	                expires = "";
	            }
	            document.cookie = name + "=" + value + expires + "; path=/";
	        }


	        function readCookie(name) {
	            var nameEQ = name + "=",
	                ca = document.cookie.split(';'),
	                i, c;


	            for (i = 0; i < ca.length; i++) {
	                c = ca[i];
	                while (c.charAt(0) == ' ') {
	                    c = c.substring(1, c.length);
	                }


	                if (c.indexOf(nameEQ) == 0) {
	                    return c.substring(nameEQ.length, c.length);
	                }
	            }
	            return null;
	        }


	        function setData(data) {
	            data = JSON.stringify(data);
	            if (type == 'session') {
	                window.name = data;
	            } else {
	                createCookie('localStorage', data, 365);
	            }
	        }


	        function clearData() {
	            if (type == 'session') {
	                window.name = '';
	            } else {
	                createCookie('localStorage', '', 365);
	            }
	        }


	        function getData() {
	            var data = type == 'session' ? window.name : readCookie('localStorage');
	            return data ? JSON.parse(data) : {};
	        }




	        // initialise if there's already data
	        var data = getData();


	        function numKeys() {
	            var n = 0;
	            for (var k in data) {
	                if (data.hasOwnProperty(k)) {
	                    n += 1;
	                }
	            }
	            return n;
	        }


	        return {
	            clear: function() {
	                data = {};
	                clearData();
	                this.length = numKeys();
	            },
	            getItem: function(key) {
	                key = encodeURIComponent(key);
	                return data[key] === undefined ? null : data[key];
	            },
	            key: function(i) {
	                // not perfect, but works
	                var ctr = 0;
	                for (var k in data) {
	                    if (ctr == i) return decodeURIComponent(k);
	                    else ctr++;
	                }
	                return null;
	            },
	            removeItem: function(key) {
	                key = encodeURIComponent(key);
	                delete data[key];
	                setData(data);
	                this.length = numKeys();
	            },
	            setItem: function(key, value) {
	                key = encodeURIComponent(key);
	                data[key] = String(value);
	                setData(data);
	                this.length = numKeys();
	            },
	            length: 0
	        };
	    };
	if (!window.localStorage) window.localStorage = new Storage('local');
	if (!window.sessionStorage) window.sessionStorage = new Storage('session');	

})();
}

//Exercise 1, create the trash can, the objects to drag and make the functions of the drag effect
//The effect of the opened and closed trash can and the balls removing and adding

window.onload = GenerateBalls(15);

function GenerateBalls (ammount) {
	for (var ball = 0; ball < ammount; ball++) {

		var ballSpawnPoint = document.getElementById("Balls");

		var balls = document.createElement("img");
		balls.setAttribute("id", "Ball"+(ball+1));
		balls.setAttribute("src","CottonBall.png");
		balls.setAttribute("draggable" ,"true");
		balls.setAttribute("ondragstart","drag(event)");

		balls.style.position = "absolute";
		balls.style.left = 15 + GenerateRandomPosition(200);
		balls.style.top = GenerateRandomPosition(400)

		ballSpawnPoint.appendChild(balls)
	};
	
	theTime = window.setInterval("CountTime()",1000);
}

var checkTimer = window.setInterval("CheckBallsCount()",1000);

function CheckBallsCount(){
	var balls = document.getElementById("Balls").childNodes.length;
	if (balls <= 0){
		clearInterval(checkTimer);
		clearInterval(theTime);
		saveScore();
	};

}

function removeBall(id) {
    var elem = document.getElementById(id);
    elem.parentNode.removeChild(elem);
    return false;
}

function GenerateRandomPosition (max) {
		return Math.random()*max;
}

function allowDrop(ev){
	var closed = document.getElementById("TrashClosed");
	closed.style.display = "none";
	var opened = document.getElementById("TrashOpened");
	opened.style.display = "block";
	ev.preventDefault();
}

function noDrop(ev){
	var closed = document.getElementById("TrashClosed");
	closed.style.display = "block";
	var opened = document.getElementById("TrashOpened");
	opened.style.display = "none";
	ev.preventDefault();
}

function drag (ev) {
	ev.dataTransfer.setData("Text",ev.target.id);
}

function drop(ev){
	ev.preventDefault();
	var data=ev.dataTransfer.getData("Text");
	removeBall(data);
	var opened = document.getElementById("TrashClosed");
	opened.style.display = "block";
	var closed = document.getElementById("TrashOpened");
	closed.style.display = "none";
}

//Exercise 2, to make a score using the time spent on removing the balls.

var counterTimer = 0;
function CountTime() {
		counterTimer += 1;
		GetTimerTime(counterTimer);
}

function GetTimerTime (time) {
	var minutes = parseInt(time / 60);
	var timer = document.getElementById("Timer");
	timer.innerHTML = "Time: " + minutes +":"+ time % 60;
}

function saveScore(){
	var name = prompt("Enter your name!");
  	localStorage.setItem(counterTimer, name);
 	printScore();
}

function printScore() {
 	var storageArray = [];
    for (var i = 0; i < localStorage.length; i++) {
        storageArray.push(parseFloat(localStorage.key(i)));
    }
     storageArray = Object.keys(localStorage).sort(function (a, b) {
        return a - b;
    });

    var div = document.getElementById("resultContainer");
    div.innerHTML = "";

    for (var j = 0; j < 5; j++) {

        var key = storageArray[j];
        var value = localStorage.getItem(key);
        if (key > 0 ){
        	 div.innerHTML += parseInt(key/60) + ":"+ key%60 + " - ";
       		 div.innerHTML += value + "<br/>";
        }
	}
}


