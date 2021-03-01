
using System.Diagnostics;
using System.Media;

namespace Production_line_simulator
{
    partial class Production
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Login loginWindow;
        private int animationFrame = 0;
        private int ventilatorFrame = 0;
        private int fireAnimation = 0;

        private int pizzaHeight = 65;
        private int pizzaWidth = 223;

        private bool vent1Active = false;
        private bool vent2Active = false;
        private bool vent3Active = false;
        private int activeVents = 0;

        private double energy;
        private int cpuCounter = 0;
        private int processorConsumption = 0;
        PerformanceCounter cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private int failureCounter = 0;
        private int nextFailure = 0;

        private bool confirmationRequired = false;
        private bool turnAlarm = false;
        private bool turnFire = false;
        private int timeCounter = 10;
        private int timeFailureCounter = 10;
        SoundPlayer alarmSound = new SoundPlayer(Production_line_simulator.Properties.Resources.alarm);
        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Production));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.change_size = new System.Windows.Forms.TrackBar();
            this.change_speed = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.info_richTextBox = new System.Windows.Forms.RichTextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.vent1_button = new System.Windows.Forms.Button();
            this.vent2_button = new System.Windows.Forms.Button();
            this.vent3_button = new System.Windows.Forms.Button();
            this.failureinfo_richTextBox = new System.Windows.Forms.RichTextBox();
            this.confirm_activity_button = new System.Windows.Forms.Button();
            this.activity_richTextBox = new System.Windows.Forms.RichTextBox();
            this.alarm_pictureBox = new System.Windows.Forms.PictureBox();
            this.vent3 = new System.Windows.Forms.PictureBox();
            this.vent2 = new System.Windows.Forms.PictureBox();
            this.vent1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.conveyor_belt = new System.Windows.Forms.Panel();
            this.pizza3 = new System.Windows.Forms.PictureBox();
            this.pizza2 = new System.Windows.Forms.PictureBox();
            this.pizza1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ovenTemperature = new System.Windows.Forms.NumericUpDown();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.fire_pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.change_size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.change_speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alarm_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vent3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vent2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.conveyor_belt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pizza3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pizza2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pizza1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovenTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fire_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // change_size
            // 
            this.change_size.BackColor = System.Drawing.Color.Gainsboro;
            this.change_size.Location = new System.Drawing.Point(12, 527);
            this.change_size.Maximum = 280;
            this.change_size.Minimum = 140;
            this.change_size.Name = "change_size";
            this.change_size.Size = new System.Drawing.Size(182, 56);
            this.change_size.TabIndex = 4;
            this.change_size.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.change_size.Value = 200;
            this.change_size.ValueChanged += new System.EventHandler(this.change_size_ValueChanged);
            // 
            // change_speed
            // 
            this.change_speed.BackColor = System.Drawing.Color.Gainsboro;
            this.change_speed.Location = new System.Drawing.Point(12, 628);
            this.change_speed.Maximum = 90;
            this.change_speed.Name = "change_speed";
            this.change_speed.Size = new System.Drawing.Size(182, 56);
            this.change_speed.TabIndex = 5;
            this.change_speed.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.change_speed.Value = 50;
            this.change_speed.ValueChanged += new System.EventHandler(this.change_speed_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(35, 499);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "PIZZA SIZE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(62, 600);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "SPEED";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // info_richTextBox
            // 
            this.info_richTextBox.BackColor = System.Drawing.Color.Black;
            this.info_richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.info_richTextBox.ForeColor = System.Drawing.Color.White;
            this.info_richTextBox.Location = new System.Drawing.Point(221, 503);
            this.info_richTextBox.Name = "info_richTextBox";
            this.info_richTextBox.Size = new System.Drawing.Size(266, 181);
            this.info_richTextBox.TabIndex = 8;
            this.info_richTextBox.Text = "";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // vent1_button
            // 
            this.vent1_button.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.vent1_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vent1_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.vent1_button.Location = new System.Drawing.Point(609, 126);
            this.vent1_button.Name = "vent1_button";
            this.vent1_button.Size = new System.Drawing.Size(34, 36);
            this.vent1_button.TabIndex = 12;
            this.vent1_button.Text = "O";
            this.vent1_button.UseVisualStyleBackColor = false;
            this.vent1_button.Click += new System.EventHandler(this.vent1_button_Click);
            // 
            // vent2_button
            // 
            this.vent2_button.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.vent2_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vent2_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.vent2_button.Location = new System.Drawing.Point(753, 126);
            this.vent2_button.Name = "vent2_button";
            this.vent2_button.Size = new System.Drawing.Size(34, 36);
            this.vent2_button.TabIndex = 13;
            this.vent2_button.Text = "O";
            this.vent2_button.UseVisualStyleBackColor = false;
            this.vent2_button.Click += new System.EventHandler(this.vent2_button_Click);
            // 
            // vent3_button
            // 
            this.vent3_button.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.vent3_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vent3_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.vent3_button.Location = new System.Drawing.Point(892, 126);
            this.vent3_button.Name = "vent3_button";
            this.vent3_button.Size = new System.Drawing.Size(34, 36);
            this.vent3_button.TabIndex = 14;
            this.vent3_button.Text = "O";
            this.vent3_button.UseVisualStyleBackColor = false;
            this.vent3_button.Click += new System.EventHandler(this.vent3_button_Click);
            // 
            // failureinfo_richTextBox
            // 
            this.failureinfo_richTextBox.BackColor = System.Drawing.Color.Black;
            this.failureinfo_richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.failureinfo_richTextBox.ForeColor = System.Drawing.Color.White;
            this.failureinfo_richTextBox.Location = new System.Drawing.Point(500, 503);
            this.failureinfo_richTextBox.Name = "failureinfo_richTextBox";
            this.failureinfo_richTextBox.Size = new System.Drawing.Size(359, 181);
            this.failureinfo_richTextBox.TabIndex = 16;
            this.failureinfo_richTextBox.Text = "";
            // 
            // confirm_activity_button
            // 
            this.confirm_activity_button.BackColor = System.Drawing.Color.GreenYellow;
            this.confirm_activity_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirm_activity_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.confirm_activity_button.Location = new System.Drawing.Point(892, 600);
            this.confirm_activity_button.Name = "confirm_activity_button";
            this.confirm_activity_button.Size = new System.Drawing.Size(114, 84);
            this.confirm_activity_button.TabIndex = 17;
            this.confirm_activity_button.Text = "CONFIRM ACTIVITY";
            this.confirm_activity_button.UseVisualStyleBackColor = false;
            this.confirm_activity_button.Click += new System.EventHandler(this.confirm_activity_button_Click);
            // 
            // activity_richTextBox
            // 
            this.activity_richTextBox.BackColor = System.Drawing.Color.Black;
            this.activity_richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.activity_richTextBox.ForeColor = System.Drawing.Color.White;
            this.activity_richTextBox.Location = new System.Drawing.Point(870, 503);
            this.activity_richTextBox.Name = "activity_richTextBox";
            this.activity_richTextBox.Size = new System.Drawing.Size(152, 84);
            this.activity_richTextBox.TabIndex = 18;
            this.activity_richTextBox.Text = "";
            // 
            // alarm_pictureBox
            // 
            this.alarm_pictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("alarm_pictureBox.BackgroundImage")));
            this.alarm_pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.alarm_pictureBox.Location = new System.Drawing.Point(302, 26);
            this.alarm_pictureBox.Name = "alarm_pictureBox";
            this.alarm_pictureBox.Size = new System.Drawing.Size(105, 103);
            this.alarm_pictureBox.TabIndex = 15;
            this.alarm_pictureBox.TabStop = false;
            // 
            // vent3
            // 
            this.vent3.BackgroundImage = global::Production_line_simulator.Properties.Resources.ventilator0000;
            this.vent3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.vent3.Location = new System.Drawing.Point(868, 42);
            this.vent3.Name = "vent3";
            this.vent3.Size = new System.Drawing.Size(80, 78);
            this.vent3.TabIndex = 11;
            this.vent3.TabStop = false;
            // 
            // vent2
            // 
            this.vent2.BackgroundImage = global::Production_line_simulator.Properties.Resources.ventilator0003;
            this.vent2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.vent2.Location = new System.Drawing.Point(728, 42);
            this.vent2.Name = "vent2";
            this.vent2.Size = new System.Drawing.Size(80, 78);
            this.vent2.TabIndex = 10;
            this.vent2.TabStop = false;
            // 
            // vent1
            // 
            this.vent1.BackgroundImage = global::Production_line_simulator.Properties.Resources.ventilator0009;
            this.vent1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.vent1.Location = new System.Drawing.Point(588, 42);
            this.vent1.Name = "vent1";
            this.vent1.Size = new System.Drawing.Size(81, 78);
            this.vent1.TabIndex = 9;
            this.vent1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 487);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1030, 212);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // conveyor_belt
            // 
            this.conveyor_belt.BackColor = System.Drawing.Color.Linen;
            this.conveyor_belt.BackgroundImage = global::Production_line_simulator.Properties.Resources._0000;
            this.conveyor_belt.Controls.Add(this.pizza3);
            this.conveyor_belt.Controls.Add(this.pizza2);
            this.conveyor_belt.Controls.Add(this.pizza1);
            this.conveyor_belt.Location = new System.Drawing.Point(171, 341);
            this.conveyor_belt.Name = "conveyor_belt";
            this.conveyor_belt.Size = new System.Drawing.Size(861, 114);
            this.conveyor_belt.TabIndex = 0;
            // 
            // pizza3
            // 
            this.pizza3.BackColor = System.Drawing.Color.Transparent;
            this.pizza3.BackgroundImage = global::Production_line_simulator.Properties.Resources.pizza2;
            this.pizza3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pizza3.Location = new System.Drawing.Point(618, 6);
            this.pizza3.Name = "pizza3";
            this.pizza3.Size = new System.Drawing.Size(217, 66);
            this.pizza3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pizza3.TabIndex = 3;
            this.pizza3.TabStop = false;
            // 
            // pizza2
            // 
            this.pizza2.BackColor = System.Drawing.Color.Transparent;
            this.pizza2.BackgroundImage = global::Production_line_simulator.Properties.Resources.pizza2;
            this.pizza2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pizza2.Location = new System.Drawing.Point(299, 6);
            this.pizza2.Name = "pizza2";
            this.pizza2.Size = new System.Drawing.Size(227, 65);
            this.pizza2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pizza2.TabIndex = 3;
            this.pizza2.TabStop = false;
            // 
            // pizza1
            // 
            this.pizza1.BackColor = System.Drawing.Color.Transparent;
            this.pizza1.BackgroundImage = global::Production_line_simulator.Properties.Resources.pizza2;
            this.pizza1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pizza1.Location = new System.Drawing.Point(-62, 2);
            this.pizza1.Name = "pizza1";
            this.pizza1.Size = new System.Drawing.Size(220, 69);
            this.pizza1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pizza1.TabIndex = 2;
            this.pizza1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Production_line_simulator.Properties.Resources.panel1_BackgroundImage;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.ovenTemperature);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(0, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 492);
            this.panel1.TabIndex = 1;
            // 
            // ovenTemperature
            // 
            this.ovenTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ovenTemperature.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ovenTemperature.Location = new System.Drawing.Point(76, 350);
            this.ovenTemperature.Maximum = new decimal(new int[] {
            620,
            0,
            0,
            0});
            this.ovenTemperature.Minimum = new decimal(new int[] {
            230,
            0,
            0,
            0});
            this.ovenTemperature.Name = "ovenTemperature";
            this.ovenTemperature.ReadOnly = true;
            this.ovenTemperature.Size = new System.Drawing.Size(70, 34);
            this.ovenTemperature.TabIndex = 2;
            this.ovenTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ovenTemperature.Value = new decimal(new int[] {
            350,
            0,
            0,
            0});
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::Production_line_simulator.Properties.Resources.pictureBox1_BackgroundImage;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(173, 492);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // fire_pictureBox
            // 
            this.fire_pictureBox.BackgroundImage = global::Production_line_simulator.Properties.Resources.fire0000;
            this.fire_pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fire_pictureBox.Enabled = false;
            this.fire_pictureBox.Location = new System.Drawing.Point(-1, -2);
            this.fire_pictureBox.Name = "fire_pictureBox";
            this.fire_pictureBox.Size = new System.Drawing.Size(1030, 701);
            this.fire_pictureBox.TabIndex = 3;
            this.fire_pictureBox.TabStop = false;
            this.fire_pictureBox.Visible = false;
            // 
            // Production
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(1028, 696);
            this.Controls.Add(this.fire_pictureBox);
            this.Controls.Add(this.activity_richTextBox);
            this.Controls.Add(this.confirm_activity_button);
            this.Controls.Add(this.failureinfo_richTextBox);
            this.Controls.Add(this.alarm_pictureBox);
            this.Controls.Add(this.vent3_button);
            this.Controls.Add(this.vent2_button);
            this.Controls.Add(this.vent1_button);
            this.Controls.Add(this.vent3);
            this.Controls.Add(this.vent2);
            this.Controls.Add(this.vent1);
            this.Controls.Add(this.info_richTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.change_speed);
            this.Controls.Add(this.change_size);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.conveyor_belt);
            this.Controls.Add(this.panel1);
            this.Name = "Production";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Production_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.change_size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.change_speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alarm_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vent3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vent2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.conveyor_belt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pizza3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pizza2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pizza1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ovenTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fire_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel conveyor_belt;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pizza1;
        private System.Windows.Forms.PictureBox pizza3;
        private System.Windows.Forms.PictureBox pizza2;
        private System.Windows.Forms.NumericUpDown ovenTemperature;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TrackBar change_size;
        private System.Windows.Forms.TrackBar change_speed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox info_richTextBox;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox vent1;
        private System.Windows.Forms.PictureBox vent2;
        private System.Windows.Forms.PictureBox vent3;
        private System.Windows.Forms.Button vent1_button;
        private System.Windows.Forms.Button vent2_button;
        private System.Windows.Forms.Button vent3_button;
        private System.Windows.Forms.PictureBox alarm_pictureBox;
        private System.Windows.Forms.RichTextBox failureinfo_richTextBox;
        private System.Windows.Forms.Button confirm_activity_button;
        private System.Windows.Forms.RichTextBox activity_richTextBox;
        private System.Windows.Forms.PictureBox fire_pictureBox;
    }
}

