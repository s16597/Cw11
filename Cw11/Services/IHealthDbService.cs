using Cw11.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Services
{
    public interface IHealthDbService
    {
        public IEnumerable<Doctor> GetDoctors();
        public IEnumerable<Doctor> GetDoctor(string id);
        public Doctor AddDoctor(Doctor doctor);
        public Doctor UpdateDoctor(int id, Doctor doctor);
        public Boolean DeleteDoctor(Doctor doctor);
    }
}
