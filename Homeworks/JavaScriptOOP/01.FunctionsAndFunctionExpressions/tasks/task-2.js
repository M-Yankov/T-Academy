/* Task 2 description */
/*
 Write a function that finds all the prime numbers in a range

 It should return the prime numbers in an array
 It must throw an Error if any of the range params is not convertible to Number
 It must throw an Error if any of the range params is missing

 */

function findPrimes() {
    return function (start, end) {
        var num, sqetNum, j, isPrime, result = [];
        if (start === undefined || end === undefined) {
            throw 'The argument is missing!';
        }
        if (isNaN(start) || isNaN(end)) {
            throw 'Argument type Error';
        }
        start -= 0;
        end -= 0;
        for (num = start; num <= end; num += 1) {
            if (num <= 1) {
                continue;
            }
            sqetNum = Math.sqrt(num);
            isPrime = true;
            for (j = 2; j <= sqetNum; j += 1) {

                if (num % j === 0) {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime) {
                result.push(num);
            }
        }
        return result;
    }
}

/* Code below is not for BGcoder */
/*var res = findPrimes();
console.log(res());*/
module.exports = findPrimes();