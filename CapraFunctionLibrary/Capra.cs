using System;

namespace Cpr314Lib
{
    public enum Rotation
    {
        RightRotation,
        LeftRotation
    }

#if !SYSTEM

    public static class CprSystem
    {
        /// <summary>
        /// Int型をBoolean型に変換する関数。
        /// </summary>
        /// <param name="value">Int型の値</param>
        /// <returns>Boolean型に変換された値</returns>
        public static bool BoolInt(int value)
            => (value != 0);

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
        /// インスタンスを詳細コピーします。
        /// </summary>
        /// <typeparam name="T">クラスの種類</typeparam>
        /// <param name="t">インスタンス</param>
        /// <returns></returns>
        public static object PassByValue<T>(T t)
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
    }

#endif

#if !STRING

    public static class CprString
    {
        /// <summary>
        /// 指定した単語より前の文字列を出力する。
        /// </summary>
        /// <param name="str1">処理する文字列</param>
        /// <param name="str2">この文字より前が抜き出されます。</param>
        /// <returns>処理後の文字列</returns>
        public static string Before(string str1, string str2)
            => str1.Remove(str1.IndexOf(str2));

        /// <summary>
        /// 空白区切りされた文字列を文字列の配列に変換する。
        /// </summary>
        /// <param name="str">処理する文字列</param>
        /// <returns>処理後の文字列の配列</returns>
        public static string[] Separate(string str)
            => str.Split(' ');
    }

#endif

#if !POINT

    public class CprPoint
    {
        public double x = 0;
        public double y = 0;
        public double z = 0;

        public CprPoint(double x = 0, double y = 0)
        {
            this.x = x;
            this.y = y;
        }
        public CprPoint(double x = 0, double y = 0, double z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public new string ToString()
            => "X : " + x.ToString() + " / Y : " + y.ToString() + " / Z : " + z.ToString();
        public string ToString(byte dimensions)
        {
            switch (dimensions)
            {
                case 0:
                    return "0";
                case 1:
                    return "X : " + x.ToString();
                case 2:
                    return "X : " + x.ToString() + " / Y : " + y.ToString();
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
    }

#endif
}
