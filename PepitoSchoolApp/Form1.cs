using PepitoSchoolApp.Applications.Interfaces;
using PepitoSchoolApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PepitoSchoolApp
{
    public partial class Form1 : Form
    {
        private IEstudianteService estudianteService;
        public Form1(IEstudianteService estudianteService)
        {
            this.estudianteService = estudianteService;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = false;
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            limpiar();
            dgvEstudiantes.DataSource = estudianteService.GetAll();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool verificado = verificar();
            if (verificado == false)
            {
                MessageBox.Show("Tienes que llenar todos los campos.");
            }
            else
            {
                Estudiante estudiante = new Estudiante()
                {
                    Nombres = txtNombres.Text,
                    Apellidos = txtApellidos.Text,
                    Carnet = txtCarnet.Text,
                    Phone = txtPhone.Text,
                    Direccion = txtDireccion.Text,
                    Correo = txtCorreo.Text,
                    Matematicas = (int)nudMatematicas.Value,
                    Contabilidad = (int)nudContabilidad.Value,
                    Programacion = (int)nudProgramacion.Value,
                    Estadistica = (int)nudEstadistica.Value
                };
                estudianteService.Create(estudiante);
                LoadDataGridView();
            }   
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool verificado = verificar();
            if (verificado == false)
            {
                MessageBox.Show("Tienes que llenar todos los campos.");
            }
            else
            {
                Estudiante estudiante = new Estudiante()
                {
                    Id = int.Parse(txtId.Text),
                    Nombres = txtNombres.Text,
                    Apellidos = txtApellidos.Text,
                    Carnet = txtCarnet.Text,
                    Phone = txtPhone.Text,
                    Direccion = txtDireccion.Text,
                    Correo = txtCorreo.Text,
                    Matematicas = (int)nudMatematicas.Value,
                    Contabilidad = (int)nudContabilidad.Value,
                    Programacion = (int)nudProgramacion.Value,
                    Estadistica = (int)nudEstadistica.Value
                };
                estudianteService.Delete(estudiante);
                LoadDataGridView();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool verificado = verificar();
            if (verificado == false)
            {
                MessageBox.Show("Tienes que llenar todos los campos.");
            }
            else
            {
                Estudiante estudiante = new Estudiante()
                {
                    Id = int.Parse(txtId.Text),
                    Nombres = txtNombres.Text,
                    Apellidos = txtApellidos.Text,
                    Carnet = txtCarnet.Text,
                    Phone = txtPhone.Text,
                    Direccion = txtDireccion.Text,
                    Correo = txtCorreo.Text,
                    Matematicas = (int)nudMatematicas.Value,
                    Contabilidad = (int)nudContabilidad.Value,
                    Programacion = (int)nudProgramacion.Value,
                    Estadistica = (int)nudEstadistica.Value
                };
                estudianteService.Update(estudiante);
                LoadDataGridView();
            } 
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if (txtId.Text == String.Empty)
            {
                if (txtNombres.Text == String.Empty)
                {
                    btnAdd.Enabled = false;
                }
                else
                {
                    btnAdd.Enabled = true;
                }
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void dgvEstudiantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                limpiar();
                int f = e.RowIndex;
                txtId.Text = dgvEstudiantes.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                txtNombres.Text = dgvEstudiantes.Rows[e.RowIndex].Cells["Nombres"].Value.ToString();
                txtApellidos.Text = dgvEstudiantes.Rows[e.RowIndex].Cells["Apellidos"].Value.ToString();
                txtCarnet.Text = dgvEstudiantes.Rows[e.RowIndex].Cells["Carnet"].Value.ToString();
                txtPhone.Text = dgvEstudiantes.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
                txtDireccion.Text = dgvEstudiantes.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();
                txtCorreo.Text = dgvEstudiantes.Rows[e.RowIndex].Cells["Correo"].Value.ToString();
                nudMatematicas.Value = (int)dgvEstudiantes.Rows[e.RowIndex].Cells["Matematicas"].Value;
                nudContabilidad.Value = (int)dgvEstudiantes.Rows[e.RowIndex].Cells["Contabilidad"].Value;
                nudProgramacion.Value = (int)dgvEstudiantes.Rows[e.RowIndex].Cells["Programacion"].Value;
                nudEstadistica.Value = (int)dgvEstudiantes.Rows[e.RowIndex].Cells["Estadistica"].Value;
            }
        }

        private void limpiar()
        {
            this.txtId.Text = string.Empty;
            this.txtNombres.Text = string.Empty;
            this.txtApellidos.Text = string.Empty;
            this.txtCarnet.Text = string.Empty;
            this.txtPhone.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtCorreo.Text = string.Empty;
            this.nudMatematicas.Value = nudMatematicas.Minimum;
            this.nudContabilidad.Value = nudContabilidad.Minimum;
            this.nudProgramacion.Value = nudProgramacion.Minimum;
            this.nudEstadistica.Value = nudEstadistica.Minimum;
        }

        private bool verificar()
        {
            if (String.IsNullOrEmpty(txtNombres.Text) || String.IsNullOrEmpty(txtApellidos.Text) || String.IsNullOrEmpty(txtCarnet.Text) || String.IsNullOrEmpty(txtPhone.Text) || String.IsNullOrEmpty(txtDireccion.Text) || String.IsNullOrEmpty(txtCorreo.Text) || nudMatematicas.Value < 0 || nudContabilidad.Value < 0 || nudProgramacion.Value < 0 || nudEstadistica.Value < 0)
            {

                return false;
            }
            return true;
        }

        private void btnPromedio_Click(object sender, EventArgs e)
        {
            int i = dgvEstudiantes.CurrentCell.RowIndex;

            if(i >= 0)
            {
                Estudiante estudiante = estudianteService.GetAll()[i];
                int suma = estudiante.Matematicas + estudiante.Contabilidad + estudiante.Programacion + estudiante.Estadistica;
                int promedio = suma / 4;
                MessageBox.Show($"el promedio de notas de {estudiante.Nombres} {estudiante.Apellidos} es de: {promedio} ");
            }
        }
    }
}
