using Doctor_management.ConnectionString;
using Doctor_management.interfaces;
using Doctor_management.Models;
using Microsoft.CodeAnalysis.Options;
using System.Data;
using System.Data.SqlClient;

namespace Doctor_management.BusinessLayer
{
    public class DataAccess : IDataAccess
    {
        string cs = ConnectionClass.dbcs;
        public void usersignup(signup adm)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("usp_signup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", adm.Name);
                cmd.Parameters.AddWithValue("@Email", adm.Email);
                cmd.Parameters.AddWithValue("@Phonenumber", adm.PhoneNumber);
                cmd.Parameters.AddWithValue("@Password", adm.Password);
                cmd.Parameters.AddWithValue("@Utype", adm.utype);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


            }



        }


        public DataTable UserLogin(string Emailid, string Password)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("usp_signin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EMail", Emailid);
                cmd.Parameters.AddWithValue("@Password", Password);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }


        }




        public void AddUpdateDeleteMedicineCategory(MedicineCategory objMedicineCategory)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("usp_medicinecategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MedicineCategoryId", objMedicineCategory.MedicineCategoryId);
                cmd.Parameters.AddWithValue("@Categoryname", objMedicineCategory.CategoryName);
                cmd.Parameters.AddWithValue("@description", objMedicineCategory.Descreption);
                cmd.Parameters.AddWithValue("@addedby", objMedicineCategory.AddedBy);
                cmd.Parameters.AddWithValue("@addedon", DateTime.Now);
                cmd.Parameters.AddWithValue("@Isactive", objMedicineCategory.Status == 1 ? true : false);
                cmd.Parameters.AddWithValue("@mode", objMedicineCategory.Mode);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


            }



        }


        public List<MedicineCategory> MedicineCategoryList(int MedicineCategoryId, string Mode)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                List<MedicineCategory> objMedicinecategoryList = new List<MedicineCategory>();
                SqlCommand cmd = new SqlCommand("usp_BindMedicinecategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MedicineCategoryId", MedicineCategoryId);
                cmd.Parameters.AddWithValue("@mode", Mode);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd;
                da.Fill(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objMedicinecategoryList.Add(
                            new MedicineCategory
                            {
                                MedicineCategoryId = Convert.ToInt32(dt.Rows[i]["MedicineCategoryId"]),
                                CategoryName = dt.Rows[i]["Categoryname"].ToString(),
                                Descreption = dt.Rows[i]["description"].ToString(),
                                AddedBy = dt.Rows[i]["addedby"].ToString(),
                                AddedOn = dt.Rows[i]["addedon"].ToString(),
                                CategoryStatus = dt.Rows[i]["Status"].ToString(),
                                isactive = Convert.ToBoolean(dt.Rows[i]["isactive"])

                            });
                    }
                }

                return objMedicinecategoryList;
            }


        }


        public List<dropdown> GetDataFromDatabase()
        {
            List<dropdown> options = new List<dropdown>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "SELECT MedicineCategoryId  as  Id, Categoryname as Name FROM medicinecategory ";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dropdown option = new dropdown
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString()
                        };
                        options.Add(option);
                    }
                    reader.Close();
                }
            }
            return options;
        }


        public List<dropdown> BindPatientNames()
        {
            List<dropdown> options = new List<dropdown>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select Uid as Id,Name  As Name from signup where Utype=2 AND isactive=1 ";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dropdown option = new dropdown
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString()
                        };
                        options.Add(option);
                    }
                    reader.Close();
                }
            }
            return options;
        }

        public List<dropdown> BindMedicinePres()
        {
            List<dropdown> options = new List<dropdown>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select MedicineId as Id,name  As Name from medicinemaster  ";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dropdown option = new dropdown
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString()
                        };
                        options.Add(option);
                    }
                    reader.Close();
                }
            }
            return options;
        }
        public List<dropdown> BindDiagnosticPres()
        {
            List<dropdown> options = new List<dropdown>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select DMID as Id,daignostic  As Name from daignostic_master ";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dropdown option = new dropdown
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString()
                        };
                        options.Add(option);
                    }
                    reader.Close();
                }
            }
            return options;
        }

        public void AddUpdateDeleteMedicineMaster(medicinemaster objMedicinemaster)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("usp_medicinemaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MedicineId", objMedicinemaster.MedicineId);
                cmd.Parameters.AddWithValue("@MedicineCat", objMedicinemaster.MedicineCategory);
                cmd.Parameters.AddWithValue("@description", objMedicinemaster.Descreption);
                cmd.Parameters.AddWithValue("@Power", objMedicinemaster.Power);
                cmd.Parameters.AddWithValue("@addedby", objMedicinemaster.AddedBy);
                cmd.Parameters.AddWithValue("@addedon", DateTime.Now);
                cmd.Parameters.AddWithValue("@Isactive", objMedicinemaster.Status == 1 ? true : false);
                cmd.Parameters.AddWithValue("@mode", objMedicinemaster.Mode);
                cmd.Parameters.AddWithValue("@name", objMedicinemaster.MedicineName);
                cmd.Parameters.AddWithValue("@MediccalForumla", objMedicinemaster.MedicineFormula);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


            }



        }
        public List<medicinemaster> MedicineMasterList(int MedicineId, string Mode)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                List<medicinemaster> objMedicinecategoryList = new List<medicinemaster>();
                SqlCommand cmd = new SqlCommand("usp_BindMedicineMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MedicineId", MedicineId);
                cmd.Parameters.AddWithValue("@mode", Mode);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd;
                da.Fill(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objMedicinecategoryList.Add(
                            new medicinemaster
                            {
                                MedicineId = Convert.ToInt32(dt.Rows[i]["MedicineId"]),
                                MedicineName = dt.Rows[i]["name"].ToString(),
                                MedicineCat = dt.Rows[i]["MedicineCat"].ToString(),
                                Descreption = dt.Rows[i]["description"].ToString(),
                                AddedBy = dt.Rows[i]["addedby"].ToString(),
                                AddedOn = dt.Rows[i]["addedon"].ToString(),
                                MedicineStatus = Convert.ToString(dt.Rows[i]["Status"]),
                                MedicineFormula = dt.Rows[i]["MedicineFormula"].ToString(),
                                Power = dt.Rows[i]["Power"].ToString(),


                            });
                    }
                }

                return objMedicinecategoryList;
            }
        }

        public List<MedicineEdit> MedicineEditList(int MedicineCategoryId, string Mode)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                List<MedicineEdit> objMedicineeditList = new List<MedicineEdit>();
                SqlCommand cmd = new SqlCommand("usp_BindMedicinecategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MedicineCategoryId", MedicineCategoryId);
                cmd.Parameters.AddWithValue("@mode", Mode);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd;
                da.Fill(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objMedicineeditList.Add(
                            new MedicineEdit
                            {
                                MedicineCategoryId = Convert.ToInt32(dt.Rows[i]["MedicineCategoryId"]),
                                CategoryName = dt.Rows[i]["Categoryname"].ToString(),
                                Description = dt.Rows[i]["description"].ToString(),



                            });
                    }
                }

                return objMedicineeditList;
            }
        }
        public void AddUpdateDeleteDaignosticmaster(daignostic objdaignostic)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("usp_daignostic_master", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DMID", objdaignostic.DMID);
                cmd.Parameters.AddWithValue("@daignostic", objdaignostic.daignosticc);
                cmd.Parameters.AddWithValue("@description", objdaignostic.Descreption);
                cmd.Parameters.AddWithValue("@AddedBy", objdaignostic.AddedBy);
                cmd.Parameters.AddWithValue("@AddedOn", DateTime.Now);
                cmd.Parameters.AddWithValue("@Updateby", objdaignostic.Updateby);
                cmd.Parameters.AddWithValue("@Updateon", objdaignostic.Updateon);
                cmd.Parameters.AddWithValue("@Isactive", objdaignostic.Status == 1 ? true : false);
                cmd.Parameters.AddWithValue("@mode", objdaignostic.Mode);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


            }



        }
        public List<daignostic> daignosticList(int DMID, string Mode)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                List<daignostic> objdaignosticList = new List<daignostic>();
                SqlCommand cmd = new SqlCommand("usp_BindDaignostic", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DMID", DMID);
                cmd.Parameters.AddWithValue("@mode", Mode);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd;
                da.Fill(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objdaignosticList.Add(
                            new daignostic
                            {
                                DMID = Convert.ToInt32(dt.Rows[i]["DMID"]),
                                daignosticc = dt.Rows[i]["daignostic"].ToString(),
                                Descreption = dt.Rows[i]["description"].ToString(),
                                AddedBy = dt.Rows[i]["addedby"].ToString(),
                                AddedOn = dt.Rows[i]["addedon"].ToString(),
                                DiagnosticStatus = Convert.ToString(dt.Rows[i]["Status"]),



                            });
                    }
                }

                return objdaignosticList;
            }
        }
        public void AddUpdateDeletePatientAppointment(Patient objPatient)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("usp_PateintAppointment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AID", objPatient.AID);
                cmd.Parameters.AddWithValue("@Did", objPatient.Did);
                cmd.Parameters.AddWithValue("@AddedOn", DateTime.Now);
                cmd.Parameters.AddWithValue("@AddedBy", objPatient.AddedBy);
                cmd.Parameters.AddWithValue("@ValidUpto", objPatient.ValidUpto);
                cmd.Parameters.AddWithValue("@DcotorFees", objPatient.DcotorFees);
                cmd.Parameters.AddWithValue("@Isactive", objPatient.Isactive == 1 ? true : false);
                cmd.Parameters.AddWithValue("@mode", objPatient.mode);
                cmd.Parameters.AddWithValue("@Remarks", objPatient.Remarks);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


            }



        }
        //public List<Patient> PatientAppointmentList(int MedicineCategoryId, string Mode)
        //{
        //    using (SqlConnection con = new SqlConnection(cs))
        //    {
        //        List<Patient> objMedicinecategoryList = new List<Patient>();
        //        SqlCommand cmd = new SqlCommand("usp_BindMedicinecategory", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@MedicineCategoryId", MedicineCategoryId);
        //        cmd.Parameters.AddWithValue("@mode", Mode);
        //        con.Open();
        //        SqlDataAdapter da = new SqlDataAdapter();
        //        DataTable dt = new DataTable();
        //        da.SelectCommand = cmd;
        //        da.Fill(dt);
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                objMedicinecategoryList.Add(
        //                    new MedicineCategory
        //                    {
        //                        MedicineCategoryId = Convert.ToInt32(dt.Rows[i]["MedicineCategoryId"]),
        //                        CategoryName = dt.Rows[i]["Categoryname"].ToString(),
        //                        Descreption = dt.Rows[i]["description"].ToString(),
        //                        AddedBy = dt.Rows[i]["addedby"].ToString(),
        //                        AddedOn = dt.Rows[i]["addedon"].ToString(),
        //                        CategoryStatus = dt.Rows[i]["Status"].ToString(),
        //                        isactive = Convert.ToBoolean(dt.Rows[i]["isactive"])

        //                    });
        //            }
        //        }

        //        return objMedicinecategoryList;
        //    }
        //}
    

		}
}
