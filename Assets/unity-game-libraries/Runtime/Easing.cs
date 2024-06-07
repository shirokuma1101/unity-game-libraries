using System;
using UnityEngine;

namespace UGL.Easing
{
    public static class Easing
    {
        public enum EasingType
        {
            Linear,
            SineIn,
            SineOut,
            SineInOut,
            QuadIn,
            QuadOut,
            QuadInOut,
            CubicIn,
            CubicOut,
            CubicInOut,
            QuartIn,
            QuartOut,
            QuartInOut,
            QuintIn,
            QuintOut,
            QuintInOut,
            ExpoIn,
            ExpoOut,
            ExpoInOut,
            CircIn,
            CircOut,
            CircInOut,
            BackIn,
            BackOut,
            BackInOut,
            ElasticIn,
            ElasticOut,
            ElasticInOut,
            BounceIn,
            BounceOut,
            BounceInOut,

            __COUNT__,
            __INVALID__ = -1,
        }

        public static float Linear(float n) => Normalize(n, 0.0f, 1.0f);
        public static class Sine
        {
            public static float In(float n) => 1.0f - Mathf.Cos((n * Mathf.PI) / 2.0f);
            public static float Out(float n) => Mathf.Sin((n * Mathf.PI) / 2.0f);
            public static float InOut(float n) => -(Mathf.Cos(Mathf.PI * n) - 1.0f) / 2.0f;
        }
        public static class Quad
        {
            public static float In(float n) => Easing.In(n, 2.0f);
            public static float Out(float n) => Easing.Out(n, 2.0f);
            public static float InOut(float n) => Easing.InOut(n, 2.0f);
        }
        public static class Cubic
        {
            public static float In(float n) => Easing.In(n, 3.0f);
            public static float Out(float n) => Easing.Out(n, 3.0f);
            public static float InOut(float n) => Easing.InOut(n, 3.0f);
        }
        public static class Quart
        {
            public static float In(float n) => Easing.In(n, 4.0f);
            public static float Out(float n) => Easing.Out(n, 4.0f);
            public static float InOut(float n) => Easing.InOut(n, 4.0f);
        }
        public static class Quint
        {
            public static float In(float n) => Easing.In(n, 5.0f);
            public static float Out(float n) => Easing.Out(n, 5.0f);
            public static float InOut(float n) => Easing.InOut(n, 5.0f);
        }
        public static class Expo
        {
            public static float In(float n) => n == 0.0f ? 0.0f : Mathf.Pow(2.0f, 10.0f * n - 10.0f);
            public static float Out(float n) => n == 1.0f ? 1.0f : 1.0f - Mathf.Pow(2.0f, -10.0f * n);
            public static float InOut(float n)
                => n == 0.0f
                ? 0.0f
                : n == 1.0f
                ? 1.0f
                : n < 0.5f ? Mathf.Pow(2.0f, 20.0f * n - 10.0f) / 2.0f
                : (2.0f - Mathf.Pow(2.0f, -20.0f * n + 10.0f)) / 2.0f;
        }
        public static class Circ
        {
            public static float In(float n) => 1.0f - Mathf.Sqrt(1.0f - Mathf.Pow(n, 2.0f));
            public static float Out(float n) => Mathf.Sqrt(1.0f - Mathf.Pow(n - 1.0f, 2.0f));
            public static float InOut(float n)
                => n < 0.5f
                ? (1.0f - Mathf.Sqrt(1.0f - Mathf.Pow(2.0f * n, 2.0f))) / 2.0f
                : (Mathf.Sqrt(1.0f - Mathf.Pow(-2.0f * n + 2.0f, 2.0f)) + 1.0f) / 2.0f;
        }
        public static class Back
        {
            const float C1 = 1.70158f;
            const float C2 = C1 * 1.525f;
            const float C3 = C1 + 1.0f;


            public static float In(float n) => C3 * n * n * n - C1 * n * n;
            public static float Out(float n) => 1.0f + C3 * Mathf.Pow(n - 1.0f, 3.0f) + C1 * Mathf.Pow(n - 1.0f, 2.0f);
            public static float InOut(float n)
                => n < 0.5f
                ? (Mathf.Pow(2.0f * n, 2.0f) * ((C2 + 1.0f) * 2.0f * n - C2)) / 2.0f
                : (Mathf.Pow(2.0f * n - 2.0f, 2.0f) * ((C2 + 1.0f) * (n * 2.0f - 2.0f) + C2) + 2.0f) / 2.0f;
        }
        public static class Elastic
        {
            const float C4 = (2.0f * Mathf.PI) / 3.0f;
            const float C5 = (2.0f * Mathf.PI) / 4.5f;


            public static float In(float n)
                => n == 0.0f
                ? 0.0f
                : n == 1.0f
                ? 1.0f
                : -Mathf.Pow(2.0f, 10.0f * n - 10.0f) * Mathf.Sin((n * 10.0f - 10.75f) * C4);
            public static float Out(float n)
                => n == 0.0f
                ? 0.0f
                : n == 1.0f
                ? 1.0f
                : Mathf.Pow(2.0f, -10.0f * n) * Mathf.Sin((n * 10.0f - 0.75f) * C4) + 1.0f;
            public static float InOut(float n)
                => n == 0.0f
                ? 0.0f
                : n == 1.0f
                ? 1.0f
                : n < 0.5f
                ? -(Mathf.Pow(2.0f, 20.0f * n - 10.0f) * Mathf.Sin((20.0f * n - 11.125f) * C5)) / 2.0f
                : (Mathf.Pow(2.0f, -20.0f * n + 10.0f) * Mathf.Sin((20.0f * n - 11.125f) * C5)) / 2.0f + 1.0f;
        }
        public static class Bounce
        {
            const float N1 = 7.5625f;
            const float D1 = 2.75f;


