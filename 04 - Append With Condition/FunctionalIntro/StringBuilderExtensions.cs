using System;
using System.Linq;
using System.Text;

namespace FunctionalIntro
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendFormattedLine(
            this StringBuilder @this,
            string format,
            params object[] args) =>
                @this.AppendFormat(format, args).AppendLine();

        //TODO: 04 - 01 - Implemento un When mas general
        //public static StringBuilder AppendLineWhen(
        //    this StringBuilder stringBuilder,
        //    Func<bool> condition,
        //    string value) =>
        //    condition()
        //    ? stringBuilder.AppendLine(value)
        //    : stringBuilder;

        public static StringBuilder AppendWhen(
            this StringBuilder stringBuilder,
            Func<bool> condition,
            Func<StringBuilder, StringBuilder> funcToApply) =>
            condition()
            ? funcToApply(stringBuilder)
            : stringBuilder;

    }
}
