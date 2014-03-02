using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Night
{
	public class Camera2D
	{
		public Matrix Transform;
		public Vector2 Position; 
		public Vector2 ViewPortSize;
		protected float Rotation; 

		protected float mZoom;
		public float Zoom
		{
			get { return mZoom; }
			set { mZoom = value; if (mZoom < 0.1f) mZoom = 0.1f; } 
		}

		float MoveSpeed;
		public Vector2 Origin;
		Vector2 ScreenCenter;
		public Vector2 Focus;

		public void Initialize(Vector2 viewPortSize)
		{
			Zoom = 1.0f;
			Rotation = 0.0f;
			MoveSpeed = 1.25f;
			Position = Vector2.Zero;

			ViewPortSize = viewPortSize;
			ScreenCenter = new Vector2(ViewPortSize.X/2, ViewPortSize.Y/2);

		}

		public Matrix getTransformation()
		{
			Transform =       
				Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0)) *
				Matrix.CreateRotationZ(Rotation) *
				Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
				Matrix.CreateTranslation(new Vector3(ViewPortSize.X * 0.5f, ViewPortSize.Y * 0.5f, 0));
			return Transform;
		}

		public void Update(GameTime gameTime)
		{
			Origin = ScreenCenter / Zoom;

			// Move the Camera to the position that it needs to go
			var delta = (float) gameTime.ElapsedGameTime.TotalSeconds;

			Position.X += (Focus.X - Position.X) * MoveSpeed * delta;
			Position.Y += (Focus.Y - Position.Y) * MoveSpeed * delta;
		}

		// NON TESTE
		public bool IsInView(Vector2 position, Texture2D texture)
		{
			// If the object is not within the horizontal bounds of the screen
			if ( (position.X + texture.Width) < (Position.X - Origin.X) || (position.X) > (Position.X + Origin.X) )
				return false;

			// If the object is not within the vertical bounds of the screen
			if ((position.Y + texture.Height) < (Position.Y - Origin.Y) || (position.Y) > (Position.Y + Origin.Y))
				return false;

			// In View
			return true;
		}
	}
}

