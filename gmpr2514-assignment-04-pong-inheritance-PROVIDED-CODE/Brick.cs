using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gmpr2514_assignment_04_pong_inheritance;

public class Brick
{
    private Vector2 _position;
    private Vector2 _dimensions;
    private Rectangle _playAreaBoundingBox;
    private Texture2D _pixel;

    private bool _isAlive;

    internal bool IsAlive
    {
        get
        {
            return _isAlive;
        }
    }

    internal Rectangle BoundingBox
    {
        get
        {
            return new Rectangle(_position.ToPoint(), _dimensions.ToPoint());
        }
    }

    internal void Initialize(Vector2 initialPosition, Vector2 dimensions, Rectangle playAreaBoundingBox)
    {
        _position = initialPosition;
        _dimensions = dimensions;
        _playAreaBoundingBox = playAreaBoundingBox;
        _isAlive = true;
    }

    internal void LoadContent(GraphicsDevice graphicsDevice, Color colour)
    {
        _pixel = CreatePixel(graphicsDevice, colour);
    }

    internal void Draw(SpriteBatch spriteBatch)
    {
        if(_isAlive)
        {
            spriteBatch.Draw(_pixel, BoundingBox, Color.White);
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