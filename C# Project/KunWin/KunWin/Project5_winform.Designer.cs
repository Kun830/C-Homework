using System;

namespace KunWin
{
    partial class Project5_winform
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
            this.txb_Receiver = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txb_ProductNum = new System.Windows.Forms.TextBox();
            this.txb_ProducerName = new System.Windows.Forms.TextBox();
            this.txb_EventMsg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txb_Receiver
            // 
            this.txb_Receiver.Location = new System.Drawing.Point(12, 104);
            this.txb_Receiver.Multiline = true;
            this.txb_Receiver.Name = "txb_Receiver";
            this.txb_Receiver.Size = new System.Drawing.Size(698, 141);
            this.txb_Receiver.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(541, 279);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 35);
            this.button2.TabIndex = 2;
            this.button2.Text = "Event Begin";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // txb_ProductNum
            // 
            this.txb_ProductNum.Location = new System.Drawing.Point(400, 286);
            this.txb_ProductNum.Name = "txb_ProductNum";
            this.txb_ProductNum.Size = new System.Drawing.Size(100, 28);
            this.txb_ProductNum.TabIndex = 3;
            // 
            // txb_ProducerName
            // 
            this.txb_ProducerName.Location = new System.Drawing.Point(152, 286);
            this.txb_ProducerName.Name = "txb_ProducerName";
            this.txb_ProducerName.Size = new System.Drawing.Size(100, 28);
            this.txb_ProducerName.TabIndex = 5;
            // 
            // txb_EventMsg
            // 
            this.txb_EventMsg.Location = new System.Drawing.Point(12, 320);
            this.txb_EventMsg.Multiline = true;
            this.txb_EventMsg.Name = "txb_EventMsg";
            this.txb_EventMsg.Size = new System.Drawing.Size(698, 118);
            this.txb_EventMsg.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Producer Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Product Num:";
            // 
            // Project5_winform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txb_EventMsg);
            this.Controls.Add(this.txb_ProducerName);
            this.Controls.Add(this.txb_ProductNum);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txb_Receiver);
            this.Name = "Project5_winform";
            this.Text = "Project5_winform";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.TextBox txb_Receiver;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txb_ProductNum;
        private System.Windows.Forms.TextBox txb_ProducerName;
        private System.Windows.Forms.TextBox txb_EventMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}