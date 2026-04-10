using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace gmpr2514_assignment_04_pong_inheritance;

public class Ball
{
    private const int _WidthAndHeight = 7;
    private const int _Speed = 100;
    private const int _CollisionTimerIntervalMillis = 400;

    private Vector2 _position;
    private Vector2 _dimensions;
    private Rectangle _playAreaBoundingBox;
    private Texture2D _pixel;

    private Vector2 _direction;
    private float _speed;

    private int _collisionTimerMillis;

    internal Rectangle BoundingBox
    {
        get
        {
            return new Rectangle(_position.ToPoint(), _dimensions.ToPoint());
        }
    }

    internal void Initialize(Vector2 initialPosition, Vector2 initialDirection, Rectangle playAreaBoundingBox)
    {
        _position = initialPosition;
        _dimensions = new Vector2(_WidthAndHeight * 2);
        _playAreaBoundingBox = playAreaBoundingBox;
        _direction = initialDirection;
        _speed = _Speed;
    }

    internal void LoadContent(ContentManager content)
    {
        _pixel = content.Load<Texture2D>("ball");
    }

    internal void Update(GameTime gameTime)
    {
        _collisionTimerMillis += gameTime.ElapsedGameTime.Milliseconds;

        _position += _direction * _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if(BoundingBox.Left <= _playAreaBoundingBox.Left || BoundingBox.Right >= _playAreaBoundingBox.Right)
        {
            _direction.X *= -1;
        }
        else if(BoundingBox.Top <= _playAreaBoundingBox.Top || BoundingBox.Bottom >= _playAreaBoundingBox.Bottom)
        {
            _direction.Y *= -1;
        }
    }

    internal void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_pixel, BoundingBox, Color.White);
    }

    internal bool ProcessCollision(Rectangle otherBoundingBox)
    {
        bool didCollide = false;

        if(_collisionTimerMillis >= _CollisionTimerIntervalMillis && BoundingBox.Intersects(otherBoundingBox))
        {
            didCollide = true;
            _collisionTimerMillis = 0;

            Rectangle intersection = Rectangle.Intersect(BoundingBox, otherBoundingBox);
            if(intersection.Width > intersection.Height)
            {
                _direction.Y *= -1;
            }
            else
            {
                _direction.X *= -1;
            }
        }

        return didCollide;
    }
}