#if !CONSOLE

using System;

namespace Cpr314Lib
{
    namespace ConsoleApp
    {
        public static class CprConsole
        {
            private static string Text = null;

            /// <summary>
            /// Conosle画面に文字を出力します。
            /// </summary>
            /// <param name="str">表示したい文字列</param>
            public static void Write(string str)
            {
                Console.Write(str);
                Text += str;
            }

            /// <summary>
            /// Console画面に文字を出力し、改行します。
            /// </summary>
            /// <param name="str">表示したい文字列</param>
            public static void WriteLine(string str)
            {
                Console.WriteLine(str);
                Text += (str + Environment.NewLine);
            }

            /// <summary>
            /// 文字列を入力させます。
            /// </summary>
            /// <returns>入力された文字列</returns>
            public static string ReadLine()
            {
                string str = Console.ReadLine();
                Text += (str + Environment.NewLine);
                return str;
            }

            /// <summary>
            /// Console画面に書かれた文字を一行消します。
            /// </summary>
            public static void EraseLine()
            {
                Console.Clear();
                Text = Text.Remove(Text.LastIndexOf(Environment.NewLine));
                Console.Write(Text);
            }

            /// <summary>
            /// Console画面に書かれた文字を複数行消します。
            /// </summary>
            /// <param name="value">何行消すか</param>
            public static void EraseLine(int value)
            {
                for (int i = 0; i < value; i++) EraseLine();
            }

            /// <summary>
            /// Console画面を消します。
            /// </summary>
            public static void Clear()
            {
                Console.Clear();
                Text = null;
            }
        }
    }
}

#endif