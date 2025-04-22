using OfficeOpenXml; // Cần cài thư viện EPPlus
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace Test1.Controllers
{
    public class TemplateController : Controller
    {
        // Action để tải template
        public IActionResult DownloadTemplate()
        {
            // Tạo một MemoryStream để chứa file Excel
            using (var package = new ExcelPackage())
            {
                // Thêm sheet vào file Excel
                var worksheet = package.Workbook.Worksheets.Add("Template");

                // Thiết lập tiêu đề cột trong Excel
                worksheet.Cells[1, 1].Value = "Mã nhân viên";
                worksheet.Cells[1, 2].Value = "Họ tên";
                worksheet.Cells[1, 3].Value = "Tài khoản FE";
                worksheet.Cells[1, 4].Value = "Tài khoản FPT";
                worksheet.Cells[1, 5].Value = "Phòng ban";
                worksheet.Cells[1, 6].Value = "Chuyên ngành";

                // Cài đặt kiểu chữ và căn giữa cho các tiêu đề
                worksheet.Cells[1, 1, 1, 6].Style.Font.Bold = true;
                worksheet.Cells[1, 1, 1, 6].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 1, 1, 6].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                // Lưu file vào MemoryStream
                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;  // Đặt lại vị trí của stream trước khi gửi về client

                // Trả về file Excel dưới dạng download
                string fileName = "Template_Import_Staff.xlsx";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }
    }
}
