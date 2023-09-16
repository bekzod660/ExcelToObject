﻿using CsvHelper.Configuration;
using Task.Domain.Entity;

namespace Task.Application.Commons.Models
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Map(m => m.Payroll).Name("Personnel_Records.Payroll_Number");
            Map(m => m.Forename).Name("Personnel_Records.Forenames");
            Map(m => m.Surname).Name("Personnel_Records.Surname");
            Map(m => m.DateOfBirth).Name("Personnel_Records.Date_of_Birth");
            Map(m => m.Telephone).Name("Personnel_Records.Telephone");
            Map(m => m.Mobile).Name("Personnel_Records.Mobile");
            Map(m => m.Address).Name("Personnel_Records.Address");
            Map(m => m.Address2).Name("Personnel_Records.Address_2");
            Map(m => m.PostCode).Name("Personnel_Records.Postcode");
            Map(m => m.Email).Name("Personnel_Records.EMail_Home");
            Map(m => m.StartDate).Name("Personnel_Records.Start_Date");
        }
    }

}
