using System;
using System.Collections;
using System.Data;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.RuntimePublic.Db;
using Microsoft.Reporting.WinForms;
using System.IO;

namespace OutSystems.NssExtensionTest {

    public class CssExtensionTest : IssExtensionTest
    {

        static byte[] GeneratePDF(string Path)
        {
            {
                // Path to the RDLC file
                string rdlcFilePath = Path;

                // Set up the ReportViewer control
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Local;
                reportViewer.LocalReport.ReportPath = rdlcFilePath;

                // Set up data sources if needed
                // reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSourceName", yourDataSource));

                // Refresh the report viewer
                reportViewer.LocalReport.Refresh();

                // Export the report as PDF
                string mimeType, encoding, extension;
                string[] streams;
                Warning[] warnings;
                byte[] pdfBytes = reportViewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streams, out warnings);

                //pdfFilePath = "C:\\Users\\yoges\\Music\\op";

                // Save the PDF file
                string pdfFilePath = "output.pdf";
                File.WriteAllBytes(pdfFilePath, pdfBytes);
                // Write the binary data to the PDF file
                pdfFilePath = "output.text";

                File.WriteAllBytes(pdfFilePath, pdfBytes);
                Console.WriteLine("PDF file has been generated successfully.");
                return pdfBytes;

            }
        } // CssExtensionTest
    }
} // OutSystems.NssExtensionTest

