var state = [0, 0, 0, 0, 0, 0, 0, 0, 0];
var playerOneTurn = true;
var win = null;
var player=null;

var matches;

function play(i) {

    console.log(i, state);

    if (state[i] == 0 && win == null) {

        if (playerOneTurn == true) {
            state[i] = 1;
            document.getElementById(i).value = "X";
        }
        else {
            state[i] = 2;
            document.getElementById(i).value = "O";
        }

        document.getElementsByClassName("gameField")[i].classList.add(playerOneTurn ? 'a' : 'b');

        if (win = calculateWinner(state)) {
            var infoBox = document.getElementById("info");
            infoBox.innerHTML = "Player " + win + " Wins!";
        }
        playerOneTurn = !playerOneTurn;
    }
}

function calculateWinner(squares) {
    const lines = [
        [0, 1, 2],
        [3, 4, 5],
        [6, 7, 8],
        [0, 3, 6],
        [1, 4, 7],
        [2, 5, 8],
        [0, 4, 8],
        [2, 4, 6],
    ];
    for (let i = 0; i < lines.length; i++) {
        const [a, b, c] = lines[i];
        if (squares[a] && squares[a] === squares[b] && squares[a] === squares[c]) {
            win = squares[a]
            showWinningRow(lines[i]);
            return squares[a];
        }
    }
    return null;
}

function showWinningRow(squares) {
    for (var i = 0; i < 3; i++) {
        document.getElementById(squares[i]).style.border = "10px solid orange";
    }
}

function restart() {
    state = [0, 0, 0, 0, 0, 0, 0, 0, 0];
    win = null;

    for (var button of document.getElementsByClassName("gameField")) {
        button.classList.remove('a');
        button.value = "";
        button.classList.remove('b');
        button.style.border = "";
    }
    document.getElementById("info").innerHTML = "";
    document.getElementById("InfoMatches").innerHTML = "";
}

function Red() {
    playerOneTurn = false;
}

function Green() {
    playerOneTurn = true;
}



function getMatches() {

    removeTable();
    addTable();
    const Http = new XMLHttpRequest();
    const url = 'http://localhost:59265/api/matches';

    Http.open("GET", url);
    Http.send();

    Http.onloadend = (e) => {
        matches = JSON.parse(Http.responseText);
        tableCreate(matches);
    }
}

function newGame() {
    const Http = new XMLHttpRequest();
    const url = 'http://localhost:59265/api/matches'; //+ document.getElementById("InfoMatches").innerHTML+'/player';
    Http.open("POST", url);
    Http.send();

}


function joinMatch(i) {
    const Http = new XMLHttpRequest();
    const url = 'http://localhost:59265/api/matches/' + i + '/player';

    Http.open("POST", url);
    Http.send();

    Http.onloadend = (e) => {
        console.log(Http);             //! ! +-            !
    }
}


function createMatch() {
    const Http = new XMLHttpRequest();
    const url = 'http://localhost:59265/api/matches';

    Http.open("POST", url);
    Http.send();

    Http.onreadystatechange = (e) => {
        console.log(Http.responseText)
    }
}

function tableCreate(matches) {
    for (var j = 0; j < matches.length; j++) {
        match = {
            name: "Spiel" + j,
            id: matches[j].id,
        };
        var table = document.getElementById("matchesTable");
        var row = table.insertRow(j);
        row.setAttribute("id", j); 
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);

        cell1.innerHTML = match.name,
            cell2.innerHTML = match.id;
    }

    var table = document.getElementById('matchesTable');

    for (var i = 1; i < table.rows.length; i++) {
        table.rows[i].onclick = function () {
            //rIndex = this.rowIndex;
            console.log(this.rowIndex);
            //joinMatch(this.rowIndex);

            var rows = document.getElementsByTagName("TABLE")[0].rows;
            var last = rows[this.rowIndex];
            var cell = last.cells[1];
            console.log(cell.innerHTML);
            joinMatch(cell.innerHTML)
        };
    }
}

function removeTable() {
    document.getElementById("matchesTable").remove();
}

function addTable() {
    var table = document.createElement("TABLE");
    document.getElementById("table").appendChild(table);
    document.getElementsByTagName("TABLE")[0].setAttribute("id", "matchesTable");
}
