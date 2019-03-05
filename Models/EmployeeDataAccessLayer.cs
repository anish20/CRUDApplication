    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    namespace CRUDApplication.Models{
        public class EmployeeDataAccessLayer{
            
            string connectionString="Your Connection String Here..";
            // To GetAll Employee Data Record.. 
            public IEnumerable<Employee> GetAllRecord(){
               try
               {
                    List<Employee> list=new List<Employee>();
                using(SqlConnection con=new SqlConnection(connectionString)){
                    string procedure="getAllEmployee";
                    SqlCommand cmd =new SqlCommand(procedure,con);
                    cmd.CommandType=CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr=cmd.ExecuteReader();
                     while (dr.Read())
                     {
                       Employee emp =new Employee();
                       emp.EmpID=Convert.ToInt32(dr["emp_id"]);  
                       emp.Name=dr["name"].ToString();
                       emp.Name=dr["gender"].ToString();
                       emp.Name=dr["department"].ToString();
                       emp.Name=dr["city"].ToString();
                       list.Add(emp);
                     }
                     con.Close();
                }
                return list;
               }
               catch (System.Exception)
               {
                   
                   throw;
               }
            }
            
            //To Add new employee record    

            public int addEmpRecord(Employee emp){
                    try
                    {
                        using(SqlConnection con=new SqlConnection(connectionString)){
                        string addRecordProcedure="addEmployee";
                        SqlCommand cmd =new SqlCommand(addRecordProcedure,con);
                        cmd.CommandType=CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@name",emp.Name);
                        cmd.Parameters.AddWithValue("@gender",emp.Gender);
                        cmd.Parameters.AddWithValue("@department",emp.Department);
                        cmd.Parameters.AddWithValue("@city",emp.City);
                        con.Open();
                        int result= cmd.ExecuteNonQuery();
                        if(result>0){
                            Console.Write("Data Inserted...");
                        }else{
                                Console.Write("Data not Inserted...");
                        }
                        return result;
                    }
                    }
                    catch (System.Exception)
                    {
                        
                        throw;
                    }
            }     


            //To Update the records of a particluar employee

                public int updateEmpRecord(Employee emp){
                        try
                        {
                            using(SqlConnection con=new SqlConnection(connectionString)){
                                string updateEmpProcedure="updateEmloyee";
                                SqlCommand cmd =new SqlCommand(updateEmpProcedure,con);
                                cmd.CommandType=CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@emp_id",emp.EmpID);
                                cmd.Parameters.AddWithValue("@name",emp.Name);
                                cmd.Parameters.AddWithValue("@gender",emp.Gender);
                                cmd.Parameters.AddWithValue("@department",emp.Department);
                                cmd.Parameters.AddWithValue("@city",emp.City);
                                con.Open();
                                int result=cmd.ExecuteNonQuery();
                                if(result>0){
                                    System.Console.WriteLine("Data updated..");
                                }else{
                                    System.Console.WriteLine("Data not updated,..");
                                }
                                 con.Close();    
                                return result;
                               
                            }
                        }
                        catch (System.Exception)
                        {
                            
                            throw;
                        }
                }

                //Get the details of a particular employee

                public int deleteEmpRecord(int? EmpID){

                try
                {
                    Employee em=new Employee();
                    using(SqlConnection con =new SqlConnection(connectionString)){
                        string deleteEmpProcedure="deleteEmployee";
                        SqlCommand cmd =new SqlCommand(deleteEmpProcedure,con);
                        cmd.CommandType=CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@emp_id",EmpID);
                        con.Open();
                        int res=cmd.ExecuteNonQuery();
                        if(res>0){
                            System.Console.WriteLine("Data deleted");
                        }else{
                            System.Console.WriteLine("data not deleted");
                        }
                        con.Close();
                        return res;
                    }
                }
                catch (System.Exception)
                {
                    
                    throw;
                }

                }   
        }
        
            
        
    }