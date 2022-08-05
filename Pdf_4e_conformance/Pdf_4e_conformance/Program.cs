using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;

//Creates a new PDF document.

PdfDocument document = new PdfDocument(PdfConformanceLevel.Pdf_A4E);

//Creates a new page

PdfPage page = document.Pages.Add();

FileStream inputStream = new FileStream("../../../box.u3d", FileMode.Open, FileAccess.Read);

//Creates a new pdf 3d annotation.

Pdf3DAnnotation pdf3dAnnotation = new Pdf3DAnnotation(new RectangleF(10, 50, 300, 150), inputStream);

//Handles the activation of the 3d annotation

Pdf3DActivation activation = new Pdf3DActivation();

activation.ActivationMode = Pdf3DActivationMode.PageOpen;

activation.ShowToolbar = true;

pdf3dAnnotation.Activation = activation;

pdf3dAnnotation.Appearance.Normal.Graphics.DrawRectangle(PdfBrushes.Red, new RectangleF(10, 50, 300, 150));

//Adds annotation to page

page.Annotations.Add(pdf3dAnnotation);

//Save the document into stream

FileStream stream = new FileStream("sample.pdf", FileMode.Create);

document.Save(stream);

stream.Position = 0;

//Closes the document

document.Close(true);

