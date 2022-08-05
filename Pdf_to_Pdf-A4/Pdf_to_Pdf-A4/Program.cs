using SkiaSharp;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

FileStream docStream = new FileStream(@"../../../invoice.pdf", FileMode.Open, FileAccess.Read);

PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Sample level font event handling

loadedDocument.SubstituteFont += LoadedDocument_SubstituteFont;

//Convert the loaded document to PDF/A document

loadedDocument.ConvertToPDFA(PdfConformanceLevel.Pdf_A4E);

FileStream stream = new FileStream("output.pdf", FileMode.Create);

//Save the document

loadedDocument.Save(stream);

stream.Position = 0;

//Close the document 

loadedDocument.Close(true);


static void LoadedDocument_SubstituteFont(object sender, PdfFontEventArgs args)
{
    //get the font name

    string fontName = args.FontName.Split(',')[0];

    //get the font style

    PdfFontStyle fontStyle = args.FontStyle;

    SKFontStyle sKFontStyle = SKFontStyle.Normal;

    if (fontStyle != PdfFontStyle.Regular)
    {
        if (fontStyle == PdfFontStyle.Bold)
        {
            sKFontStyle = SKFontStyle.Bold;
        }
        else if (fontStyle == PdfFontStyle.Italic)
        {
            sKFontStyle = SKFontStyle.Italic;
        }
        else if (fontStyle == (PdfFontStyle.Italic | PdfFontStyle.Bold))
        {
            sKFontStyle = SKFontStyle.BoldItalic;
        }
    }

    SKTypeface typeface = SKTypeface.FromFamilyName(fontName, sKFontStyle);

    SKStreamAsset typeFaceStream = typeface.OpenStream();

    MemoryStream memoryStream = null;

    if (typeFaceStream != null && typeFaceStream.Length > 0)
    {
        //Create the fontData from the type face stream.

        byte[] fontData = new byte[typeFaceStream.Length - 1];

        typeFaceStream.Read(fontData, typeFaceStream.Length);

        typeFaceStream.Dispose();

        //Create the new memory stream from the font data.

        memoryStream = new MemoryStream(fontData);
    }

    //set the font stream to the event args.

    args.FontStream = memoryStream;
}
