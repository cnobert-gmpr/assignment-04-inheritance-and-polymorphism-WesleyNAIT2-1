// using Microsoft.Xna.Framework;
// using Microsoft.Xna.Framework.Graphics;

// namespace gmpr2514_assignment_04_pong_inheritance;

//  public class BlockerStationary  //this needs to go away in favor of PongRectangle
//  {
//     private Vector2 _position;
//     private Vector2 _dimensions;
//     private Rectangle _playAreaBoundingBox;
//     private Texture2D _pixel;

//     internal Rectangle BoundingBox
//     {
//         get
//         {
//             return new Rectangle(_position.ToPoint(), _dimensions.ToPoint());
//         }
//     }

//     internal void Initialize(Vector2 initialPosition, Vector2 dimensions, Rectangle playAreaBoundingBox)
//     {
//         _position = initialPosition;
//         _dimensions = dimensions;
//         _playAreaBoundingBox = playAreaBoundingBox;

//         ClampToPlayArea();
//     }

//     internal void LoadContent(GraphicsDevice graphicsDevice)
//     {
//         _pixel = CreatePixel(graphicsDevice, Color.Goldenrod);
//     }

//     internal void Update(GameTime gameTime)
//     {
//     }

//     internal void Draw(SpriteBatch spriteBatch)
//     {
//         spriteBatch.Draw(_pixel, BoundingBox, Color.White);
//     }

//     private void ClampToPlayArea()
//     {
//         if(BoundingBox.Left < _playAreaBoundingBox.Left)
//         {
//             _position.X = _playAreaBoundingBox.Left;
//         }
//         if(BoundingBox.Right > _playAreaBoundingBox.Right)
//         {
//             _position.X = _playAreaBoundingBox.Right - _dimensions.X;
//         }
//         if(BoundingBox.Top < _playAreaBoundingBox.Top)
//         {
//             _position.Y = _playAreaBoundingBox.Top;
//         }
//         if(BoundingBox.Bottom > _playAreaBoundingBox.Bottom)
//         {
//             _position.Y = _playAreaBoundingBox.Bottom - _dimensions.Y;
//         }
//     }

//     private Texture2D CreatePixel(GraphicsDevice graphicsDevice, Color colour)
//     {
//         Texture2D pixel = new Texture2D(graphicsDevice, 1, 1);
//         pixel.SetData(new[] { colour });
//         return pixel;
//     }
// }