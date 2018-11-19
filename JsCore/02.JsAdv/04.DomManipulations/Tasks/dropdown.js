function addItem() {
    let key = document.getElementById("newItemText").value;
    let value = document.getElementById("newItemValue").value;

    let menu = document.getElementById("menu");

let element = document.createElement("option");
debugger;
element.textContent = key;
element.value = value;
menu.appendChild(element);

document.getElementById("newItemText").value = "";
document.getElementById("newItemValue").value = "";
    }