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
        private List<Ball> balls = new List<Ball>();
        private int numberOfBalls = 10;

        public Controller(Graphics graphics, Size clientSize)
        {
            Random rand = new Random();

            for (int i = 0; i < numberOfBalls; i++)
            {
                PointF position = new PointF(rand.Next(clientSize.Width), rand.Next(clientSize.Height));
                PointF velocity = new PointF((float)(rand.NextDouble() * 4 - 2), (float)(rand.NextDouble() * 4 - 2));
                balls.Add(new Ball(graphics, clientSize, position, velocity));
            }
        }
        
        public void Update()
        {
            foreach (var ball in balls)
            {
                ball.Move();
                ball.Draw();
            }
        }
    }
}
