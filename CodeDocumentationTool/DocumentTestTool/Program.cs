using System;
using System.Reflection;
using System.Text;
using System.Text.Json;
using CodeDocumentationTool;
using System.IO;

namespace DocumentTestTool
{
    public class Program
    {
        static void Main(string[] args)
        {
            ShowCodeDocuments.GetDocs();
            StringBuilder text = ShowCodeDocuments.FileData;
            string Text = Convert.ToString(text);
            string CrossPlatformFilePath =
                @$"C{Path.VolumeSeparatorChar}Users{Path.PathSeparator}achar{Path.PathSeparator}source{Path.PathSeparator}repos{Path.PathSeparator}CodeDocumentationTool{Path.PathSeparator}DocumentTestTool{Path.PathSeparator}";
            string filePath =
                "C:\\Users\\achar\\source\\repos\\CodeDocumentationTool\\DocumentTestTool\\";

            string FileName = "FileDcoument.txt";
            SerializeObj.CreateAndWrite(Text, $"{filePath}{FileName}");
            Console.WriteLine($"FileName:{filePath}{FileName}");

            /*string jsonFile = "jsonDcoument.json";
            SerializeObj.CreateAndWriteJson(ShowCodeDocuments.@DocumentAttribute, $"{filePath}{jsonFile}");
            Console.WriteLine($"FileName:{jsonFile}");*/


            string xmlFile = "xmlDcoument.xml";
            SerializeObj.CreateAndWritexml(
                ShowCodeDocuments.@DocumentAttribute,
                $"{filePath}{xmlFile}"
            );
            Console.WriteLine($"FileName:{xmlFile}");


            string pdfFile = "pdfDcoument.pdf";
            SerializeObj.CreateAndWritexml(Text, $"{filePath}{pdfFile}");
            Console.WriteLine($"FileName:{pdfFile}");
        }
    }
}
