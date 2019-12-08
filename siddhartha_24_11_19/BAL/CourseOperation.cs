using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using siddhartha_24_11_19.Models;
using System.Data.SqlClient;
using siddhartha_24_11_19.DAL;

namespace siddhartha_24_11_19.BAL
{
    public class CourseOperation
    {
        DataAdapter da = new DataAdapter();
        public int addCourse(Course cse ) {

            string command = "dbo.spCourseOperation";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Action", "ADD");
            param[1] = new SqlParameter("@CourseName", cse.CourseName);
            return da.InsertSP(param, command);
        }
        public int updateCourse(Course cse)
        {

            string command = "dbo.spCourseOperation";
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Action", "UPDATE");
            param[1] = new SqlParameter("@Id" , cse.Id);
            param[2] = new SqlParameter("@CourseName", cse.CourseName);
            return da.InsertSP(param, command);
        }
        public bool deleteCourse(Course cse)
        {

            string command = "dbo.spCourseOperation";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Action", "DELETE");
            param[1] = new SqlParameter("@Id", cse.Id);
            int a = da.InsertSP(param, command);
            if (a > 0)
            {
                return true;
            }
            return false;
        }
        public List<Course> getAllCourses()
        {
            string command = "SELECT * FROM Course";
            List<Course> courses = new List<Course>();
            DataTable dt = new DataTable();
            dt = da.FetchAll(command);
            if (dt.Rows.Count > 0)
            {
               courses = (from DataRow dr in dt.Rows
                            select new Course()
                            {
                                Id = int.Parse(dr["Id"].ToString()),
                                CourseName = dr["CourseName"].ToString(),
                                CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString())
                            }).ToList();
            }
            return courses;
        }
    }
}