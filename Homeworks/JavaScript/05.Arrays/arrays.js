function show(text) {
    document.getElementById('output').value = text;
}
function add(text) {
    var old = document.getElementById('output').value;
    document.getElementById('output').value = old + '\r\n' + text;
}
/*** Problem 1 ***/
function simpleArray() {
    show('My array:');
    var i,
        count = 20,
        myArray = []; // empty array;
    for (i = 0; i <= count; i += 1) {
        myArray[i] = i * 5;
        add('array[' + i + '] -> ' + myArray[i]);
    }
    add(myArray);
}

/*** Problem 3 ***/
function maxSequence() {
    var i,
        resultArr,
        index,
        max = 0,
        count = 1, //Why 1 ? - because min sequence can't be 0;
        temp = document.getElementById('p3input').value,
        input = temp.trim(),
        arr = input.split(/,\s+|\s+,+\s+|,|\s+,|\s+/); //the regEx splits by space ' ' and comma ',' () ; ,|[\s]+
    for (i = 1; i < arr.length; i += 1) {
        if (arr[i] === arr[i - 1]) {
            count += 1;
            if (count > max) { // to match last sequence just make (count >= max)
                max = count;
                index = i;
            }
        } else {
            count = 1;
        }
    }
    resultArr = arr.slice((index - max) + 1, index + 1);
    show('Your array is -> ' + arr);
    add('longest sequence -> ' + max);
    add('new arr-> ' + resultArr);
    add('if there are more than one sequence - result is first match.');
    add('see the code how to match last sequence.');
}
