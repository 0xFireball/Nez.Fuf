using System;
using Microsoft.Xna.Framework;
using Nez;

namespace Nez.Fuf.Physics
{
	public class KinematicBody2D : Component, IUpdatable
	{
		public Vector2 velocity { get; set; } = Vector2.Zero;
		public Vector2 drag { get; set; } = Vector2.Zero;
		public Vector2 acceleration { get; set; } = Vector2.Zero;

		public Vector2 maxVelocity { get; set; } = Vector2.Zero;

		public float angle
		{
			get { return entity.transform.rotation; }
			set { entity.transform.rotation = value; }
		}

		public float angularVelocity { get; set; } = 0;
		public float angularDrag { get; set; } = 0;
		public float angularAcceleration { get; set; } = 0;

		public float maxAngular { get; set; } = 0;

		public virtual void update()
		{
			updateMotion(Time.deltaTime);
		}

		public void updateMotion(float dt)
		{
			var velocityDelta = 0.5f * (computeVelocity(angularVelocity, angularAcceleration, angularDrag, maxAngular, dt) - angularVelocity);
			angularVelocity += velocityDelta;
			angle += angularVelocity * dt;
			angularVelocity += velocityDelta;

			var newPos = entity.position;
			var newVel = velocity;

			velocityDelta = 0.5f * (computeVelocity(velocity.X, acceleration.X, drag.X, maxVelocity.X, dt) - velocity.X);
			newVel.X += velocityDelta;
			var delta = newVel.X * dt;
			newVel.X += velocityDelta;
			newPos.X += delta;

			velocityDelta = 0.5f * (computeVelocity(velocity.Y, acceleration.Y, drag.Y, maxVelocity.Y, dt) - velocity.Y);
			newVel.Y += velocityDelta;
			delta = newVel.Y * dt;
			newVel.Y += velocityDelta;
			newPos.Y += delta;

			entity.position = newPos;
			velocity = newVel;
		}

		private float computeVelocity(float vel, float acc, float drg, float max, float dt)
		{
			if (Math.Abs(acc) > 0)
			{
				vel += acc * dt;
			}
			else if (Math.Abs(drg) > 0)
			{
				var tDrg = drg * dt;
				if (vel - tDrg > 0)
				{
					vel -= tDrg;
				}
				else if (vel + tDrg < 0)
				{
					vel += tDrg;
				}
				else
				{
					vel = 0;
				}
			}

			if (Math.Abs(vel) > 0 && Math.Abs(max) > 0)
			{
				if (vel > max)
				{
					vel = max;
				}
				else if (vel < -max)
				{
					vel = -max;
				}
			}
			return vel;
		}
	}
}
