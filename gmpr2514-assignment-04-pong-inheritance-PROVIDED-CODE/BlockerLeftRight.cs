using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gmpr2514_assignment_04_pong_inheritance;

public class BlockerLeftRight
{
    private const float _Speed = 110f;

    private Vector2 _position;
    private Vector2 _dimensions;
    private Rectangle _playAreaBoundingBox;
    private Texture2D _pixel;

    private Vector2 _direction;
    private float _speed;

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

        _direction = new Vector2(1, 0);
        _speed = _Speed * 2;

        ClampToPlayArea();
    }

    internal void LoadContent(GraphicsDevice graphicsDevice)
    {
        _pixel = CreatePixel(graphicsDevice, Color.SteelBlue);
    }

    internal void Update(GameTime gameTime)
    {
        _position += _direction * _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if(BoundingBox.Left <= _playAreaBoundingBox.Left)
        {
            _position.X = _playAreaBoundingBox.Left;
            _direction.X *= -1;
        }
        else if(BoundingBox.Right >= _playAreaBoundingBox.Right)
        {
            _position.X = _playAreaBoundingBox.Right - _dimensions.X;
            _direction.X *= -1;
        }
    }

    internal void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_pixel, BoundingBox, Color.White);
    }

    private void ClampToPlayArea()
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