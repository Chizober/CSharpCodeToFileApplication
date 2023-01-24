using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Text.Json;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Xml.Serialization;
using System.Reflection;

namespace DocumentTestTool
{
    public class SerializeObj
    {
        public static void CreateAndWrite(string text, string fileName)
        {
            using (StreamWriter writer = File.CreateText(fileName))
            {
                writer.Write(text);
                writer.Write(writer.NewLine);
            }
        }

        public static void CreateAndWriteJson<T>(T objGraph, string fileName)
        {
            var options = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true };
            File.WriteAllText(fileName, JsonSerializer.Serialize(objGraph, options));
        }

        public static void CreateAndWritexml<T>(T obj, string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(T));
            using (
                Stream stream = new FileStream(
                    fileName,
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None
                )
            )
            {
                xml.Serialize(stream, obj);
            }
        }

        public static void CreatePDFFile(string text, string fileName)
        {
            PdfDocument document = new PdfDocument();

            document.SetPageSize(PageSize.A4);
            document.SetMargins(50, 50, 50, 50);

            PdfWriter writer = PdfWriter.GetInstance(
                document,
                new FileStream(fileName, FileMode.Create)
            );

            document.Open();

            Font font = new Font(Font.FontFamily.HELVETICA, 16, Font.NORMAL);
            document.Add(new Paragraph(text, font));

            document.Close();
        }
    }
}
