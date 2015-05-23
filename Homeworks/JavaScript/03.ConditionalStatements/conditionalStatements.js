/**
 * Created by M.Yankov on 22/05/2015.
 */
function write(text) {
    document.getElementById("output").value = text;
}
//*** Problem 1 ***
function exchange() {
    var a = (document.getElementById("p1a").value - 0); // extract from zero to make it type number
    var b = (document.getElementById("p1b").value - 0);
    var temp;
    if (a > b) {
        temp = a;
        a = b;
        b = temp;
    }
    write("A: " + a + "\tB: " + b);
}
//*** Problem 2 ***
function multiplication() {
    var a = (document.getElementById("p2a").value - 0);
    var b = (document.getElementById("p2b").value - 0);
    var c = (document.getElementById("p2c").value - 0);

    var allplus = (a > 0 && b > 0 && c > 0);
    var acMinus = (a < 0 && c < 0 && b > 0);
    var abMinus = (a < 0 && b < 0 && c > 0);
    var cbMinus = (b < 0 && c < 0 && a > 0);
    if (a === 0 || b === 0 || c === 0) {
        write(0);
    }
    else if (allplus || acMinus || abMinus || cbMinus) {
        write("sign is: +");
    }
    else {
        write("sign is: -");
    }
}
//*** Problem 3 ***
function threeBig() {
    var a = (document.getElementById("p3a").value - 0);
    var b = (document.getElementById("p3b").value - 0);
    var c = (document.getElementById("p3c").value - 0);
    if (a > b) {
        if (a > c) {
            write(a);
        }
        else {
            write(c);
        }
    }
    else {
        if (b > c) {
            write(b);
        }
        else {
            write(c);
        }
    }
}
//*** Problem 4 ***
function sort() {
    var a = (document.getElementById("p4a").value - 0);
    var b = (document.getElementById("p4b").value - 0);
    var c = (document.getElementById("p4c").value - 0);
    var result;
    if (a > b && a > c) {
        result = "A: " + a;
        if (b > c) {
            result += " B: " + b + " C: " + c;
        }
        else {
            result += " C: " + c + " B: " + b;
        }
    }
    else if (b > a && b > c) {
        result = "B: " + b;
        if (c > a) {
            result += " C: " + c + " A: " + a;
        }
        else {
            result += " A: " + a + " C: " + c;
        }
    }
    else {
        result = "C: " + c;
        if (a > b) {
            result += " A: " + a + " B: " + b;
        }
        else {
            result += " B: " + b + " A: " + a;
        }
    }
    write(result);
}
//*** Problem 5 ***//
function digitWord() {
    var number = prompt("Enter number (0-9):", "5");
    number -= 0;
    var result;
    switch (number) {
        case 0:
            result = "zero";
            break;
        case 1:
            result = "one";
            break;
        case 2:
            result = "two";
            break;
        case 3:
            result = "three";
            break;
        case 4:
            result = "four";
            break;
        case 5:
            result = "five";
            break;
        case 6:
            result = "six";
            break;
        case 7:
            result = "seven";
            break;
        case 8:
            result = "eight";
            break;
        case 9:
            result = "nine";
            break;
        default :
            result = "not a digit";
            break;
    }
    write(result);
}
//*** Problem 6 ***//
function quadratic() {
    var a = (document.getElementById("p6a").value - 0);
    var b = (document.getElementById("p6b").value - 0);
    var c = (document.getElementById("p6c").value - 0);
    var discriminant = Math.pow(b, 2) - 4 * a * c;
    var x1;
    var x2;
    if (discriminant > 0) {
        x1 = (-b - Math.sqrt(discriminant)) / (2 * a);
        x2 = (-b + Math.sqrt(discriminant)) / (2 * a);
    }
    else if (discriminant === 0) {
        x1 = -b / (2 * a);
        x2 = x1;
    }
    else {
        x1 = "no real roots";
        x2 = x1;
    }
    write("X1: " + x1 + " X2: " + x2);

}
//*** Problem 7 ***
function fiveBiggest() {
    var a = (document.getElementById("p7a").value - 0);
    var b = (document.getElementById("p7b").value - 0);
    var c = (document.getElementById("p7c").value - 0);
    var d = (document.getElementById("p7d").value - 0);
    var e = (document.getElementById("p7e").value - 0);
    var max;
    // if you want nested if else statements - take it. :)
    if (a > b) {
        if (a > c) {
            if (a > d) {
                if (a > e) {
                    max = a;
                }
                else {
                    max = e;
                }
            }
            else {
                if (d > e) {
                    max = d;
                }
                else {
                    max = e;
                }
            }
        }
        else {
            if (c > d) {
                if (c > e) {
                    max = c;
                }
                else {
                    max = e;
                }
            }
            else {
                if (d > e) {
                    max = d;
                }
                else {
                    max = e;
                }
            }
        }
    }
    else {
        if (b > c) {
            if (b > d) {
                if (b > e) {
                    max = b;
                }
                else {
                    max = e;
                }
            }
            else {
                if (d > e) {
                    max = d;
                }
                else {
                    max = e;
                }
            }
        }
        else {
            if (c > d) {
                if (c > e) {
                    max = c;
                }
                else {
                    max = e;
                }
            }
            else {
                if (d > e) {
                    max = d;
                }
                else {
                    max = e;
                }
            }
        }
    }
    write("Biggest is: " + max);
}
//*** Problem 8 **8
function numberAsWord() {
    var number = (document.getElementById("p8input").value - 0);
    var result;
    if (number < 0 || number >= 1000) {
        write("try another number [0-999]");
        return;
    }
    else if (number === 0) {
        result = "Zero";
    }
    else if (number < 20) {
        result = zeroTwenty(number);
        result = result.charAt(0).toUpperCase() + result.substring(1); // to make first letter uppercase.

        //console.log(result);
    }
    else if (number > 19 && number < 100) {
        result = takebefore99(number);
        result = result.charAt(0).toUpperCase() + result.substring(1);
        //console.log(result);
    }
    else if (number > 99 && number < 1000) {
        var hun = number.toString().substring(0, 1);
        result = hundreds(hun - 0);
        var others = number.toString().substring(1);
        if (takebefore99(others - 0) !== "") {
            result += " and " + takebefore99(others - 0);
        }


        result = result.charAt(0).toUpperCase() + result.substring(1);
        //console.log(result);
    }
    function takebefore99(number) {
        if (number < 20) {
            return zeroTwenty(number);
        }
        var decimals = number.toString().substring(0, 1);
        decimals = tens(decimals - 0);
        var digit = number.toString().substring(1);
        digit = zeroTwenty(digit - 0);
        var final = decimals + " " + digit;
        //final = final.charAt(0).toUpperCase() + final.substring(1);
        return final;
        /*write(result);
         console.log(result);*/
    }

    function zeroTwenty(number) {
        switch (number) {
            case 0:
                return "";
            case 1:
                return "one";
            case 2:
                return "two";
            case 3:
                return "three";
            case 4:
                return "four";
            case 5:
                return "five";
            case 6:
                return "six";
            case 7:
                return "seven";
            case 8:
                return "eight";
            case 9:
                return "nine";
            case 10:
                return "ten";
            case 11:
                return "eleven";
            case 12:
                return "twelve";
            case 13:
                return "thirteen";
            case 14:
                return "fourteen";
            case 15:
                return "fifteen";
            case 16:
                return "sixteen";
            case 17:
                return "seventeen";
            case 18:
                return "eighteen";
            case 19:
                return "nineteen";


        }
    }

    function tens(number) {
        switch (number) {
            case 2:
                return "twenty";
            case 3:
                return "thirty";
            case 4:
                return "forty";
            case 5:
                return "fifty";
            case 6:
                return "sixty";
            case 7:
                return "seventy";
            case 8:
                return "eighty";
            case 9:
                return "ninety";


        }
    }

    function hundreds(number) {
        switch (number) {
            case 1:
                return "one hundred";
            case 2:
                return "two hundred";
            case 3:
                return "three hundred";
            case 4:
                return "four hundred";
            case 5:
                return "five hundred";
            case 6:
                return "six hundred";
            case 7:
                return "seven hundred";
            case 8:
                return "eight hundred";
            case 9:
                return "nine hundred";
        }
    }

    write(result);
}