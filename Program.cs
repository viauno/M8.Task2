using System.IO;
using System.Runtime.Intrinsics.Arm;

namespace M8.Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long weight = 0;
            string DirPath = "";
            do
            {
                Console.WriteLine("Введите путь до папки для очистки:");
                DirPath = @"" + Console.ReadLine();
            } while (CheckDir(DirPath));

            WeighDir(DirPath,ref weight);

            Console.WriteLine($"Размер заданой папки = {weight} байт");
        }

        static bool CheckDir(string dp)
        {
            if (dp != "")
            {
                if (Directory.Exists(dp))
                {
                    return false;
                }
                else { Console.WriteLine("Введенная папка не существует"); return true; }
            }
            else { return true; };
        }

        static void WeighDir(string dp, ref long weight)
        {
            foreach (var d in Directory.GetDirectories(dp))
            {
                WeighDir(d,ref weight);
            }

            foreach (var f in Directory.GetFiles(dp))
            {
                long length = new System.IO.FileInfo(f).Length;
                weight += length;
            }
            return;
        }

    }
}