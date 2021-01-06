﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Api.Services.Queries
{
    public interface ICommandText
    {
        string GetProducts { get; }
        string GetProductById { get; }
        string GetProductByName { get; }
        string AddProduct { get; }
        string UpdateProduct { get; }
        string RemoveProduct { get; }
    }
    public class CommandText : ICommandText
    {
        public string GetProducts => "Select * From Product";
        public string GetProductById => "Select * From Product Where Id= @Id";
        public string GetProductByName => "Select * From Product Where Name= @Name";
        public string AddProduct => "Insert Into  Product (Name, Cost, CreatedDate) Values (@Name, @Cost, @CreatedDate)";
        public string UpdateProduct => "Update Product set Name = @Name, Cost = @Cost, CreatedDate = GETDATE() Where Id =@Id";
        public string RemoveProduct => "Delete From Product Where Id= @Id";

 
    }
}
