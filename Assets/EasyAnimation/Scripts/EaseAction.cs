using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EsayAnimation {

    public enum EaseActionMethod
    {
        Linear, SineEaseIn, SineEaseOut, SineEaseInOut, BounceEaseOut, BackEaseOut, BackEaseIn, CubicEaseOut, CubicEaseIn, CubicEaseInOut
    }
    /// <summary>
    /// 缓动函数集
    /// </summary>
    public static class EaseAction
    {

        public static float GetEaseAction(EaseActionMethod ease_type , float x) {
            switch (ease_type) {
                case EaseActionMethod.BackEaseIn:
                    return BackEaseIn(x, 0, 1, 1);
                case EaseActionMethod.BackEaseOut:
                    return BackEaseOut(x, 0, 1, 1);
                case EaseActionMethod.BounceEaseOut:
                    return BounceEaseOut(x, 0, 1, 1);
                case EaseActionMethod.Linear:
                    return Linear(x, 0, 1, 1);
                case EaseActionMethod.SineEaseIn:
                    return SineEaseIn(x, 0, 1, 1);
                case EaseActionMethod.SineEaseInOut:
                    return SineEaseInOut(x, 0, 1, 1);
                case EaseActionMethod.SineEaseOut:
                    return SineEaseOut(x, 0, 1, 1);
                case EaseActionMethod.CubicEaseIn:
                    return CubicEaseIn(x, 0, 1, 1);
                case EaseActionMethod.CubicEaseInOut:
                    return CubicEaseInOut(x, 0, 1, 1);
                case EaseActionMethod.CubicEaseOut:
                    return CubicEaseOut(x, 0, 1, 1);
                default:
                    return x;
            }
        }

        static float Linear(float t, float b, float c, float d)
        {
            return c * t / d + b;
        }

        static float SineEaseIn(float t, float b, float c, float d)
        {
            return -c * Mathf.Cos(t / d * (Mathf.PI / 2)) + c + b;
        }

        static float SineEaseOut(float t, float b, float c, float d)
        {
            return c * Mathf.Sin(t / d * (Mathf.PI / 2)) + b;
        }

        static float SineEaseInOut(float t, float b, float c, float d)
        {
            if ((t /= d / 2) < 1)
                return c / 2 * (Mathf.Sin(Mathf.PI * t / 2)) + b;

            return -c / 2 * (Mathf.Cos(Mathf.PI * --t / 2) - 2) + b;
        }

        static float BounceEaseOut(float t, float b, float c, float d)
        {
            if ((t /= d) < (1 / 2.75f))
                return c * (7.5625f * t * t) + b;
            else if (t < (2 / 2.75f))
                return c * (7.5625f * (t -= (1.5f / 2.75f)) * t + 0.75f) + b;
            else if (t < (2.5f / 2.75f))
                return c * (7.5625f * (t -= (2.25f / 2.75f)) * t + 0.9375f) + b;
            else
                return c * (7.5625f * (t -= (2.625f / 2.75f)) * t + .984375f) + b;
        }

        static float BackEaseOut(float t, float b, float c, float d)
        {
            return c * ((t = t / d - 1) * t * ((1.70158f + 1) * t + 1.70158f) + 1) + b;
        }

        static float BackEaseIn(float t, float b, float c, float d)
        {
            return c * (t /= d) * t * ((1.70158f + 1) * t - 1.70158f) + b;
        }

        static float CubicEaseOut(float t, float b, float c, float d)
        {
            return c * ((t = t / d - 1) * t * t + 1) + b;
        }

        static float CubicEaseIn(float t, float b, float c, float d)
        {
            return c * (t /= d) * t * t + b;
        }

        public static float CubicEaseInOut(float t, float b, float c, float d)
        {
            if ((t /= d / 2) < 1)
                return c / 2 * t * t * t + b;

            return c / 2 * ((t -= 2) * t * t + 2) + b;
        }
    }
}