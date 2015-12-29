'use strict';

// fs means: file system. It's embedded in node JS(core modules). If you running code with WebStorm,
// a message will appear for install or download a reference for node js core modules. It help to
// intellij (completion while typing) to find methods like readdirSync('...').
let fs = require('fs');
let path = './models';

/**
 * modules exports from ES6 is necessary when this file is called with require(...) (in this case from app.js).
 * This function reads all files in the current directory, except this one (using filter) and for each call a require with
 * same syntax - they returns a function that is invoked with @param app. Ref: see one of the router files.
 * @param app express() instance.
 */
fs.readdirSync(path)
	.filter(file => file !== 'index.js')
	.forEach(file => require(`./${file}`));