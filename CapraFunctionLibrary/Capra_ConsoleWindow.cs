#if !CONSOLE

using System;
using System.Threading.Tasks;

namespace Cpr314Lib
{
    namespace ConsoleApp
    {
        public static class CprConsole
        {
            /// <summary>
            /// Console画面に書かれた文字を一行消します。
            /// </summary>
            public static void EraseLine()
                => EraseLine(1);

            /// <summary>
            /// Console画面に書かれた文字を複数行消します。
            /// </summary>
            public static void EraseLine(int value)
                => Console.SetCursorPosition(0, Console.CursorTop >= value ? Console.CursorTop - value : 0);

            /// <summary>
            /// 仕事をさせながら、画面を変更し続けます。
            /// (注)途中でConsole画面に書き込みをしないでください。また、この関数はWait()を使用しています。
            /// </summary>
            public static void Wait(Action a, int interval = 100, Rotation r = Rotation.RightRotation)
            {
                bool loop = true;
                var tsk = Task.Run(() =>
                {
                    int count = 0;
                    string s = null;
                    if(r == Rotation.RightRotation)
                        s = "＼｜／－";
                    else
                        s = "／｜＼－";
                    while (loop)
                    {
                        Console.Write(s[count]);
                        count++;
                        if (count == 4) count = 0;
                        Task.Delay(interval).Wait();
                        Console.CursorLeft -= 2;
                    }
                });
                Task.Run(a).Wait();
                loop = false;
                tsk.Wait();
            }
        }
    }
}

#endif