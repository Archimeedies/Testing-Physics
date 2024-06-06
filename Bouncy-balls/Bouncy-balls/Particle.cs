using System;
using System.Drawing;

namespace BouncyBalls
{
    public class Particle
    {
        private int size = 10; // Size of the ball
        private float gravity = 0.98f; // Gravity effect on the ball
        private float damping = 0.99f; // Damping factor for energy loss
        private Graphics graphics;
        private Size clientSize;
        private PointF position; // Use PointF for floating-point precision
        private PointF velocity;
        private Brush brush;

        public Particle(Graphics graphics, Size clientSize, PointF position, PointF velocity)
        {
            this.graphics = graphics;
            this.clientSize = clientSize;
            this.position = position;
            this.velocity = velocity;
            this.brush = new SolidBrush(Color.White); // Initialize the brush
        }

        public void Draw()
        {
            graphics.FillEllipse(brush, new RectangleF(position.X, position.Y, size, size));
        }

        public void Move()
        {
            // Apply gravity to the vertical velocity
            velocity.Y += gravity;

            // Apply damping to simulate energy loss
            velocity.X *= damping;
            velocity.Y *= damping;

            // Update the particles position based on its velocity
            position.X += velocity.X;
            position.Y += velocity.Y;

            // Check for collisions with the form's boundaries
            ResolveCollisions();
        }

        private void ResolveCollisions()
        {
            // Check for collision with the form's boundaries
            if (position.X < 0 || position.X + size > clientSize.Width)
            {
                velocity.X = -velocity.X * damping; // Reverse and reduce horizontal speed
                position.X = Math.Max(0, Math.Min(position.X, clientSize.Width - size)); // Keep particle within boundaries
            }

            if (position.Y < 0 || position.Y + size > clientSize.Height)
            {
                velocity.Y = -velocity.Y * damping; // Reverse and reduce vertical speed
                position.Y = Math.Max(0, Math.Min(position.Y, clientSize.Height - size)); // Keep ball within boundaries
            }
        }
    }
}
