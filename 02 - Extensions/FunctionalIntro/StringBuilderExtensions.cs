using System.Text;

namespace FunctionalIntro
{
    public static class StringBuilderExtensions
    {
        //TODO: 02 - 01 - Implemento un método de extension para StringBuilder
        public static StringBuilder AppendFormattedLine(
            this StringBuilder @this,
            string format,
            params object[] args) =>
                @this.AppendFormat(format, args).AppendLine();
    }
}
