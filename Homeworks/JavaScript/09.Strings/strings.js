// This HOMEWORK is for strings just make wrong title.
function show(text) {
    document.getElementById('output').value = text;
}
function add(text) {
    var old = document.getElementById('output').value;
    document.getElementById('output').value = old + '\r\n' + text;
}
function validate(data) {
    var regEx = /\S+/;
    if (data == '' || !regEx.test(data)) {
        show('Bad input!');
        return true;
    }
    return false;
}

/*** Problem 1 ***/
function reversing() {
    var text = document.getElementById('p1input').value;
    if (validate(text)) {
        return;
    }
    var i,
        result = '',
        len = text.length - 1;
    for (i = len; i >= 0; i -= 1) {
        result += text[i];
    }
    show('"' + result + '"');
}

/* Problem 2 */
function correctBracets() {
    var input = document.getElementById('p2input').value;
    if (validate(input)) {
        return;
    }
    show('Your input: "' + input + '"');
    var i,
        count = 0,
        len = input.length,
        correct = true,
        showError = '';
    for (i = 0; i < len; i += 1) {
        if (!correct) {
            break;
        }
        switch (input[i]) {
            case '(':
                count += 1;
                showError += '.';
                break;
            case ')':
                if (count <= 0) {
                    add('Your input: "'.replace(/./g, ' ') + showError.replace(/./g, ' ') + '^Error at index [' + i + ']');
                    correct = false;
                } else {
                    count -= 1;
                    showError += '.';
                }
                break;
            default:
                showError += '.';

        }
    }
    if (count !== 0) {
        correct = false;
    }
    correct ? add("It's correct.") : add('Not correct');
}

/* Problem 3 */
function search() {
    var matches = [],
        key = document.getElementById('p3key').value,
        text = document.getElementById('p3text').value,
        regExer = new RegExp(key, 'ig');
    if (validate(key) || validate(text)) {
        return;
    }
    matches = text.match(regExer);
    show('In this text:');
    add('\t' + text);
    add('with search word: ' + key);
    add('Program founds ' + matches.length + ' matches');
    // if you use escape character like \s \d \w ... you can test them. some works some not :D
}

/* Problem 4 */
function parseTags() {
    show('Task');
    var text = document.getElementById('p4text').value;

    if (validate(text)) {
        return;
    }
    var mix = function (text) {
        var j,
            result = '',
            len = text.length;
        for (j = 0; j < len; j += 1) {
            if (j % 2) {
                result += text[j].toLowerCase();
            } else {
                result += text[j].toUpperCase();
            }

        }
        return result;
    };

    var startIndex, endIndex, word, newWord;
    //text = text.toLowerCase();
    while (text.indexOf('<upcase>') !== -1) {
        startIndex = text.indexOf('<upcase>');
        endIndex = text.indexOf('</upcase>');
        word = text.substring(startIndex, endIndex + 9);
        //add('word -> ' + word);
        endIndex = word.indexOf('<', 8);
        newWord = word.substring(8, endIndex);
        newWord = newWord.toUpperCase();
        //add('to upper -> ' + newWord);
        text = text.replace(word, newWord);
    }
    while (text.indexOf('<lowcase>') !== -1) {
        startIndex = text.indexOf('<lowcase>');
        endIndex = text.indexOf('</lowcase>');
        word = text.substring(startIndex, endIndex + 10);
        endIndex = word.indexOf('<', 9);
        newWord = word.substring(9, endIndex);
        newWord = newWord.toLowerCase();
        text = text.replace(word, newWord);
    }
    while (text.indexOf('<mixcase>') !== -1) {
        startIndex = text.indexOf('<mixcase>');
        endIndex = text.indexOf('</mixcase>');
        word = text.substring(startIndex, endIndex + 10);
        endIndex = word.indexOf('<', 9);
        newWord = word.substring(9, endIndex);
        newWord = mix(newWord);
        text = text.replace(word, newWord);
    }
    add(text);
//fucking task.!
    // not working with nested tags. sorry
    /* try this -> We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase>
     have <lowcase>AnYThinG</lowcase> else. <upcase>more big text</upcase>
     <mixcase>Mac-X OS S-ciin const of (a -w)</mixcase> <upcase>my text is bigger</upcase>
     <lowcase>This Must Be LOw CASE 12 CHaracters ? NOT</lowcase> */
}

