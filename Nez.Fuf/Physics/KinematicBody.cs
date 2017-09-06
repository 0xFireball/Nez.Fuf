using System;
using Microsoft.Xna.Framework;

namespace Nez.Fuf.Physics
{
    public class KinematicBody : PhysicsBody, IUpdatable
    {
        public Vector2 drag { get; set; } = Vector2.Zero;
        public Vector2 acceleration { get; set; } = Vector2.Zero;

        public Vector2 maxVelocity { get; set; } = Vector2.Zero;

        public float angle
        {
            get => entity.transform.localRotation;
            set => entity.transform.localRotation = value;
        }

        public float angularVelocity { get; set; } = 0;
        public float angularDrag { get; set; } = 0;
        public float angularAcceleration { get; set; } = 0;

        public float maxAngular { get; set; } = 0;

        private Vector2 _precisePosition;
        private Vector2 _lastPosition;

        public override void initialize()
        {
            _precisePosition = entity.position;
            
            base.initialize();
        }

        public virtual void update()
        {
            updateMotion(Time.deltaTime);
        }

        public (Vector2, Vector2) computeLinearDeltas(float dt)
        {
            var posDelta = Vector2.Zero;
            var velDelta = Vector2.Zero;

            float velocityDelta;

            velocityDelta =
                0.5f * (computeVelocity(velocity.X, acceleration.X, drag.X, maxVelocity.X, dt) - velocity.X);
            velDelta.X += velocityDelta;
            var delta = (velocity.X + velDelta.X) * dt;
            velDelta.X += velocityDelta;
            posDelta.X += delta;

            velocityDelta =
                0.5f * (computeVelocity(velocity.Y, acceleration.Y, drag.Y, maxVelocity.Y, dt) - velocity.Y);
            velDelta.Y += velocityDelta;
            delta = (velocity.Y + velDelta.Y) * dt;
            velDelta.Y += velocityDelta;
            posDelta.Y += delta;

            return (posDelta, velDelta);
        }

        public void updateMotion(float dt)
        {
            if (_lastPosition != entity.position)
            {
                // The entity teleported, the _precisePosition must be updated
                _precisePosition = entity.position;
            }
            
            var velocityDelta =
                0.5f * (computeVelocity(angularVelocity, angularAcceleration, angularDrag, maxAngular, dt) -
                        angularVelocity);
            angularVelocity += velocityDelta;
            angle += angularVelocity * dt;
            angularVelocity += velocityDelta;

            (var posDelta, var velDelta) = computeLinearDeltas(dt);

            _precisePosition += posDelta;
            velocity += velDelta;
            entity.position = _precisePosition;
            _lastPosition = entity.position;
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