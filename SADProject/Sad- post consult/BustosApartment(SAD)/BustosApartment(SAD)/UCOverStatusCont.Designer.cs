namespace BustosApartment_SAD_
{
    partial class UCOverStatusCont
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.calendar1 = new Calendar.NET.Calendar();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panel2.Location = new System.Drawing.Point(12, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1075, 10);
            this.panel2.TabIndex = 42;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.label5.Location = new System.Drawing.Point(461, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(219, 25);
            this.label5.TabIndex = 41;
            this.label5.Text = "MONTHLY STATUS";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // calendar1
            // 
            this.calendar1.AllowEditingEvents = true;
            this.calendar1.BackColor = System.Drawing.SystemColors.Control;
            this.calendar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.calendar1.CalendarDate = new System.DateTime(2018, 2, 23, 9, 32, 54, 271);
            this.calendar1.CalendarView = Calendar.NET.CalendarViews.Month;
            this.calendar1.DateHeaderFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.calendar1.DayOfWeekFont = new System.Drawing.Font("Arial", 10F);
            this.calendar1.DaysFont = new System.Drawing.Font("Arial", 10F);
            this.calendar1.DayViewTimeFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.calendar1.DimDisabledEvents = true;
            this.calendar1.HighlightCurrentDay = true;
            this.calendar1.LoadPresetHolidays = false;
            this.calendar1.Location = new System.Drawing.Point(12, 74);
            this.calendar1.Name = "calendar1";
            this.calendar1.ShowArrowControls = true;
            this.calendar1.ShowDashedBorderOnDisabledEvents = true;
            this.calendar1.ShowDateInHeader = true;
            this.calendar1.ShowDisabledEvents = false;
            this.calendar1.ShowEventTooltips = true;
            this.calendar1.ShowTodayButton = true;
            this.calendar1.Size = new System.Drawing.Size(1075, 464);
            this.calendar1.TabIndex = 43;
            this.calendar1.TodayFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.calendar1.Load += new System.EventHandler(this.calendar1_Load);
            // 
            // UCOverStatusCont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.calendar1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label5);
            this.Name = "UCOverStatusCont";
            this.Size = new System.Drawing.Size(1104, 619);
            this.Load += new System.EventHandler(this.UCOverStatusCont_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private Calendar.NET.Calendar calendar1;
    }
}
