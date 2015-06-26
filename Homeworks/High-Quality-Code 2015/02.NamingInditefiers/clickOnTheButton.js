/*Task 3. _ClickON_TheButton in JavaScript

    Refactor the following examples to produce code with well-named identifiers in JavaScropt */

function buttonOnClick(event, arguments) {
    var mainWindow = window,
        browser = mainWindow.navigator.appCodeName,
        isMozilla = (browser == "Mozilla");
    if (isMozilla) {
        alert("Yes"); // What yes ?
    } else {
        alert("No");
    }
}