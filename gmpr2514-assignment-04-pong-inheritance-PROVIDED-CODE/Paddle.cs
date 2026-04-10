using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gmpr2514_assignment_04_pong_inheritance;

public class Paddle
{
    private const int _Width = 2 * 2, _Height = 18 * 2, _Speed = 200 * 2;

    private Vector2 _position;
    private Vector2 _dimensions;
    private Rectangle _playAreaBoundingBox;
    private Texture2D _pixel;

    private Vector2 _direction;
    private float _speed;

    internal Vector2 Direction
    {
        get => _direction;
        set => _direction = value;
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
        _dimensions = new Vector2(_Width, _Height);
        _playAreaBoundingBox = playAreaBoundingBox;
        _speed = _Speed;
    }

    internal void LoadContent(GraphicsDevice graphicsDevice)
    {
        _pixel = CreatePixel(graphicsDevice, Color.Purple);
    }

    internal void Update(GameTime gameTime)
    {
        _position += _direction * _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if(_position.Y <= _playAreaBoundingBox.Top)
        {
            _position.Y = _playAreaBoundingBox.Top;
        }
        else if((_position.Y + _dimensions.Y) >= _playAreaBoundingBox.Bottom)
        {
            _position.Y = _playAreaBoundingBox.Bottom - _dimensions.Y;
        }
    }

    internal void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_pixel, BoundingBox, Color.White);
    }

    private Texture2D CreatePixel(GraphicsDevice graphicsDevice, Color colour)
    {
        Texture2D pixel = new Texture2D(graphicsDevice, 1, 1);
        pixel.SetData(new[] { colour });
        return pixel;
    }
}