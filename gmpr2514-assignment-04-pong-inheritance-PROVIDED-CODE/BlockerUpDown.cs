using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gmpr2514_assignment_04_pong_inheritance;

public class BlockerUpDown : PongRectangleMoving
{
    private const float _Speed = 90f;

    internal override void Initialize(Vector2 initialPosition, Vector2 dimensions, Rectangle playAreaBoundingBox)
    {
        base.Initialize(initialPosition, dimensions, playAreaBoundingBox);

        _direction = new Vector2(0, 1);
        _speed = _Speed;

        //ClampToPlayArea();
    }

    internal override void Update(GameTime gameTime)
    {
        _position += _direction * _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if(BoundingBox.Top <= _playAreaBoundingBox.Top)
        {
            _position.Y = _playAreaBoundingBox.Top;
            _direction.Y *= -1;
        }
        else if(BoundingBox.Bottom >= _playAreaBoundingBox.Bottom)
        {
            _position.Y = _playAreaBoundingBox.Bottom - _dimensions.Y;
            _direction.Y *= -1;
        }
    }
}