using System;  
using System.Collections.Generic;  
using System.Diagnostics;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using CRUDApplication.Models;
namespace CRUDApplication.Controllers{
    public class EmployeeController:Controller{

        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();  
        public IActionResult Index()  
        {  
            List<Employee> lstEmployee = new List<Employee>();  
            lstEmployee = objemployee.GetAllRecord().ToList();
  
            return View(lstEmployee);  
        }  
    }
    
}