String.prototype.format = function (object) {
    var currentText = this;                                             // this is equal to current text.
    //console.log(currentText);
    var regExer = new RegExp("#{\\w+}", "g");                           //currentText.match(/#{\w+}/);
    while (currentText.indexOf('#{') !== -1) {
        var arr = currentText.match(regExer);                           // take matches into array
        var word = arr[0];                                              // get first element like #{text}
        var placeholder = word.substring(2, word.length - 1);           // cut only the name of placeholder
        currentText = currentText.replace(word, object[placeholder]);
        /* replace first match with object of this
         * property. If obj don't have such property
         * the result will be undefined. */
        //console.log(placeholder);

    }

    return currentText;
};
/*Problem 1. Format with placeholders

 Write a function that formats a string. The function should have placeholders, as shown in the example
 Add the function to the String.prototype
 */

console.log('Problem 1');
var options = {name: 'John', age: 13};
var txt = 'My name is #{name} and I am #{age}-years-old';
console.log(txt.format(options));

var talibanin = {status: 'dangerous', inventory: 'AK-47, glock 18, katana', frags: '2 towns', hostages: 31};
txt = 'We have a very #{status} terrorist. He is armed with #{inventory}. Till now #{frags} died from hands of this #{status} bandit. According to people gossip there\'are #{hostages} hostages.'
console.log(txt.format(talibanin));


/*Problem 2. HTML binding

 Write a function that puts the value of an object into the content/attributes of HTML tags.
 Add the function to the String.prototype
 */

String.prototype.bind = function (text, object) {
    var tag,
        htmlTag, i, len,
        tempArr = [],
        dataBindArr = [],
        myObj = {},
        workText = text; // text = this but that's in the homework task.

    // My explanation for this task: (I always have some difficulties with understanding of problem in the task.)
    // data-bind-<HTML property>="object property".
    var regExForTag = new RegExp('<\\w+');
    var regExer = new RegExp('data-bind-\\w+="\\w+"', 'g');//global or not

    // We must have a one tag in the string.!
    tempArr = workText.match(regExForTag);
    tag = tempArr[0].substring(1);   // "<a" to get only "a"  or  "<span" to get only "span"
    htmlTag = document.createElement(tag);  // to see if it works

    //console.log(htmlTag);

    // get all data-bindings
    dataBindArr = workText.match(regExer);
    dataBindArr.forEach(function (element, index, array) {
        var tarr = element.split('=');
        var attribute = tarr[0].split('-')[2]; // data-bind-content
        var prop = tarr[1].substring(1, tarr[1].length - 1);

        myObj[attribute] = prop;


        //array[index] = element.substring( element.indexOf('data-bind-') + 10,element.indexOf('='))
    });
    var value;
    for (var key in myObj) {
        value = myObj[key];
        if(key === 'content'){
            key = 'innerText'; // Content it's not really a property. So I use innerText. Judge me if you want.
            htmlTag[key] = object[value];
        } else{

            htmlTag.setAttribute(key, object[value]);
        }
    }

    document.body.appendChild(htmlTag);
    //console.log(myObj);
    //console.log(dataBindArr);
    return htmlTag;
};
console.log('To test Problem 2 - open it in browser, Node.js will not work.');
var test = '<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></a>';
console.log(test.bind(test, {name: 'Elena', link: 'http://telerikacademy.com'}));
var example = '<div data-bind-content="name"></div>';
console.log(example.bind(example, {name : 'Steven'}));

// Tag a don's have attribute content!
// Result it's not the same but that's it.