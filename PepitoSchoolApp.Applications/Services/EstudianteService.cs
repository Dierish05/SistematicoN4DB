using PepitoSchoolApp.Applications.Interfaces;
using PepitoSchoolApp.Domain.Entities;
using PepitoSchoolApp.Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchoolApp.Applications.Services
{
    public class EstudianteService : IEstudianteService
    {
        private IEstudianteRepository estudianteRepository;
            
        public EstudianteService(IEstudianteRepository estudianteRepository)
        {
            this.estudianteRepository = estudianteRepository;
        }
        public List<Estudiante> CalcularPromedio(int Matematicas, int Contabilidad, int Programacion, int Estadistica)
        {
            return estudianteRepository.CalcularPromedio(Matematicas, Contabilidad, Programacion, Estadistica);
        }

        public void Create(Estudiante t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("El Estudiante no puede ser null.");
            }
            estudianteRepository.Create(t);
        }

        public bool Delete(Estudiante t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("El Estudiante no puede ser null.");
            }
            return estudianteRepository.Delete(t);
        }

        public Estudiante FindByCarnet(string carnet)
        {
            return estudianteRepository.FindByCarnet(carnet);
        }

        public List<Estudiante> FindByName(string name)
        {
            return estudianteRepository.FindByName(name);
        }

        public List<Estudiante> GetAll()
        {
            return estudianteRepository.GetAll();
        }

        public int Update(Estudiante t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("El Estudiante no puede ser null.");
            }
            return estudianteRepository.Update(t);
        }
    }
}
