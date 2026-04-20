using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gmpr2514_assignment_04_pong_inheritance;

public class BlockerLeftRight : PongRectangleMoving
{
    private const float _Speed = 110f;

    internal override void Initialize(Vector2 initialPosition, Vector2 dimensions, Rectangle playAreaBoundingBox)
    {
        base.Initialize(initialPosition, dimensions, playAreaBoundingBox);
        
        _direction = new Vector2(1, 0);
        _speed = _Speed * 2;
    }

    internal override void Update(GameTime gameTime)
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
}