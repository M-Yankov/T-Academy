console.log("Data types and Variables");
console.warn("*** Problem 1 ***");
var msg = "Press F12 to see result into the console!";
alert(msg);
document.body.innerHTML = "<div>" + msg + "</div>";

var integer = 50;
var floatNumber = 3.141592;
var booleanType = (integer > floatNumber); // must be true.
var string = "Az sam pesho и говоря български! ↕%▼○▼╬Iô♪☼?6v6956≡|=ë¬¬¬◙◙jj◙*¬¬⌂?86I"; //
var unknown = undefined;
var x = null;
console.log("integer = " + integer);
console.log("float = " + floatNumber);
console.log("bool = " + booleanType);
console.log("string as text = " + string);
console.log("undefined = " + unknown);
console.log("nullVariable = " + x);
/*I can do this too below. It's the same.*/
var x = 50;
console.log("integer = " + x);
x = 3.141592;
console.log("float = " + x);
x = 5 > 3;
console.log("bool = " + x);
x = "Some text here " + 'and here.';
console.log("text = " + x);
x = null;
console.log("nulltype = " + x);
x = undefined;
console.log("undefined = " + x);
console.log("");
