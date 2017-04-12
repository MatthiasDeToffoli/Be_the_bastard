using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    class HourInfo
    {
        public static int hours = 9;
        public static int minutes = 0;

        public static Vector2 getHour() {
            return new Vector2(hours, minutes);
        }

        public static void reset()
        {
            hours = 9;
            minutes = 0;
        }
    }
}
