using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using DataAccesslayers.Entity;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace DataAccesslayers
{
    public class DetailRepository: IDetailRepository
    {
        string connectionString = string.Empty;
        SqlConnection con = null;
        public DetailRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Dbconnection");
            con = new SqlConnection(connectionString);
        }
        public void  InsertDetails(Details reg)
        {
            try
            {
                var insertquery = $"  exec InsertDetails '{reg.Name}','{reg.Degree}',{reg.UID}," +
                    $"'{reg.DateofBirth.ToString("MM-dd-yyyy")}','{reg.HospitalName}',{reg.MobileNumber}";
                con.Open();
                con.Execute(insertquery);
                con.Close();
            }
            catch(Exception e)
            {
                throw;
            }
        }
        public void  UpdateDetatils(Details reg)
        {
            try
            {
                var updatequery = $" exec  UpdateDetatils {reg.DoctorDetailsID},'{reg.Name}','{reg.Degree}',{reg.UID}," +
                    $"'{reg.DateofBirth.ToString("MM-dd-yyyy")}','{reg.HospitalName}',{reg.MobileNumber} ";
                con.Open();
                con.Execute(updatequery);
                con.Close();
            }
            catch(Exception e)
            {
                throw;
            }
        }
        public void  DeleteTable(long reg)
        {
            try
            {
                var Deletequery = $"exec DeleteTable {reg}";
                con.Open();
                con.Execute(Deletequery);
                con.Close();
            }
            catch(Exception e)
            {
                throw;
            }
        }
        public List<Details>  showallname()
        {
            try
            {
                var Selectall = $" exec showallname ";
                con.Open();
                List<Details> result = con.Query<Details>(Selectall).ToList();
                return result;
            }
            catch(Exception e)
            {
                throw;
            }
        }
        public Details  showDetailsbyName(string Name)
        {
            try
            {
                var selectbyName = $"exec showDetailsbyName{Name} ";
                con.Open();
                Details result = con.QueryFirstOrDefault<Details>(selectbyName);
                con.Close();
                return result;
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}
