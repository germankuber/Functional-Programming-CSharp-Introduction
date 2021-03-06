﻿using System;
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

            html.AppendFormattedLine("<select id=\"{0}\" name=\"{0}\">", id)

                .AppendWhen(
                () => includeUnknown,
                (stringBuilder) => stringBuilder.AppendLine("\t<option>Unknown</option>"))
                //TODO: 05 - 02 - Utilizo el método de extensión
                .AppendSequence(
                    options,
                    (sb, opt) =>
                        sb.AppendFormattedLine("\t<option value=\"{0}\">{1}</option>", opt.Key, opt.Value));


            //foreach (var opt in options)
            //    html.AppendFormattedLine("\t<option value=\"{0}\">{1}</option>", opt.Key, opt.Value);

            html.AppendLine("</select>");

            return html.ToString();
        }

        //private static string BuildTechnologiesList(IDictionary<int, string> options, string id, bool includeUnknown)
        //    => new StringBuilder().AppendFormattedLine("<select id=\"{0}\" name=\"{0}\">", id)

        //            .AppendWhen(
        //                () => includeUnknown,
        //                (stringBuilder) => stringBuilder.AppendLine("\t<option>Unknown</option>"))
        //            //TODO: 05 - 03 - Método final
        //            .AppendSequence(
        //                options,
        //                (sb, opt) =>
        //                    sb.AppendFormattedLine("\t<option value=\"{0}\">{1}</option>", opt.Key, opt.Value))
        //            .AppendLine("</select>")
        //            .ToString();

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
