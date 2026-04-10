// Pong.cs
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace gmpr2514_assignment_04_pong_inheritance;

public class Pong : Game
{
    private const int _WindowWidth = 500, _WindowHeight = 300;
    private const int _PlayAreaEdgeLineWidth = 8;
    private const int _PaddleWidth = 2 * 2, _PaddleHeight = 18 * 2;

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _backgroundTexture;

    private Rectangle _playAreaBoundingBox;

    private Ball _ball;
    private Paddle _paddle;

    private BlockerStationary _blockerStationary;
    private BlockerUpDown _blockerUpDown;
    private BlockerLeftRight _blockerLeftRight;

    private Brick[] _bricks;

    public Pong()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = _WindowWidth;
        _graphics.PreferredBackBufferHeight = _WindowHeight;
        _graphics.ApplyChanges();

        _playAreaBoundingBox = new Rectangle(0, _PlayAreaEdgeLineWidth, _WindowWidth, _WindowHeight - 2 * _PlayAreaEdgeLineWidth);

        _ball = new Ball();
        _ball.Initialize(new Vector2(50, 65), new Vector2(1, -2), _playAreaBoundingBox);

        _paddle = new Paddle();
        _paddle.Initialize(new Vector2(420, 150), new Vector2(_PaddleWidth, _PaddleHeight), _playAreaBoundingBox);

        _blockerStationary = new BlockerStationary();
        Vector2 stationaryDimensions = new Vector2(28, 36);
        Vector2 stationaryPosition = new Vector2(
            _playAreaBoundingBox.Center.X - stationaryDimensions.X / 2f,
            _playAreaBoundingBox.Center.Y - stationaryDimensions.Y / 2f
        );
        _blockerStationary.Initialize(stationaryPosition, stationaryDimensions, _playAreaBoundingBox);

        _blockerUpDown = new BlockerUpDown();
        _blockerUpDown.Initialize(new Vector2(240, 60), new Vector2(20, 32), _playAreaBoundingBox);

        _blockerLeftRight = new BlockerLeftRight();
        _blockerLeftRight.Initialize(new Vector2(80, 110), new Vector2(32, 20), _playAreaBoundingBox);

        _bricks = new Brick[4];

        Vector2 brickDimensions = new Vector2(36, 16);

        _bricks[0] = new Brick();
        _bricks[0].Initialize(new Vector2(80, 40), brickDimensions, _playAreaBoundingBox);

        _bricks[1] = new Brick();
        _bricks[1].Initialize(new Vector2(140, 40), brickDimensions, _playAreaBoundingBox);

        _bricks[2] = new Brick();
        _bricks[2].Initialize(new Vector2(200, 40), brickDimensions, _playAreaBoundingBox);

        _bricks[3] = new Brick();
        _bricks[3].Initialize(new Vector2(260, 40), brickDimensions, _playAreaBoundingBox);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _backgroundTexture = Content.Load<Texture2D>("Court");

        _ball.LoadContent(Content);

        _paddle.LoadContent(GraphicsDevice);
        _blockerStationary.LoadContent(GraphicsDevice);
        _blockerUpDown.LoadContent(GraphicsDevice);
        _blockerLeftRight.LoadContent(GraphicsDevice);

        _bricks[0].LoadContent(GraphicsDevice, Color.OrangeRed);
        _bricks[1].LoadContent(GraphicsDevice, Color.Gold);
        _bricks[2].LoadContent(GraphicsDevice, Color.LimeGreen);
        _bricks[3].LoadContent(GraphicsDevice, Color.DeepSkyBlue);
    }

    protected override void Update(GameTime gameTime)
    {
        KeyboardState kbState = Keyboard.GetState();
        if(kbState.IsKeyDown(Keys.W))
        {
            _paddle.Direction = new Vector2(0, -1);
        }
        else if(kbState.IsKeyDown(Keys.S))
        {
            _paddle.Direction = new Vector2(0, 1);
        }
        else
        {
            _paddle.Direction = new Vector2(0, 0);
        }

        _blockerStationary.Update(gameTime);
        _blockerUpDown.Update(gameTime);
        _blockerLeftRight.Update(gameTime);

        _ball.Update(gameTime);
        _paddle.Update(gameTime);

        _ball.ProcessCollision(_paddle.BoundingBox);
        _ball.ProcessCollision(_blockerStationary.BoundingBox);
        _ball.ProcessCollision(_blockerUpDown.BoundingBox);
        _ball.ProcessCollision(_blockerLeftRight.BoundingBox);

        foreach(Brick brick in _bricks)
        {
            brick.ProcessCollision(_ball);
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        _spriteBatch.Draw(_backgroundTexture, Vector2.Zero, null, Color.White, 0, Vector2.Zero, 2f, SpriteEffects.None, 0);

        _ball.Draw(_spriteBatch);
        _paddle.Draw(_spriteBatch);

        _blockerStationary.Draw(_spriteBatch);
        _blockerUpDown.Draw(_spriteBatch);
        _blockerLeftRight.Draw(_spriteBatch);

        foreach(Brick brick in _bricks)
        {
            brick.Draw(_spriteBatch);
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}