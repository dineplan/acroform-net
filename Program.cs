using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using iTextSharp.text.pdf;

namespace acroform_net
{
    class Program
    {
        static void Main(string[] args)
        {
            PdfReader reader = new PdfReader("User-details.pdf");
            using (FileStream pdfOutputFile = new FileStream("Userdetails-Modified.pdf", FileMode.Create))
            {
                PdfStamper formFiller = null;
                try
                {
                    formFiller = new PdfStamper(reader, pdfOutputFile);

                    AcroFields form = formFiller.AcroFields;

                    form.SetField("Name", "LevelFive");
                    form.SetField("EMail", "lf@lfsolutions.net");
                    form.SetField("Designation", "CEO");
                    form.SetField("Address", "18 Primrose Road");
                    formFiller.FormFlattening = true;
                }
                finally
                {
                    if (formFiller != null)
                    {
                        formFiller.Close();
                    }
                }
            }

            reader.Close();
            Console.WriteLine("Its completed perfectly.");
            Console.Read();
        }
    }
}
