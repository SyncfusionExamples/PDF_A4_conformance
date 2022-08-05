using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;


//Create a new document with the PDF/A-4 standard. 
PdfDocument document = new PdfDocument(PdfConformanceLevel.Pdf_A4);

//Add a page to the document. 
PdfPage page = document.Pages.Add();

//Create the PDF graphics for the page. 
PdfGraphics graphics = page.Graphics;

//Load the TrueType font from the local file. 
FileStream fontStream = new FileStream("../../../arial.ttf", FileMode.Open, FileAccess.Read);

PdfFont font = new PdfTrueTypeFont(fontStream, 14);

//Draw the text.
graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(0, 0));

//Create the stream object. 
FileStream stream = new FileStream("output.pdf",FileMode.Create);

//Save the document into the memory stream. 
document.Save(stream);

//Close the document.
document.Close(true);