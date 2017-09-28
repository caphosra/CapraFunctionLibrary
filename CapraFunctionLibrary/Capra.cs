using System;
using System.Drawing;

namespace Cpr314Lib
{
    public enum Rotation
    {
        RightRotation,
        LeftRotation
    }

    public delegate T CmdFunc<T>(string[] str);

#if !SYSTEM

    public static class CprSystem
    {
        /// <summary>
        /// Falseになった時、例外を返します。
        /// </summary>
        /// <param name="b">Boolean型の値</param>
        public static void ThrowIf(bool arg)
        {
            if (!arg) throw new Exception();
        }

        /// <summary>
        /// Falseになった時、例外を返します。
        /// </summary>
        /// <param name="arg">Boolean型の値</param>
        /// <param name="e">例外</param>
        public static void ThrowIf(bool arg, Exception e)
        {
            if (!arg) throw e;
        }

        /// <summary>
        /// インスタンスを詳細コピーします。戻り値はobjectです。
        /// </summary>
        /// <typeparam name="T">クラスの種類</typeparam>
        /// <param name="t">インスタンス</param>
        /// <returns></returns>
        public static object PassByValueInObject<T>(T t) where T : class
        {
            object clone = null;
            using (var stream = new System.IO.MemoryStream())
            {
                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(T));
                serializer.Serialize(stream, t);
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                clone = serializer.Deserialize(stream);
            }
            return clone;
        }

        /// <summary>
        /// インスタンスを詳細コピーします。戻り値は渡されたクラスです。
        /// </summary>
        /// <typeparam name="T">クラスの種類</typeparam>
        /// <param name="t">インスタンス</param>
        /// <returns></returns>
        public static T PassByValueInClass<T>(T t) where T : class
        {
            object clone = null;
            using (var stream = new System.IO.MemoryStream())
            {
                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(T));
                serializer.Serialize(stream, t);
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                clone = serializer.Deserialize(stream);
            }
            return (T)clone;
        }

        
    }

#endif

    public static class CprExtension
    {
        /// <summary>
        /// boolをintに変換します。
        /// </summary>
        public static int ToInt(this bool b)
            => b ? 1 : 0;

        /// <summary>
        /// boolの値を逆転します。
        /// </summary>
        public static bool Change(this bool b)
        {
            b = !b;
            return b;
        }

        /// <summary>
        /// trueを代入します。
        /// </summary>
        public static bool On(this bool b)
        {
            b = true;
            return true;
        }

        /// <summary>
        /// falseを代入します。
        /// </summary>
        public static bool Off(this bool b)
        {
            b = false;
            return false;
        }

        /// <summary>
        /// intをboolに変換します。
        /// </summary>
        public static bool ToBool(this int i)
            => (i != 0); 

        /// <summary>
        /// インスタンスを詳細コピーします。
        /// </summary>
        /// <typeparam name="T">クラスの種類</typeparam>
        /// <param name="params">コピーするインスタンス</param>
        /// <returns>詳細コピーされたインスタンス</returns>
        public static T PassByValue<T>(this T param) where T : class
            => CprSystem.PassByValueInClass(param);

        /// <summary>
        /// 指定した単語より前の文字列を出力する。
        /// </summary>
        /// <param name="str1">処理する文字列</param>
        /// <param name="str2">この文字より前が抜き出されます。</param>
        /// <returns>処理後の文字列</returns>
        public static string Before(this string str1, string str2)
            => str1.Remove(str1.IndexOf(str2));

        /// <summary>
        /// 空白区切りされた文字列を文字列の配列に変換する。
        /// </summary>
        /// <param name="str">処理する文字列</param>
        /// <returns>処理後の文字列の配列</returns>
        public static string[] Separate(this string str)
            => str.Split(' ');
    }

#if !POINT

    public struct CprPoint
    {
        public double X
        {
            get; set;
        }
        public double Y
        {
            get; set;
        }
        public double Z
        {
            get; set;
        }

        public CprPoint(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
            Z = 0D;
        }
        public CprPoint(double x = 0, double y = 0, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public new string ToString()
            => "X : " + X.ToString() + " / Y : " + Y.ToString() + " / Z : " + Z.ToString();
        public string ToString(byte dimensions)
        {
            switch (dimensions)
            {
                case 0:
                    return "0";
                case 1:
                    return "X : " + X.ToString();
                case 2:
                    return "X : " + X.ToString() + " / Y : " + Y.ToString();
                case 3:
                    return ToString();
                default:
                    throw new ArgumentException();
            }
        }
        public string ToString(byte dimensions, bool exception)
        {
            if (exception) return ToString(dimensions);
            else
            {
                try
                {
                    return ToString(dimensions);
                }
                catch
                {
                    return null;
                }
            }
        }
        public static explicit operator Point(CprPoint cpr)
            => new Point((int)cpr.X, (int)cpr.Y);
        public static explicit operator CprPoint(Point point)
            => new CprPoint(point.X, point.Y);

        public static CprPoint operator +(CprPoint cpr1, CprPoint cpr2)
            => new CprPoint(cpr1.X + cpr2.X, cpr1.Y + cpr2.Y, cpr1.Z + cpr2.Z);
        public static CprPoint operator -(CprPoint cpr1, CprPoint cpr2)
            => new CprPoint(cpr1.X - cpr2.X, cpr1.Y - cpr2.Y, cpr1.Z - cpr2.Z);
    }

#endif
}
