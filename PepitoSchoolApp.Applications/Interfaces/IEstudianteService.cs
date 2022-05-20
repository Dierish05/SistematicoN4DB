using PepitoSchoolApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchoolApp.Applications.Interfaces
{
    public interface IEstudianteService : IService<Estudiante>
    {
        Estudiante FindByCarnet(string carnet);
        List<Estudiante> FindByName(string name);
        List<Estudiante> CalcularPromedio(int Matematicas, int Contabilidad, int Programacion, int Estadistica);
    }
}
