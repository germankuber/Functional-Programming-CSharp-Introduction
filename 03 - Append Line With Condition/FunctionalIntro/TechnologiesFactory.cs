using System;
using System.IO;
using System.Text;

namespace FunctionalIntro
{
    public static class TechnologiesFactory
    {
        public static Stream GetAll()
        {
            var technologies =
                String.Join(
                    Environment.NewLine,
                    new[] {
                        "C#", "VB.NET", "Java", "JavaScript",
                        "Haskell", "F#", "NodeJs", "Angular", "Vue.JS",
                        "React", "Python", "Ruby", "TypeScript" });

            var buffer = Encoding.UTF8.GetBytes(technologies);

            var stream = new MemoryStream();
            stream.Write(buffer, 0, buffer.Length);
            stream.Position = 0L;

            return stream;
        }
    }
}
