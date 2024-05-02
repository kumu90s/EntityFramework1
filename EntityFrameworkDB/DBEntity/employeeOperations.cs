using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using EntityFrameworkModel;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;



namespace EntityFrameworkDB.DBEntity
{
    public class employeeOperations
    {
        public int AddEmployee(EmployeeModel employeeModel)
        {
            //var result = getEmployee();
            using (var context = new EntityDbEntities())
            {
                EmployeeTb empTb = new EmployeeTb
                {
                    FirstName = employeeModel.FirstName,
                    LastName = employeeModel.LastName,
                    Email = employeeModel.Email,
                    code = employeeModel.code
                };
                if(employeeModel.Address !=null)
                {
                    empTb.AddressTb = new AddressTb
                    {
                        Details=employeeModel.Address.Details,
                        state= employeeModel.Address.state,
                        country= employeeModel.Address.country
                    };
                }
                context.EmployeeTb.Add(empTb);
                context.SaveChanges();
                return empTb.Id;
            }
        }

        public List<EmployeeModel> getAllEmployess()
        {
            using (var context = new EntityDbEntities())
            {
                var result = context.EmployeeTb.Select(x => new EmployeeModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    code= x.code,
                    AddressId = x.AddressId,
                    Address =new AddressModel()
                    {
                        //Id = x.Address.Id,
                        //state = x.Address.state,
                        //country = x.Address.country,
                        //Details = x.Address.Details
                    }

                }).ToList();

                return result;
            }
        }

        public EmployeeModel getEmployess( int id)
        {
            using (var context = new EntityDbEntities())
            {
                var result = context.EmployeeTb
                    .Where(x=>x.Id==id)
                    .Select(x => new EmployeeModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    code = x.code,
                    AddressId = x.AddressId,
                    Address = new AddressModel()
                    {
                        //Id = x.Address.Id,
                        //state = x.Address.state,
                        //country = x.Address.country,
                        //Details = x.Address.Details
                    }

                }).FirstOrDefault();

                return result;
            }
        }

        public bool UpdateEmployee(int id, EmployeeModel _employeeModel)
        {
            using ( var context = new EntityDbEntities())
            {
                var employee = context.EmployeeTb.FirstOrDefault(x => x.Id==id);

                if(employee != null)
                {
                    employee.FirstName = _employeeModel.FirstName;
                    employee.LastName = _employeeModel.LastName;
                    employee.Email = _employeeModel.Email;
                    employee.code = _employeeModel.code;
                }

                context.SaveChanges();

                return true;
            }
        }

        public bool DeleteEmployess(int id)
        {
            using (var context = new EntityDbEntities())
            {
                var employee =context.EmployeeTb.FirstOrDefault( x => x.Id==id);
                if(employee != null)
                {
                    context.EmployeeTb.Remove(employee);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
