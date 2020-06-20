using Cw11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Cw11.ExtensionMethods;
using System.Threading.Tasks;

namespace Cw11.Services
{
    public class HealthDbService : IHealthDbService
    {
        private readonly HealthDbContext _context;
        public HealthDbService(HealthDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Doctor> GetDoctor(string id)
        {
            var _doctors = _context.Doctors.Where(p => p.IdDoctor.ToString() == id).Select(p => new Doctor()
            {
                IdDoctor = p.IdDoctor,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email
            }).ToList();

            return _doctors;
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _context.Doctors.ToList();
        }

        public Doctor AddDoctor(Doctor doctor)
        {
            try
            {
                _context.Doctors.Add(doctor);
                _context.SaveChanges();
                return doctor;
            }
            catch (Exception e)
            {
                return null;
            }
        }
       public Doctor UpdateDoctor(int id, Doctor doctor)
        {
            try
            {
                var doc = _context.Doctors.Where(d => d.IdDoctor.Equals(id)).First();
                doc.SetProperty("FirstName", doctor.FirstName);
                doc.SetProperty("LastName", doctor.LastName);
                doc.SetProperty("Email", doctor.Email);
                _context.SaveChanges();
                return doc;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
 
        public bool DeleteDoctor(Doctor doctor)
        {
            if (_context.Doctors.Contains(doctor))
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

    }
}
