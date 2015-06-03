function show(text) {
    document.getElementById('output').value = text;
}
function add(text) {
    var old = document.getElementById('output').value;
    document.getElementById('output').value = old + '\r\n' + text;
}

/*** Problem 1 ***/
function planarCoords() {
    show('Task 1:');
    var z,
        p1 = pointBuilder(3, 5),
        p2 = pointBuilder(-1, 2),
        p3 = pointBuilder(0, 3),
        p4 = pointBuilder(-2, -4),
        p5 = pointBuilder(5, 1),
        p6 = pointBuilder(5, -1),
        points = [p1, p2, p3, p4, p5, p6],
        line1 = lineBuilder(p1, p2),
        line2 = lineBuilder(p3, p4),
        line3 = lineBuilder(p5, p6);
    for ( z = 0; z < points.length; z += 1) {
        add('p' + (z + 1) + ': ' + points[z]);
    }
    add('line 1: ' + line1);
    add('line2: ' + line2);
    add('line3: ' + line3);
    add('length of line1: ' + line1.length + 'cm');
    add('length of line2: ' + line2['length'] + 'cm');
    add('length of line3: ' + line3.length + 'cm');
    add('Can above lines form a triangle? A: ' + performTriangle(line1, line2, line3));
    line2.ends = pointBuilder(-1, -1);
    line2.length = linLength(line2.begins, line2.ends);
    add('after change line2.ends coordinates:');
    add('Can above lines form a triangle? A: ' + performTriangle(line1, line2, line3));

}

var pointBuilder = function (xValue, yValue) {
    return {
        X: xValue,
        Y: yValue,
        toString: function () {
            return 'X: ' + this.X + ' Y: ' + this.Y;
        }
    };
};

var lineBuilder = function (start, end) {
    return {
        begins: start,
        ends: end,
        toString: function () {
            return 'begins at: ' + this.begins + '  ends at: ' + this.ends;
        },
        length: linLength(start, end)
    };
};
var linLength = function (point1, point2) {
    var c,
        a = point1.X - point2.X,
        b = point1.Y - point2.Y;
    a *= a; // Math.pow(a, 2); is slow;
    b *= b;
    c = Math.sqrt(a + b);
    return (Math.round(c * 100) / 100);
    // This is func calculating distance between two points = equal to line length.
};
var performTriangle = function (vector1, vector2, vector3) {
    // vector is line , just use different variable name
    var a = vector1.length,
        b = vector2.length,
        c = vector3.length; //aaaraghhh stupid JS
    return (a + b) > c && (b + c) > a && (c + a) > b;
};

/*** Problem 2 ***/
function removeElements() {
    var arr = [1, 2, 1, 4, '1', 1, 3, 4, 1, 111, 3, 2, 1, '1'];
    show('Array -> ' + arr.print());
    add('arr.reMOVE(1):');
    arr = arr.reMOVE(1);
    add(arr.print());

}
Array.prototype.reMOVE = function (value) {
    for (var i = 0; i < this.length; i += 1) {
        if (this[i] === value) {
            this.splice(i, 1);
        }
    }
    return this;
};
Array.prototype.print = function () {
    var i,
        result = '[';
    for (i = 0; i < this.length; i += 1) {

        result += prostotiq(this[i]); // returns some string in quotes
    }
    result += '];';
    result = result.replace(', ]', ']');
    return result;
};

var prostotiq = function (value) {
    switch (typeof (value)) {
        case 'number':
            return value + ', ';
        case 'string':
            return '"' + value + '", ';
        case 'boolean':
            return value ? true : false + ', ';
        default:
            break;

    }
};

