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
    if (validation(input)) {
        return;
    }
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
    if (result === '') {
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

/*** Problem 3 ***/
function occurrencesWord() {
    var temp,
        count = 0,
        overloadFunc = function (ftext, fword, checked) {
            if (!checked) {
                ftext = ftext.toLowerCase();
                fword = fword.toLowerCase();
            }
            temp = ftext.indexOf(fword, 0);
            while (temp !== -1) {
                temp += 1;
                count += 1;
                temp = ftext.indexOf(fword, temp);

            }
            show('This word \"' + fword + '\" appears ' + count + ' times.');
        },
        text = document.getElementById('p3input').value,
        checkbox = document.getElementById('p3checkbox'),
        word = document.getElementById('p3value').value;
    if (validation(text) || validation(word)) {
        return;
    }
    show('Searching...');
    if (checkbox.checked) {
        overloadFunc(text, word, true);
    } else {
        overloadFunc(text, word);
    }


}

/*** Problem 4 ***/
function divElements() {
    var openDiv = [],
        closeDiv = [],
        sourceHTMLcode = '<html> <head> <title>My web Site</title></head> <body><div id="header"> <div id="menu"><ul><li>A</li><li>B</li><li>C</li></ul></div></div> <div id="main"><div class="structure"></div><div></div></div><div id="footer"><div></div><div></div><p></p></div></body> </html>';
// there is a short html code with some div elements on it.
    openDiv = sourceHTMLcode.match(/<div\s\S+?>|<div>/g);
    closeDiv = sourceHTMLcode.match(/<\/div>/g);
    if (openDiv.length != closeDiv.length) {
        show('Maybe some error in html code');
    } else {
        show('there are ' + openDiv.length + ' <div> elements');
        add('to try your values check the code.');
    }

}

/*** Problem 5 ***/
function appearsValue() {
    var index,
        result = 0,
        temp = document.getElementById('p5input').value,
        input = temp.trim(),
        arr = input.split(/,\s+|\s+,+\s+|,|\s+,|\s+/),
        value = document.getElementById('p5value').value;
    if (validation(value) || validation(temp)) {
        return;
    }
    value -= 0;
    arr = arr.map(parseFloat);
    for (index = 0; index < arr.length; index += 1) {
        if (arr[index] === value) {
            result += 1;
        }
    }
    show('Your Array -> ' + arr);
    add('(' + value + ') appears ' + result + ' times.');

}

/*** Problem 6 ***/
function neighbours() {

    var last,
        temp = document.getElementById('p6input').value,
        input = temp.trim(),
        arr = input.split(/,\s+|\s+,+\s+|,|\s+,|\s+/),
        index = document.getElementById('p6index').value;
    if (validation(temp) || validation(index)) {
        return;
    }
    index -= 0;
    arr = arr.map(parseFloat); //Remember that array is from integers
    show('Your array -> ' + arr);
    last = arr.length - 1;
    switch (index) {
        case 0:
            if (arr[0] > arr[1]) {
                add('true');
                add(arr[index] + ' > ' + arr[index + 1]);
            } else {
                add('false');
            }
            break;
        case last:
            if (arr[last] > arr[last - 1]) {
                add('true');
                add(arr[last] + ' > ' + arr[last - 1]);
            } else {
                add('false');
            }
            break;
        default:
            if (arr[index] > arr[index + 1] && arr[index] > arr[index - 1]) {
                add('true');
                add(arr[index - 1] + ' < ' + arr[index] + ' > ' + arr[index + 1]);
            } else {
                add('false');
            }

    }
}

/*** Problem 7 ***/

function firstLarger() {

    var index,
        firstLargerNeighbour = function (arr) {
            var i,
                result,
                last = arr.length - 1;
            for (i = 0; i < arr.length; i += 1) {
                switch (i) {
                    case 0:
                        result = (arr[0] > arr[1]);
                        break;
                    case last:
                        result = (arr[last] > arr[last - 1]);
                        break;
                    default:
                        result = (arr[i] > arr[i + 1] && arr[i] > arr[i - 1]);

                }
                if (result) {
                    break;
                }
            }
            if (result) {
                return i;
            } else {
                return -1;
            }
        },
        temp = document.getElementById('p7input').value,
        input = temp.trim(),
        arr = input.split(/,\s+|\s+,+\s+|,|\s+,|\s+/);
    if (validation(temp)) {
        return;
    }
    arr = arr.map(parseFloat);
    show('Your Array -> ' + arr);
    index = firstLargerNeighbour(arr);
    if (index !== -1) {
        add('Founded at [' + index + '] index -> ' + arr[index]);
    } else {
        add('not found!');
    }


}
