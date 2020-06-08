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
           
            var selectBox =
                Disposable
                    .Using(
                        TechnologiesFactory.GetAll,
                        stream =>
                        {
                            var localBuffer = new byte[stream.Length];
                            stream.Read(localBuffer, 0, (int)stream.Length);
                            return localBuffer;
                        }
                    )
                    .Map(Encoding.UTF8.GetString)
                    .Split(new[] { Environment.NewLine, }, StringSplitOptions.RemoveEmptyEntries)
                    .Select((s, ix) => Tuple.Create(ix, s))
                    .ToDictionary(k => k.Item1, v => v.Item2)
                    .Map(options=> BuildTechnologiesList(options, "technologies", true))
                    .Tee(Console.WriteLine);

            //TODO: 08 - 02 - Utilizo Tee
            //Console.WriteLine(selectBox);

            Console.ReadLine();
        }
    }
}
