using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalIntro
{
    class Program
    {
        private static string BuildTechnologiesList(IDictionary<int, string> options, string id, bool includeUnknown)
            => new StringBuilder().AppendFormattedLine("<select id=\"{0}\" name=\"{0}\">", id)
                    .AppendWhen(
                        () => includeUnknown,
                        (stringBuilder) => stringBuilder.AppendLine("\t<option>Unknown</option>"))
                    .AppendSequence(
                        options,
                        (sb, opt) =>
                            sb.AppendFormattedLine("\t<option value=\"{0}\">{1}</option>", opt.Key, opt.Value))
                    .AppendLine("</select>")
                    .ToString();

        static void Main(string[] args)
        {
            //byte[] buffer;

            // //TODO: 06 - 02 - Utilizo Disposable Pattern
            //using (var stream = TechnologiesFactory.GetAll())
            //{
            //    buffer = new byte[stream.Length];
            //    stream.Read(buffer, 0, (int)stream.Length);
            //}
            var buffer =
                Disposable
                    .Using(
                        TechnologiesFactory.GetAll,
                        stream =>
                        {
                            var localBuffer = new byte[stream.Length];
                            stream.Read(localBuffer, 0, (int)stream.Length);
                            return localBuffer;
                        }
                    );

            var options =
                Encoding
                    .UTF8
                    .GetString(buffer)
                    .Split(new[] { Environment.NewLine, }, StringSplitOptions.RemoveEmptyEntries)
                    .Select((s, ix) => Tuple.Create(ix, s))
                    .ToDictionary(k => k.Item1, v => v.Item2);

            var selectBox = BuildTechnologiesList(options, "technologies", true);

            Console.WriteLine(selectBox);

            Console.ReadLine();
        }
    }
}
