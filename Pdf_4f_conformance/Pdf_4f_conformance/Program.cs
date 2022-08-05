using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;

//Creates a new PDF document.

PdfDocument document = new PdfDocument(PdfConformanceLevel.Pdf_A4F);

//Creates a new page

PdfPage page = document.Pages.Add();

page.Graphics.DrawRectangle(PdfBrushes.Red, new RectangleF(10, 50, 300, 150));

FileStream data = new FileStream("../../../input.txt", FileMode.Open);

//Create attachment
PdfAttachment attachment = new PdfAttachment(@"Input.txt", data);

attachment.Relationship = PdfAttachmentRelationship.Alternative;

attachment.ModificationDate = DateTime.Now;

attachment.Description = "Input.txt";

attachment.MimeType = "application/txt";

//Add the attachment to the document. 

document.Attachments.Add(attachment);

//Save the document into stream

FileStream stream = new FileStream("sample.pdf", FileMode.Create);

document.Save(stream);

//Closes the document

document.Close(true);
