using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Model;
using MVCReview.Filter;
using MVCReview.ViewModels;
using Services;

namespace MVCReview.Controllers
{
    public class UploadController : AsyncController
    {
        //
        // GET: /Upload/
        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult Index()
        {
            return View(new FileUploadViewModel());
        }
        [AdminFilter]
        public async Task<ActionResult> Upload(FileUploadViewModel model)
        {
            var t1 = Thread.CurrentThread.ManagedThreadId;
            var employees = await Task.Factory.StartNew<List<Employee>>(() => GetEmployees(model));
            var t2 = Thread.CurrentThread.ManagedThreadId;
            var bal = new EmployeeBusinessLayer();
            bal.UploadEmployees(employees);
            return RedirectToAction("Index", "User");
        }
        private static List<Employee> GetEmployees(FileUploadViewModel model)
        {
            var employees = new List<Employee>();
            var csvreader = new StreamReader(model.fileUpload.InputStream);
            csvreader.ReadLine(); // Assuming first line is header
            while (!csvreader.EndOfStream)
            {
                var line = csvreader.ReadLine();
                if (line == null) continue;
                var values = line.Split(',');//Values are comma separated
                var salary = 1000;
                var e = new Employee
                {
                    Name = "Ryan"+new Random().Next(),
                    Salary =int.Parse( values[1])
                };
                employees.Add(e);
            }
            return employees;
        }
    }
}
