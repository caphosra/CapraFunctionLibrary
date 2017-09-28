using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpr314Lib
{
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
        public static double ProjectileMotion_y(double v, double θ, double x, double h, double g = G)
            => Math.Tan(θ) * x - (g / (2 * v * v * Math.Pow(Math.Cos(θ), 2))) * x * x + h;

        /// <summary>
        /// 重力加速度
        /// </summary>
        public const double G = 9.80665;

        /// <summary>
        /// 実装したはいいものの、性能は...
        /// </summary>
        /// <param name="key">地点</param>
        /// <param name="seed">Seed値</param>
        /// <returns>値</returns>
        public static double perlin_noise_3D(CprPoint key, int seed)
            => Frac(Math.Sin(Dot(key, new CprPoint(12.9898D, 78.233D, 49.038D)) + seed) * 43758.5433D);

        /// <summary>
        /// 実装したはいいものの、性能は...
        /// </summary>
        /// <param name="key">地点</param>
        /// <param name="seed">Seed値</param>
        /// <returns>値</returns>
        public static double perlin_noise_2D(CprPoint key, int seed)
            => Frac(Math.Sin(Dot(key, new CprPoint(12.9898D, 78.233D)) + seed) * 43758.5453123D);

        /// <summary>
        /// ベクトルの内積を求めます
        /// </summary>
        /// <param name="a">ベクトル的な</param>
        /// <param name="b">ベクトル的な</param>
        /// <returns></returns>
        public static double Dot(CprPoint a, CprPoint b)
            => a.X * b.X + a.Y * b.Y + a.Z * b.Z;

        /// <summary>
        /// まるめ（非公開）
        /// </summary>
        private static double Frac(double value)
            => value - Math.Floor(value);

        /// <summary>
        /// どれか一つを選択します。
        /// </summary>
        /// <param name="rnd">乱数の発生原</param>
        /// <param name="items">選択されるものです</param>
        /// <param name="probability">それぞれが選択される確率です</param>
        /// <returns>選択したもの</returns>
        public static T RondomGet<T>(Random rnd, T[] items, params int[] probability)   
        {
            if (!(items.Length != probability.Length || items.Length == 0))
            {
                int sum = probability.Sum();
                if(sum == 0)
                {
                    throw new ArgumentException();
                }
                int rn = rnd.Next(sum);
                rn++;
                for(int i = 0;i < items.Length; i++)
                {
                    rn -= probability[i];
                    if (rn <= 0) return items[i];
                }
            }
            throw new ArgumentException();
        }
    }
}