/* Problem 5 */
function notbreakSpace() {
    var text = document.getElementById('p5text').value;
    text = text.replace(/\s/g, '&nbsp;');
    show(text);
}

/* Problem 6 */
function extractTextFromHTML() {
    function notEmpty(item) {
        var word = item.trim();  // Taq prostotiq ne raboti @@
        return !!word;
    }

    var matches = [],
        results = [],
        input = document.getElementById('p6text').value;
    matches = input.match(/[^<>]+(?=[<])/g);
    results = matches.filter(notEmpty);

    var i,
        len = results.length;
    for (i = 0; i < len; i += 1) {
        results[i] = results[i].trim();
    }
    show(results.join(''));
    add('If some spaces missing, it\'s beacuse the results is trimed.');
}

/* Problem 7 */
function urlParser() {
    var protocol,
        server,
        resource,
        obj = {},
        url = document.getElementById('p7input').value;
    var slash, dot,
        index = url.indexOf(':');
    protocol = url.substring(0, index); // + 1
    //show(protocol);
    dot = url.indexOf('.');
    if (url.indexOf('/', dot) !== -1) {
        slash = url.indexOf('/', +dot);
        server = url.substring(index + 3, slash);
        if (url.lastIndexOf('/', slash) !== -1) {
            resource = url.substring(slash, url.length);
        }
    } else {
        server = url.substring(index + 3, url.length);
    }

    show('Json Object: {');
    obj.protocol = protocol;
    obj.server = server;
    obj.resource = resource || 'None';
    for (var prop in obj) {
        add('\t' + prop + ': ' + obj[prop]);
    }
    add('}');
    /*  http://abv.bg/mail30/*/


}

/* Problem 8 */
function link() {
    // <a href="http://www.telerikacademy.com" >Link</a>;  -> ".+(?=")
    // [URL=http://www.telerikacademy.com]LINK[/URL]
    show('Task 8: ');
    var text,
        href,
        full,
        index,
        endIndex,
        result,
        link = document.getElementById('p8input').value;
    while(link.indexOf('<a') !== -1 && link.indexOf('<\/a>') !== -1){
        // get full link tag
        index = link.indexOf('<a');
        endIndex = link.indexOf('a>');
        full = link.substring(index, endIndex + 2);
        //show(full);
        // get only text between > <
        index = full.indexOf('>');
        endIndex = full.indexOf('<', index); // to search after index
        text = full.substring(index + 1, endIndex );
        //add('text-> ' + text);
        // get href value
        index = full.indexOf('"');
        endIndex = full.indexOf('"', index + 1);
        href = full.substring(index + 1, endIndex);
        //add('href -> ' + href);
        result = '[URL=' + href + ']' + text + '[/URL]';
        //add(result);
        link = link.replace(full, result);

    }
    add('Result: \r\n\t' + link );


///@@@@@ @@@ @ @@ @@ @@ @ @@@@ @@@ @@ @ @@ @@ @@
}

/* Problem 9 */
function mail() {
    var check,
        reexer = new RegExp('([\\w\\.\\-_\']+)?\\w+@[\\w-_]+(\\.\\w+){1,}'),
        text = document.getElementById('p9input').value;

    check = reexer.test(text);
    if (check) {
        show('This is a email: ' + text);
    } else {
        show('Maybe it\'s not a email: ' + text);
    }
    add('<- ' + text.match(reexer));
}

/* Problem 10*/
function palindromes() {
    var i,
        result = '',
        text = document.getElementById('p10input').value,
        len = text.length - 1;
    for (i = len; i >= 0; i -= 1) {
        result += text[i];
    }
    if (text === result && text.length === result.length) {
        show('The word is palindrome: ' + text);
    } else {
        show('The word is Not palindrome: ' + text);
    }
}

/* Problem 11 and 12*/
function notFinished(){
    show('Sorry I don\'t have time. Prefer to prepare for exam and don\'t want to copy homework from others.');
}
/*TODO Problems 11 and 12  unfinished*/