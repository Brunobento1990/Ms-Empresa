using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Application.ITextSharp
{
    public class BottomBorder : IPdfPCellEvent
    {
        public void CellLayout(PdfPCell cell, Rectangle position, PdfContentByte[] canvases)
        {
            var canvas = canvases[PdfPTable.LINECANVAS];

            canvas.SetRGBColorStroke(168, 168, 168);
            canvas.SetLineDash(0);
            canvas.MoveTo(position.Left, position.Bottom);
            canvas.LineTo(position.Right, position.Bottom);
            canvas.Stroke();
        }
    }
}