            public static float In(float n) => 1.0f - Out(1.0f - n);
            public static float Out(float n)
                => n < 1.0f / D1
                ? N1 * n * n
                : n < 2.0f / D1
                ? N1 * (n -= 1.5f / D1) * n + 0.75f
                : n < 2.5f / D1
                ? N1 * (n -= 2.25f / D1) * n + 0.9375f
                : N1 * (n -= 2.625f / D1) * n + 0.984375f;
            public static float InOut(float n)
                => n < 0.5f
                ? (1.0f - Out(1.0f - 2.0f * n)) / 2.0f
                : (1.0f + Out(2.0f * n - 1.0f)) / 2.0f;
        }

        private static Func<float, float>[] EasingMethodList { get; }
            = new Func<float, float>[]
            {
                Linear,
                Sine.In,
                Sine.Out,
                Sine.InOut,
                Quad.In,
                Quad.Out,
                Quad.InOut,
                Cubic.In,
                Cubic.Out,
                Cubic.InOut,
                Quart.In,
                Quart.Out,
                Quart.InOut,
                Quint.In,
                Quint.Out,
                Quint.InOut,
                Expo.In,
                Expo.Out,
                Expo.InOut,
                Circ.In,
                Circ.Out,
                Circ.InOut,
                Back.In,
                Back.Out,
                Back.InOut,
                Elastic.In,
                Elastic.Out,
                Elastic.InOut,
                Bounce.In,
                Bounce.Out,
                Bounce.InOut,
        };


        /// <summary>
        /// Applies the specified easing function to the given value.
        /// </summary>
        /// <typeparam name="T">The type of the easing function, which must be an enumeration.</typeparam>
        /// <param name="easingType">The type of easing function to apply.</param>
        /// <param name="n">The value to which the easing function is applied.</param>
        /// <returns>A float representing the result of the easing function applied to the value.</returns>
        public static float Ease<T>(T easingType, float n)
            where T : struct, Enum
            => EasingMethodList[Convert.ToInt32(easingType)].Invoke(n);

        /// <summary>
        /// Normalize a given value to a specified range.
        /// This function takes a value `x` and normalizes it to the range specified by `x_min`
        /// and `x_max`. The normalized value is then scaled to the range specified by `y_start`
        /// and `y_end`.
        /// </summary>
        /// <param name="x">The value to be normalized.</param>
        /// <param name="x_min">The minimum value of the range to normalize `x` to.</param>
        /// <param name="x_max">The maximum value of the range to normalize `x` to.</param>
        /// <param name="y_start">The starting value of the output range.</param>
        /// <param name="y_end">The ending value of the output range.</param>
        /// <returns>The normalized value of `x` in the specified output range.</returns>
        public static float Normalize(float x, float x_min, float x_max, float y_start = 0.0f, float y_end = 1.0f)
        {
            // If x_min is not zero, shift x, x_min, and x_max so that x_min becomes zero.
            if (x_min != 0.0f)
            {
                x -= x_min;
                x_max -= x_min;
                //x_min = 0.0f;
            }

            // If y_start is not zero, scale the output range accordingly.
            if (y_start != 0.0f)
            {
                y_end -= y_start;
            }

            // Normalize x to the range [0, 1].
            var y = x / x_max;

            // Scale the normalized value to the output range.
            return (y_end * y) + y_start;
        }

        /// <summary>
        /// Applies a normalized easing function to the given value.
        /// </summary>
        /// <typeparam name="T">The type of the easing function, which must be an enumeration.</typeparam>
        /// <param name="easingType">The type of easing function to apply.</param>
        /// <param name="x">The value to be eased.</param>
        /// <param name="x_start">The start value of the input range.</param>
        /// <param name="x_end">The end value of the input range.</param>
        /// <param name="start_displacement">The displacement to be applied at the start of the output range.</param>
        /// <param name="end_displacement">The displacement to be applied at the end of the output range.</param>
        /// <returns>A float representing the eased and normalized value.</returns>
        public static float NormalizedEasing<T>(T easingType, float x, float x_start, float x_end, int start_displacement, int end_displacement)
            where T : struct, Enum
            => Normalize(
                Ease(easingType, Normalize(x, x_start, x_end))
                , 0.0f
                , 1.0f
                , start_displacement
                , end_displacement);

        private static float In(float n, float pow)
            => Mathf.Pow(n, pow);
        private static float Out(float n, float pow)
            => 1.0f - Mathf.Pow(1.0f - n, pow);
        private static float InOut(float n, float pow)
            => n < 0.5f
            ? Mathf.Pow(2.0f, pow - 1.0f) * Mathf.Pow(n, pow)
            : 1.0f - Mathf.Pow(-2.0f * n + 2.0f, pow) / 2.0f;
    }
}
