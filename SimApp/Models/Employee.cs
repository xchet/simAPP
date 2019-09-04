//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SimApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class Employee
    {
        public int EmployeeID { get; set; }

        [Required(ErrorMessage ="Please enter Employee Name")]
        [DisplayName("Emplyee Name")]
        public string EmplyeeName { get; set; }

        [Required(ErrorMessage = "Please enter Employee Position")]
        [DisplayName("Emplyee Position")]
        public string EmplyeePosition { get; set; }

        [Required(ErrorMessage = "Please enter Employee Salary")]
        [DisplayName("Emplyee Salary")]
        public Nullable<double> EmplyeeSalary { get; set; }

        [Required(ErrorMessage = "Please enter Employee Office")]
        [DisplayName("Emplyee Office")]
        public string EmplyeeOffice { get; set; }

        [DisplayName("Emplyee Image")]
        public string EmployeeImage { get; set; }

        [NotMapped]
        public HttpPostedFileBase imageFile { get; set; }

        public Employee()
        {
            EmployeeImage = "~/Docs/Images/default.png";
        }
    }
}