using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpr314Lib
{
#if !MATH

    public static class CprMath
    {
        /// <summary>
        /// 斜方投射の際の軌道を求める
        /// </summary>
        /// <param name="v">初期速度</param>
        /// <param name="θ">角度</param>
        /// <param name="x">X座標</param>
        /// <param name="h">高さ</param>
        /// <param name="g">重力</param>
        /// <returns>Y座標</returns>
        public static double ProjectileMotion_y(double v, double θ, double x, double h, double g)
        {
            double y = 0;
            y = Math.Tan(θ) * x - (g / (2 * v * v * Math.Pow(Math.Cos(θ), 2))) * x * x + h;
            return y;
        }

        /// <summary>
        /// 斜方投射の際の軌道を求める
        /// </summary>
        /// <param name="v">初期速度</param>
        /// <param name="θ">角度</param>
        /// <param name="x">X座標</param>
        /// <param name="h">高さ</param>
        /// <returns>Y座標</returns>
        public static double ProjectileMotion_y(double v, double θ, double x, double h)
            => ProjectileMotion_y(v, θ, x, h, g);

        /// <summary>
        /// 重力加速度
        /// </summary>
        public const double g = 9.80665;

#if !POINT

        /// <summary>
        /// 実装したはいいものの、性能は...
        /// </summary>
        /// <param name="key">地点</param>
        /// <param name="seed">Seed値</param>
        /// <returns>値</returns>
        public static double perlin_noise_3D(CprPoint key, int seed)
            => frac(Math.Sin(dot(key, new CprPoint(12.9898D, 78.233D, 49.038D)) + seed) * 43758.5433D);

        /// <summary>
        /// 実装したはいいものの、性能は...
        /// </summary>
        /// <param name="key">地点</param>
        /// <param name="seed">Seed値</param>
        /// <returns>値</returns>
        public static double perlin_noise_2D(CprPoint key, int seed)
            => frac(Math.Sin(dot(key, new CprPoint(12.9898D, 78.233D)) + seed) * 43758.5453123D);

        /// <summary>
        /// ベクトルの内積を求めます
        /// </summary>
        /// <param name="a">ベクトル的な</param>
        /// <param name="b">ベクトル的な</param>
        /// <returns></returns>
        public static double dot(CprPoint a, CprPoint b)
            => a.x * b.x + a.y * b.y + a.z * b.z;

        /// <summary>
        /// まるめ
        /// </summary>
        static Func<double, double> frac = (value) => (value - Math.Floor(value));
    }
#endif

#endif
}
