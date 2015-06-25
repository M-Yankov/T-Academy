function solve() {
    var domElement = (function () {
        var domElement = {
            init: function (type) {
                if (!(/^[A-Za-z0-9]+$/.test(type)) || typeof type !== 'string') {
                    throw new Error('Invalid type element');
                }

                var result = this; // Object.create(domElement);
                result.type = type;
                result.attributes = {};
                result.childs = [];
                result.content = '';
                result.parent;
                return result;
            },

            appendChild: function (child) {
                if (typeof child === 'object') {
                    child.parent = this;
                    this.childs.push(child.innerHTML); // pushing childs like a string.
                } else {
                    // string
                    this.childs.push(child);
                }
                return this;
            },

            addAttribute: function (name, value) {
                if (!(/^[A-Za-z0-9\-]+$/.test(name))) {
                    throw new Error('Invalid name of attribute!');
                }
                this.attributes[name] = value;
                return this;
            },


            type: {
                get: function () {
                    return type;
                },
                set: function (value) {
                    type = value;
                }

            },

            get content() {
                return this._content;
            },

            set content(valueText) {
                // because I append children like a strings not object, I receive a stupid error.
                if (this.parent !== undefined) {
                    var replace = this.innerHTML,
                        i,
                        len = this.parent.childs.length;
                }
                if (this.childs.length === 0) {
                    this._content = valueText;
                }

                if(this.parent !== undefined){
                    for (i = 0; i < len; i += 1) {
                        if (this.parent.childs[i] === replace) {
                            this.parent.childs[i] = this.innerHTML;
                        }
                    }
                }
                return this;


            },


            get innerHTML() {
                if (typeof this === 'string') {
                    return this;
                }

                var attributes = '',
                    that = this,
                    childrenToString = '',
                    i;

                that.attributes = sortObject(this);

                for (var key in that.attributes) {
                    attributes += ' ' + key + '="' + that.attributes[key] + '"';
                }

                for (i = 0; i < that.childs.length; i += 1) {
                    childrenToString += that.childs[i];
                }
                return '<' + this.type + attributes + '>' + childrenToString + this.content + '</' + this.type + '>';
            }
        };

        // By condition must use sorted properties
        function sortObject(inputObject) {
            var sorted = {},
                key,
                result,
                temporaryvalues = [];

            for (key in inputObject.attributes) {
                temporaryvalues.push(key);
            }

            temporaryvalues.sort();

            for (key = 0; key < temporaryvalues.length; key += 1) {
                sorted[temporaryvalues[key]] = inputObject.attributes[temporaryvalues[key]];
            }

            return sorted;
        }

        return domElement;
    }());
    return domElement;
}

/*var style = Object.create(solve())
        .init('style')
        .appendChild('#big {\nfont-size: 144pt;\n}'),
    link = Object.create(solve())
        .init('link')
        .addAttribute('src', 'css/fancy.css'),
    meta = Object.create(solve())
        .init('meta')
        .addAttribute('charset', 'utf-8'),
    title = Object.create(solve())
        .init('title')
        .appendChild('Super-Mega awesome S173'),
    script = Object.create(solve())
        .init('script')
        .addAttribute('lang', 'javascript')
        .appendChild('function init(){}'),
    head = Object.create(solve())
        .init('head')
        .appendChild(meta)
        .appendChild(title)
        .appendChild(link)
        .appendChild(style)
        .appendChild(script),
    heading = Object.create(solve())
        .init('h1'),
    luser = Object.create(solve())
        .init('label')
        .addAttribute('for', 'username')
        .addAttribute('class', 'big'),
    lpass = Object.create(solve())
        .init('label')
        .addAttribute('for', 'password'),
    user = Object.create(solve())
        .init('input')
        .addAttribute('name', 'username')
        .addAttribute('id', 'username')
        .addAttribute('type', 'input')
        .addAttribute('tab-index', 1),
    pass = Object.create(solve())
        .init('input')
        .addAttribute('name', 'password')
        .addAttribute('id', 'password')
        .addAttribute('type', 'password')
        .addAttribute('tab-index', 2),
    submit = Object.create(solve())
        .init('input')
        .addAttribute('type', 'submit')
        .addAttribute('value', 'natis'),
    form = Object.create(solve())
        .init('form')
        .appendChild(luser)
        .appendChild(user)
        .addAttribute('action', 'vlez/mi/u/profila')
        .appendChild(lpass)
        .addAttribute('method', 'post')
        .appendChild(pass)
        .appendChild(submit),
    footer = Object.create(solve())
        .init('footer'),
    body = Object.create(solve())
        .init('body')
        .appendChild(heading)
        .appendChild(form)
        .appendChild('reklamata')
        .appendChild(footer),
    html = Object.create(solve())
        .init('html')
        .appendChild(head)
        .appendChild(body);

heading.content = 'tova izliza v golemi bukvi';
head.content = 'tova ne trqbva da izliza';
luser.content = 'Username: ';
lpass.content = 'Password: ';
footer.content = 'stiga tolkoz';

console.log(html.innerHTML);*/

var a  = Object.create(solve()).init('div');
var b = Object.create(solve()).init('p').appendChild(a);
var c = Object.create(solve()).init('body').appendChild(b);
a.content = "Some variavble";
console.log(c.innerHTML);

module.exports = solve;