using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasyAnimation {

    public enum EaseActionMethod
    {
        Linear,

        Spring,

        InQuad,
        OutQuad,
        InOutQuad,

        InCubic,
        OutCubic,
        InOutCubic,

        InQuart,
        OutQuart,
        InOutQuart,

        InQuint,
        OutQuint,
        InOutQuint,

        InSine,
        OutSine,
        InOutSine,

        InExpo,
        OutExpo,
        InOutExpo,

        InCirc,
        OutCirc,
        InOutCirc,

        InBounce,
        OutBounce,
        InOutBounce,

        InBack,
        OutBack,
        InOutBack,

        InElastic,
        OutElastic,
        InOutElastic,
    }
    /// <summary>
    /// 缓动函数集
    /// </summary>
    public static class EaseAction
    {

        public static float GetEaseAction(EaseActionMethod ease_type , float x) {
            switch (ease_type) {

                case EaseActionMethod.InBack:
                    return InBack(0, 1, x);
                case EaseActionMethod.InBounce:
                    return InBounce(0, 1, x);
                case EaseActionMethod.InCirc:
                    return InCirc(0, 1, x);
                case EaseActionMethod.InCubic:
                    return InCubic(0, 1, x);
                case EaseActionMethod.InElastic:
                    return InElastic(0, 1, x);
                case EaseActionMethod.InExpo:
                    return InExpo(0, 1, x);
                case EaseActionMethod.InOutBack:
                    return InOutBack(0, 1, x);
                case EaseActionMethod.InOutBounce:
                    return InOutBounce(0, 1, x);
                case EaseActionMethod.InOutCirc:
                    return InOutCirc(0, 1, x);
                case EaseActionMethod.InOutCubic:
                    return InOutCubic(0, 1, x);
                case EaseActionMethod.InOutElastic:
                    return InOutElastic(0, 1, x);
                case EaseActionMethod.InOutExpo:
                    return InOutExpo(0, 1, x);
                case EaseActionMethod.InOutQuad:
                    return InOutQuad(0, 1, x);
                case EaseActionMethod.InOutQuart:
                    return InOutQuart(0, 1, x);
                case EaseActionMethod.InOutQuint:
                    return InOutQuint(0, 1, x);
                case EaseActionMethod.InOutSine:
                    return InOutSine(0, 1, x);
                case EaseActionMethod.InQuad:
                    return InQuad(0, 1, x);
                case EaseActionMethod.InQuart:
                    return InQuart(0, 1, x);
                case EaseActionMethod.InQuint:
                    return InQuint(0, 1, x);
                case EaseActionMethod.InSine:
                    return InSine(0, 1, x);
                case EaseActionMethod.Linear:
                    return Linear(0, 1, x);
                case EaseActionMethod.OutBack:
                    return OutBack(0, 1, x);
                case EaseActionMethod.OutBounce:
                    return OutBounce(0, 1, x);
                case EaseActionMethod.OutCirc:
                    return OutCirc(0, 1, x);
                case EaseActionMethod.OutCubic:
                    return OutCubic(0, 1, x);
                case EaseActionMethod.OutElastic:
                    return OutElastic(0, 1, x);
                case EaseActionMethod.OutExpo:
                    return OutExpo(0, 1, x);
                case EaseActionMethod.OutQuad:
                    return OutQuad(0, 1, x);
                case EaseActionMethod.OutQuart:
                    return OutQuart(0, 1, x);
                case EaseActionMethod.OutQuint:
                    return OutQuint(0, 1, x);
                case EaseActionMethod.OutSine:
                    return OutSine(0, 1, x);
                case EaseActionMethod.Spring:
                    return Spring(0, 1, x);
                default:
                    return x;
            }
        }



        //2018-8-13 新增

        public static float Linear(float start, float end, float value)
        {
            return Mathf.Lerp(start, end, value);
        }

        public static float Spring(float start, float end, float value)
        {
            value = Mathf.Clamp01(value);
            value = (Mathf.Sin(value * Mathf.PI * (0.2f + 2.5f * value * value * value)) * Mathf.Pow(1f - value, 2.2f) + value) * (1f + (1.2f * (1f - value)));
            return start + (end - start) * value;
        }

        public static float InQuad(float start, float end, float value)
        {
            end -= start;
            return end * value * value + start;
        }

        public static float OutQuad(float start, float end, float value)
        {
            end -= start;
            return -end * value * (value - 2) + start;
        }

        public static float InOutQuad(float start, float end, float value)
        {
            value /= .5f;
            end -= start;
            if (value < 1) return end / 2 * value * value + start;
            value--;
            return -end / 2 * (value * (value - 2) - 1) + start;
        }

        public static float InCubic(float start, float end, float value)
        {
            end -= start;
            return end * value * value * value + start;
        }

        public static float OutCubic(float start, float end, float value)
        {
            value--;
            end -= start;
            return end * (value * value * value + 1) + start;
        }

        public static float InOutCubic(float start, float end, float value)
        {
            value /= .5f;
            end -= start;
            if (value < 1) return end / 2 * value * value * value + start;
            value -= 2;
            return end / 2 * (value * value * value + 2) + start;
        }

        public static float InQuart(float start, float end, float value)
        {
            end -= start;
            return end * value * value * value * value + start;
        }

        public static float OutQuart(float start, float end, float value)
        {
            value--;
            end -= start;
            return -end * (value * value * value * value - 1) + start;
        }

        public static float InOutQuart(float start, float end, float value)
        {
            value /= .5f;
            end -= start;
            if (value < 1) return end / 2 * value * value * value * value + start;
            value -= 2;
            return -end / 2 * (value * value * value * value - 2) + start;
        }

        public static float InQuint(float start, float end, float value)
        {
            end -= start;
            return end * value * value * value * value * value + start;
        }

        public static float OutQuint(float start, float end, float value)
        {
            value--;
            end -= start;
            return end * (value * value * value * value * value + 1) + start;
        }

        public static float InOutQuint(float start, float end, float value)
        {
            value /= .5f;
            end -= start;
            if (value < 1) return end / 2 * value * value * value * value * value + start;
            value -= 2;
            return end / 2 * (value * value * value * value * value + 2) + start;
        }

        public static float InSine(float start, float end, float value)
        {
            end -= start;
            return -end * Mathf.Cos(value / 1 * (Mathf.PI / 2)) + end + start;
        }

        public static float OutSine(float start, float end, float value)
        {
            end -= start;
            return end * Mathf.Sin(value / 1 * (Mathf.PI / 2)) + start;
        }

        public static float InOutSine(float start, float end, float value)
        {
            end -= start;
            return -end / 2 * (Mathf.Cos(Mathf.PI * value / 1) - 1) + start;
        }

        public static float InExpo(float start, float end, float value)
        {
            end -= start;
            return end * Mathf.Pow(2, 10 * (value / 1 - 1)) + start;
        }

        public static float OutExpo(float start, float end, float value)
        {
            end -= start;
            return end * (-Mathf.Pow(2, -10 * value / 1) + 1) + start;
        }

        public static float InOutExpo(float start, float end, float value)
        {
            value /= .5f;
            end -= start;
            if (value < 1) return end / 2 * Mathf.Pow(2, 10 * (value - 1)) + start;
            value--;
            return end / 2 * (-Mathf.Pow(2, -10 * value) + 2) + start;
        }

        public static float InCirc(float start, float end, float value)
        {
            end -= start;
            return -end * (Mathf.Sqrt(1 - value * value) - 1) + start;
        }

        public static float OutCirc(float start, float end, float value)
        {
            value--;
            end -= start;
            return end * Mathf.Sqrt(1 - value * value) + start;
        }

        public static float InOutCirc(float start, float end, float value)
        {
            value /= .5f;
            end -= start;
            if (value < 1) return -end / 2 * (Mathf.Sqrt(1 - value * value) - 1) + start;
            value -= 2;
            return end / 2 * (Mathf.Sqrt(1 - value * value) + 1) + start;
        }

        public static float InBounce(float start, float end, float value)
        {
            end -= start;
            float d = 1f;
            return end - OutBounce(0, end, d - value) + start;
        }

        public static float OutBounce(float start, float end, float value)
        {
            value /= 1f;
            end -= start;
            if (value < (1 / 2.75f))
            {
                return end * (7.5625f * value * value) + start;
            }
            else if (value < (2 / 2.75f))
            {
                value -= (1.5f / 2.75f);
                return end * (7.5625f * (value) * value + .75f) + start;
            }
            else if (value < (2.5 / 2.75))
            {
                value -= (2.25f / 2.75f);
                return end * (7.5625f * (value) * value + .9375f) + start;
            }
            else
            {
                value -= (2.625f / 2.75f);
                return end * (7.5625f * (value) * value + .984375f) + start;
            }
        }

        public static float InOutBounce(float start, float end, float value)
        {
            end -= start;
            float d = 1f;
            if (value < d / 2) return InBounce(0, end, value * 2) * 0.5f + start;
            else return OutBounce(0, end, value * 2 - d) * 0.5f + end * 0.5f + start;
        }

        public static float InBack(float start, float end, float value)
        {
            end -= start;
            value /= 1;
            float s = 1.70158f;
            return end * (value) * value * ((s + 1) * value - s) + start;
        }

        public static float OutBack(float start, float end, float value)
        {
            float s = 1.70158f;
            end -= start;
            value = (value / 1) - 1;
            return end * ((value) * value * ((s + 1) * value + s) + 1) + start;
        }

        public static float InOutBack(float start, float end, float value)
        {
            float s = 1.70158f;
            end -= start;
            value /= .5f;
            if ((value) < 1)
            {
                s *= (1.525f);
                return end / 2 * (value * value * (((s) + 1) * value - s)) + start;
            }
            value -= 2;
            s *= (1.525f);
            return end / 2 * ((value) * value * (((s) + 1) * value + s) + 2) + start;
        }

        public static float InElastic(float start, float end, float value)
        {
            end -= start;

            float d = 1f;
            float p = d * .3f;
            float s = 0;
            float a = 0;

            if (value == 0) return start;

            if ((value /= d) == 1) return start + end;

            if (a == 0f || a < Mathf.Abs(end))
            {
                a = end;
                s = p / 4;
            }
            else
            {
                s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
            }

            return -(a * Mathf.Pow(2, 10 * (value -= 1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p)) + start;
        }

        public static float OutElastic(float start, float end, float value)
        {
            end -= start;

            float d = 1f;
            float p = d * .3f;
            float s = 0;
            float a = 0;

            if (value == 0) return start;

            if ((value /= d) == 1) return start + end;

            if (a == 0f || a < Mathf.Abs(end))
            {
                a = end;
                s = p / 4;
            }
            else
            {
                s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
            }

            return (a * Mathf.Pow(2, -10 * value) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p) + end + start);
        }

        public static float InOutElastic(float start, float end, float value)
        {
            end -= start;

            float d = 1f;
            float p = d * .3f;
            float s = 0;
            float a = 0;

            if (value == 0) return start;

            if ((value /= d / 2) == 2) return start + end;

            if (a == 0f || a < Mathf.Abs(end))
            {
                a = end;
                s = p / 4;
            }
            else
            {
                s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
            }

            if (value < 1) return -0.5f * (a * Mathf.Pow(2, 10 * (value -= 1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p)) + start;
            return a * Mathf.Pow(2, -10 * (value -= 1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p) * 0.5f + end + start;
        }

        static float Punch(float amplitude, float value)
        {
            float s = 9;
            if (value == 0)
            {
                return 0;
            }
            if (value == 1)
            {
                return 0;
            }
            float period = 1 * 0.3f;
            s = period / (2 * Mathf.PI) * Mathf.Asin(0);
            return (amplitude * Mathf.Pow(2, -10 * value) * Mathf.Sin((value * 1 - s) * (2 * Mathf.PI) / period));
        }

        static float Clerp(float start, float end, float value)
        {
            float min = 0.0f;
            float max = 360.0f;
            float half = Mathf.Abs((max - min) / 2.0f);
            float retval = 0.0f;
            float diff = 0.0f;
            if ((end - start) < -half)
            {
                diff = ((max - start) + end) * value;
                retval = start + diff;
            }
            else if ((end - start) > half)
            {
                diff = -((max - end) + start) * value;
                retval = start + diff;
            }
            else retval = start + (end - start) * value;
            return retval;
        }

    }
}