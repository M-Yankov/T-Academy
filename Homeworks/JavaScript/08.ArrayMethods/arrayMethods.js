// Polyfill for task 5.
if (!Array.prototype.find) {
    Array.prototype.find = function(predicate) {
        if (this == null) {
            throw new TypeError('Array.prototype.find called on null or undefined');
        }
        if (typeof predicate !== 'function') {
            throw new TypeError('predicate must be a function');
        }
        var list = Object(this);
        var length = list.length >>> 0;
        var thisArg = arguments[1];
        var value;

        for (var i = 0; i < length; i++) {
            value = list[i];
            if (predicate.call(thisArg, value, i, list)) {
                return value;
            }
        }
        return undefined;
    };
}
/// Problem 1

var arr = [],
    count = 10;
arr[count - 1] = undefined;

var makePerson = function (fname , lname, age, sex){
    return {
        firstName : fname,
        lastName : lname,
        age : age,
        gender: sex?'female':'male'
    }
};

var p1 = makePerson('Ivan', 'Petrov',12),
    p2 = makePerson('Dragana', 'mirkovic',62, true),
    p3 = makePerson('Ivo', 'Atanasov',22),
    p4 = makePerson('Miro', 'Petrov',32),
    p5 = makePerson('Kiro', 'Petrov',82),
    p6 = makePerson('Ivana', 'Petrov',22, true),
    p7 = makePerson('Dancho', 'Petrov',17),
    p8 = makePerson('Pesho', 'Petrov',32),
    p9 = makePerson('Ivan', 'Petrov',29),
    p10 = makePerson('Petar', 'Strahilov',42);
arr =[p1, p2, p3,p4, p5, p6, p7 ,p8, p9, p10];
console.log(arr);
// Problem2
console.log('\r\nProblem 2\r\n');
console.log(arr.every(function(person){return person.age>=18}));
// Problem 3
/*Problem 3. Underage people

 Write a function that prints all underaged persons of an array of person
 Use Array#filter and Array#forEach
 Use only array methods and no regular loops (for, while)
 */
console.log('\r\nProblem 3\r\n');
var secondArr = arr.filter(function(element,index, array){ return element.age < 18});
secondArr.forEach(function(element){console.log(element)});

/*Problem 4. Average age of females

 Write a function that calculates the average age of all females, extracted from an array of persons
 Use Array#filter
 Use only array methods and no regular loops (for, while)
 */
console.log('\r\nProblem 4\r\n');
var femaleAvgAge = arr.filter(function(person, index, array){ if(person.gender === 'female'){return person} });
var sum = 0;
console.log(femaleAvgAge);
femaleAvgAge.forEach(function(person, index, array){ sum += person.age });
console.log(sum / femaleAvgAge.length);

/*Problem 5. Youngest person

 Write a function that finds the youngest male person in a given array of people and prints his full name
 Use only array methods and no regular loops (for, while)
 Use Array#find
 */
function youngest(element, index, array){
    var i, len = array.length;
    var min = 0, obj = {};
    for ( i = 0; i < len ; i += 1) {
        if(min > element.age){
            min = element.age;
            obj = element;
        }
    }
    return obj;
}
console.log(arr.find(youngest));

/* Problem 6 - no time.*/

