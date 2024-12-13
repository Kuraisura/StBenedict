namespace StBenedict
{
    partial class DocMedicalHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocMedicalHistory));
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnView = new Guna.UI2.WinForms.Guna2GradientButton();
            this.txtFrequency = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDosage = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPrescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtProcedure = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtTimeOut = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel10 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtTimeIn = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtDiagnosis = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel9 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbPatientFullName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtDoctorFullName = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel11 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtSpecialization = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(358, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 44);
            this.label1.TabIndex = 79;
            this.label1.Text = "Medical History";
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
            this.btnDelete.Location = new System.Drawing.Point(619, 509);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDelete.ShadowDecoration.Parent = this.btnDelete;
            this.btnDelete.Size = new System.Drawing.Size(199, 56);
            this.btnDelete.TabIndex = 175;
            this.btnDelete.Text = "  Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnView
            // 
            this.btnView.Animated = true;
            this.btnView.BorderRadius = 5;
            this.btnView.CheckedState.Parent = this.btnView;
            this.btnView.CustomImages.Image = ((System.Drawing.Image)(resources.GetObject("btnView.CustomImages.Image")));
            this.btnView.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnView.CustomImages.Parent = this.btnView;
            this.btnView.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.btnView.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(84)))), ((int)(((byte)(134)))));
            this.btnView.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.HoverState.Parent = this.btnView;
            this.btnView.Location = new System.Drawing.Point(167, 509);
            this.btnView.Name = "btnView";
            this.btnView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnView.ShadowDecoration.Parent = this.btnView;
            this.btnView.Size = new System.Drawing.Size(199, 56);
            this.btnView.TabIndex = 173;
            this.btnView.Text = "   View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click_1);
            // 
            // txtFrequency
            // 
            this.txtFrequency.Animated = true;
            this.txtFrequency.BorderThickness = 2;
            this.txtFrequency.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFrequency.DefaultText = "";
            this.txtFrequency.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFrequency.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFrequency.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFrequency.DisabledState.Parent = this.txtFrequency;
            this.txtFrequency.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFrequency.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.txtFrequency.FocusedState.Parent = this.txtFrequency;
            this.txtFrequency.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrequency.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFrequency.HoverState.Parent = this.txtFrequency;
            this.txtFrequency.Location = new System.Drawing.Point(394, 427);
            this.txtFrequency.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.PasswordChar = '\0';
            this.txtFrequency.PlaceholderText = "";
            this.txtFrequency.SelectedText = "";
            this.txtFrequency.ShadowDecoration.Parent = this.txtFrequency;
            this.txtFrequency.Size = new System.Drawing.Size(381, 36);
            this.txtFrequency.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtFrequency.TabIndex = 209;
            // 
            // txtDosage
            // 
            this.txtDosage.Animated = true;
            this.txtDosage.BorderThickness = 2;
            this.txtDosage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDosage.DefaultText = "";
            this.txtDosage.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDosage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDosage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDosage.DisabledState.Parent = this.txtDosage;
            this.txtDosage.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDosage.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.txtDosage.FocusedState.Parent = this.txtDosage;
            this.txtDosage.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDosage.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDosage.HoverState.Parent = this.txtDosage;
            this.txtDosage.Location = new System.Drawing.Point(394, 385);
            this.txtDosage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDosage.Name = "txtDosage";
            this.txtDosage.PasswordChar = '\0';
            this.txtDosage.PlaceholderText = "";
            this.txtDosage.SelectedText = "";
            this.txtDosage.ShadowDecoration.Parent = this.txtDosage;
            this.txtDosage.Size = new System.Drawing.Size(381, 36);
            this.txtDosage.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtDosage.TabIndex = 208;
            // 
            // txtPrescription
            // 
            this.txtPrescription.Animated = true;
            this.txtPrescription.BorderThickness = 2;
            this.txtPrescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrescription.DefaultText = "";
            this.txtPrescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPrescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPrescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrescription.DisabledState.Parent = this.txtPrescription;
            this.txtPrescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.txtPrescription.FocusedState.Parent = this.txtPrescription;
            this.txtPrescription.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrescription.HoverState.Parent = this.txtPrescription;
            this.txtPrescription.Location = new System.Drawing.Point(394, 345);
            this.txtPrescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrescription.Name = "txtPrescription";
            this.txtPrescription.PasswordChar = '\0';
            this.txtPrescription.PlaceholderText = "";
            this.txtPrescription.SelectedText = "";
            this.txtPrescription.ShadowDecoration.Parent = this.txtPrescription;
            this.txtPrescription.Size = new System.Drawing.Size(381, 36);
            this.txtPrescription.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtPrescription.TabIndex = 207;
            // 
            // txtProcedure
            // 
            this.txtProcedure.Animated = true;
            this.txtProcedure.BorderThickness = 2;
            this.txtProcedure.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProcedure.DefaultText = "";
            this.txtProcedure.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtProcedure.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtProcedure.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProcedure.DisabledState.Parent = this.txtProcedure;
            this.txtProcedure.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProcedure.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.txtProcedure.FocusedState.Parent = this.txtProcedure;
            this.txtProcedure.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcedure.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProcedure.HoverState.Parent = this.txtProcedure;
            this.txtProcedure.Location = new System.Drawing.Point(394, 306);
            this.txtProcedure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProcedure.Name = "txtProcedure";
            this.txtProcedure.PasswordChar = '\0';
            this.txtProcedure.PlaceholderText = "";
            this.txtProcedure.SelectedText = "";
            this.txtProcedure.ShadowDecoration.Parent = this.txtProcedure;
            this.txtProcedure.Size = new System.Drawing.Size(381, 36);
            this.txtProcedure.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtProcedure.TabIndex = 206;
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
            this.dtpDate.Location = new System.Drawing.Point(394, 224);
            this.dtpDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.ShadowDecoration.Parent = this.dtpDate;
            this.dtpDate.Size = new System.Drawing.Size(381, 36);
            this.dtpDate.TabIndex = 205;
            this.dtpDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpDate.Value = new System.DateTime(2024, 11, 30, 17, 29, 12, 972);
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
            this.txtTimeOut.Location = new System.Drawing.Point(591, 265);
            this.txtTimeOut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTimeOut.Name = "txtTimeOut";
            this.txtTimeOut.PasswordChar = '\0';
            this.txtTimeOut.PlaceholderText = "Time Out";
            this.txtTimeOut.SelectedText = "";
            this.txtTimeOut.ShadowDecoration.Parent = this.txtTimeOut;
            this.txtTimeOut.Size = new System.Drawing.Size(184, 36);
            this.txtTimeOut.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtTimeOut.TabIndex = 204;
            this.txtTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guna2HtmlLabel10
            // 
            this.guna2HtmlLabel10.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel10.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel10.Location = new System.Drawing.Point(203, 271);
            this.guna2HtmlLabel10.Name = "guna2HtmlLabel10";
            this.guna2HtmlLabel10.Size = new System.Drawing.Size(155, 20);
            this.guna2HtmlLabel10.TabIndex = 203;
            this.guna2HtmlLabel10.Text = "Time In and Time Out";
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
            this.txtTimeIn.Location = new System.Drawing.Point(394, 265);
            this.txtTimeIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTimeIn.Name = "txtTimeIn";
            this.txtTimeIn.PasswordChar = '\0';
            this.txtTimeIn.PlaceholderText = "Time In";
            this.txtTimeIn.SelectedText = "";
            this.txtTimeIn.ShadowDecoration.Parent = this.txtTimeIn;
            this.txtTimeIn.Size = new System.Drawing.Size(184, 36);
            this.txtTimeIn.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtTimeIn.TabIndex = 202;
            this.txtTimeIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNotes
            // 
            this.txtNotes.Animated = true;
            this.txtNotes.BorderThickness = 2;
            this.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNotes.DefaultText = "";
            this.txtNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNotes.DisabledState.Parent = this.txtNotes;
            this.txtNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.txtNotes.FocusedState.Parent = this.txtNotes;
            this.txtNotes.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNotes.HoverState.Parent = this.txtNotes;
            this.txtNotes.Location = new System.Drawing.Point(394, 469);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.PasswordChar = '\0';
            this.txtNotes.PlaceholderText = "";
            this.txtNotes.SelectedText = "";
            this.txtNotes.ShadowDecoration.Parent = this.txtNotes;
            this.txtNotes.Size = new System.Drawing.Size(381, 36);
            this.txtNotes.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtNotes.TabIndex = 200;
            // 
            // guna2HtmlLabel8
            // 
            this.guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel8.Location = new System.Drawing.Point(314, 475);
            this.guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            this.guna2HtmlLabel8.Size = new System.Drawing.Size(44, 20);
            this.guna2HtmlLabel8.TabIndex = 199;
            this.guna2HtmlLabel8.Text = "Notes";
            // 
            // guna2HtmlLabel7
            // 
            this.guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel7.Location = new System.Drawing.Point(320, 229);
            this.guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            this.guna2HtmlLabel7.Size = new System.Drawing.Size(38, 20);
            this.guna2HtmlLabel7.TabIndex = 198;
            this.guna2HtmlLabel7.Text = "Date";
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(276, 433);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(82, 20);
            this.guna2HtmlLabel5.TabIndex = 197;
            this.guna2HtmlLabel5.Text = "Frequency";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(298, 389);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(60, 20);
            this.guna2HtmlLabel4.TabIndex = 196;
            this.guna2HtmlLabel4.Text = "Dosage";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(178, 350);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(180, 20);
            this.guna2HtmlLabel3.TabIndex = 195;
            this.guna2HtmlLabel3.Text = "Prescription/Medication";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(221, 312);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(140, 20);
            this.guna2HtmlLabel2.TabIndex = 194;
            this.guna2HtmlLabel2.Text = "Surgery Procedure";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(288, 186);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(73, 20);
            this.guna2HtmlLabel1.TabIndex = 193;
            this.guna2HtmlLabel1.Text = "Diagnosis";
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
            this.txtDiagnosis.Location = new System.Drawing.Point(394, 181);
            this.txtDiagnosis.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.PasswordChar = '\0';
            this.txtDiagnosis.PlaceholderText = "";
            this.txtDiagnosis.SelectedText = "";
            this.txtDiagnosis.ShadowDecoration.Parent = this.txtDiagnosis;
            this.txtDiagnosis.Size = new System.Drawing.Size(381, 36);
            this.txtDiagnosis.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtDiagnosis.TabIndex = 192;
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(227, 105);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(139, 20);
            this.guna2HtmlLabel6.TabIndex = 191;
            this.guna2HtmlLabel6.Text = "Doctor\'s Full Name";
            // 
            // guna2HtmlLabel9
            // 
            this.guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel9.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel9.Location = new System.Drawing.Point(227, 63);
            this.guna2HtmlLabel9.Name = "guna2HtmlLabel9";
            this.guna2HtmlLabel9.Size = new System.Drawing.Size(138, 20);
            this.guna2HtmlLabel9.TabIndex = 211;
            this.guna2HtmlLabel9.Text = "Patient\'s Full Name";
            // 
            // cbPatientFullName
            // 
            this.cbPatientFullName.BackColor = System.Drawing.Color.Transparent;
            this.cbPatientFullName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPatientFullName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPatientFullName.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.cbPatientFullName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.cbPatientFullName.FocusedState.Parent = this.cbPatientFullName;
            this.cbPatientFullName.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.cbPatientFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbPatientFullName.FormattingEnabled = true;
            this.cbPatientFullName.HoverState.Parent = this.cbPatientFullName;
            this.cbPatientFullName.ItemHeight = 30;
            this.cbPatientFullName.ItemsAppearance.Parent = this.cbPatientFullName;
            this.cbPatientFullName.Location = new System.Drawing.Point(394, 56);
            this.cbPatientFullName.Name = "cbPatientFullName";
            this.cbPatientFullName.ShadowDecoration.Parent = this.cbPatientFullName;
            this.cbPatientFullName.Size = new System.Drawing.Size(381, 36);
            this.cbPatientFullName.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cbPatientFullName.TabIndex = 210;
            this.cbPatientFullName.SelectedIndexChanged += new System.EventHandler(this.cbPatientFullName_SelectedIndexChanged);
            // 
            // txtDoctorFullName
            // 
            this.txtDoctorFullName.Animated = true;
            this.txtDoctorFullName.BorderThickness = 2;
            this.txtDoctorFullName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDoctorFullName.DefaultText = "";
            this.txtDoctorFullName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDoctorFullName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDoctorFullName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDoctorFullName.DisabledState.Parent = this.txtDoctorFullName;
            this.txtDoctorFullName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDoctorFullName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.txtDoctorFullName.FocusedState.Parent = this.txtDoctorFullName;
            this.txtDoctorFullName.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoctorFullName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDoctorFullName.HoverState.Parent = this.txtDoctorFullName;
            this.txtDoctorFullName.Location = new System.Drawing.Point(394, 98);
            this.txtDoctorFullName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDoctorFullName.Name = "txtDoctorFullName";
            this.txtDoctorFullName.PasswordChar = '\0';
            this.txtDoctorFullName.PlaceholderText = "";
            this.txtDoctorFullName.SelectedText = "";
            this.txtDoctorFullName.ShadowDecoration.Parent = this.txtDoctorFullName;
            this.txtDoctorFullName.Size = new System.Drawing.Size(381, 36);
            this.txtDoctorFullName.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtDoctorFullName.TabIndex = 212;
            // 
            // guna2HtmlLabel11
            // 
            this.guna2HtmlLabel11.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel11.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel11.Location = new System.Drawing.Point(259, 145);
            this.guna2HtmlLabel11.Name = "guna2HtmlLabel11";
            this.guna2HtmlLabel11.Size = new System.Drawing.Size(107, 20);
            this.guna2HtmlLabel11.TabIndex = 214;
            this.guna2HtmlLabel11.Text = "Specialization";
            // 
            // txtSpecialization
            // 
            this.txtSpecialization.Animated = true;
            this.txtSpecialization.BorderThickness = 2;
            this.txtSpecialization.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSpecialization.DefaultText = "";
            this.txtSpecialization.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSpecialization.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSpecialization.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSpecialization.DisabledState.Parent = this.txtSpecialization;
            this.txtSpecialization.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSpecialization.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.txtSpecialization.FocusedState.Parent = this.txtSpecialization;
            this.txtSpecialization.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpecialization.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSpecialization.HoverState.Parent = this.txtSpecialization;
            this.txtSpecialization.Location = new System.Drawing.Point(394, 139);
            this.txtSpecialization.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSpecialization.Name = "txtSpecialization";
            this.txtSpecialization.PasswordChar = '\0';
            this.txtSpecialization.PlaceholderText = "";
            this.txtSpecialization.SelectedText = "";
            this.txtSpecialization.ShadowDecoration.Parent = this.txtSpecialization;
            this.txtSpecialization.Size = new System.Drawing.Size(381, 36);
            this.txtSpecialization.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtSpecialization.TabIndex = 213;
            // 
            // DocMedicalHistory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(238)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(979, 570);
            this.Controls.Add(this.guna2HtmlLabel11);
            this.Controls.Add(this.txtSpecialization);
            this.Controls.Add(this.txtDoctorFullName);
            this.Controls.Add(this.guna2HtmlLabel9);
            this.Controls.Add(this.cbPatientFullName);
            this.Controls.Add(this.txtFrequency);
            this.Controls.Add(this.txtDosage);
            this.Controls.Add(this.txtPrescription);
            this.Controls.Add(this.txtProcedure);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txtTimeOut);
            this.Controls.Add(this.guna2HtmlLabel10);
            this.Controls.Add(this.txtTimeIn);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.guna2HtmlLabel8);
            this.Controls.Add(this.guna2HtmlLabel7);
            this.Controls.Add(this.guna2HtmlLabel5);
            this.Controls.Add(this.guna2HtmlLabel4);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.txtDiagnosis);
            this.Controls.Add(this.guna2HtmlLabel6);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DocMedicalHistory";
            this.Text = "DocMedicalHistory";
            this.Load += new System.EventHandler(this.DocMedicalHistory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GradientButton btnDelete;
        private Guna.UI2.WinForms.Guna2GradientButton btnView;
        private Guna.UI2.WinForms.Guna2TextBox txtFrequency;
        private Guna.UI2.WinForms.Guna2TextBox txtDosage;
        private Guna.UI2.WinForms.Guna2TextBox txtPrescription;
        private Guna.UI2.WinForms.Guna2TextBox txtProcedure;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDate;
        private Guna.UI2.WinForms.Guna2TextBox txtTimeOut;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel10;
        private Guna.UI2.WinForms.Guna2TextBox txtTimeIn;
        private Guna.UI2.WinForms.Guna2TextBox txtNotes;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox txtDiagnosis;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel9;
        private Guna.UI2.WinForms.Guna2ComboBox cbPatientFullName;
        private Guna.UI2.WinForms.Guna2TextBox txtDoctorFullName;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel11;
        private Guna.UI2.WinForms.Guna2TextBox txtSpecialization;
    }
}