/*** Problem 3 ***/
function deepCopy() {
    var pesho = {
        name: 'Pesho', age: 33, mission: 'to study', face: 'ugly', toString: function () {
            return this.name + ' is ' + this.age + ' old. And he wants ' + this.mission + ' ' + this.face;
        }
    };
    var str,
        copystr,
        booleanVar1,
        copyBool,
        notCopyOfPesho = pesho,
        copyOfPesho = clone(pesho);


    copyOfPesho.age = 22;
    copyOfPesho.name = 'New Pesho';
    copyOfPesho.mission = 'develop';
    copyOfPesho.face = 'smart';
    show('pesho: \r\n\t' + pesho);
    add(copyOfPesho);
    //if I change property of 'notCopyOfPesho' i will change the pesho. Watch:
    notCopyOfPesho.age = 1;
    notCopyOfPesho.face = 'beautiful';
    notCopyOfPesho.name = 'notCopy';
    notCopyOfPesho.mission = 'to work';
    add("'trying to change notCopyOfPesho variable - observe the code.'");
    add('pesho: \r\n\t' + pesho);
    add('notCopyOfPesho: \r\n\t' + notCopyOfPesho);
    booleanVar1 = true;
    copyBool = clone(booleanVar1);
    copyBool = false;
    add('first bool: ' + booleanVar1);
    add('copied bool changed to false: ' + copyBool);
    str = 'Hello World';
    copystr = clone(str);
    add('first string: ' + str);
    add('copied string: ' + copystr);
    copystr = "I'm copied variable";
    add('Change value to copied string: ' + copystr + '\r\nOld string: ' + str);
    // So it works if you want test it. Too much time spend for this shit.
}

// Sorry Object.prototype.copy don't work for primitive values like - 4, 'a' , true;
var clone = function (obj) {
    var i,
        newObj = {};

    switch (typeof (obj)) {
        case 'object':
            for (i in obj) {
                newObj[i] = obj[i];
            }
            return newObj;
            break;
        default:
            return obj;
    }
};

/*** Problem 4 ***/
function hasProp() {
    show('hasProperty(console , "log"")  = ' + hasProperty(console, 'log'));
    add('hasProperty(Math , "PI") = ' + hasProperty(Math, 'PI'));
    var pesho = {
        prostak: 'da',
        drugs: 'more'
    };
    add('hasProperty(pesho, "drugs")  = ' + hasProperty(pesho, 'drugs')); // :D
    add('hasProperty(pesho, "name"  = ' + hasProperty(pesho, 'name'));
    add("hasProperty(Math , 'length') = " + hasProperty(Math, 'length'));
}

var hasProperty = function (obj, string) {
    // validation for string;
    return obj[string] || 'None';
}; // the shortest task!

/*** Problem 5 ***/
function youngestPerson() {
    var i,
        index,
        min = +Infinity,// Number.Min_VALUE;
        personBuider = function (fname, lname, intAge) {
            return {
                firstName: fname,
                family: lname,
                age: intAge,
                toString: function () {
                    return this.firstName + ' ' + this.family + ' Age: ' + this.age;
                }
            };
        },
        p1 = personBuider('Goshe', 'Ivanov', 17),
        p2 = personBuider('Tosho', 'Ganchev', 25),
        p3 = personBuider('Hristo', 'Georgiev', 15),
        p4 = personBuider('Slender', 'TheGame', 99),
        p5 = personBuider('Parvan', 'Kirilov', 22),
        p6 = personBuider('Radoslav', 'Tapanarov', 19),
        p7 = personBuider('Jakson', 'Lamf', 28),
        p8 = personBuider('Michael', 'Efremov', 12),
        p9 = personBuider('Takeshi', 'Casel', 21),

        myArr = [p1, p2, p3, p4, p5, p6, p7, p8, p9];
    show('Task 5');
    for (i = 0; i < myArr.length; i += 1) {
        add((i + 1) + '. ' + myArr[i]);
        if (min > myArr[i].age) {
            index = i;
            min = myArr[i].age;
        }
    }
    add('Youngest is: ' + myArr[index]);
}


function something() {
    var myBigArray = [1, 2, 3];
    for (var x in myBigArray) {
        console.log(x);
    }

}
//why when use for( in ) loop it reaches a prototype function like 'reMOVE' and 'print'