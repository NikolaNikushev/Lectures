var todoContent = document.getElementById('TODOContent')
var todoItems = 0;

function AddNewElement (ev) {
	ev.preventDefault();
	todoItems += 1;
	var radItem = document.createElement("input");
	radItem.setAttribute("type", "checkbox");
	radItem.setAttribute("id", "item" + todoItems);
	radItem.setAttribute("name", "radios");

	var radLabel = document.createElement("label");
	radLabel.innerHTML = document.getElementById('itemToAdd').value + "<br />";
	radLabel.setAttribute("for", "item" + todoItems);
	radLabel.setAttribute("id", "item" + todoItems);
	radLabel.setAttribute("class", "item" + todoItems);

	todoContent.appendChild(radItem);
	todoContent.appendChild(radLabel);

}

function RemoveSelectedElements (ev) {
	ev.preventDefault();
	var selectedElements = document.getElementById("TODOContent").childNodes;
	for (var i = 0; i < selectedElements.length; i++) {
		console.log(selectedElements[i].style.display)
		if (selectedElements[i].checked === true) {
			
			selectedElements[i].parentNode.removeChild(selectedElements[i])

			var theId = selectedElements[i].id;
			var theLabel = document.getElementById(theId);

			theLabel.parentNode.removeChild(theLabel);
			todoItems -= 1;
		};
	};
}

function HideElements (ev) {
	ev.preventDefault();
	var selectedElements = document.getElementById("TODOContent").childNodes;
	for (var i = 0; i < selectedElements.length; i++) {
		if (selectedElements[i].checked === true) {

			selectedElements[i].style.display ="none"

			var theId = selectedElements[i].id;
			var theLabel = document.getElementsByClassName(theId);

			theLabel[0].style.display = "none";
		};
	};
}

function ShowHidden (ev) {
	ev.preventDefault();

	var elements = document.getElementById("TODOContent").childNodes;
	for (var i = 0; i < elements.length; i++) {
		if (elements[i].style.display === "none") {
			ev.preventDefault();
			elements[i].style.display = "";

			var theId = elements[i].id;
			var theLabel = document.getElementById(theId);
			theLabel.style.display = "";
		};
	};
}
