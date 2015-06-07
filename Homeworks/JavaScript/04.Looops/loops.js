/**
 * Created by M.Yankov on 30/05/2015.
 */

function show(text) {
    document.getElementById("output").value = text;
}
/*adds new line*/
function add(text) {
    var old = document.getElementById('output').value;
    document.getElementById('output').value = old + '\r\n' + text;
}

/*** Problem 1 ***/
function fromOneToN() {
    var i,
        result = '',
        number = (document.getElementById("p1input").value - 0); //parsing to number.
    if (number < 0) {
        show('Try another number');
        return;
    }
    for (i = 1; i <= number; i += 1) {
        result += i + '\r\n';
    }
    show(result);
}
/*** Problem 2 ***/
function notDevisibleTo3And7() {
    var i,
        result = '',
        number = (document.getElementById("p2input").value - 0);
    if (number < 0) {
        show('Try another number');
        return;
    }
    for (i = 1; i <= number; i += 1) {
        if (i % 3 && i % 7) {
            result += i + '\r\n';
        }
    }
    show(result);
}


/*** Problem 3 ***/
function minMax() {
    var valueNum,
        index,
        numbers = '',
        temp = document.getElementById('p3input').value,
        input = temp.trim(),
        res = input.split(/,\s+|\s+,+\s+|,|\s+,|\s+/), //the regEx splits by space ' ' and comma ',' () ; ,|[\s]+
        max = Number.MIN_VALUE, // for max I set minimum value for number type
        min = Number.MAX_VALUE; // and same for the

    for (index in res) {
        res[index] = res[index] - 0; // I make this array to be from type Number.
    }
    // First method.
    for (valueNum of res) {
        if (valueNum < min) {
            min = valueNum;
        }
        if (valueNum > max) {
            max = valueNum;
        }
    }
    console.log('Your numbers -> ' + res.join(', '));
    console.log('min  -> ' + min + ' max -> ' + max);
    console.log(Array.isArray(res) + ' ' + typeof(res[2]));
    numbers = 'Your numbers -> ' + res.join(', ') + '\r\n';
    numbers += 'min  -> [' + min + '] max -> [' + max + ']';
    show(numbers);
    // there is another methods in stackoverflow
}
function props() {
    var min = 'z',
        max = 'a';
    for (var key in document) {
        if (min > key) {
            min = key;
        }
        if (max < key) {
            max = key;
        }
    }
    show('\t\tdocument:');
    add('min -> [' + min + '] max -> [' + max + ']');
    min ='z';
    max = 'a';
    for (var key in window) {
        if (min > key) {
            min = key;
        }
        if (max < key) {
            max = key;
        }
    }
    add('\t\twindow:');
    add('min -> [' + min + '] max -> [' + max + ']');
    min = 'z';
    max = 'a';
    for (var key in navigator) {
        if (min > key) {
            min = key;
        }
        if (max < key) {
            max = key;
        }
    }
    add('\t\tnavigation:');
    add('min -> [' + min + '] max -> [' + max + ']');
}