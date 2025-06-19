using Microsoft.EntityFrameworkCore;
using ProyectoCiber.Data;
using ProyectoCiber.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCiber.Desktop
{
    public partial class FormTurno : Form
    {
        public FormTurno()
        {
            InitializeComponent();
            CargarTurnos();
        }

        private void CargarPCs()
        {
            try
            {
                using var db = new NuevoTurnoDBContext();
                var pcs = db.PCs.ToList();
                cbPCs.DataSource = pcs;
                cbPCs.DisplayMember = "Tipo";
                cbPCs.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar PCs: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTurnos()
        {
            try
            {
                using var db = new NuevoTurnoDBContext();
                var turnos = db.Turnos.Include(t => t.PC).ToList();
                dgvTurnos.DataSource = turnos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar turnos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrearTurno_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones
                if (cbPCs.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, seleccione una PC.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using var db = new NuevoTurnoDBContext();

                // Crear nuevo turno
                var turno = new Turno
                {
                    PCId = (int)cbPCs.SelectedValue,
                    HorarioDeInicio = dtInicio.Value,
                    
                };

                db.Turnos.Add(turno);
                db.SaveChanges();

                MessageBox.Show("Turno creado exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                CargarTurnos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el turno: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            cbPCs.SelectedIndex = -1;
            dtInicio.Value = DateTime.Now;
        }

        private void dgvTurnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dgvTurnos.Rows[e.RowIndex];

                    // Cargar datos del turno seleccionado en los controles
                    if (row.Cells["PCId"]?.Value != null)
                    {
                        cbPCs.SelectedValue = row.Cells["PCId"].Value;
                    }

                    if (row.Cells["HoraDeInicio"]?.Value != null)
                    {
                        string fechaString = row.Cells["HoraDeInicio"].Value.ToString() ?? string.Empty;
                        if (DateTime.TryParse(fechaString, out DateTime fecha))
                        {
                            dtInicio.Value = fecha;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al seleccionar el turno: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormTurno_Load(object sender, EventArgs e)
        {
            InitializeComponent();
           ;
        }
    }
}
