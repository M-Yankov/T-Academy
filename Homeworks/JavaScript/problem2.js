// this code is for maximum points - 75

function solve(params) {
    var sum = 0,
        product = 1,
        text = params[0],
        offset = params[1],
        alphabet = 'abcdefghijklmnopqrstuvwxyz'.split(''); // da se nadqvame che sa v pravilen red.
    text = compression(text);
    console.log(text);// works

    text = encryption(text, alphabet, offset);
    console.log(text);// works

    transformation(text, sum, product);

    function compression(text) {
        var i,
            result = '',
            char = '',
            counter = 1,
            len = text.length;
        for (i = 0; i < len; i += 1) {
            char = text[i];
            while (char === text[i + 1]) {
                counter += 1;
                i += 1;
            }
            if (counter === 2) {
                result += text[i] + text[i - 1];
            } else if (counter > 2) {
                result += counter + char;
            } else {
                result += text[i];
            }
            counter = 1;
        }
        return result; //works for now
    }

    function encryption(text, letters, offset) {
        var offseedLetters = letters.slice(); // make a new not reference copy
        var char, i, j, len, index;
        for (i = 0; i < offset; i += 1) {
            char = offseedLetters.pop(); // last letter
            offseedLetters.unshift(char);
        }
        //now it's ok
        len = text.length;
        char = '';
        var number, result = '';
        for (j = 0; j < len; j += 1) {
            char = text[j];
            if (isNaN(char)) {
                // letter
                index = letters.indexOf(char);
                number = (char.charCodeAt(0) - 0) ^ (offseedLetters[index].charCodeAt(0) - 0);
                console.log((char.charCodeAt(0) - 0) + ' =---- ' + (offseedLetters[index].charCodeAt(0) - 0));
                console.log('number ' + number);
                result += number;

            } else {
                //number
                result += char;
            }
        }
        return result;

        // to get any letter we must 97 + index  ,122 - offset , char.charCodeAt(0) - offset
    }

    function transformation(numbers, sum, product) {
        var z, len = numbers.length;
        for (z = 0; z < len; z += 1) {
            if (numbers[z] % 2) {
                //odd
                product *= numbers[z];
            } else {
                // even
                sum += (numbers[z] - 0);
            }
        }
        console.log(sum);
        console.log(product);
    }
}


var args = [
    'abcdefgh',
    '3'
];

solve(args);