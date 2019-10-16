


var state = [0, 0, 0, 0, 0, 0, 0, 0, 0];


var asTurn = true;


function play(i) {

    console.log(i, state);

    if (state[i] == 0) {

        state[i] = asTurn ? 1 : 2;

        document.getElementsByClassName("gameField")[i].classList.add(asTurn ? 'a' : 'b');

        var win;

        if (win = checkWin()) {

            alert("Player " + win + " Wins!");

            state = [0, 0, 0, 0, 0, 0, 0, 0, 0];

            for (var button of document.getElementsByClassName("gameField")) {

                button.classList.remove('a');

                button.classList.remove('b');

            }

        }

        asTurn = !asTurn;

    }

}


function checkWin() {

    var win = 0;

    for (var i = 0; i < 3; i++) {

        if (state[i * 3] == state[i * 3 + 1] && state[i * 3] == state[i * 3 + 2]) return state[i * 3];

    }

    for (var i = 0; i < 3; i++) {

        if (state[i] == state[3 + i] && state[i] == state[6 + i]) return state[i];

    }

    if (state[0] == state[5] && state[4] == state[8]) return state[0];

    if (state[2] == state[5] && state[4] == state[6]) return state[2];

}