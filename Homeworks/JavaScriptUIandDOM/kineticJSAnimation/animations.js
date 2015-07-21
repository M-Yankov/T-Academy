var stage = new Kinetic.Stage({
    container: 'content',
    width: 500,
    height: 500
});

var layer = new Kinetic.Layer();

var ball = new Kinetic.Circle({
    x: 109,
    y: 28,
    radius: 15,
    fill: '#00fff0',
    stroke: '#0212da'
});

var updateX = 1.5,
    updateY = 5;

function animationFrame() {
    var x = ball.getX() + updateX,
        y = ball.getY() + updateY;
    if (x < 15 || stage.getWidth() - ball.getRadius() < x) {
        updateX *= -1;
    }

    if (y < 15 || stage.getHeight() - ball.getRadius() < y) {
        updateY *= -1
    }

    ball.setX(x);
    ball.setY(y);
    layer.draw();

    //setTimeout(animationFrame, 30);
    requestAnimationFrame(animationFrame);
}

animationFrame();

layer.add(ball);
stage.add(layer);