namespace StBenedict
{
    partial class Appointment
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Appointment));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnDelete = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnInsert = new Guna.UI2.WinForms.Guna2GradientButton();
            this.cbPatFullName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbDocFullName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbAppointmentStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbFloor = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbTimeAvailability = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dgvAppointment = new Guna.UI.WinForms.GunaDataGridView();
            this.AppointmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoctorFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppointmentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppointmentStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Floor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeAvailability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewButtonColumn();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpTimeIn = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeOut = new System.Windows.Forms.DateTimePicker();
            this.guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.stBenedictDataSet = new StBenedict.StBenedictDataSet();
            this.stBenedictDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appointmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appointmentTableAdapter = new StBenedict.StBenedictDataSetTableAdapters.AppointmentTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stBenedictDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stBenedictDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.btnDelete.Location = new System.Drawing.Point(940, 185);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDelete.ShadowDecoration.Parent = this.btnDelete;
            this.btnDelete.Size = new System.Drawing.Size(92, 56);
            this.btnDelete.TabIndex = 109;
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
            this.btnUpdate.Location = new System.Drawing.Point(940, 123);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnUpdate.ShadowDecoration.Parent = this.btnUpdate;
            this.btnUpdate.Size = new System.Drawing.Size(92, 56);
            this.btnUpdate.TabIndex = 108;
            this.btnUpdate.Text = "   Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(112, 167);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(137, 20);
            this.guna2HtmlLabel3.TabIndex = 99;
            this.guna2HtmlLabel3.Text = "Appointment Date";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(185, 119);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(139, 20);
            this.guna2HtmlLabel1.TabIndex = 98;
            this.guna2HtmlLabel1.Text = "Doctor\'s Full Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(380, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 44);
            this.label1.TabIndex = 97;
            this.label1.Text = "APPOINTMENT";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(185, 77);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(138, 20);
            this.guna2HtmlLabel2.TabIndex = 93;
            this.guna2HtmlLabel2.Text = "Patient\'s Full Name";
            // 
            // btnInsert
            // 
            this.btnInsert.Animated = true;
            this.btnInsert.BorderRadius = 5;
            this.btnInsert.CheckedState.Parent = this.btnInsert;
            this.btnInsert.CustomImages.Image = ((System.Drawing.Image)(resources.GetObject("btnInsert.CustomImages.Image")));
            this.btnInsert.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnInsert.CustomImages.Parent = this.btnInsert;
            this.btnInsert.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.btnInsert.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(84)))), ((int)(((byte)(134)))));
            this.btnInsert.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.ForeColor = System.Drawing.Color.White;
            this.btnInsert.HoverState.Parent = this.btnInsert;
            this.btnInsert.Location = new System.Drawing.Point(940, 61);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnInsert.ShadowDecoration.Parent = this.btnInsert;
            this.btnInsert.Size = new System.Drawing.Size(92, 56);
            this.btnInsert.TabIndex = 92;
            this.btnInsert.Text = "   Insert";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // cbPatFullName
            // 
            this.cbPatFullName.Animated = true;
            this.cbPatFullName.BackColor = System.Drawing.Color.Transparent;
            this.cbPatFullName.DisplayMember = "FullName";
            this.cbPatFullName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPatFullName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPatFullName.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.cbPatFullName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.cbPatFullName.FocusedState.Parent = this.cbPatFullName;
            this.cbPatFullName.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.cbPatFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbPatFullName.FormattingEnabled = true;
            this.cbPatFullName.HoverState.Parent = this.cbPatFullName;
            this.cbPatFullName.ItemHeight = 30;
            this.cbPatFullName.ItemsAppearance.Parent = this.cbPatFullName;
            this.cbPatFullName.Location = new System.Drawing.Point(329, 71);
            this.cbPatFullName.Name = "cbPatFullName";
            this.cbPatFullName.ShadowDecoration.Parent = this.cbPatFullName;
            this.cbPatFullName.Size = new System.Drawing.Size(402, 36);
            this.cbPatFullName.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cbPatFullName.TabIndex = 138;
            this.cbPatFullName.ValueMember = "PatientID";
            // 
            // cbDocFullName
            // 
            this.cbDocFullName.Animated = true;
            this.cbDocFullName.BackColor = System.Drawing.Color.Transparent;
            this.cbDocFullName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDocFullName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDocFullName.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.cbDocFullName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.cbDocFullName.FocusedState.Parent = this.cbDocFullName;
            this.cbDocFullName.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.cbDocFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbDocFullName.FormattingEnabled = true;
            this.cbDocFullName.HoverState.Parent = this.cbDocFullName;
            this.cbDocFullName.ItemHeight = 30;
            this.cbDocFullName.ItemsAppearance.Parent = this.cbDocFullName;
            this.cbDocFullName.Location = new System.Drawing.Point(329, 114);
            this.cbDocFullName.Name = "cbDocFullName";
            this.cbDocFullName.ShadowDecoration.Parent = this.cbDocFullName;
            this.cbDocFullName.Size = new System.Drawing.Size(402, 36);
            this.cbDocFullName.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cbDocFullName.TabIndex = 139;
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
            "Scheduled"});
            this.cbAppointmentStatus.ItemsAppearance.Parent = this.cbAppointmentStatus;
            this.cbAppointmentStatus.Location = new System.Drawing.Point(631, 154);
            this.cbAppointmentStatus.Name = "cbAppointmentStatus";
            this.cbAppointmentStatus.ShadowDecoration.Parent = this.cbAppointmentStatus;
            this.cbAppointmentStatus.Size = new System.Drawing.Size(186, 36);
            this.cbAppointmentStatus.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cbAppointmentStatus.TabIndex = 143;
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(482, 159);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(143, 20);
            this.guna2HtmlLabel5.TabIndex = 142;
            this.guna2HtmlLabel5.Text = "Appointment Status";
            // 
            // cbFloor
            // 
            this.cbFloor.Animated = true;
            this.cbFloor.BackColor = System.Drawing.Color.Transparent;
            this.cbFloor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFloor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFloor.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.cbFloor.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.cbFloor.FocusedState.Parent = this.cbFloor;
            this.cbFloor.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.cbFloor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbFloor.FormattingEnabled = true;
            this.cbFloor.HoverState.Parent = this.cbFloor;
            this.cbFloor.ItemHeight = 30;
            this.cbFloor.ItemsAppearance.Parent = this.cbFloor;
            this.cbFloor.Location = new System.Drawing.Point(631, 218);
            this.cbFloor.Name = "cbFloor";
            this.cbFloor.ShadowDecoration.Parent = this.cbFloor;
            this.cbFloor.Size = new System.Drawing.Size(186, 36);
            this.cbFloor.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cbFloor.TabIndex = 145;
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(586, 222);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(39, 20);
            this.guna2HtmlLabel6.TabIndex = 144;
            this.guna2HtmlLabel6.Text = "Floor";
            // 
            // cbTimeAvailability
            // 
            this.cbTimeAvailability.Animated = true;
            this.cbTimeAvailability.BackColor = System.Drawing.Color.Transparent;
            this.cbTimeAvailability.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTimeAvailability.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimeAvailability.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.cbTimeAvailability.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.cbTimeAvailability.FocusedState.Parent = this.cbTimeAvailability;
            this.cbTimeAvailability.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.cbTimeAvailability.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbTimeAvailability.FormattingEnabled = true;
            this.cbTimeAvailability.HoverState.Parent = this.cbTimeAvailability;
            this.cbTimeAvailability.ItemHeight = 30;
            this.cbTimeAvailability.ItemsAppearance.Parent = this.cbTimeAvailability;
            this.cbTimeAvailability.Location = new System.Drawing.Point(255, 276);
            this.cbTimeAvailability.Name = "cbTimeAvailability";
            this.cbTimeAvailability.ShadowDecoration.Parent = this.cbTimeAvailability;
            this.cbTimeAvailability.Size = new System.Drawing.Size(562, 36);
            this.cbTimeAvailability.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cbTimeAvailability.TabIndex = 147;
            this.cbTimeAvailability.SelectedIndexChanged += new System.EventHandler(this.cbTimeAvailability_SelectedIndexChanged);
            // 
            // guna2HtmlLabel7
            // 
            this.guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel7.Location = new System.Drawing.Point(111, 282);
            this.guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            this.guna2HtmlLabel7.Size = new System.Drawing.Size(123, 20);
            this.guna2HtmlLabel7.TabIndex = 146;
            this.guna2HtmlLabel7.Text = "Time Availability";
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
            this.dtpDate.Location = new System.Drawing.Point(255, 157);
            this.dtpDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.ShadowDecoration.Parent = this.dtpDate;
            this.dtpDate.Size = new System.Drawing.Size(189, 36);
            this.dtpDate.TabIndex = 148;
            this.dtpDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpDate.Value = new System.DateTime(2024, 11, 30, 17, 29, 12, 972);
            // 
            // dgvAppointment
            // 
            this.dgvAppointment.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(223)))), ((int)(((byte)(251)))));
            this.dgvAppointment.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAppointment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppointment.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            this.dgvAppointment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAppointment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAppointment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(120)))), ((int)(((byte)(154)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAppointment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAppointment.ColumnHeadersHeight = 21;
            this.dgvAppointment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AppointmentID,
            this.PatientFullName,
            this.DoctorFullName,
            this.AppointmentDate,
            this.AppointmentStatus,
            this.Floor,
            this.TimeAvailability,
            this.TimeIn,
            this.TimeOut,
            this.Select});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(185)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAppointment.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAppointment.EnableHeadersVisualStyles = false;
            this.dgvAppointment.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.dgvAppointment.Location = new System.Drawing.Point(12, 336);
            this.dgvAppointment.Name = "dgvAppointment";
            this.dgvAppointment.RowHeadersVisible = false;
            this.dgvAppointment.RowHeadersWidth = 51;
            this.dgvAppointment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointment.Size = new System.Drawing.Size(955, 222);
            this.dgvAppointment.TabIndex = 149;
            this.dgvAppointment.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Blue;
            this.dgvAppointment.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(223)))), ((int)(((byte)(251)))));
            this.dgvAppointment.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvAppointment.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvAppointment.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvAppointment.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvAppointment.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            this.dgvAppointment.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.dgvAppointment.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(120)))), ((int)(((byte)(154)))));
            this.dgvAppointment.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvAppointment.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.dgvAppointment.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvAppointment.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvAppointment.ThemeStyle.HeaderStyle.Height = 21;
            this.dgvAppointment.ThemeStyle.ReadOnly = false;
            this.dgvAppointment.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            this.dgvAppointment.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAppointment.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvAppointment.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvAppointment.ThemeStyle.RowsStyle.Height = 22;
            this.dgvAppointment.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(185)))), ((int)(((byte)(246)))));
            this.dgvAppointment.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
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
            // DoctorFullName
            // 
            this.DoctorFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DoctorFullName.HeaderText = "Doctor\'s Name";
            this.DoctorFullName.MinimumWidth = 6;
            this.DoctorFullName.Name = "DoctorFullName";
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
            this.TimeIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TimeIn.HeaderText = "Time In";
            this.TimeIn.Name = "TimeIn";
            // 
            // TimeOut
            // 
            this.TimeOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TimeOut.HeaderText = "Time Out";
            this.TimeOut.Name = "TimeOut";
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
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(182, 208);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(54, 20);
            this.guna2HtmlLabel4.TabIndex = 150;
            this.guna2HtmlLabel4.Text = "Time In";
            // 
            // dtpTimeIn
            // 
            this.dtpTimeIn.CustomFormat = "hh:mm tt";
            this.dtpTimeIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeIn.Location = new System.Drawing.Point(255, 209);
            this.dtpTimeIn.Name = "dtpTimeIn";
            this.dtpTimeIn.ShowUpDown = true;
            this.dtpTimeIn.Size = new System.Drawing.Size(189, 20);
            this.dtpTimeIn.TabIndex = 151;
            // 
            // dtpTimeOut
            // 
            this.dtpTimeOut.CustomFormat = "hh:mm tt";
            this.dtpTimeOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeOut.Location = new System.Drawing.Point(255, 242);
            this.dtpTimeOut.Name = "dtpTimeOut";
            this.dtpTimeOut.ShowUpDown = true;
            this.dtpTimeOut.Size = new System.Drawing.Size(189, 20);
            this.dtpTimeOut.TabIndex = 153;
            // 
            // guna2HtmlLabel8
            // 
            this.guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel8.Location = new System.Drawing.Point(165, 239);
            this.guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            this.guna2HtmlLabel8.Size = new System.Drawing.Size(67, 20);
            this.guna2HtmlLabel8.TabIndex = 152;
            this.guna2HtmlLabel8.Text = "Time Out";
            // 
            // stBenedictDataSet
            // 
            this.stBenedictDataSet.DataSetName = "StBenedictDataSet";
            this.stBenedictDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stBenedictDataSetBindingSource
            // 
            this.stBenedictDataSetBindingSource.DataSource = this.stBenedictDataSet;
            this.stBenedictDataSetBindingSource.Position = 0;
            // 
            // appointmentBindingSource
            // 
            this.appointmentBindingSource.DataMember = "Appointment";
            this.appointmentBindingSource.DataSource = this.stBenedictDataSetBindingSource;
            // 
            // appointmentTableAdapter
            // 
            this.appointmentTableAdapter.ClearBeforeFill = true;
            // 
            // Appointment
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(238)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(979, 570);
            this.Controls.Add(this.dtpTimeOut);
            this.Controls.Add(this.guna2HtmlLabel8);
            this.Controls.Add(this.dtpTimeIn);
            this.Controls.Add(this.guna2HtmlLabel4);
            this.Controls.Add(this.dgvAppointment);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.cbTimeAvailability);
            this.Controls.Add(this.guna2HtmlLabel7);
            this.Controls.Add(this.cbFloor);
            this.Controls.Add(this.guna2HtmlLabel6);
            this.Controls.Add(this.cbAppointmentStatus);
            this.Controls.Add(this.guna2HtmlLabel5);
            this.Controls.Add(this.cbDocFullName);
            this.Controls.Add(this.cbPatFullName);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.btnInsert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Appointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Appointment";
            this.Load += new System.EventHandler(this.Appointment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stBenedictDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stBenedictDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientButton btnDelete;
        private Guna.UI2.WinForms.Guna2GradientButton btnUpdate;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2GradientButton btnInsert;
        private Guna.UI2.WinForms.Guna2ComboBox cbPatFullName;
        private Guna.UI2.WinForms.Guna2ComboBox cbDocFullName;
        private Guna.UI2.WinForms.Guna2ComboBox cbAppointmentStatus;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2ComboBox cbFloor;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2ComboBox cbTimeAvailability;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDate;
        private Guna.UI.WinForms.GunaDataGridView dgvAppointment;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private System.Windows.Forms.DateTimePicker dtpTimeIn;
        private System.Windows.Forms.DateTimePicker dtpTimeOut;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppointmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoctorFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppointmentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppointmentStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Floor;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeAvailability;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeOut;
        private System.Windows.Forms.DataGridViewButtonColumn Select;
        private System.Windows.Forms.BindingSource stBenedictDataSetBindingSource;
        private StBenedictDataSet stBenedictDataSet;
        private System.Windows.Forms.BindingSource appointmentBindingSource;
        private StBenedictDataSetTableAdapters.AppointmentTableAdapter appointmentTableAdapter;
    }
}