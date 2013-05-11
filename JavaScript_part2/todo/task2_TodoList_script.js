var todoList = (function () {
    var list = document.getElementById("list");

    function addItem(itemData) {
        if (itemData === "") {
            return;
        }
        var newItem = document.createElement("li");
        newItem.innerHTML = itemData;

        var deleteIcon = document.createElement('button');
        deleteIcon.className = "deleteIcon";
        deleteIcon.addEventListener(
        "click",
        function (ev) {
            ev.preventDefault();
            deleteItem(ev.target);
        }, false);
        newItem.appendChild(deleteIcon);

        var doneIcon = document.createElement('button');
        doneIcon.className = "doneIcon";
        doneIcon.addEventListener(
            "click",
            function (ev) {
                ev.preventDefault();
                hideItem(ev.target);
            }, false);
        newItem.appendChild(doneIcon);

        list.appendChild(newItem);
    }

    function deleteItem(item) {
        item.parentNode.parentNode.removeChild(item.parentNode);
    }

    function hideItem(item) {
        item.parentNode.classList.remove("show");
        item.parentNode.classList.add("hidden");
    }

    function showAll() {
        var todos = document.getElementsByTagName("li");
        for (var i = 0; i < todos.length; i++) {
            if(todos[i].classList.contains("hidden")){
                todos[i].classList.remove("hidden");
                todos[i].classList.add("show");
            }
            
        }
    }

    function removeAll() {
        var list = document.getElementById("list");
        while (list.firstChild) {
            list.removeChild(list.firstChild);
        }
    }

    return {
        add: addItem,
        remove: deleteItem,
        markAsDone: hideItem,
        showDone: showAll,
        removeAll: removeAll
    }
}());

document.getElementById("addItemButton").addEventListener(
    "click",
    function (ev) {
        ev.preventDefault();
        var input = document.getElementById("todoInput").value;
        todoList.add(input);
        document.getElementById("todoInput").value = "";
    }, false);

document.getElementById("showAll").addEventListener(
    "click",
    function (ev) {
        ev.preventDefault();
        todoList.showDone();
    }, false);

document.getElementById("removeAll").addEventListener(
    "click",
    function (ev) {
        ev.preventDefault();
        todoList.removeAll();
    }, false);




