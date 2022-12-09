using System;
using System.IO;
using System.Text;

namespace middle
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            var path = Encoding.Default.GetString(Convert.FromBase64String(args[0]));                        
            using (var stream = File.OpenRead(path))
            {
                using (var br = new BinaryReader(stream))
                {
                    using (Stream stdout = Console.OpenStandardOutput())
                    {
                        byte[] buffer = new byte[2048];
                        while (true)
                        {
                            int cnt = br.Read(buffer, 0, 2048);
                            if (cnt > 0)
                            {
                                stdout.Write(buffer, 0, cnt);
                            }
                            else break;
                        }

                    }
                }
            }

        }
    }
}
