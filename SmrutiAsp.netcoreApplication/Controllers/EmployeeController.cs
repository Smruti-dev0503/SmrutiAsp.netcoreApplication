using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using SmrutiAsp.netcoreApplication.Models;
using SmrutiAsp.netcoreApplication.ViewModel;

namespace SmrutiAsp.netcoreApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult AddOrEddit(int id)
        {
            List<Qualification> qualificationsList = new List<Qualification>();
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            try
            {               
                qualificationsList = _employeeRepository.GetQualifications();
                qualificationsList.Insert(0, new Qualification { Qualification_Id = 0, Qualification_Name = "--Select--" });

                List<HobbiesTable> hobbiesTables = new List<HobbiesTable>();
                hobbiesTables.Insert(0, new HobbiesTable { HobbyId = 0, HobbyName = "Reading" });
                hobbiesTables.Insert(1, new HobbiesTable { HobbyId = 1, HobbyName = "Swimming" });
                hobbiesTables.Insert(2, new HobbiesTable { HobbyId = 2, HobbyName = "Watching Movies" });
                hobbiesTables.Insert(3, new HobbiesTable { HobbyId = 3, HobbyName = "Playing" });

                employeeViewModel.Hobbies = hobbiesTables;

                ViewBag.Hobbies = hobbiesTables;
                ViewBag.QualificationList = qualificationsList;
            }
            catch
            {
                return View("/Shared/Error.cshtml");
            }
            
            return View(employeeViewModel);
        }

        [HttpPost]
        public IActionResult AddOrEddit(int id, EmployeeViewModel employeeViewModel)
        {
            Employee employee = new Employee();
            try
            {
                if (id != null || id <= 0)
                {
                    employee.Employee_Name = employeeViewModel.Employee_Name;
                    employee.DOB = employeeViewModel.DOB;
                    employee.Designation = employeeViewModel.Designation;
                    employee.Experience = employeeViewModel.Experience;
                    employee.Joining_Date = employeeViewModel.Joining_Date;
                    employee.Salary = employeeViewModel.Salary;
                    employee.Qualification = employeeViewModel.Qualification_Id;                    

                    foreach(var hobby in employeeViewModel.Hobbies)
                    {
                        if(hobby.IsSelected)
                        {
                            employee.Hobbies += hobby.HobbyName;
                        }
                    }
                   var EmployeeId = _employeeRepository.Add(employee);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {

               return View("~/Shared/Error.cshtml");
            }
        }

      
        public void ExportToExcel()
        {

            var EmployeeList = _employeeRepository.GetEmployees();

            List<string> listOfColumnsForReports = new List<string>();
            DataTable dataTable = LINQResultToDataTable(EmployeeList, listOfColumnsForReports);
            ExcelDownload(dataTable, "EmployeeList", "EmployeeList", "EmployeeList.xlsx");
        }


        public DataTable LINQResultToDataTable<T>(IEnumerable<T> linqList, List<string> listOfColumnsForReports)
        {
            DataTable dataTable = new DataTable();

            PropertyInfo[] columns = null;

            if (linqList == null) return dataTable;

            foreach (T Record in linqList)
            {

                if (columns == null)
                {
                    columns = Record.GetType().GetProperties();
                    foreach (PropertyInfo GetProperty in columns)
                    {
                        Type colType = GetProperty.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dataTable.Columns.Add(new DataColumn(GetProperty.Name, colType));
                    }
                }

                DataRow dr = dataTable.NewRow();

                foreach (PropertyInfo pinfo in columns)
                {
                    dr[pinfo.Name] = pinfo.GetValue(Record, null) == null ? DBNull.Value : pinfo.GetValue
                    (Record, null);
                }

                dataTable.Rows.Add(dr);
            }
            return dataTable;
        }

        public void ExcelDownload(DataTable dataTable, string tableName, string workSheetName, string excelFileName)
        {
            MemoryStream statusStream = new MemoryStream();

            if (dataTable.Rows.Count != 0)
            {
                dataTable.TableName = tableName;
                XLWorkbook excelWorkbook = new XLWorkbook();
                //Add the DataTable as Excel Worksheet.
                excelWorkbook.Worksheets.Add(dataTable, workSheetName);
                excelWorkbook.SaveAs(statusStream);
            }
            Response.Clear();
            Response.Headers[HeaderNames.ContentDisposition] = "attachment;filename=" + excelFileName ;
            Response.Headers[HeaderNames.ContentType] = "application/vnd.ms-excel";
            Response.WriteAsync(statusStream.ToString()).Wait() ;
        }

        public IActionResult GetEmployeeList()
        {
            var EmployeeList = _employeeRepository.GetEmployees();
            return View(EmployeeList);
        }

        public IActionResult GetEmployeeById()
        {
            return View();
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        public IActionResult EditEmployee()
        {
            return View();
        }

        public IActionResult UpdateEmployee()
        {
            return View();
        }


    }
}