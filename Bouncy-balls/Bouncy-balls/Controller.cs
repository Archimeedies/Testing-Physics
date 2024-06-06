using BouncyBalls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bouncy_balls
{
    public class Controller
    {
        private Ball ball;

        public Controller(Graphics graphics, Size clientSize)
        {
            PointF initialPosition = new PointF(50, 50);
            PointF initialVelocity = new PointF(0, 0);
            ball = new Ball(graphics, clientSize, initialPosition, initialVelocity);
        }
        
        public void Update()
        {
            ball.Draw();
            ball.Move();
        }
    }
}
