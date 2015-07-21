var stage = new Kinetic.Stage({
    container: 'content',
    width: 500,
    height: 500
});

var layer = new Kinetic.Layer();

var i,
    count = 10;
for (i = 0; i < count; i += 1) {
    var ball = new Kinetic.Circle({
        x: Math.random() * (stage.getWidth() - 30) + 15,
        y: Math.random() * (stage.getHeight() - 30) + 15,
        radius: 15,
        fill: '#00fff0',
        stroke: '#0212da'
    });

    layer.add(ball);
}
var updateXes = Array.apply(null, {length: count})
        .map(function () {
            return Math.random() * 10;
        }),

    updateYes = Array.apply(null, {length: count})
        .map(function () {
            return Math.random() * 10;
        });

function animationFrame() {
    var balls = layer.find('Circle');
    balls.forEach(function (ball, index) {
        var updateX = updateXes[index],
            updateY = updateYes[index],
            x = ball.getX() + updateX,
            y = ball.getY() + updateY,
            r = ball.getRadius();

        if (x < r || stage.getWidth() - r < x) {
            updateX *= -1;
        }

        if (y < r || stage.getHeight() - r < y) {
            updateY *= -1
        }

        if (balls.some(function (other) {
                if (other === ball) {
                    return false;
                }
                var b1 = {
                        x: ball.getX(),
                        y: ball.getY(),
                        r: ball.getRadius()
                    },
                    b2 = {
                        x: other.getX(),
                        y: other.getY(),
                        r: ball.getRadius()
                    };
                var d = Math.sqrt((b1.x - b2.x) * (b1.x - b2.x) +
                                  (b1.y - b2.y) * (b1.y - b2.y));
                return d <= (b1.r + b2.r);
            })) {
            updateX *= -1;
            updateY *= -1;
        }
        ball.setX(ball.getX() + updateX);
        ball.setY(ball.getY() + updateY);

        updateXes[index] = updateX;
        updateYes[index] = updateY;
    });
    layer.draw();
    //setTimeout(animationFrame, 30);
    requestAnimationFrame(animationFrame);
}

animationFrame();

stage.add(layer);