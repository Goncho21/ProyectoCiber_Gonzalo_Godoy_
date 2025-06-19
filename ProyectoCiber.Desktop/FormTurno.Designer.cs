using ProyectoCiber.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace ProyectoCiber.Desktop
{
    partial class FormTurno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cbPCs = new ComboBox();
            dtInicio = new DateTimePicker();
            btnCrearTurno = new Button();
            dgvTurnos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTurnos).BeginInit();
            SuspendLayout();
            // 
            // cbPCs
            // 
            cbPCs.FormattingEnabled = true;
            cbPCs.Location = new Point(46, 96);
            cbPCs.Name = "cbPCs";
            cbPCs.Size = new Size(307, 28);
            cbPCs.TabIndex = 0;
            // 
            // dtInicio
            // 
            dtInicio.Location = new Point(46, 42);
            dtInicio.Name = "dtInicio";
            dtInicio.Size = new Size(307, 27);
            dtInicio.TabIndex = 1;
            // 
            // btnCrearTurno
            // 
            btnCrearTurno.Location = new Point(46, 146);
            btnCrearTurno.Name = "btnCrearTurno";
            btnCrearTurno.Size = new Size(94, 29);
            btnCrearTurno.TabIndex = 2;
            btnCrearTurno.Text = "Turno";
            btnCrearTurno.UseVisualStyleBackColor = true;
            // 
            // dgvTurnos
            // 
            dgvTurnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTurnos.Location = new Point(53, 201);
            dgvTurnos.Name = "dgvTurnos";
            dgvTurnos.RowHeadersWidth = 51;
            dgvTurnos.Size = new Size(300, 207);
            dgvTurnos.TabIndex = 3;
            // 
            // FormTurno
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Indigo;
            ClientSize = new Size(390, 450);
            Controls.Add(dgvTurnos);
            Controls.Add(btnCrearTurno);
            Controls.Add(dtInicio);
            Controls.Add(cbPCs);
            Name = "FormTurno";
            Text = "FormTurno";
            Load += FormTurno_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTurnos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cbPCs;
        private DateTimePicker dtInicio;
        private Button btnCrearTurno;
        private DataGridView dgvTurnos;
    }
}