var wrapper = document.getElementById("wrapper");
var seperateTags = [];
var tagsCounter =[];

Input();

function Input() {
    var tags = ["cms", "javascript", "js", "ASP.NET MVC", ".net", ".net", "css",
    "wordpress", "xaml", "js", "http", "web", "asp.net", "asp.net MVC",
    "ASP.NET MVC", "wp", "javascript", "js", "cms", "html", "javascript",
    "http", "http", "CMS"];
    var addTags = true;
    while (addTags) {
        addTags = addNewTag(tags);
    }
    var minFontSize = parseInt(prompt("Enter minimum size in Pixels", 5));
    var maxFontSize = parseInt(prompt("Enter minimum size in Pixels", 20));
    var tagCloud = generateTagCloud(tags, minFontSize, maxFontSize);
}

function addNewTag(tags) {
    var input = prompt("Enter \"EndInput\" to stop adding tags to the cloud" +
        "\nYou can enter multiple tags, seperated by a \",\"", "css");
    var inputedTags = input.split(',');
    for (var i = 0, length = inputedTags.length; i < length; i++) {
        if (inputedTags[i].toLowerCase() == "endinput") {
            return false;
        }
        else {
            inputedTags[i] = inputedTags[i].trim();
            tags.push(inputedTags[i]);
        }
    }
    return true;
}

function generateTagCloud(tags, minSize, maxSize) {
    getOccurance(tags);
    displayTagCloud(minSize, maxSize);
}

function getOccurance(tags) {
    var counter = 0;
    for (var i = 0, length = tags.length; i < length; i++) {
        if (seperateTags.indexOf(tags[i]) != -1) {
            tagsCounter[seperateTags.indexOf(tags[i])] += 1;
        }
        else{
            seperateTags.push(tags[i]);
            tagsCounter.push(1);
        }
    }
}

function displayTagCloud(minSize, maxSize) {
    var div = document.createElement("div");
    var individualCounters = getCounters(tagsCounter);

    var rate = (maxSize - minSize) / individualCounters.length;
    
    for (var i = 0, length = seperateTags.length; i < length; i++) {
        div.innerHTML += "<span style = \"font-size:" + parseInt(tagsCounter[i] * rate + minSize) + "px;\">" + seperateTags[i] + "</span> ";
    }
    wrapper.appendChild(div);
}

function getCounters(counters){
    var individualCounters = [];
    for (var i = 0, length = counters.length; i < length; i++) {
        if(individualCounters.indexOf(counters[i]) == -1) {
            individualCounters.push(counters[i]);
        }
    }
    return individualCounters;
}