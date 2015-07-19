(function () {
    var canvas = document.getElementById('cycle');
    var context = canvas.getContext('2d');

    var darkBLue = 'rgb(51, 125, 143)',
        lightBlue = 'rgb(133, 202, 215)',
        centerOfBackWheel = {
            X: 93,
            Y: 250
        },
        centerOfFrontWheel = {
            X: 450,
            Y: centerOfBackWheel.Y
        },
        centerOfPedals = {
            X: 250,
            Y: centerOfBackWheel.Y
        },
        radiusOfWheels = 90;


    context.lineWidth = 5;
    context.fillStyle = lightBlue;
    context.strokeStyle = darkBLue;

    // back wheel
    context.arc(centerOfBackWheel.X, centerOfBackWheel.Y, radiusOfWheels, 0, Math.PI * 2);
    context.fill();
    context.stroke();

    // front wheel
    context.beginPath();
    context.arc(centerOfFrontWheel.X, centerOfFrontWheel.Y, radiusOfWheels, 0, Math.PI * 2);
    context.fill();
    context.stroke();

    // frame
    context.beginPath();
    context.moveTo(centerOfBackWheel.X, centerOfBackWheel.Y);
    context.lineTo(200, 125);
    context.lineTo(425, 125);
    context.lineTo(250, centerOfBackWheel.Y);
    context.closePath();
    context.stroke();

    // handlebar
    context.beginPath();
    context.moveTo(centerOfFrontWheel.X, centerOfFrontWheel.Y);
    context.lineTo(418, 60);
    context.lineTo(464, 2);
    context.moveTo(418, 60);
    context.lineTo(343, 85);
    context.stroke();

    // pedals
    context.beginPath();
    context.arc(centerOfPedals.X, centerOfPedals.Y, 25, 45 * Math.PI / 180, (360 + 45) * Math.PI / 180);
    context.lineTo(285, 287);
    context.stroke();
    context.beginPath();
    context.arc(centerOfPedals.X, centerOfPedals.Y, 25, 0, (270 - 45) * Math.PI / 180);
    context.lineTo(215, 210);
    context.stroke();

    // seat
    context.beginPath();
    context.moveTo(centerOfPedals.X, centerOfPedals.Y);
    context.lineTo(180, 85);
    context.lineTo(140, 85);
    context.lineTo(220, 85);
    context.stroke();

}());