using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace RefplusWebtools
{
    class PDFMerge
    {
        private string _strError = "";

        readonly ArrayList _arrFiles = new ArrayList();


        public string Error
        {
            get { return _strError; }
        }

        public bool AddFile(string strFilePath)
        {
            bool bolReturnValue = true;
            if (File.Exists(strFilePath))
            {
                _arrFiles.Add(strFilePath);
            }
            else
            {
                _strError = "File cannot be found";
                bolReturnValue = false;
            }
            return bolReturnValue;
        }

        public bool Merge(string strOutputFile)
        {
            bool bolReturnValue = true;
            if (_arrFiles.Count > 0)
            {
                var filesByte = new List<byte[]>();
                for (int icount = 0; icount < _arrFiles.Count; icount++)
                {
                    filesByte.Add(File.ReadAllBytes((string)_arrFiles[icount]));
                }

                // Call pdf merger
                File.WriteAllBytes(strOutputFile, MergeFiles(filesByte));
            }
            else
            {
                _strError = "No files in the list";
                bolReturnValue = false;
            }
            return bolReturnValue;
        }

        public byte[] MergeFiles(List<byte[]> sourceFiles)
        {
            var document = new Document();
            var output = new MemoryStream();
            try
            {
                try
                {
                    // Initialize pdf writer
                    PdfWriter writer = PdfWriter.GetInstance(document, output);
                    writer.PageEvent = new PdfPageEvents();

                    // Open document to write
                    document.Open();
                    PdfContentByte content = writer.DirectContent;

                    // Iterate through all pdf documents
                    for (int fileCounter = 0; fileCounter < sourceFiles.Count; fileCounter++)
                    {
                        // Create pdf reader
                        var reader = new PdfReader(sourceFiles[fileCounter]);
                        int numberOfPages = reader.NumberOfPages;

                        // Iterate through all pages
                        for (int currentPageIndex = 1; currentPageIndex <= numberOfPages; currentPageIndex++)
                        {
                            document.SetPageSize(reader.GetPageSize(currentPageIndex));
                            document.NewPage();
                            PdfImportedPage importedPage = writer.GetImportedPage(reader, currentPageIndex);
                            content.AddTemplate(importedPage, 1f, 0, 0, 1f, 0, 0);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Public.PushLog(ex.ToString(),"PDF_CLass MergeFiles");
                    throw new Exception("There has an unexpected exception occured during the pdf merging process.", ex);
                }
            }
            finally
            {
                document.Close();
            }
            return output.GetBuffer();
        }
    }

    internal class PdfPageEvents : IPdfPageEvent
    {
        #region members

        #endregion

        #region IPdfPageEvent Members

        public void OnOpenDocument(PdfWriter writer, Document document)
        {
            BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        }

        public void OnStartPage(PdfWriter writer, Document document)
        {
        }

        public void OnEndPage(PdfWriter writer, Document document)
        {

        }

        public void OnCloseDocument(PdfWriter writer, Document document)
        {
        }

        public void OnParagraph(PdfWriter writer, Document document, float paragraphPosition)
        {
        }

        public void OnParagraphEnd(PdfWriter writer, Document document, float paragraphPosition)
        {
        }

        public void OnChapter(PdfWriter writer, Document document, float paragraphPosition, Paragraph title)
        {
        }

        public void OnChapterEnd(PdfWriter writer, Document document, float paragraphPosition)
        {
        }

        public void OnSection(PdfWriter writer, Document document, float paragraphPosition, int depth, Paragraph title)
        {
        }

        public void OnSectionEnd(PdfWriter writer, Document document, float paragraphPosition)
        {
        }

        public void OnGenericTag(PdfWriter writer, Document document, Rectangle rect, string text)
        {
        }

        #endregion
    }
}
