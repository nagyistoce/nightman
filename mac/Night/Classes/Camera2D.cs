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

		public void Update(GameTime gameTime, Vector2 focusPos)
		{
			Focus = focusPos;

			Origin = ScreenCenter / Zoom;

			// Move the Camera to the position that it needs to go
			var delta = (float) gameTime.ElapsedGameTime.TotalSeconds;

			Position.X += (Focus.X - Position.X) * MoveSpeed * delta;
			Position.Y += (Focus.Y - Position.Y) * MoveSpeed * delta;
		}

		public Vector2 getTopLeftView()
		{
			return new Vector2 (Position.X - ViewPortSize.X / 2, Position.Y - ViewPortSize.Y / 2); 
		}

		public Vector2 getWorldPosition(Vector2 screenPosition)
		{
			return Vector2.Transform (screenPosition, Matrix.Invert(this.getTransformation()));
		}
	}
}

