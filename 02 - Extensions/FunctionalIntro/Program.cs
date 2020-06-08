using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalIntro
{
    class Program
    {
        private static string BuildTechnologiesList(IDictionary<int, string> options, string id, bool includeUnknown)
        {
            var html = new StringBuilder();
            //TODO: 02 - 02 - Utilizo el método de extension
            //html.AppendFormat("<select id=\"{0}\" name=\"{0}\">", id);
            //html.AppendLine();
            html.AppendFormattedLine("<select id=\"{0}\" name=\"{0}\">", id);

            if (includeUnknown)
            {
                html.AppendLine("\t<option>Unknown</option>");
            }

            foreach (var opt in options)
            {
                //TODO: 02 - 03 - Utilizo el método de extension
                //html.AppendFormat("\t<option value=\"{0}\">{1}</option>", opt.Key, opt.Value);
                //html.AppendLine();
                html.AppendFormattedLine("\t<option value=\"{0}\">{1}</option>", opt.Key, opt.Value);
            }

            html.AppendLine("</select>");

            return html.ToString();
        }

        static void Main(string[] args)
        {
            byte[] buffer;

            using (var stream = TechnologiesFactory.GetAll())
            {
                buffer = new byte[stream.Length];
                stream.Read(buffer, 0, (int)stream.Length);
            }

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
