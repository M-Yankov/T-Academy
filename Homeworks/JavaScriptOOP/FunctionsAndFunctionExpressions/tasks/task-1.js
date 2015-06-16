/* Task Description */
/* 
 Write a function that sums an array of numbers:
 numbers must be always of type Number
 returns `null` if the array is empty
 throws Error if the parameter is not passed (undefined) // podawam
 throws if any of the elements is not convertible to Number

 */

function solve() {
    return function (params) {
        params = params || arguments[0];
        // params mus br Array.
        if (!Array.isArray(params)) {
            throw 'This is not an array';
        } else if (params.length === 0) {
            return null;
        } else if (arguments.length === 0) {
            return undefined;
        } else {
            params.forEach(function (element, index, sourceArr) {
                sourceArr[index] = element - 0
            });
            var i, sum = 0, len = params.length;
            for (i = 0; i < len; i += 1) {
                if (isNaN(params[i])) {
                    throw  'Not all elements is type number!';
                }
                sum += params[i];
            }
            return sum;
        }
    }
}

/* This code works in BGcoder and local in Node.js with command "npm test" */

module.exports = solve();
