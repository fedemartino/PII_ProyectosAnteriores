namespace PicEditor
{
    partial class GUI
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
            this.cmbImagen = new System.Windows.Forms.ComboBox();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.grpImagen = new System.Windows.Forms.GroupBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.txtImagen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoadTags = new System.Windows.Forms.Button();
            this.txtTags = new System.Windows.Forms.TextBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.cmbFiltros = new System.Windows.Forms.ComboBox();
            this.imageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tagFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.tabFiltros = new System.Windows.Forms.TabControl();
            this.tabFiltroUnico = new System.Windows.Forms.TabPage();
            this.tabFiltroMultiple = new System.Windows.Forms.TabPage();
            this.lstViewSecuenciaFiltros = new System.Windows.Forms.ListView();
            this.lstViewFiltros = new System.Windows.Forms.ListView();
            this.btnRemoveFilter = new System.Windows.Forms.Button();
            this.btnAddFilter = new System.Windows.Forms.Button();
            this.grpImagen.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            this.tabFiltros.SuspendLayout();
            this.tabFiltroUnico.SuspendLayout();
            this.tabFiltroMultiple.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbImagen
            // 
            this.cmbImagen.AutoCompleteCustomSource.AddRange(new string[] {
            "Mario Bros.",
            "Sr. Myagi",
            "Imagen prueba 1",
            "Imagen prueba 2",
            "Nueva imagen..."});
            this.cmbImagen.FormattingEnabled = true;
            this.cmbImagen.Items.AddRange(new object[] {
            "Mario Bros.",
            "Sr. Myagi",
            "Imagen prueba 1",
            "Imagen prueba 2",
            "Nueva Imagen..."});
            this.cmbImagen.Location = new System.Drawing.Point(6, 19);
            this.cmbImagen.Name = "cmbImagen";
            this.cmbImagen.Size = new System.Drawing.Size(121, 21);
            this.cmbImagen.TabIndex = 0;
            this.cmbImagen.SelectedIndexChanged += new System.EventHandler(this.cmbImagen_SelectedIndexChanged);
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(193, 276);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(75, 23);
            this.btnMostrar.TabIndex = 1;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // grpImagen
            // 
            this.grpImagen.Controls.Add(this.btnLoadImage);
            this.grpImagen.Controls.Add(this.txtImagen);
            this.grpImagen.Controls.Add(this.label1);
            this.grpImagen.Controls.Add(this.cmbImagen);
            this.grpImagen.Location = new System.Drawing.Point(8, 2);
            this.grpImagen.Name = "grpImagen";
            this.grpImagen.Size = new System.Drawing.Size(271, 77);
            this.grpImagen.TabIndex = 2;
            this.grpImagen.TabStop = false;
            this.grpImagen.Text = "Imagen";
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Enabled = false;
            this.btnLoadImage.Location = new System.Drawing.Point(171, 44);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(75, 23);
            this.btnLoadImage.TabIndex = 5;
            this.btnLoadImage.Text = "Browse";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // txtImagen
            // 
            this.txtImagen.Enabled = false;
            this.txtImagen.Location = new System.Drawing.Point(6, 46);
            this.txtImagen.Name = "txtImagen";
            this.txtImagen.Size = new System.Drawing.Size(159, 20);
            this.txtImagen.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccionar imagen";
            // 
            // btnLoadTags
            // 
            this.btnLoadTags.Enabled = false;
            this.btnLoadTags.Location = new System.Drawing.Point(161, 42);
            this.btnLoadTags.Name = "btnLoadTags";
            this.btnLoadTags.Size = new System.Drawing.Size(75, 23);
            this.btnLoadTags.TabIndex = 7;
            this.btnLoadTags.Text = "Browse";
            this.btnLoadTags.UseVisualStyleBackColor = true;
            this.btnLoadTags.Click += new System.EventHandler(this.btnLoadTags_Click);
            // 
            // txtTags
            // 
            this.txtTags.Enabled = false;
            this.txtTags.Location = new System.Drawing.Point(6, 42);
            this.txtTags.Name = "txtTags";
            this.txtTags.Size = new System.Drawing.Size(149, 20);
            this.txtTags.TabIndex = 6;
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(138, 18);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(85, 13);
            this.lblFiltro.TabIndex = 3;
            this.lblFiltro.Text = "Seleccionar filtro";
            // 
            // cmbFiltros
            // 
            this.cmbFiltros.FormattingEnabled = true;
            this.cmbFiltros.Items.AddRange(new object[] {
            "Ninguno",
            "Negativo",
            "Blanco & Negro",
            "Grises",
            "Suavizar",
            "Relieve",
            "Tags"});
            this.cmbFiltros.Location = new System.Drawing.Point(6, 15);
            this.cmbFiltros.Name = "cmbFiltros";
            this.cmbFiltros.Size = new System.Drawing.Size(121, 21);
            this.cmbFiltros.TabIndex = 2;
            this.cmbFiltros.SelectedIndexChanged += new System.EventHandler(this.cmbFiltros_SelectedIndexChanged);
            // 
            // imageFileDialog
            // 
            this.imageFileDialog.FileName = "openFileDialog1";
            // 
            // tagFileDialog
            // 
            this.tagFileDialog.FileName = "openFileDialog2";
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.tabFiltros);
            this.grpFiltros.Location = new System.Drawing.Point(8, 85);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(271, 185);
            this.grpFiltros.TabIndex = 8;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros";
            // 
            // tabFiltros
            // 
            this.tabFiltros.Controls.Add(this.tabFiltroUnico);
            this.tabFiltros.Controls.Add(this.tabFiltroMultiple);
            this.tabFiltros.Location = new System.Drawing.Point(6, 19);
            this.tabFiltros.Name = "tabFiltros";
            this.tabFiltros.SelectedIndex = 0;
            this.tabFiltros.Size = new System.Drawing.Size(254, 156);
            this.tabFiltros.TabIndex = 9;
            // 
            // tabFiltroUnico
            // 
            this.tabFiltroUnico.BackColor = System.Drawing.SystemColors.Control;
            this.tabFiltroUnico.Controls.Add(this.btnLoadTags);
            this.tabFiltroUnico.Controls.Add(this.lblFiltro);
            this.tabFiltroUnico.Controls.Add(this.txtTags);
            this.tabFiltroUnico.Controls.Add(this.cmbFiltros);
            this.tabFiltroUnico.Location = new System.Drawing.Point(4, 22);
            this.tabFiltroUnico.Name = "tabFiltroUnico";
            this.tabFiltroUnico.Padding = new System.Windows.Forms.Padding(3);
            this.tabFiltroUnico.Size = new System.Drawing.Size(246, 130);
            this.tabFiltroUnico.TabIndex = 0;
            this.tabFiltroUnico.Text = "Single";
            // 
            // tabFiltroMultiple
            // 
            this.tabFiltroMultiple.BackColor = System.Drawing.SystemColors.Control;
            this.tabFiltroMultiple.Controls.Add(this.lstViewSecuenciaFiltros);
            this.tabFiltroMultiple.Controls.Add(this.lstViewFiltros);
            this.tabFiltroMultiple.Controls.Add(this.btnRemoveFilter);
            this.tabFiltroMultiple.Controls.Add(this.btnAddFilter);
            this.tabFiltroMultiple.Location = new System.Drawing.Point(4, 22);
            this.tabFiltroMultiple.Name = "tabFiltroMultiple";
            this.tabFiltroMultiple.Padding = new System.Windows.Forms.Padding(3);
            this.tabFiltroMultiple.Size = new System.Drawing.Size(246, 130);
            this.tabFiltroMultiple.TabIndex = 1;
            this.tabFiltroMultiple.Text = "Multiple";
            // 
            // lstViewSecuenciaFiltros
            // 
            this.lstViewSecuenciaFiltros.FullRowSelect = true;
            this.lstViewSecuenciaFiltros.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstViewSecuenciaFiltros.Location = new System.Drawing.Point(140, 6);
            this.lstViewSecuenciaFiltros.MultiSelect = false;
            this.lstViewSecuenciaFiltros.Name = "lstViewSecuenciaFiltros";
            this.lstViewSecuenciaFiltros.Size = new System.Drawing.Size(99, 108);
            this.lstViewSecuenciaFiltros.TabIndex = 12;
            this.lstViewSecuenciaFiltros.UseCompatibleStateImageBehavior = false;
            this.lstViewSecuenciaFiltros.View = System.Windows.Forms.View.List;
            // 
            // lstViewFiltros
            // 
            this.lstViewFiltros.FullRowSelect = true;
            this.lstViewFiltros.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstViewFiltros.Location = new System.Drawing.Point(6, 6);
            this.lstViewFiltros.MultiSelect = false;
            this.lstViewFiltros.Name = "lstViewFiltros";
            this.lstViewFiltros.Size = new System.Drawing.Size(99, 108);
            this.lstViewFiltros.TabIndex = 9;
            this.lstViewFiltros.UseCompatibleStateImageBehavior = false;
            this.lstViewFiltros.View = System.Windows.Forms.View.List;
            // 
            // btnRemoveFilter
            // 
            this.btnRemoveFilter.Location = new System.Drawing.Point(111, 35);
            this.btnRemoveFilter.Name = "btnRemoveFilter";
            this.btnRemoveFilter.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveFilter.TabIndex = 11;
            this.btnRemoveFilter.Text = "<";
            this.btnRemoveFilter.UseVisualStyleBackColor = true;
            this.btnRemoveFilter.Click += new System.EventHandler(this.btnRemoveFilter_Click);
            // 
            // btnAddFilter
            // 
            this.btnAddFilter.Location = new System.Drawing.Point(111, 6);
            this.btnAddFilter.Name = "btnAddFilter";
            this.btnAddFilter.Size = new System.Drawing.Size(23, 23);
            this.btnAddFilter.TabIndex = 10;
            this.btnAddFilter.Text = ">";
            this.btnAddFilter.UseVisualStyleBackColor = true;
            this.btnAddFilter.Click += new System.EventHandler(this.btnAddFilter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 308);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.grpImagen);
            this.Controls.Add(this.btnMostrar);
            this.Name = "Form1";
            this.Text = "Editar Imagenes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpImagen.ResumeLayout(false);
            this.grpImagen.PerformLayout();
            this.grpFiltros.ResumeLayout(false);
            this.tabFiltros.ResumeLayout(false);
            this.tabFiltroUnico.ResumeLayout(false);
            this.tabFiltroUnico.PerformLayout();
            this.tabFiltroMultiple.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbImagen;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.GroupBox grpImagen;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.TextBox txtImagen;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.ComboBox cmbFiltros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadTags;
        private System.Windows.Forms.TextBox txtTags;
        private System.Windows.Forms.OpenFileDialog imageFileDialog;
        private System.Windows.Forms.OpenFileDialog tagFileDialog;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.TabControl tabFiltros;
        private System.Windows.Forms.TabPage tabFiltroUnico;
        private System.Windows.Forms.TabPage tabFiltroMultiple;
        private System.Windows.Forms.Button btnRemoveFilter;
        private System.Windows.Forms.Button btnAddFilter;
        private System.Windows.Forms.ListView lstViewFiltros;
        private System.Windows.Forms.ListView lstViewSecuenciaFiltros;
    }
}

