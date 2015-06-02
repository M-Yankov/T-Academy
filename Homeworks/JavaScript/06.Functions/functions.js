function show(text) {
    document.getElementById('output').value = text;
}
function add(text) {
    var old = document.getElementById('output').value;
    document.getElementById('output').value = old + '\r\n' + text;
}
function validation(data) {
    if (data === '') {
        show('bad input!');
        return true;
    }

}

/*** Problem 1 ***/
function digitWord() {
    var lastDigit,
        result = '',
        input = document.getElementById('p1input').value;
    if(validation(input)){ return; }
    input = parseInt(input);
    lastDigit = input % 10;
    switch (lastDigit) {
        case 0:
            result = 'zero';
            break;
        case 1:
            result = 'one';
            break;
        case 2:
            result = 'two';
            break;
        case 3:
            result = 'three';
            break;
        case 4:
            result = 'four';
            break;
        case 5:
            result = 'five';
            break;
        case 6:
            result = 'six';
            break;
        case 7:
            result = 'seven';
            break;
        case 8:
            result = 'eight';
            break;
        case 9:
            result = 'nine';
            break;
        default:
            show('NaN of undefined');
            break;
    }
    if(result === ''){
        show('some kind of error');
    } else {
        show('last digit is -> ' + result + ' (' + lastDigit + ')');
    }

}

/*** Problem 2 ***/
function reversing() {
    // Not work with negative numbers.
    var arr = [],
        input = document.getElementById('p2input').value;
    if (validation(input)) {
        return;
    }
    for (var key in input) {
        arr.unshift(input[key]);
    }
    show(arr.join(''));

}