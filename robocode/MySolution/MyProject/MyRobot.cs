using System;
using System.Drawing;
using Robocode;

namespace CVOS
{
    class MyRobot : Robot
    {
        bool peek;
        double moveAmount;
        public override void Run()
        {
            SetAllColors(Color.Purple);
            BulletColor = Color.Cyan;

            moveAmount = Math.Max(BattleFieldWidth, BattleFieldHeight);
            peek = false;
            TurnLeft(Heading % 90);
            Ahead(moveAmount);
            peek = true;
            TurnGunRight(90);
            TurnRight(90);
            while (true)
            {
                peek = true;
                Ahead(moveAmount);
                peek = false;
                TurnRight(90);
            }
        }

        public override void OnScannedRobot(ScannedRobotEvent e)
        {
            if (GunHeat == 0)
                Fire(Math.Min((400 / e.Distance), 3));
            if (peek)
                Scan();
        }

        public override void OnHitRobot(HitRobotEvent evnt)
        {
            base.OnHitRobot(evnt);

            if (evnt.Bearing > -90 && evnt.Bearing < 90)
                Back(100);
            else
                Ahead(100);
        }
    }
}

