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

        //TODO: 03 - 01 - Implemento un método de extension para StringBuilder
        public static StringBuilder AppendLineWhen(
            this StringBuilder stringBuilder,
            Func<bool> condition,
            string value) =>
            condition()
            ? stringBuilder.AppendLine(value)
            : stringBuilder;
    }
}
