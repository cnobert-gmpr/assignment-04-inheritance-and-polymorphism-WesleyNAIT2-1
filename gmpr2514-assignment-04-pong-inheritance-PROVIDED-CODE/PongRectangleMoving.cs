using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gmpr2514_assignment_04_pong_inheritance;

public abstract class PongRectangleMoving : PongRectangle
{
    //inherits from PongRectangle but adds direction and speed

    protected Vector2 _direction;
    protected float _speed;

    

    new internal abstract void Update(GameTime gameTime);
    // it said to add "new" here but I'm not sure about it. doesn't seem to break anything though
}