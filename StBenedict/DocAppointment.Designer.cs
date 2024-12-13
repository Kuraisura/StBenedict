namespace StBenedict
{
    partial class DocAppointment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocAppointment));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dgvDocAppointment = new Guna.UI.WinForms.GunaDataGridView();
            this.txtTimeIn = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtTimeOut = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtPatFullName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTimeAvailability = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtFloor = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbAppointmentStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtDiagnosis = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.AppointmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppointmentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppointmentStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Floor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeAvailability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocAppointment)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(335, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 44);
            this.label1.TabIndex = 79;
            this.label1.Text = "Appointment";
            // 
            // btnDelete
            // 
            this.btnDelete.Animated = true;
            this.btnDelete.BorderRadius = 5;
            this.btnDelete.CheckedState.Parent = this.btnDelete;
            this.btnDelete.CustomImages.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.CustomImages.Image")));
            this.btnDelete.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDelete.CustomImages.Parent = this.btnDelete;
            this.btnDelete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.btnDelete.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(84)))), ((int)(((byte)(134)))));
            this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.HoverState.Parent = this.btnDelete;
            this.btnDelete.Location = new System.Drawing.Point(941, 165);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDelete.ShadowDecoration.Parent = this.btnDelete;
            this.btnDelete.Size = new System.Drawing.Size(92, 56);
            this.btnDelete.TabIndex = 160;
            this.btnDelete.Text = "  Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Animated = true;
            this.btnUpdate.BorderRadius = 5;
            this.btnUpdate.CheckedState.Parent = this.btnUpdate;
            this.btnUpdate.CustomImages.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.CustomImages.Image")));
            this.btnUpdate.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnUpdate.CustomImages.Parent = this.btnUpdate;
            this.btnUpdate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.btnUpdate.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(84)))), ((int)(((byte)(134)))));
            this.btnUpdate.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.HoverState.Parent = this.btnUpdate;
            this.btnUpdate.Location = new System.Drawing.Point(941, 103);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnUpdate.ShadowDecoration.Parent = this.btnUpdate;
            this.btnUpdate.Size = new System.Drawing.Size(92, 56);
            this.btnUpdate.TabIndex = 159;
            this.btnUpdate.Text = "   Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // guna2HtmlLabel7
            // 
            this.guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel7.Location = new System.Drawing.Point(139, 305);
            this.guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            this.guna2HtmlLabel7.Size = new System.Drawing.Size(123, 20);
            this.guna2HtmlLabel7.TabIndex = 170;
            this.guna2HtmlLabel7.Text = "Time Availability";
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(600, 232);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(39, 20);
            this.guna2HtmlLabel6.TabIndex = 168;
            this.guna2HtmlLabel6.Text = "Floor";
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(496, 169);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(143, 20);
            this.guna2HtmlLabel5.TabIndex = 166;
            this.guna2HtmlLabel5.Text = "Appointment Status";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(126, 173);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(137, 20);
            this.guna2HtmlLabel3.TabIndex = 163;
            this.guna2HtmlLabel3.Text = "Appointment Date";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(124, 78);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(138, 20);
            this.guna2HtmlLabel2.TabIndex = 161;
            this.guna2HtmlLabel2.Text = "Patient\'s Full Name";
            // 
            // dgvDocAppointment
            // 
            this.dgvDocAppointment.AllowUserToAddRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(223)))), ((int)(((byte)(251)))));
            this.dgvDocAppointment.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDocAppointment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDocAppointment.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            this.dgvDocAppointment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDocAppointment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDocAppointment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(120)))), ((int)(((byte)(154)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocAppointment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDocAppointment.ColumnHeadersHeight = 21;
            this.dgvDocAppointment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AppointmentID,
            this.PatientFullName,
            this.Diagnosis,
            this.AppointmentDate,
            this.AppointmentStatus,
            this.Floor,
            this.TimeAvailability,
            this.TimeIn,
            this.TimeOut,
            this.Select});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(185)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocAppointment.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDocAppointment.EnableHeadersVisualStyles = false;
            this.dgvDocAppointment.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.dgvDocAppointment.Location = new System.Drawing.Point(12, 370);
            this.dgvDocAppointment.Name = "dgvDocAppointment";
            this.dgvDocAppointment.RowHeadersVisible = false;
            this.dgvDocAppointment.RowHeadersWidth = 51;
            this.dgvDocAppointment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocAppointment.Size = new System.Drawing.Size(955, 188);
            this.dgvDocAppointment.TabIndex = 177;
            this.dgvDocAppointment.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Blue;
            this.dgvDocAppointment.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(223)))), ((int)(((byte)(251)))));
            this.dgvDocAppointment.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDocAppointment.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDocAppointment.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDocAppointment.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDocAppointment.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            this.dgvDocAppointment.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.dgvDocAppointment.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(120)))), ((int)(((byte)(154)))));
            this.dgvDocAppointment.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDocAppointment.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.dgvDocAppointment.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDocAppointment.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDocAppointment.ThemeStyle.HeaderStyle.Height = 21;
            this.dgvDocAppointment.ThemeStyle.ReadOnly = false;
            this.dgvDocAppointment.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            this.dgvDocAppointment.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDocAppointment.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvDocAppointment.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDocAppointment.ThemeStyle.RowsStyle.Height = 22;
            this.dgvDocAppointment.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(185)))), ((int)(((byte)(246)))));
            this.dgvDocAppointment.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // txtTimeIn
            // 
            this.txtTimeIn.Animated = true;
            this.txtTimeIn.BorderThickness = 2;
            this.txtTimeIn.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimeIn.DefaultText = "";
            this.txtTimeIn.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimeIn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimeIn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimeIn.DisabledState.Parent = this.txtTimeIn;
            this.txtTimeIn.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimeIn.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.txtTimeIn.FocusedState.Parent = this.txtTimeIn;
            this.txtTimeIn.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeIn.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimeIn.HoverState.Parent = this.txtTimeIn;
            this.txtTimeIn.Location = new System.Drawing.Point(269, 211);
            this.txtTimeIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTimeIn.Name = "txtTimeIn";
            this.txtTimeIn.PasswordChar = '\0';
            this.txtTimeIn.PlaceholderText = "";
            this.txtTimeIn.SelectedText = "";
            this.txtTimeIn.ShadowDecoration.Parent = this.txtTimeIn;
            this.txtTimeIn.Size = new System.Drawing.Size(189, 37);
            this.txtTimeIn.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtTimeIn.TabIndex = 179;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(208, 216);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(54, 20);
            this.guna2HtmlLabel1.TabIndex = 178;
            this.guna2HtmlLabel1.Text = "Time In";
            // 
            // txtTimeOut
            // 
            this.txtTimeOut.Animated = true;
            this.txtTimeOut.BorderThickness = 2;
            this.txtTimeOut.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimeOut.DefaultText = "";
            this.txtTimeOut.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimeOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimeOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimeOut.DisabledState.Parent = this.txtTimeOut;
            this.txtTimeOut.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimeOut.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.txtTimeOut.FocusedState.Parent = this.txtTimeOut;
            this.txtTimeOut.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeOut.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimeOut.HoverState.Parent = this.txtTimeOut;
            this.txtTimeOut.Location = new System.Drawing.Point(269, 256);
            this.txtTimeOut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTimeOut.Name = "txtTimeOut";
            this.txtTimeOut.PasswordChar = '\0';
            this.txtTimeOut.PlaceholderText = "";
            this.txtTimeOut.SelectedText = "";
            this.txtTimeOut.ShadowDecoration.Parent = this.txtTimeOut;
            this.txtTimeOut.Size = new System.Drawing.Size(189, 36);
            this.txtTimeOut.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtTimeOut.TabIndex = 181;
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(196, 261);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(67, 20);
            this.guna2HtmlLabel4.TabIndex = 180;
            this.guna2HtmlLabel4.Text = "Time Out";
            // 
            // dtpDate
            // 
            this.dtpDate.Animated = true;
            this.dtpDate.BackColor = System.Drawing.Color.White;
            this.dtpDate.CheckedState.Parent = this.dtpDate;
            this.dtpDate.CustomFormat = "yyyy-MM-dd";
            this.dtpDate.FillColor = System.Drawing.Color.White;
            this.dtpDate.Font = new System.Drawing.Font("Century Gothic", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.HoverState.Parent = this.dtpDate;
            this.dtpDate.Location = new System.Drawing.Point(269, 163);
            this.dtpDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.ShadowDecoration.Parent = this.dtpDate;
            this.dtpDate.Size = new System.Drawing.Size(189, 36);
            this.dtpDate.TabIndex = 172;
            this.dtpDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpDate.Value = new System.DateTime(2024, 11, 30, 17, 29, 12, 972);
            // 
            // txtPatFullName
            // 
            this.txtPatFullName.Animated = true;
            this.txtPatFullName.BorderThickness = 2;
            this.txtPatFullName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPatFullName.DefaultText = "";
            this.txtPatFullName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPatFullName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPatFullName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPatFullName.DisabledState.Parent = this.txtPatFullName;
            this.txtPatFullName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPatFullName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.txtPatFullName.FocusedState.Parent = this.txtPatFullName;
            this.txtPatFullName.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatFullName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPatFullName.HoverState.Parent = this.txtPatFullName;
            this.txtPatFullName.Location = new System.Drawing.Point(269, 72);
            this.txtPatFullName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPatFullName.Name = "txtPatFullName";
            this.txtPatFullName.PasswordChar = '\0';
            this.txtPatFullName.PlaceholderText = "";
            this.txtPatFullName.SelectedText = "";
            this.txtPatFullName.ShadowDecoration.Parent = this.txtPatFullName;
            this.txtPatFullName.Size = new System.Drawing.Size(561, 37);
            this.txtPatFullName.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtPatFullName.TabIndex = 182;
            // 
            // txtTimeAvailability
            // 
            this.txtTimeAvailability.Animated = true;
            this.txtTimeAvailability.BorderThickness = 2;
            this.txtTimeAvailability.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimeAvailability.DefaultText = "";
            this.txtTimeAvailability.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimeAvailability.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimeAvailability.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimeAvailability.DisabledState.Parent = this.txtTimeAvailability;
            this.txtTimeAvailability.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimeAvailability.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.txtTimeAvailability.FocusedState.Parent = this.txtTimeAvailability;
            this.txtTimeAvailability.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeAvailability.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimeAvailability.HoverState.Parent = this.txtTimeAvailability;
            this.txtTimeAvailability.Location = new System.Drawing.Point(269, 300);
            this.txtTimeAvailability.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTimeAvailability.Name = "txtTimeAvailability";
            this.txtTimeAvailability.PasswordChar = '\0';
            this.txtTimeAvailability.PlaceholderText = "";
            this.txtTimeAvailability.SelectedText = "";
            this.txtTimeAvailability.ShadowDecoration.Parent = this.txtTimeAvailability;
            this.txtTimeAvailability.Size = new System.Drawing.Size(562, 37);
            this.txtTimeAvailability.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtTimeAvailability.TabIndex = 184;
            // 
            // txtFloor
            // 
            this.txtFloor.Animated = true;
            this.txtFloor.BorderThickness = 2;
            this.txtFloor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFloor.DefaultText = "";
            this.txtFloor.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFloor.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFloor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFloor.DisabledState.Parent = this.txtFloor;
            this.txtFloor.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFloor.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.txtFloor.FocusedState.Parent = this.txtFloor;
            this.txtFloor.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFloor.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFloor.HoverState.Parent = this.txtFloor;
            this.txtFloor.Location = new System.Drawing.Point(646, 225);
            this.txtFloor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFloor.Name = "txtFloor";
            this.txtFloor.PasswordChar = '\0';
            this.txtFloor.PlaceholderText = "";
            this.txtFloor.SelectedText = "";
            this.txtFloor.ShadowDecoration.Parent = this.txtFloor;
            this.txtFloor.Size = new System.Drawing.Size(185, 37);
            this.txtFloor.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtFloor.TabIndex = 185;
            // 
            // cbAppointmentStatus
            // 
            this.cbAppointmentStatus.Animated = true;
            this.cbAppointmentStatus.BackColor = System.Drawing.Color.Transparent;
            this.cbAppointmentStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAppointmentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAppointmentStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.cbAppointmentStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.cbAppointmentStatus.FocusedState.Parent = this.cbAppointmentStatus;
            this.cbAppointmentStatus.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.cbAppointmentStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbAppointmentStatus.FormattingEnabled = true;
            this.cbAppointmentStatus.HoverState.Parent = this.cbAppointmentStatus;
            this.cbAppointmentStatus.ItemHeight = 30;
            this.cbAppointmentStatus.Items.AddRange(new object[] {
            "Scheduled",
            "Rescheduled"});
            this.cbAppointmentStatus.ItemsAppearance.Parent = this.cbAppointmentStatus;
            this.cbAppointmentStatus.Location = new System.Drawing.Point(646, 163);
            this.cbAppointmentStatus.Name = "cbAppointmentStatus";
            this.cbAppointmentStatus.ShadowDecoration.Parent = this.cbAppointmentStatus;
            this.cbAppointmentStatus.Size = new System.Drawing.Size(186, 36);
            this.cbAppointmentStatus.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cbAppointmentStatus.TabIndex = 186;
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.Animated = true;
            this.txtDiagnosis.BorderThickness = 2;
            this.txtDiagnosis.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiagnosis.DefaultText = "";
            this.txtDiagnosis.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDiagnosis.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDiagnosis.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiagnosis.DisabledState.Parent = this.txtDiagnosis;
            this.txtDiagnosis.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiagnosis.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.txtDiagnosis.FocusedState.Parent = this.txtDiagnosis;
            this.txtDiagnosis.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiagnosis.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiagnosis.HoverState.Parent = this.txtDiagnosis;
            this.txtDiagnosis.Location = new System.Drawing.Point(269, 117);
            this.txtDiagnosis.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.PasswordChar = '\0';
            this.txtDiagnosis.PlaceholderText = "";
            this.txtDiagnosis.SelectedText = "";
            this.txtDiagnosis.ShadowDecoration.Parent = this.txtDiagnosis;
            this.txtDiagnosis.Size = new System.Drawing.Size(561, 37);
            this.txtDiagnosis.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtDiagnosis.TabIndex = 188;
            // 
            // guna2HtmlLabel8
            // 
            this.guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel8.Location = new System.Drawing.Point(190, 124);
            this.guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            this.guna2HtmlLabel8.Size = new System.Drawing.Size(73, 20);
            this.guna2HtmlLabel8.TabIndex = 187;
            this.guna2HtmlLabel8.Text = "Diagnosis";
            // 
            // AppointmentID
            // 
            this.AppointmentID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AppointmentID.HeaderText = "No";
            this.AppointmentID.MinimumWidth = 6;
            this.AppointmentID.Name = "AppointmentID";
            this.AppointmentID.Width = 51;
            // 
            // PatientFullName
            // 
            this.PatientFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PatientFullName.HeaderText = "Patient\'s Name";
            this.PatientFullName.MinimumWidth = 6;
            this.PatientFullName.Name = "PatientFullName";
            // 
            // Diagnosis
            // 
            this.Diagnosis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Diagnosis.HeaderText = "Diagnosis";
            this.Diagnosis.Name = "Diagnosis";
            // 
            // AppointmentDate
            // 
            this.AppointmentDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AppointmentDate.HeaderText = "Date";
            this.AppointmentDate.MinimumWidth = 6;
            this.AppointmentDate.Name = "AppointmentDate";
            // 
            // AppointmentStatus
            // 
            this.AppointmentStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AppointmentStatus.HeaderText = "Status";
            this.AppointmentStatus.MinimumWidth = 6;
            this.AppointmentStatus.Name = "AppointmentStatus";
            this.AppointmentStatus.Width = 73;
            // 
            // Floor
            // 
            this.Floor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Floor.HeaderText = "Floor";
            this.Floor.MinimumWidth = 6;
            this.Floor.Name = "Floor";
            this.Floor.Width = 64;
            // 
            // TimeAvailability
            // 
            this.TimeAvailability.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TimeAvailability.HeaderText = "Availability";
            this.TimeAvailability.MinimumWidth = 6;
            this.TimeAvailability.Name = "TimeAvailability";
            this.TimeAvailability.Width = 107;
            // 
            // TimeIn
            // 
            this.TimeIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TimeIn.HeaderText = "Time In";
            this.TimeIn.Name = "TimeIn";
            this.TimeIn.Width = 78;
            // 
            // TimeOut
            // 
            this.TimeOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TimeOut.HeaderText = "Time Out";
            this.TimeOut.Name = "TimeOut";
            this.TimeOut.Width = 92;
            // 
            // Select
            // 
            this.Select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Select.HeaderText = "Select";
            this.Select.MinimumWidth = 6;
            this.Select.Name = "Select";
            this.Select.Text = "Select";
            this.Select.UseColumnTextForButtonValue = true;
            this.Select.Width = 55;
            // 
            // DocAppointment
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(238)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(979, 570);
            this.Controls.Add(this.txtDiagnosis);
            this.Controls.Add(this.guna2HtmlLabel8);
            this.Controls.Add(this.cbAppointmentStatus);
            this.Controls.Add(this.txtFloor);
            this.Controls.Add(this.txtTimeAvailability);
            this.Controls.Add(this.txtPatFullName);
            this.Controls.Add(this.txtTimeOut);
            this.Controls.Add(this.guna2HtmlLabel4);
            this.Controls.Add(this.txtTimeIn);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.dgvDocAppointment);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.guna2HtmlLabel7);
            this.Controls.Add(this.guna2HtmlLabel6);
            this.Controls.Add(this.guna2HtmlLabel5);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DocAppointment";
            this.Text = "DocAppointment";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocAppointment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GradientButton btnDelete;
        private Guna.UI2.WinForms.Guna2GradientButton btnUpdate;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI.WinForms.GunaDataGridView dgvDocAppointment;
        private Guna.UI2.WinForms.Guna2TextBox txtTimeIn;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox txtTimeOut;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDate;
        private Guna.UI2.WinForms.Guna2TextBox txtPatFullName;
        private Guna.UI2.WinForms.Guna2TextBox txtTimeAvailability;
        private Guna.UI2.WinForms.Guna2TextBox txtFloor;
        private Guna.UI2.WinForms.Guna2ComboBox cbAppointmentStatus;
        private Guna.UI2.WinForms.Guna2TextBox txtDiagnosis;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppointmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diagnosis;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppointmentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppointmentStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Floor;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeAvailability;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeOut;
        private System.Windows.Forms.DataGridViewButtonColumn Select;
    }
}