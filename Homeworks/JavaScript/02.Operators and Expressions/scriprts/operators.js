/*Read Me;
 * I get value from textbox (inputs) calculate some function depends 
 * on problem and return result in the outbut black console box.
 * it's like console.log();
/*Problem 1*/
function oddEven() {
    var num = document.getElementById("input").value;
    var result;
    if (num % 2 == 0) {
        result = "even";
    }
    else {
        result = "odd";
    }
    document.getElementById("output").value = result;
}
/*Problem 2*/
function divSevenFive() {
    var number = document.getElementById("p2input").value;
    var result = (number % 5 == 0 && number % 7 == 0);
    if (number == 0) {
        result = false;
    }

    document.getElementById("output").value = result;
}
/*Problem 3*/
function rectArea() {
    var width = document.getElementById("p3width").value;
    var height = document.getElementById("p3height").value;
    var area = (width * height);
    if (width == "" || height == "") {
        document.getElementById("output").value = "Input a number!";
    }
    else {

        document.getElementById("output").value = "Area: " + area + "cm²";
    }


}
/*Problem 4*/
function thirdDigit() {
    var input = document.getElementById("p4input").value;
    var isSeven;
    var len = input.length;
    if (len >= 3) {
        isSeven = (input.substring(len - 3, len - 2) == 7);
    }
    else {
        isSeven = false;
    }
    document.getElementById("output").value = isSeven; // tui mai moje da si go iznesa vav fonkciq - by spinderman
}
/*Problem 5*/
function bitThird() {
    var input = document.getElementById("p5input").value;
    var resultInBits = (input | 0).toString(2);
    var final = ((input & 8) >> 3);
    document.getElementById("output").value = "Binary: " + resultInBits + " Third bit: " + final;

}
/*Problem 6*/
function circle() {
    var x = document.getElementById("p6x").value;
    var y = document.getElementById("p6y").value;
    var isTrue = (x * x + y * y <= 25) && (Math.abs(y) < 5);
    document.getElementById("output").value = isTrue;
}
/*Problem 7*/
function primeNum() {
    var x = document.getElementById("p7input").value;
    x = parseInt(x); // manja. X is now a number.
    var isPrime = true;
    for (var i = 2; i < x / i; i++) {
        if (x % i == 0) {
            isPrime = false; break;
        }
        
    }
    document.getElementById("output").value = isPrime;
    console.log(isPrime);
}
/*Problem 8*/
function trapezoiod() {
    var a = document.getElementById("p8a").value;
    var b = document.getElementById("p8b").value;
    var h = document.getElementById("p8h").value;
    a = parseFloat(a);
    b = parseFloat(b);
    h = parseFloat(h);
    var s = ((a + b) * h) / 2;
    if (s.toString().length > 9) {  // if result is too long
        s = s.toFixed(7);  // round to seventh digit after decimal point
    }
    document.getElementById("output").value = s + "cm²";
    
}
/*Problem 9*/
function inCircleOutRect() {
    var x = document.getElementById("p9x").value;
    var y = document.getElementById("p9y").value;
    x = parseFloat(x);
    y = parseFloat(y);
    var inCircle = ((x - 1) * (x - 1)) + ((y - 1) * (y - 1)) <= 9 && Math.abs(y - 1) < 3;
    var outOfRect = true; // има и по-лесни начини,ако им сложим х+1 и у+1 може да се 
    // ползва кординати у[0,2] х[0,6] ако точката е в тези интервали то е в правоъгълника. 
    if (x >= -1 && x <= 5) { // това е малко по-тъп начин. ама това се сетих.
        if(y >= -1 && y <= 1){
            outOfRect = false;
        }
    }
    else if (y >= -1 && y <= 1) {
        if (x >= -1 && x <= 5) {
            outOfRect = false;
        }
    }
    
    document.getElementById("output").value = (inCircle && outOfRect);
    console.log("inCircle: " + inCircle);
    console.log("outRect: " + outOfRect);
}