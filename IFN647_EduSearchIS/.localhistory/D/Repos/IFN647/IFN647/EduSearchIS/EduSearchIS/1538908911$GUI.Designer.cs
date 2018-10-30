﻿using System.Data;

namespace EduSearchIS
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
            this.CollectionButton = new System.Windows.Forms.Button();
            this.IndexButton = new System.Windows.Forms.Button();
            this.CreateIndexButton = new System.Windows.Forms.Button();
            this.folderToReadLocation = new System.Windows.Forms.FolderBrowserDialog();
            this.CollectionDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.IndexDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.TimeLabelToIndex = new System.Windows.Forms.Label();
            this.QueryBox = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.PreprocessingCheckBox = new System.Windows.Forms.CheckBox();
            this.TimeTakenToSearch = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PageNumLabel = new System.Windows.Forms.Label();
            this.TotalPageLabel = new System.Windows.Forms.Label();
            this.AbstractButton = new System.Windows.Forms.Button();
            this.ResultButton = new System.Windows.Forms.Button();
            this.TopicIDBox = new System.Windows.Forms.TextBox();
            this.ResultDirectoryText = new System.Windows.Forms.TextBox();
            this.BrowseResultButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.FinalQueryText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NumOfResultText = new System.Windows.Forms.Label();
            this.ResultMsg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // CollectionButton
            // 
            this.CollectionButton.Location = new System.Drawing.Point(214, 6);
            this.CollectionButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CollectionButton.Name = "CollectionButton";
            this.CollectionButton.Size = new System.Drawing.Size(83, 19);
            this.CollectionButton.TabIndex = 0;
            this.CollectionButton.Text = "Browse";
            this.CollectionButton.UseVisualStyleBackColor = true;
            this.CollectionButton.Click += new System.EventHandler(this.CollectionButton_Click);
            // 
            // IndexButton
            // 
            this.IndexButton.Location = new System.Drawing.Point(214, 31);
            this.IndexButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IndexButton.Name = "IndexButton";
            this.IndexButton.Size = new System.Drawing.Size(83, 19);
            this.IndexButton.TabIndex = 1;
            this.IndexButton.Text = "Browse";
            this.IndexButton.UseVisualStyleBackColor = true;
            this.IndexButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // CreateIndexButton
            // 
            this.CreateIndexButton.Location = new System.Drawing.Point(332, 16);
            this.CreateIndexButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CreateIndexButton.Name = "CreateIndexButton";
            this.CreateIndexButton.Size = new System.Drawing.Size(80, 19);
            this.CreateIndexButton.TabIndex = 4;
            this.CreateIndexButton.Text = "Create Index";
            this.CreateIndexButton.UseVisualStyleBackColor = true;
            this.CreateIndexButton.Click += new System.EventHandler(this.CreateIndexButton_Click);
            // 
            // folderToReadLocation
            // 
            this.folderToReadLocation.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // CollectionDirectoryTextBox
            // 
            this.CollectionDirectoryTextBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.CollectionDirectoryTextBox.Location = new System.Drawing.Point(68, 6);
            this.CollectionDirectoryTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CollectionDirectoryTextBox.Name = "CollectionDirectoryTextBox";
            this.CollectionDirectoryTextBox.Size = new System.Drawing.Size(138, 20);
            this.CollectionDirectoryTextBox.TabIndex = 5;
            this.CollectionDirectoryTextBox.Text = "Insert Collection Directory";
            this.CollectionDirectoryTextBox.TextChanged += new System.EventHandler(this.CollectionDirectoryTextBox_TextChanged);
            this.CollectionDirectoryTextBox.Enter += new System.EventHandler(this.CollectionDirectoryTextBox_Enter);
            this.CollectionDirectoryTextBox.Leave += new System.EventHandler(this.CollectionDirectoryTextBox_Leave);
            // 
            // IndexDirectoryTextBox
            // 
            this.IndexDirectoryTextBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.IndexDirectoryTextBox.Location = new System.Drawing.Point(68, 31);
            this.IndexDirectoryTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IndexDirectoryTextBox.Name = "IndexDirectoryTextBox";
            this.IndexDirectoryTextBox.Size = new System.Drawing.Size(138, 20);
            this.IndexDirectoryTextBox.TabIndex = 6;
            this.IndexDirectoryTextBox.Text = "Insert Index Directory";
            this.IndexDirectoryTextBox.TextChanged += new System.EventHandler(this.IndexDirectoryTextBox_TextChanged);
            this.IndexDirectoryTextBox.Enter += new System.EventHandler(this.IndexDirectoryTextBox_Enter);
            this.IndexDirectoryTextBox.Leave += new System.EventHandler(this.IndexDirectoryTextBox_Leave);
            // 
            // TimeLabelToIndex
            // 
            this.TimeLabelToIndex.AutoSize = true;
            this.TimeLabelToIndex.Location = new System.Drawing.Point(446, 20);
            this.TimeLabelToIndex.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TimeLabelToIndex.Name = "TimeLabelToIndex";
            this.TimeLabelToIndex.Size = new System.Drawing.Size(108, 13);
            this.TimeLabelToIndex.TabIndex = 7;
            this.TimeLabelToIndex.Text = "Time Taken to Index:";
            this.TimeLabelToIndex.Click += new System.EventHandler(this.TimeLabelToIndex_Click);
            // 
            // QueryBox
            // 
            this.QueryBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.QueryBox.Location = new System.Drawing.Point(16, 80);
            this.QueryBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.QueryBox.Name = "QueryBox";
            this.QueryBox.Size = new System.Drawing.Size(245, 20);
            this.QueryBox.TabIndex = 8;
            this.QueryBox.Text = "Enter Query";
            this.QueryBox.TextChanged += new System.EventHandler(this.QueryBox_TextChanged);
            this.QueryBox.Enter += new System.EventHandler(this.QueryBox_Enter);
            this.QueryBox.Leave += new System.EventHandler(this.QueryBox_Leave);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(277, 80);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(76, 19);
            this.SearchButton.TabIndex = 9;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // PreprocessingCheckBox
            // 
            this.PreprocessingCheckBox.AutoSize = true;
            this.PreprocessingCheckBox.Location = new System.Drawing.Point(367, 80);
            this.PreprocessingCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PreprocessingCheckBox.Name = "PreprocessingCheckBox";
            this.PreprocessingCheckBox.Size = new System.Drawing.Size(156, 17);
            this.PreprocessingCheckBox.TabIndex = 10;
            this.PreprocessingCheckBox.Text = "Pre-Processing not required";
            this.PreprocessingCheckBox.UseVisualStyleBackColor = true;
            // 
            // TimeTakenToSearch
            // 
            this.TimeTakenToSearch.AutoSize = true;
            this.TimeTakenToSearch.Location = new System.Drawing.Point(527, 80);
            this.TimeTakenToSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TimeTakenToSearch.Name = "TimeTakenToSearch";
            this.TimeTakenToSearch.Size = new System.Drawing.Size(116, 13);
            this.TimeTakenToSearch.TabIndex = 11;
            this.TimeTakenToSearch.Text = "Time Taken to Search:";
            this.TimeTakenToSearch.Click += new System.EventHandler(this.TimeTakenToSearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(16, 161);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(626, 337);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(14, 59);
            this.StatusLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(37, 13);
            this.StatusLabel.TabIndex = 13;
            this.StatusLabel.Text = "Status";
            // 
            // PreviousButton
            // 
            this.PreviousButton.Location = new System.Drawing.Point(189, 506);
            this.PreviousButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(56, 19);
            this.PreviousButton.TabIndex = 14;
            this.PreviousButton.Text = "Previous";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(410, 506);
            this.NextButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(56, 19);
            this.NextButton.TabIndex = 15;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(281, 509);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Page";
            // 
            // PageNumLabel
            // 
            this.PageNumLabel.AutoSize = true;
            this.PageNumLabel.Location = new System.Drawing.Point(317, 509);
            this.PageNumLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PageNumLabel.Name = "PageNumLabel";
            this.PageNumLabel.Size = new System.Drawing.Size(13, 13);
            this.PageNumLabel.TabIndex = 17;
            this.PageNumLabel.Text = "1";
            // 
            // TotalPageLabel
            // 
            this.TotalPageLabel.AutoSize = true;
            this.TotalPageLabel.Location = new System.Drawing.Point(334, 509);
            this.TotalPageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TotalPageLabel.Name = "TotalPageLabel";
            this.TotalPageLabel.Size = new System.Drawing.Size(43, 13);
            this.TotalPageLabel.TabIndex = 18;
            this.TotalPageLabel.Text = "out of 1";
            this.TotalPageLabel.Click += new System.EventHandler(this.TotalPageLabel_Click);
            // 
            // AbstractButton
            // 
            this.AbstractButton.Location = new System.Drawing.Point(658, 161);
            this.AbstractButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AbstractButton.Name = "AbstractButton";
            this.AbstractButton.Size = new System.Drawing.Size(86, 19);
            this.AbstractButton.TabIndex = 19;
            this.AbstractButton.Text = "View Abstract";
            this.AbstractButton.UseVisualStyleBackColor = true;
            this.AbstractButton.Click += new System.EventHandler(this.AbstractButton_Click);
            // 
            // ResultButton
            // 
            this.ResultButton.Location = new System.Drawing.Point(658, 317);
            this.ResultButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ResultButton.Name = "ResultButton";
            this.ResultButton.Size = new System.Drawing.Size(86, 19);
            this.ResultButton.TabIndex = 20;
            this.ResultButton.Text = "Save Result";
            this.ResultButton.UseVisualStyleBackColor = true;
            this.ResultButton.Click += new System.EventHandler(this.ResultButton_Click);
            // 
            // TopicIDBox
            // 
            this.TopicIDBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.TopicIDBox.Location = new System.Drawing.Point(658, 294);
            this.TopicIDBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TopicIDBox.Name = "TopicIDBox";
            this.TopicIDBox.Size = new System.Drawing.Size(134, 20);
            this.TopicIDBox.TabIndex = 21;
            this.TopicIDBox.Text = "Enter Topic ID";
            this.TopicIDBox.TextChanged += new System.EventHandler(this.TopicIDBox_TextChanged);
            this.TopicIDBox.Enter += new System.EventHandler(this.TopicIDBox_Enter);
            this.TopicIDBox.Leave += new System.EventHandler(this.TopicIDBox_Leave);
            // 
            // ResultDirectoryText
            // 
            this.ResultDirectoryText.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.ResultDirectoryText.Location = new System.Drawing.Point(658, 217);
            this.ResultDirectoryText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ResultDirectoryText.Name = "ResultDirectoryText";
            this.ResultDirectoryText.Size = new System.Drawing.Size(134, 20);
            this.ResultDirectoryText.TabIndex = 22;
            this.ResultDirectoryText.Text = "Insert Result Directory";
            this.ResultDirectoryText.TextChanged += new System.EventHandler(this.ResultDirectoryText_TextChanged);
            this.ResultDirectoryText.Enter += new System.EventHandler(this.ResultDirectoryText_Enter);
            this.ResultDirectoryText.Leave += new System.EventHandler(this.ResultDirectoryText_Leave);
            // 
            // BrowseResultButton
            // 
            this.BrowseResultButton.Location = new System.Drawing.Point(658, 240);
            this.BrowseResultButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BrowseResultButton.Name = "BrowseResultButton";
            this.BrowseResultButton.Size = new System.Drawing.Size(56, 19);
            this.BrowseResultButton.TabIndex = 23;
            this.BrowseResultButton.Text = "Browse";
            this.BrowseResultButton.UseVisualStyleBackColor = true;
            this.BrowseResultButton.Click += new System.EventHandler(this.BrowseResultButton_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Final Query:";
            // 
            // FinalQueryText
            // 
            this.FinalQueryText.AutoSize = true;
            this.FinalQueryText.Location = new System.Drawing.Point(82, 108);
            this.FinalQueryText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FinalQueryText.Name = "FinalQueryText";
            this.FinalQueryText.Size = new System.Drawing.Size(0, 13);
            this.FinalQueryText.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 132);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Number of Result:";
            // 
            // NumOfResultText
            // 
            this.NumOfResultText.AutoSize = true;
            this.NumOfResultText.BackColor = System.Drawing.SystemColors.Control;
            this.NumOfResultText.Location = new System.Drawing.Point(119, 132);
            this.NumOfResultText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NumOfResultText.Name = "NumOfResultText";
            this.NumOfResultText.Size = new System.Drawing.Size(0, 13);
            this.NumOfResultText.TabIndex = 27;
            // 
            // ResultMsg
            // 
            this.ResultMsg.AutoSize = true;
            this.ResultMsg.Location = new System.Drawing.Point(658, 362);
            this.ResultMsg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ResultMsg.Name = "ResultMsg";
            this.ResultMsg.Size = new System.Drawing.Size(68, 13);
            this.ResultMsg.TabIndex = 28;
            this.ResultMsg.Text = "Result status";
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 617);
            this.Controls.Add(this.ResultMsg);
            this.Controls.Add(this.NumOfResultText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FinalQueryText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BrowseResultButton);
            this.Controls.Add(this.ResultDirectoryText);
            this.Controls.Add(this.TopicIDBox);
            this.Controls.Add(this.ResultButton);
            this.Controls.Add(this.AbstractButton);
            this.Controls.Add(this.TotalPageLabel);
            this.Controls.Add(this.PageNumLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.TimeTakenToSearch);
            this.Controls.Add(this.PreprocessingCheckBox);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.QueryBox);
            this.Controls.Add(this.TimeLabelToIndex);
            this.Controls.Add(this.IndexDirectoryTextBox);
            this.Controls.Add(this.CollectionDirectoryTextBox);
            this.Controls.Add(this.CreateIndexButton);
            this.Controls.Add(this.IndexButton);
            this.Controls.Add(this.CollectionButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "GUI";
            this.Text = "GUI";
            this.Load += new System.EventHandler(this.GUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CollectionButton;
        private System.Windows.Forms.Button IndexButton;
        private System.Windows.Forms.Button CreateIndexButton;
        private System.Windows.Forms.FolderBrowserDialog folderToReadLocation;
        private System.Windows.Forms.TextBox CollectionDirectoryTextBox;
        private System.Windows.Forms.TextBox IndexDirectoryTextBox;
        private System.Windows.Forms.Label TimeLabelToIndex;
        private System.Windows.Forms.TextBox QueryBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.CheckBox PreprocessingCheckBox;
        private System.Windows.Forms.Label TimeTakenToSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PageNumLabel;
        private System.Windows.Forms.Label TotalPageLabel;
        private System.Windows.Forms.Button AbstractButton;
        private System.Windows.Forms.Button ResultButton;
        private System.Windows.Forms.TextBox TopicIDBox;
        private System.Windows.Forms.TextBox ResultDirectoryText;
        private System.Windows.Forms.Button BrowseResultButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label FinalQueryText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label NumOfResultText;
        private System.Windows.Forms.Label ResultMsg;
    }
}