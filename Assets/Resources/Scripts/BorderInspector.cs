using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class BorderInspector
    {
        public static float GameBorderLeft = -12.5f;
        public static float GameBorderRight = 12.5f;
        public static float GameBorderUp = 6.9f;
        public static float GameBorderDown = -6.9f;

        //是否到达游戏上边界
        public static bool OnUpBorder(Vector3 pos)
        {
            if (pos.y > GameBorderUp)
            {
                return true;
            }
            return false;
        }
        //是否到达游戏下边界
        public static bool OnDownBorder(Vector3 pos)
        {
            if (pos.y < GameBorderDown)
            {
                return true;
            }
            return false;
        }
        //是否到达游戏左边界
        public static bool OnLeftBorder(Vector3 pos)
        {
            if (pos.x < GameBorderLeft)
            {
                return true;
            }
            return false;
        }
        //是否到达游戏右边界
        public static bool OnRightBorder(Vector3 pos)
        {
            if (pos.x > GameBorderRight)
            {
                return true;
            }
            return false;
        }

        //检测是否到达游戏边界
        public static bool Onborder(Vector3 pos)
        {
            if (pos.y > GameBorderUp)
            {
                return true;
            }
            if (pos.y < GameBorderDown)
            {
                return true;
            }
            if (pos.x < GameBorderLeft)
            {
                return true;
            }
            if (pos.x > GameBorderRight)
            {
                return true;
            }
            return false;
        }
    }
}


