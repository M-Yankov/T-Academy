function show(text) {
    document.getElementById('output').value = text;
}
function add(text) {
    var old = document.getElementById('output').value;
    document.getElementById('output').value = old + '\r\n' + text;
}
function validation(data) {
    if (data == '') {
        show('Bad input');
        return true;
    }
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
/*** Problem 2 ***/
function compareArrays() {
    show('Task 2:');
    var equal = true,
        firstArr = document.getElementById('p2input1').value,
        secondArr = document.getElementById('p2input2').value;
    if (firstArr === '' && secondArr === '') {
        show('Please enter a value!');
        return;
    }
    if (firstArr.length != secondArr.length) {
        show('The two arrays do not have same length, so they are different');
        add('array1 -> [' + firstArr + ']');
        add('array2 -> [' + secondArr + ']');
        return;
    } else {
        for (var i = 0; i < firstArr.length; i += 1) {
            if (firstArr[i] === secondArr[i]) {
                add('[' + firstArr[i] + '] = [' + secondArr[i] + ']');
            } else {
                add('[' + firstArr[i] + '] != [' + secondArr[i] + ']');
                equal = false;
            }
        }
    }
    if (equal) {
        add('The two arrays are equal!');
    } else {
        add('The two arrays are NOT equal!');
    }

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
    if (validation(temp)) { return; }
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
    add('answer -> ' + resultArr);
    add('if there are more than one sequence - result is first match.');
    add('see the code how to match last sequence.');
}
/*** Problem 4 ***/
function maxIncreaseSequence() {
    var i,
        resultArr,
        index,
        max = 0,
        count = 1,
        temp = document.getElementById('p4input').value,
        input = temp.trim(),
        arr = input.split(/,\s+|\s+,+\s+|,|\s+,|\s+/);  // but i must make my array to be from type number so...
    if (validation(temp)) { return; }
    for (var key in arr) {
        arr[key] -= 0;
    }
    for (i = 1; i < arr.length; i += 1) {
        if (arr[i] > arr[i - 1]) {
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
    add('answer -> ' + resultArr);
    add('if there are more than one sequence - result is first match.');
    add('see the code how to match last sequence.');
}
/*** problem 5 ***/
function selectionSort() {
    var i,
        min,
        index,
        resultArray = [],
        temp = document.getElementById('p5input').value,
        input = temp.trim(),
        arr = input.split(/,\s+|\s+,+\s+|,|\s+,|\s+/),
        lengthOfArr = arr.length;
    if (validation(temp)) { return; }
    for (var key in arr) {
        arr[key] -= 0;
    }
    show('Your array -> ' + arr);
    add('sort step by step:');
    for (i = 0; i < lengthOfArr; i += 1) {
        min = Math.min.apply(Math, arr);  // for finding min element in array -> http://stackoverflow.com/questions/1669190/javascript-min-max-array-values#answer-6102340
        index = arr.indexOf(min);
        resultArray.push(arr.splice(index, 1));
        add((i + 1) + '. ' + resultArray);
    }
    add('sorted array -> ' + resultArray);

}
/*** Problem 7 ***/
// I will try with second variant from the link.
function binarySearch() {
    var mid,
        min,
        max,
        value = document.getElementById('p7value').value - 0, // try to enter number
        temp = document.getElementById('p7input').value,
        input = temp.trim(),
        arr = input.split(/,\s+|\s+,+\s+|,|\s+,|\s+/);
    if (validation(temp)) { return; }
    if (isNaN(value)) {
        show('Bad input in search value!');
        return;
    }
    for (var key in arr) {
        arr[key] -= 0;
    }
    arr = arr.sort();
    min = 0;
    max = arr.length - 1;
    show('sorted your array ' + arr);
    while (arr[max] >= arr[min]) {
        mid = midpoint(min, max);
        if (arr[mid] === value) {
            add('Found you! -> at index [' + mid + '] = ' + arr[mid]);
            return;
        } else if (arr[mid] < value) {
            min = mid + 1; //?
        } else {
            max = mid - 1;
        }
    }
    add('Not found ! ');

}

/*
 Array.prototype.min = function(){
 return Math.min.apply(null, this);
 };*/
var midpoint = function (min, max) {
    return ((min + max) / 2) | 0;
}

/*** Problem 6 ***/
function mostFrequent() {
    var i,
        index,
        count = 1,
        max = 1,
        temp = document.getElementById('p6input').value,
        input = temp.trim(),
        arr = input.split(/,\s+|\s+,+\s+|,|\s+,|\s+/);

    if (validation(temp)) { return; }
    for (var key in arr) {
        arr[key] -= 0;
    }
    // to find most frequent number - first I sorting the array - and then using algorithm from task 3, find the maximal
    // sequence . Example: "input: 9,2,4,6,4,2,4,1,2,4; sorted: 1,2,2,2,4,4,4,4,6,9
    arr = arr.sort(); // sorting array.
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
    show(arr[index] + ' is the most frequent number - ' + max + ' times.');
}