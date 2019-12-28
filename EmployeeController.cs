using GetData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace GetData.Controllers
{
    public class EmployeeController : ApiController
    {

        //public HttpResponseMessage Get()
        //{
        //List<Employee_tb> employeeList = new List<Employee_tb>();
        //using (VaraprasadEntities entity = new VaraprasadEntities())
        //{
        //    employeeList = entity.Employee_tb.OrderBy(a => a.empname).ToList();
        //    HttpResponseMessage response;
        //    response = Request.CreateResponse(HttpStatusCode.OK, employeeList);
        //    return response;
        //}


        // }


        private VaraprasadEntities db;
        public EmployeeController()
        {
            db = new VaraprasadEntities();
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("Employee/GetEmployees")]
        public IEnumerable<Employee_tb> GetEmployees()
        {
            return db.Employee_tb.ToList();
        }

        [HttpPost]
        [Route("Employee/InsertEmployee")]
        public IHttpActionResult InsertEmployee(Employee_tb data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Employee_tb.Add(data);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(data);
        }

        [HttpPut]
        [Route("Employee/UpdateEmployee")]
        public IHttpActionResult UpdateEmployee(Employee_tb updatedata)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Employee_tb objEmp = new Employee_tb();
                objEmp = db.Employee_tb.Find(updatedata.empno);
                if(objEmp != null)
                {
                    objEmp.empname = updatedata.empname;
                    objEmp.jobrole = updatedata.jobrole;
                    objEmp.location = updatedata.location;
                }
                int i = this.db.SaveChanges();

            }
            catch(Exception)
            {
                throw;
            }

            return Ok(updatedata);
        }

        [HttpDelete]
        [Route("Employee/DeleteEmployee")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee_tb deleteEmp = db.Employee_tb.Find(id);
            if(deleteEmp == null)
            {
                return NotFound();
            }

            db.Employee_tb.Remove(deleteEmp);
            db.SaveChanges();

            return Ok(deleteEmp);
        }

    }
}
