using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SautinSoft.Document;
using SautinSoft.Document.Drawing;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.IO;
using System.Drawing.Imaging;

namespace Application.GenerarEscarapela
{
    public class CtlrGenerarEscarapela
    {
        public string GenerarEscarapela(int eventoId,string nombre, string tipo,string identificacion)
        {
            GenerarCodigoQR(eventoId, identificacion);
            // Set a path to our pdf file and image path
            string pdfPath = $@"..\Application\GenerarEscarapela\EscarapelasGeneradas\Result.pdf";
            string logo = @"..\Application\GenerarEscarapela\LogoEscarapela\descarga.png";
            string qr = @"..\Application\GenerarEscarapela\codigosQR\codigo.jpg";

            // Let's create a simple PDF document.
            // ccreate a new picture 
            DocumentCore dc = new DocumentCore();
            Picture pict = new Picture(dc, logo);
            Picture codigo = new Picture(dc, qr);

            // Add new section.
            Section section = new Section(dc);
            dc.Sections.Add(section);

            // Let's set page size A4.
            section.PageSetup.PaperType = PaperType.A4;

            // Add two paragraphs using different ways:

            // Way 1: Add 1st paragraph.
            Paragraph par1 = new Paragraph(dc);
            par1.ParagraphFormat.Alignment = HorizontalAlignment.Center;
            section.Blocks.Add(par1);

            // Let's create a characterformat for text in the 1st paragraph.
            CharacterFormat cf = new CharacterFormat()
            {
                FontName = "Verdana",
                Size = 16,
                FontColor = SautinSoft.Document.Color.Black
            };

            Run text1 = new Run(dc, "Conferencia:" + eventoId);
            text1.CharacterFormat = cf;
            par1.Inlines.Add(text1);

            // Let's add a line break into our paragraph.
            par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));

            Run text2 = text1.Clone();
            text2.Text = "Nombre:" + nombre; ;
            par1.Inlines.Add(text2);

            par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));

            Run text4 = text1.Clone();
            text4.Text = "Identificacion:" + identificacion; ;
            par1.Inlines.Add(text4);

            par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
            Run tex3 = text1.Clone();
            tex3.Text = "Tipo:" + tipo;
            par1.Inlines.Add(tex3);

            // Way 2 (easy): Add 2nd paragraph using ContentRange.
            dc.Content.End.Insert("", new CharacterFormat()
            { Size = 25, FontColor = SautinSoft.Document.Color.Black, Bold = true });
            SpecialCharacter lBr = new SpecialCharacter(dc, SpecialCharacterType.LineBreak);
            dc.Content.End.Insert(lBr.Content);
            dc.Content.End.Insert("Fecha:" + DateTime.UtcNow.ToString("yyyy-MM-dd"), new CharacterFormat()
            { Size = 20, FontColor = SautinSoft.Document.Color.Black }
            );

            /*
            Asignacion de posicion y tamaño de la imagen importada
            Para luego insertarla en el documento
             */
            pict.Layout = new FloatingLayout(
                new HorizontalPosition(10, LengthUnit.Millimeter, HorizontalPositionAnchor.Page),
                new VerticalPosition(60, LengthUnit.Millimeter, VerticalPositionAnchor.TopMargin),
                new SautinSoft.Document.Drawing.Size(LengthUnitConverter.Convert(162, LengthUnit.Pixel, LengthUnit.Point),
                         LengthUnitConverter.Convert(181, LengthUnit.Pixel, LengthUnit.Point))
                         );
            codigo.Layout = new FloatingLayout(
                new HorizontalPosition(10, LengthUnit.Millimeter, HorizontalPositionAnchor.Page),
                new VerticalPosition(100, LengthUnit.Millimeter, VerticalPositionAnchor.TopMargin),
                new SautinSoft.Document.Drawing.Size(LengthUnitConverter.Convert(162, LengthUnit.Pixel, LengthUnit.Point),
                         LengthUnitConverter.Convert(181, LengthUnit.Pixel, LengthUnit.Point))
                         );
            dc.Sections.Content.Start.Insert(pict.Content);
            dc.Sections.Content.Start.Insert(codigo.Content);

            // Save PDF to a file
            dc.Save(pdfPath);

            // Open the result for demonstration purposes.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pdfPath) { UseShellExecute = true });
            return pdfPath; 
        }

        public static void GenerarCodigoQR(int eventoId,string identificacion)
        {
            String codigo = eventoId + "," + identificacion;
            QrEncoder qrEncoder = new QrEncoder(Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode(codigo, out qrCode);

            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);

            MemoryStream ms = new MemoryStream();

            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Jpeg, ms);
            var imageTemporal = new Bitmap(ms);
            var imagen = new Bitmap(imageTemporal, new System.Drawing.Size(new System.Drawing.Point(200, 200)));
            imagen.Save(@"..\Application\GenerarEscarapela\codigosQR\codigo.jpg");
        }
    }
}

