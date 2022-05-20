using PepitoSchoolApp.Domain.Entities;
using PepitoSchoolApp.Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchoolApp.Infraestructure.Repositories
{
    public class EFEstudianteRepository : IEstudianteRepository
    {
        public IPepitoSchoolContext pepitoSchoolContext;

        public EFEstudianteRepository(IPepitoSchoolContext pepitoSchoolContext)
        {
            this.pepitoSchoolContext = pepitoSchoolContext;
        }
        public List<Estudiante> CalcularPromedio(int Matematicas, int Contabilidad, int Programacion, int Estadistica)
        {
            throw new NotImplementedException();
        }

        public void Create(Estudiante t)
        {
            try
            {
                pepitoSchoolContext.Estudiantes.Add(t);
                pepitoSchoolContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(Estudiante t)
        {
            try
            {
                if (t == null)
            {
                throw new ArgumentNullException("El objeto Asset no puede ser null.");
            }

            Estudiante estudiante = FindByCarnet(t.Carnet);
            if (estudiante == null)
            {
                throw new Exception($"El objeto con carnet {t.Carnet} no existe.");
            }

            pepitoSchoolContext.Estudiantes.Remove(estudiante);
            int result = pepitoSchoolContext.SaveChanges();

            return result > 0;
            }
            catch(Exception)
            {
                throw;
            }
}

        public Estudiante FindByCarnet(string carnet)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(carnet))
                {
                    throw new Exception($"El parametro code {carnet} no tiene el formato correcto.");
                }

                return pepitoSchoolContext.Estudiantes.FirstOrDefault(x => x.Carnet.Equals(carnet));
            }
            catch
            {
                throw;
            }
        }

        public List<Estudiante> FindByName(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new Exception($"El parametro name '{name}' no tiene el formato correcto.");
                }

                return pepitoSchoolContext.Estudiantes
                                        .Where(x => x.Nombres.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                                        .ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<Estudiante> GetAll()
        {
            return pepitoSchoolContext.Estudiantes.ToList();
        }

        public int Update(Estudiante t)
        {
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException("El objeto estudiante no puede ser null.");
                }

                Estudiante estudiante = FindByCarnet(t.Carnet);
                if (estudiante == null)
                {
                    throw new Exception($"El objeto estudiante con id {t.Id} no existe.");
                }

                estudiante.Nombres = t.Nombres;
                estudiante.Apellidos = t.Apellidos;
                estudiante.Carnet = t.Carnet;
                estudiante.Phone = t.Phone;
                estudiante.Direccion = t.Direccion;
                estudiante.Correo = t.Correo;
                estudiante.Matematicas = t.Matematicas;
                estudiante.Contabilidad = t.Contabilidad;
                estudiante.Programacion = t.Programacion;
                estudiante.Estadistica = t.Estadistica;

                pepitoSchoolContext.Estudiantes.Update(estudiante);
                return pepitoSchoolContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
