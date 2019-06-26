using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Robocode;
using Robocode.RobotInterfaces;

namespace CVOS
{
    class MyRobot : Robot
    {
        bool peek; // Don't turn if there's a robot there
        double moveAmount; // How much to move
        public override void Run()
        {
            SetAllColors(Color.Purple);
            BulletColor = Color.Cyan;
            // Initialize moveAmount to the maximum possible for this battlefield.
            moveAmount = Math.Max(BattleFieldWidth, BattleFieldHeight);
            // Initialize peek to false
            peek = false;

            // turnLeft to face a wall.
            // getHeading() % 90 means the remainder of
            // getHeading() divided by 90.
            TurnLeft(Heading % 90);
            Ahead(moveAmount);
            // Turn the gun to turn right 90 degrees.
            peek = true;
            TurnGunRight(90);
            TurnRight(90);
            while (true)
            {
                // Look before we turn when ahead() completes.
                peek = true;
                // Move up the wall
                Ahead(moveAmount);
                // Don't look now
                peek = false;
                // Turn to the next wall
                TurnRight(90);
            }
        }

        //public override void OnStatus(StatusEvent e)
        //{
        //    base.OnStatus(e);
        //    robotStatus = e.Status;
        //}

        // Robot event handler, when the robot sees another robot
        public override void OnScannedRobot(ScannedRobotEvent e)
        {
            //double absoluteBearing = Heading + e.Bearing;
            //double bearingFromGun = Robocode.Util.Utils.NormalRelativeAngleDegrees(absoluteBearing - GunHeading);

            //// If it's close enough, fire!
            //if (Math.Abs(bearingFromGun) <= 3)
            //{
            //    TurnGunRight(bearingFromGun);
            //    // We check gun heat here, because calling fire()
            //    // uses a turn, which could cause us to lose track
            //    // of the other robot.
            //    if (GunHeat == 0)
            //    {
            //        Fire(Math.Min(3 - Math.Abs(bearingFromGun), Energy - .1));
            //    }
            //} // otherwise just set the gun to turn.
            //  // Note:  This will have no effect until we call scan()
            //else
            //{
            //    Fire(1);

            //    //TurnGunRight(bearingFromGun);
            //}
            //// Generates another scan event if we see a robot.
            //// We only need to call this if the gun (and therefore radar)
            //// are not turning.  Otherwise, scan is called automatically.
            //if (bearingFromGun == 0)
            //{
            //    Scan();
            //}

            //TurnGunRight(Heading - GunHeading + e.Bearing);
            if (GunHeat == 0)
            {
                //double bearingFromGun = Robocode.Util.Utils.NormalRelativeAngleDegrees(Heading + e.Bearing - GunHeading);
               // TurnGunRight(bearingFromGun);
                Fire(Math.Min((400 / e.Distance), 3));
            }
            if (peek)
            {
                Scan();
            }


        }

        public override void OnHitRobot(HitRobotEvent evnt)
        {
            if (evnt.Bearing > -90 && evnt.Bearing < 90)
            {
                Back(100);
            } // else he's in back of us, so set ahead a bit.
            else
            {
                Ahead(100);
            }
            base.OnHitRobot(evnt);
        }

        public override void OnHitByBullet(HitByBulletEvent evnt)
        {
            //TurnRight(45);
            //Back(100);
            base.OnHitByBullet(evnt);
        }
        //public override void OnHitWall(HitWallEvent evnt)
        //{
        //    ReverseDirection();
        //    base.OnHitWall(evnt);
        //}
        //public void ReverseDirection()
        //{
        //    if (movingForward)
        //    {
        //        Back(500);
        //        movingForward = false;
        //    }
        //    else
        //    {
        //        Ahead(500);
        //        movingForward = true;
        //    }
        //}
        public override void OnWin(WinEvent evnt)
        {
            base.OnWin(evnt);
            TurnRight(36000);
        }
    }
}

