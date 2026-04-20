using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gmpr2514_assignment_04_pong_inheritance;

public class PongRectangle
{
    // has replaced BlockerStationary

    protected Vector2 _position;
    protected Vector2 _dimensions;
    protected Rectangle _playAreaBoundingBox;
    protected Texture2D _pixel;

    internal Rectangle BoundingBox
    {
        get
        {
            return new Rectangle(_position.ToPoint(), _dimensions.ToPoint());
        }
    }

    internal virtual void Initialize(Vector2 initialPosition, Vector2 dimensions, Rectangle playAreaBoundingBox)
    {
        _position = initialPosition;
        _dimensions = dimensions;
        _playAreaBoundingBox = playAreaBoundingBox;

        ClampToPlayArea();
    }

    internal void LoadContent(GraphicsDevice graphicsDevice)
    {
        _pixel = CreatePixel(graphicsDevice, Color.Goldenrod);
    }

    internal void Update(GameTime gameTime)
    {
    }

    internal virtual void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_pixel, BoundingBox, Color.White);
    }

    internal void ClampToPlayArea()
    {
        if(BoundingBox.Left < _playAreaBoundingBox.Left)
        {
            _position.X = _playAreaBoundingBox.Left;
        }
        if(BoundingBox.Right > _playAreaBoundingBox.Right)
        {
            _position.X = _playAreaBoundingBox.Right - _dimensions.X;
        }
        if(BoundingBox.Top < _playAreaBoundingBox.Top)
        {
            _position.Y = _playAreaBoundingBox.Top;
        }
        if(BoundingBox.Bottom > _playAreaBoundingBox.Bottom)
        {
            _position.Y = _playAreaBoundingBox.Bottom - _dimensions.Y;
        }
    }

    private Texture2D CreatePixel(GraphicsDevice graphicsDevice, Color colour)
    {
        Texture2D pixel = new Texture2D(graphicsDevice, 1, 1);
        pixel.SetData(new[] { colour });
        return pixel;
    }
}