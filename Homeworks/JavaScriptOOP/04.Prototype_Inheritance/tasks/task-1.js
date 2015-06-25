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
                    this.childs.push(child); // pushing childs like a objects.
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

            removeAttribute: function(name){
                if(this.attributes.hasOwnProperty(name)){
                    delete this.attributes[name];
                    return this;
                } else {
                    throw new Error('Removing property is invalid.');
                }

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
                    if(typeof that.childs[i] === 'string'){
                        childrenToString += that.childs[i];
                    } else{

                        childrenToString += that.childs[i].innerHTML;
                    }
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

module.exports = solve;