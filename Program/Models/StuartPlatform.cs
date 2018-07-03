using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Math;

namespace Program.Models
{
    public class StuartPlatform
    {
        public Platform BasePlatform { get; private set; }
        public Platform WorkPlatform { get; private set; }
        public Actuator[] Actuators { get; set; } = new Actuator[6];

        public StuartPlatform(double baseAngle, double baseRadius, double workAngle, double workRadius, double actuatorMin, double actuatorMax)
        {
            BasePlatform = new Platform(baseAngle, baseRadius);
            WorkPlatform = new Platform(workAngle, workRadius);
            for (int N = 0; N < Actuators.Length; N++)
                Actuators[N] = new Actuator(this, N) { MinLength = actuatorMin, MaxLength = actuatorMax };
        }

        /// <summary>
        /// Translate work platform by vector 't'
        /// </summary>
        /// <param name="t">Translation vector</param>
        public void Move(Vector3D t)
        {
            WorkPlatform.Position += WorkPlatform.Q.Rotate(t);
        }

        /// <summary>
        /// Rotate work platform by 'Q'
        /// </summary>
        /// <param name="R">Rotation matrix</param>
        public void Move(Quaternion Q)
        {
            WorkPlatform.Q = Q * WorkPlatform.Q;
        }

        /// <summary>
        /// Rotate work platform by 'Q' and then translate by vector 't'
        /// </summary>
        /// <param name="Q">Rotation matrix</param>
        /// <param name="t">Translation vector</param>
        public void Move(Quaternion Q, Vector3D t)
        {
            WorkPlatform.Q = Q * WorkPlatform.Q;
            WorkPlatform.Position += WorkPlatform.Q.Rotate(t);
        }


        // Parts classes

        public class Platform
        {
            public Vector3D Position { get; set; } = new Vector3D(0, 0, 0);
            public Quaternion Q { get; set; } = Quaternion.I;

            /// <summary>
            /// Distance of the joints from center of the platform. 
            /// Update GUI after changing this property
            /// </summary>
            public double Radius
            {
                get { return radius; }
                set {
                    radius = value;
                    SetJoints();
                }
            }
            public double Diameter
            { 
                get {
                    return 2 * radius;
                }
            }
            private double radius = 1.0;

            /// <summary>
            /// Angle between pair of joints: {0, 120, 240}[deg] +/- {angle/2}[deg]. 
            /// Update GUI after changing this property
            /// </summary>
            public double Angle
            {
                get { return angle; }
                set {
                    angle = value;
                    SetJoints();
                }
            } 
            private double angle = 10.0;

            public Joint[] Joints { get; private set; } = new Joint[6];

            public Platform(double angle, double radius)
            {
                Angle = angle;
                Radius = radius;
                SetJoints();
            }

            private void SetJoints()
            {
                for (int N = 0; N < 6; N++)
                {
                    int sign = (N % 2) == 0 ? 1 : -1;
                    Vector2D c = Misc.PolarToCartesian(Radius, Misc.DegToRad(N * 120 + sign * Angle / 2));

                    Joints[N] = new Joint(new Vector3D(c.X, c.Y, 0.0), this);
                }
            }

        }

        public class Joint
        {
            private Platform parent;

            private Vector3D position = new Vector3D(0, 0, 0);
            public Vector3D Position
            {
                get {
                    return parent.Position + parent.Q.Rotate(position);
                }
            }


            public Joint(Vector3D position, Platform parent)
            {
                this.parent = parent;
                this.position = position;
            }
        }

        public class Actuator
        {
            private int id;
            private StuartPlatform owner;

            public Vector3D BaseEnd
            {
                get {
                    return (owner.WorkPlatform.Joints[id].Position - owner.BasePlatform.Joints[id].Position).Normalized() * MinLength + owner.BasePlatform.Joints[id].Position;
                }
            }
            public double MinLength { get; set; } = 0.5;
            public double MaxLength { get; set; } = 1.0;
            public double ActualLength
            {
                get {
                    return (owner.WorkPlatform.Joints[id].Position - owner.BasePlatform.Joints[id].Position).Length;
                }
            }

            public Actuator(StuartPlatform owner, int id)
            {
                this.owner = owner;
                this.id = id;
            }
        }
    }
}
