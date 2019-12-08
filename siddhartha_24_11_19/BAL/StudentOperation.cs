using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using siddhartha_24_11_19.Models;
using siddhartha_24_11_19.DAL;

namespace siddhartha_24_11_19.BAL
{
    public class StudentOperation
    {
        DataAdapter da = new DataAdapter();
        public int addStudent(Student std) {

            string command = "dbo.spStudentOperation";
            SqlParameter[] param = new SqlParameter[36];
            param[0] = new SqlParameter("@Action", "ADD");
            param[1] = new SqlParameter("@AadhaarCardNo",  std.AadhaarCardNo);
            param[2] = new SqlParameter("@DateofJoining", std.DateofJoining);
            param[3] = new SqlParameter("@StudentName", std.StudentName);
            param[4] = new SqlParameter("@Gender", std.Gender);
            param[5] = new SqlParameter("@FatherName", std.FatherName);
            param[6] = new SqlParameter("@MotherName", std.MotherName);
            param[7] = new SqlParameter("@DOB", std.DOB);
            param[8] = new SqlParameter("@Nationality",  std.Nationality);
            param[9] = new SqlParameter("@Occupation",  std.Occupation);
            param[10] = new SqlParameter("@Category", std.Category);
            param[11] = new SqlParameter("@Caste", std.Caste);
            param[12] = new SqlParameter("@ContactNo1" , std.ConactNo1);
            param[12] = new SqlParameter("@ContactNo2" , std.ConactNo2);
            param[12] = new SqlParameter("@ContactNo3" , std.ConactNo3);
            param[13] = new SqlParameter("@Email" , std.Email);
            param[14] = new SqlParameter("@Addresss" , std.Address);
            param[15] = new SqlParameter("@Pincode" , std.Pincode);
            param[16] = new SqlParameter("@Religion", std.Religion);
            param[17] = new SqlParameter("@PassingYears" , std.PassingYears);
            param[18] = new SqlParameter("@MaritalStatus" , std.MaritalStatus);
            param[19] = new SqlParameter("@Qualifications", std.Qualification);
            param[20] = new SqlParameter("@Marks" , std.Marks);
            param[21] = new SqlParameter("@Course" , std.Course);
            param[22] = new SqlParameter("@BatchTime" , std.BatchTime);
            param[23] = new SqlParameter("@Remarks" , std.Remarks);
            param[24] = new SqlParameter("@BranchCode" , std.BranchCode);
            param[25] = new SqlParameter("@ApplicationNo", std.ApplicationNo);
            param[26] = new SqlParameter("@MonthofExam" , std.MonthofExam);
            param[27] = new SqlParameter("@TotalFees" , std.TotalFees);
            param[28] = new SqlParameter("@isIssueBag" , std.isIssueBag);
            param[29] = new SqlParameter("@isIssueBooks" , std.isIssueBooks);
            param[30] = new SqlParameter("@isIssueCard" , std.isIssueICard);
            param[31] = new SqlParameter("@Status" , std.Status);
            param[32] = new SqlParameter("@SignofStudentPicPath", std.SignofStudentPicPath);
            param[33] = new SqlParameter("@ThumbStudentPath", std.ThumbofStudentPath);
            param[34] = new SqlParameter("@CEOofSignPath" , std.CEOofSignPath);
            param[35] = new SqlParameter("@StudentPicPath", std.StudentPicPath);
            return da.InsertSP(param, command);
        }
        public int updateStudent(Student std)
        {

            string command = "dbo.spStudentOperation";
            SqlParameter[] param = new SqlParameter[35];
            param[0] = new SqlParameter("@Action", "ADD");
            param[1] = new SqlParameter("@AadhaarCardNo", std.AadhaarCardNo);
            param[2] = new SqlParameter("@DateofJoining", std.DateofJoining);
            param[3] = new SqlParameter("@StudentName", std.StudentName);
            param[4] = new SqlParameter("@Gender", std.Gender);
            param[5] = new SqlParameter("@FathersName", std.FatherName);
            param[6] = new SqlParameter("@MothersName", std.MotherName);
            param[7] = new SqlParameter("@DateofBirth", std.DOB);
            param[8] = new SqlParameter("@Nationality", std.Nationality);
            param[9] = new SqlParameter("@Occupation", std.Occupation);
            param[10] = new SqlParameter("@Category", std.Category);
            param[11] = new SqlParameter("@Caste", std.Caste);
            param[12] = new SqlParameter("@ContactNo1", std.ConactNo1);
            param[12] = new SqlParameter("@ContactNo2", std.ConactNo2);
            param[12] = new SqlParameter("@ContactNo3", std.ConactNo3);
            param[13] = new SqlParameter("@EmailID", std.Email);
            param[14] = new SqlParameter("@Address", std.Address);
            param[15] = new SqlParameter("@Pincode", std.Pincode);
            param[16] = new SqlParameter("@PassingYears", std.PassingYears);
            param[17] = new SqlParameter("@MaritalStatus", std.MaritalStatus);
            param[18] = new SqlParameter("@Qualification", std.Qualification);
            param[19] = new SqlParameter("@Marks", std.Marks);
            param[20] = new SqlParameter("@Course", std.Course);
            param[21] = new SqlParameter("@BatchTime", std.BatchTime);
            param[22] = new SqlParameter("@Remarks", std.Remarks);
            param[23] = new SqlParameter("@BranchCode", std.BranchCode);
            param[24] = new SqlParameter("@ApplicantNo", std.ApplicationNo);
            param[25] = new SqlParameter("@MonthofExam", std.MonthofExam);
            param[26] = new SqlParameter("@TotalFees", std.TotalFees);
            param[27] = new SqlParameter("@IsBag", std.isIssueBag);
            param[28] = new SqlParameter("@IsBook", std.isIssueBooks);
            param[29] = new SqlParameter("@IsICard", std.isIssueICard);
            param[30] = new SqlParameter("@Status", std.Status);
            param[31] = new SqlParameter("@SignofStudent", std.SignofStudentPicPath);
            param[32] = new SqlParameter("@ThumbofStudent", std.ThumbofStudentPath);
            param[33] = new SqlParameter("@CeoSign", std.CEOofSignPath);
            param[34] = new SqlParameter("@ProfilePic", std.StudentPicPath);
            return da.InsertSP(param, command);
        }
        public int deleteCourse(Course cse)
        {
            string command = "dbo.spStudentOperation";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Action", "DELETE");
            param[1] = new SqlParameter("@ApplicantNo", cse.Id);
            return da.InsertSP(param, command);
        }
        public List<Student> getAllStudents()
        {
            string command = "SELECT * FROM Student";
            List<Student> std = new List<Student>();
            DataTable dt = new DataTable();
            dt = da.FetchAll(command);
            if (dt.Rows.Count > 0)
            {
                std = (from DataRow dr in dt.Rows
                       select new Student()
                       {
                           ApplicationNo = dr["ApplicationNo"].ToString(),
                           StudentName = dr["StudentName"].ToString(),
                           FatherName = dr["FathersName"].ToString(),
                           Course = dr["Course"].ToString(),
                           BatchTime = dr["BatchTime"].ToString(),
                           TotalFees = dr["TotalFees"].ToString(),
                           ConactNo1 = dr["ConatctNo1"].ToString(),
                           Gender = dr["Gender"].ToString(),
                           Status = dr["Status"].ToString()
                       }).ToList();
            }
            return std;
        }
    }
}