using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeManagement.Entity;

namespace EmployeeManagement.DAO
{
    public class EmployeeDAO
    {
        public EmployeeDAO() { }
        public List<EmployeeEntity> FindAll()
        {
            List<EmployeeEntity> listEmployee = new List<EmployeeEntity>();
            return listEmployee;
        }
        public EmployeeEntity Find(string pkey)
        {
            EmployeeEntity employeeEntity = new EmployeeEntity();
            return employeeEntity;
        }
        public int Insert(EmployeeEntity entity)
        {
            int result = 0;
            return result;
        }
        public int Update(EmployeeEntity entity)
        {
            int result = 0;
            return result;
        }
        public int Delete(EmployeeEntity entity)
        {
            int result = 0;
            return result;
        }
    }
}