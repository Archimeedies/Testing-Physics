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
        private List<Particle> particles = new List<Particle>();
        private int numberOfParticles = 10;

        public Controller(Graphics graphics, Size clientSize)
        {
            Random rand = new Random();
            int particlePerRow = (int)Math.Sqrt(numberOfParticles);
            int particlePerCol = (numberOfParticles - 1) / particlePerRow + 1;

            for (int i = 0; i < numberOfParticles; i++)
            {
                PointF position = new PointF(rand.Next(clientSize.Width), rand.Next(clientSize.Height));
                PointF velocity = new PointF((float)(rand.NextDouble() * 4 - 2), (float)(rand.NextDouble() * 4 - 2));
                particles.Add(new Particle(graphics, clientSize, position, velocity));
            }
        }
        
        public void Update()
        {
            foreach (var particles in particles)
            {
                particles.Move();
                particles.Draw();
            }
        }
    }
}
