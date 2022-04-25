using System;

using Docnet.Core.Bindings;

namespace Docnet.Core.Models
{
    public struct CharacterRef
    {
        private FpdfTextpageT TextPage { get; }

        private int Index { get; }

        internal CharacterRef(FpdfTextpageT tp, int idx)
        {
            TextPage = tp;
            Index = idx;
        }

        public PdfPoint Origin()
        {
            double x = 0;
            double y = 0;

            // TODO: Handle failure
            fpdf_text.FPDFTextGetCharOrigin(TextPage, Index, ref x, ref y);

            return new PdfPoint(x, y);
        }

        public PdfBoundBox CharBox()
        {
            double left = 0;
            double top = 0;
            double right = 0;
            double bottom = 0;

            // TODO: Handle failure
            fpdf_text.FPDFTextGetCharBox(TextPage, Index, ref left, ref right, ref bottom, ref top);

            return new PdfBoundBox(left, top, right, bottom);
        }

        /*public PdfBoundBox LooseCharBox()
        {
            double left = 0;
            double top = 0;
            double right = 0;
            double bottom = 0;

            // TODO: Handle failure
            fpdf_text.FPDFTextGetLooseCharBox(TextPage, Index, ref left, ref right, ref bottom, ref top);

            return new PdfBoundBox(left, top, right, bottom);
        }*/

        public uint Code()
        {
            return fpdf_text.FPDFTextGetUnicode(TextPage, Index);
        }

        public double FontSize()
        {
            return fpdf_text.FPDFTextGetFontSize(TextPage, Index);
        }

        public int FontWeight()
        {
            return fpdf_text.FPDFTextGetFontWeight(TextPage, Index);
        }

        public double Angle()
        {
            return fpdf_text.FPDFTextGetCharAngle(TextPage, Index);
        }
    }

    public struct Character : IEquatable<Character>
    {
        private const double Tolerance = 0.001;

        public char Char { get; }

        public BoundBox Box { get; }

        public Point Origin { get; }

        public float Angle { get; }

        public double FontSize { get; }

        public Character(char character, BoundBox box, float angle, double fontSize, Point origin)
        {
            Char = character;
            Box = box;
            Origin = origin;
            Angle = angle;
            FontSize = fontSize;
        }

        public static bool operator ==(Character obj1, Character obj2)
        {
            return obj1.Equals(obj2);
        }

        public static bool operator !=(Character obj1, Character obj2)
        {
            return !(obj1 == obj2);
        }

        public bool Equals(Character other)
        {
            return Char == other.Char
                   && Box.Equals(other.Box)
                   && Math.Abs(Angle - other.Angle) < Tolerance
                   && Math.Abs(FontSize - other.FontSize) < Tolerance;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Character))
            {
                return false;
            }

            var character = (Character)obj;

            return Equals(character);
        }

        public override int GetHashCode()
        {
            var hashCode = 13;
            hashCode = hashCode * 7 + Char.GetHashCode();
            hashCode = hashCode * 7 + Box.GetHashCode();
            return hashCode;
        }
    }
}
