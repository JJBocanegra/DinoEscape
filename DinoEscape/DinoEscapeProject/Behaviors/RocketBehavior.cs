#region Using Statements
using System;
using WaveEngine.Common.Input;
using WaveEngine.Framework;
using WaveEngine.Framework.Diagnostic;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Services;
#endregion

namespace DinoEscapeProject.Behaviors
{
    class RocketBehavior : Behavior
    {
        [RequiredComponent]
        private Transform2D transform2D;
        
        private int speed;
        private int maneuverability;
        private float rotationLimit;    //Angulo limite en el que puede girar la nave

        private float offset;

        protected override void Initialize()
        {
            base.Initialize();

            speed   = 500;
            maneuverability = 1;
            rotationLimit = 0.5f;

            offset  = (transform2D.Rectangle.Width / 2) * transform2D.XScale;

            transform2D.Y = (float)(WaveServices.ViewportManager.VirtualHeight - (transform2D.Rectangle.Height * 0.75f) * transform2D.XScale);
        }

        protected override void Update(TimeSpan gameTime)
        {
            Move(gameTime);
        }

        private void Move(TimeSpan gameTime)
        {
            float calculatedSpeed       = speed * (float)gameTime.TotalSeconds;
            float calculatedRotation    = maneuverability * (float)gameTime.TotalSeconds;
            float X                     = transform2D.X;
            KeyboardState keyState      = WaveServices.Input.KeyboardState;

            Labels.Add("Rotation", transform2D.Rotation.ToString());
            Labels.Add("Offset", offset.ToString());
            Labels.Add("X", X.ToString());
            Labels.Add("calculatedSpeed", calculatedSpeed.ToString());
            Labels.Add("calculatedRotation", calculatedRotation.ToString());

            if (keyState.IsConnected)
            {
                if ((keyState.Left == ButtonState.Pressed || keyState.A == ButtonState.Pressed)
                    && X > offset
                    && transform2D.Rotation > -rotationLimit)
                {
                        transform2D.Rotation -= calculatedRotation;
                }
                else if ((keyState.Right == ButtonState.Pressed || keyState.D == ButtonState.Pressed)
                    && X < WaveServices.ViewportManager.VirtualWidth - offset
                    && transform2D.Rotation < rotationLimit)
                {
                        transform2D.Rotation += calculatedRotation;
                }
                else
                    StabilizeRocket(transform2D.Rotation, calculatedRotation, rotationLimit);

                //Segun la rotacion que tenga la nave, se movera a un lado u otro
                if (transform2D.Rotation < 0)
                    X -= calculatedSpeed * -transform2D.Rotation;
                else if (transform2D.Rotation > 0)
                    X += calculatedSpeed * transform2D.Rotation;

                //Evitamos que sobresalga por los bordes
                if (X < offset)
                    X = offset;
                else if (X > WaveServices.ViewportManager.VirtualWidth - offset)
                    X = WaveServices.ViewportManager.VirtualWidth - offset;

                transform2D.X = X;
            }
        }

        private void StabilizeRocket(float rotation, float calculatedRotation, float rotationLimit)
        {
            if (rotation > 0.05f)
                rotation -= calculatedRotation;
            else if (rotation < -0.05f)
                rotation += calculatedRotation;
            else
                rotation = 0; 

            transform2D.Rotation = rotation;
        }
    }
}
