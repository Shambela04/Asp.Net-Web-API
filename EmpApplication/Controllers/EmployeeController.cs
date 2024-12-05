using EmpApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace EmpApplication.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllEmployee")]

        public ActionResult GetEmployee()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("EmpCon"));
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM EmployeeS", con);

            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Employee> emplist = new List<Employee>();
            Response response = new Response();

            if(dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee employee = new Employee();
                    employee.Empid = Convert.ToInt32(dt.Rows[i]["Empid"]);
                    employee.FisrtName = Convert.ToString(dt.Rows[i]["FisrtName"]);
                    employee.EmpAdd = Convert.ToString(dt.Rows[i]["EmpAdd"]);
                    employee.salary = Convert.ToInt32(dt.Rows[i]["salary"]);
                    emplist.Add(employee);
                       
                }
            }
            if (emplist.Count > 0)
            {
                //return JsonConvert.SerializeObject(emplist);
                return Ok(emplist);
            }
            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "Not data found";
                //return  JsonConvert.SerializeObject(response);
                return Ok(response);
            }    

        }



    }



   

}
