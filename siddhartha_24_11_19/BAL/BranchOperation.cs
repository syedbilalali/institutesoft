using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using siddhartha_24_11_19.DAL;
using siddhartha_24_11_19.Models;

namespace siddhartha_24_11_19.BAL
{
    public class BranchOperation
    {
        DataAdapter da = new DataAdapter();
        public int addBranch(Branch branch)
        {
            string command = "dbo.spBranchOperation";
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@Action" , "ADD");
            param[1] = new SqlParameter("@InstituteRegNo", branch.InstituteRegNo);
            param[2] = new SqlParameter("@InstittuteName", branch.InstittuteName);
            param[3] = new SqlParameter("@DirectorName", branch.DirectorName);
            param[4] = new SqlParameter("@AccountantName", branch.AccountantName);
            param[5] = new SqlParameter("@Website", branch.Website);
            param[6] = new SqlParameter("@BranchCode", branch.BranchCode);
            param[7] = new SqlParameter("@MobileNumber", branch.MobileNumber);
            param[8] = new SqlParameter("@EmailAddress", branch.EmailAddress);
            param[9] = new SqlParameter("@Address", branch.Address);
            param[10] = new SqlParameter("@Password", branch.Password);
            param[11] = new SqlParameter("@LogoPath", branch.LogoPath);
            return da.InsertSP(param, command);
        }
        public int updateBranch(Branch branch) {
            string command = "dbo.spBranchOperation";
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@InstituteRegNo", branch.InstituteRegNo);
            param[1] = new SqlParameter("@InstittuteName", branch.InstittuteName);
            param[2] = new SqlParameter("@DirectorName", branch.DirectorName);
            param[3] = new SqlParameter("@AccountantName", branch.AccountantName);
            param[4] = new SqlParameter("@Website", branch.Website);
            param[5] = new SqlParameter("@BranchCode", branch.BranchCode);
            param[6] = new SqlParameter("@MobileNumber", branch.MobileNumber);
            param[7] = new SqlParameter("@EmailAddress", branch.EmailAddress);
            param[8] = new SqlParameter("@Address", branch.Address);
            param[9] = new SqlParameter("@Password", branch.Password);
            param[10] = new SqlParameter("@LogoPath", branch.LogoPath);
            return da.InsertSP(param, command);
        }
        public bool Login(String Email, String Password, String BranchCode)
        {
           
            DataTable dt;
            bool allow = false;
            string command = "SELECT * FROM dbo.Branch WHERE EmailAddress=@Email and Password=@Password and BranchCode=@BranchCode";
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Email", Email);
            param[1] = new SqlParameter("@Password", Password);
            param[2] = new SqlParameter("@BranchCode" , BranchCode);
            dt = da.FetchByParameter(param, command);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["EmailAddress"].ToString().Contains(Email) && dt.Rows[0]["Password"].ToString().Contains(Password) && dt.Rows[0]["BranchCode"].ToString().Contains(BranchCode))
                {
                    allow = true;
                }
            }
            return allow;

        }
        public List<Branch> getAllBranches() {

            string command = "SELECT * FROM Branch";
            List<Branch> branches = new List<Branch>();
            DataTable dt = new DataTable();
                dt = da.FetchAll(command);
                if (dt.Rows.Count > 0)
                {
                branches = (from DataRow dr in dt.Rows
                                   select new Branch()
                                   {
                                       Id = int.Parse(dr["Id"].ToString()),
                                       InstituteRegNo = dr["InstituteRegNo"].ToString(),
                                       InstittuteName = dr["InstittuteName"].ToString(),
                                       DirectorName = dr["DirectorName"].ToString(),
                                       AccountantName = dr["AccountantName"].ToString(),
                                       Website = dr["Website"].ToString(),
                                       BranchCode = dr["BranchCode"].ToString(),
                                       MobileNumber = dr["MobileNumber"].ToString(),
                                       EmailAddress = dr["EmailAddress"].ToString(),
                                       Address = dr["Address"].ToString(),
                                       Password = dr["Password"].ToString(),
                                       LogoPath = dr["LogoPath"].ToString(),
                                       CreatedAt = DateTime.Parse(dr["CreatedAt"].ToString())
                                   }).ToList();
                }  
            return branches;
        }
        public DataTable getData(String Email, String Password)
        {
            string command = "SELECT * FROM dbo.Branch WHERE EmailAddress=@Email and Password=@Password";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Email", Email);
            param[1] = new SqlParameter("@Password", Password);
            return da.FetchByParameter(param, command);
        }
        public bool DeleteBranch(int Id)
        {

            string command = "DELETE FROM Branch WHERE Id=@Id";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", Id);
            return da.Insert(param, command);
        }

    }
}