﻿using System;
using SQLServerProject.Services;
using SQLServerProject.Models;
using SQLServerProject.Repositories;
using Microsoft.Data.SqlClient;

namespace SQLServerProject
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(CONNECTION_STRING);
            var repository = new Repository<User>(connection);

            
        }
    }
}