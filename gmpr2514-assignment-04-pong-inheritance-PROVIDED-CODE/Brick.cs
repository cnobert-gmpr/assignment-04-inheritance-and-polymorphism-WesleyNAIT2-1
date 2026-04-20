using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gmpr2514_assignment_04_pong_inheritance;

public class Brick : PongRectangleMoving
{
    private bool _isAlive;

    internal bool IsAlive
    {
        get
        {
            return _isAlive;
        }
    }

    internal override void Initialize(Vector2 initialPosition, Vector2 dimensions, Rectangle playAreaBoundingBox)
    {
        base.Initialize(initialPosition, dimensions, playAreaBoundingBox);
        _isAlive = true;
    }

    internal void LoadContent(GraphicsDevice graphicsDevice, Color colour)
    {
        _pixel = CreatePixel(graphicsDevice, colour);
    }

    internal override void Update(GameTime gameTime)
    {
        
    }

    internal override void Draw(SpriteBatch spriteBatch)
    {
        if(_isAlive)
        {
            spriteBatch.Draw(_pixel, BoundingBox, Color.White);
            // I was not sure what to do with this
        }
    }

    internal void ProcessCollision(Ball ball)
    {
        if(_isAlive && ball.ProcessCollision(BoundingBox))
        {
            _isAlive = false;
        }
    }

    private Texture2D CreatePixel(GraphicsDevice graphicsDevice, Color colour)
    {
        Texture2D pixel = new Texture2D(graphicsDevice, 1, 1);
        pixel.SetData(new[] { colour });
        return pixel;
    }
}