using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Force.Crc32;
using Microsoft.Office.Interop.Word;
using Microsoft.VisualBasic;

namespace IUL_Generate
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void Close_bt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Browse_bt_Click(object sender, EventArgs e)
        {
            DialogResult DR = BrowseFolderWithFiles_fbd.ShowDialog();
            if (DR == DialogResult.OK && BrowseFolderWithFiles_fbd.SelectedPath != "") 
            {
                FolderPath_tb.Text = BrowseFolderWithFiles_fbd.SelectedPath;

                FilesWithCRC32_DGV.Columns.Clear();

                FilesWithCRC32_DGV.ColumnCount = 2;
                FilesWithCRC32_DGV.Columns[0].Name = "FileName";
                FilesWithCRC32_DGV.Columns[1].Name = "CRC32";
                FilesWithCRC32_DGV.Columns[1].Width = 80;
                FilesWithCRC32_DGV.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Action_PrB.Maximum = Directory.GetFiles(FolderPath_tb.Text).Count();
                Action_PrB.Value = 0;
                Action_PrB.Visible = true;
                foreach (var FilePath in Directory.GetFiles(FolderPath_tb.Text))
                {
                    Crc32Algorithm crc32 = new Crc32Algorithm();
                    String hash = String.Empty;
                    using (FileStream fs = File.Open(FilePath, FileMode.Open))
                        foreach (byte b in crc32.ComputeHash(fs)) hash += b.ToString("x2").ToLower();
                    FilesWithCRC32_DGV.Rows.Add(Path.GetFileName(FilePath), hash);
                    Action_PrB.Value++;
                }
                Action_PrB.Visible = false;
                CreateWordFile_bt.Enabled = true;
            }
        }
        public static string ProjectName;
        public static string GIP;
        public static string Developer;
        public static string GIP_Date;
        public static string Developer_Date;

        public static DialogResult DR;
        private void CreateWordFile_bt_Click(object sender, EventArgs e)
        {
            Action_PrB.Value = 0;
            Action_PrB.Visible = true;

            //string ProjectName = Interaction.InputBox;

            ProjectInfo PrInfo = new ProjectInfo();
            PrInfo.Show();

            System.Threading.Tasks.Task.Factory.StartNew(() => 
            {
                while (DR == DialogResult.None)
                { }
                if (DR == DialogResult.OK)
                {
                    try
                    {
                        this.Invoke(new Action(() => { CreateWordFile_bt.Enabled = false; }));
                        DR = DialogResult.None;
                        Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
                        word.Application.Documents.Add(Type.Missing);
                        word.ActiveDocument.Sections.PageSetup.LeftMargin = word.ActiveDocument.Sections.PageSetup.TopMargin;
                        word.ActiveDocument.Sections.PageSetup.RightMargin = word.ActiveDocument.Sections.PageSetup.LeftMargin / 2;
                        word.ActiveDocument.Sections.PageSetup.TopMargin = (word.ActiveDocument.Sections.PageSetup.RightMargin / 4) * 3;
                        word.ActiveDocument.Sections.PageSetup.BottomMargin = word.ActiveDocument.Sections.PageSetup.RightMargin / 4;
                        AddCenterText(word, "Информационно-удостоверяющий лист", false);
                        AddCenterText(word, $"«{ProjectName}»", true);
                        AddCenterText(word, "", false);

                        foreach (DataGridViewRow row in FilesWithCRC32_DGV.Rows)
                        {
                            bool FirstIndex;
                            if (row.Index == 0)
                                FirstIndex = true;
                            else
                                FirstIndex = false;

                            AddIULTable(word, row.Index + 1, row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString().ToUpper(), FirstIndex);
                            this.Invoke(new Action(() => { Action_PrB.Value++; }));

                        }

                        AddEndTable(word);

                        this.Invoke(new Action(() => { 
                            Action_PrB.Visible = false;
                            CreateWordFile_bt.Enabled = true;

                        }));


                        word.Visible = true;
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }
                
            });

            

        }
        private void AddEndTable(Microsoft.Office.Interop.Word.Application Word)
        {
            AddCenterText(Word, "", false);
            AddCenterText(Word, "", false);
            AddCenterText(Word, "", false);
            var ParagraphToFirstTable = Word.ActiveDocument.Paragraphs.Add();
            ParagraphToFirstTable.SpaceAfter = 0;
            Table table = Word.Application.ActiveDocument.Tables.Add(ParagraphToFirstTable.Range, 2, 4, Type.Missing, Type.Missing);
            table.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
            table.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
            table.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            table.Range.ParagraphFormat.SpaceAfter = 0;
            table.Range.Font.Name = "Times New Roman";

            table.Cell(1, 1).Range.Text = "ГИП";
            table.Cell(1, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            table.Cell(1, 1).Width = (float)(4.4 * Word.ActiveDocument.Sections.PageSetup.RightMargin);
            table.Cell(1, 2).Range.Text = GIP;
            table.Cell(1, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            table.Cell(1, 2).Width = (float)(7.85 * Word.ActiveDocument.Sections.PageSetup.RightMargin);
            table.Cell(1, 3).Range.Text = "";
            table.Cell(1, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            table.Cell(1, 3).Width = (float)(3.53 * Word.ActiveDocument.Sections.PageSetup.RightMargin);
            table.Cell(1, 4).Range.Text = DateTime.Parse(GIP_Date).ToString("dd.MM.yyyy");
            table.Cell(1, 4).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            table.Cell(1, 4).Width = (float)(2.74 * Word.ActiveDocument.Sections.PageSetup.RightMargin);

            table.Cell(2, 1).Range.Text = "Разраб.";
            table.Cell(2, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            table.Cell(2, 1).Width = (float)(4.4 * Word.ActiveDocument.Sections.PageSetup.RightMargin);
            table.Cell(2, 2).Range.Text = Developer;
            table.Cell(2, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            table.Cell(2, 2).Width = (float)(7.85 * Word.ActiveDocument.Sections.PageSetup.RightMargin);
            table.Cell(2, 3).Range.Text = "";
            table.Cell(2, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            table.Cell(2, 3).Width = (float)(3.53 * Word.ActiveDocument.Sections.PageSetup.RightMargin);
            table.Cell(2, 4).Range.Text = DateTime.Parse(Developer_Date).ToString("dd.MM.yyyy");
            table.Cell(2, 4).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            table.Cell(2, 4).Width = (float)(2.74 * Word.ActiveDocument.Sections.PageSetup.RightMargin);
            AddText(Word, "", false);
        }
        private void AddIULTable(Microsoft.Office.Interop.Word.Application Word, int NumberPP, string FileName, string Hash, bool firstindex)
        {
            var ParagraphToFirstTable = Word.ActiveDocument.Paragraphs.Add();
            ParagraphToFirstTable.SpaceAfter = 0;
            int RowCount = 1;
            int FillIndex = 1;
            if (firstindex)
            {
                RowCount = 2;
                FillIndex = 2;
            } 

            Table FirstTable = Word.Application.ActiveDocument.Tables.Add(ParagraphToFirstTable.Range, RowCount, 5, Type.Missing, Type.Missing);
            FirstTable.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
            FirstTable.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;

            FirstTable.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            FirstTable.Range.ParagraphFormat.SpaceAfter = 0;
            FirstTable.Range.Font.Name = "Times New Roman";

            if (firstindex)
            {
                FirstTable.Cell(1, 1).Range.Text = "Номер п/п";
                FirstTable.Cell(1, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                FirstTable.Cell(1, 1).Width = (float)(1.7 * Word.ActiveDocument.Sections.PageSetup.RightMargin);
                FirstTable.Cell(1, 2).Range.Text = "Обозначение документа";
                FirstTable.Cell(1, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                FirstTable.Cell(1, 2).Width = (float)(5.5 * Word.ActiveDocument.Sections.PageSetup.RightMargin);
                FirstTable.Cell(1, 3).Range.Text = "Наименование изделия, вид документа";
                FirstTable.Cell(1, 3).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                FirstTable.Cell(1, 3).Width = (float)(5.05 * Word.ActiveDocument.Sections.PageSetup.RightMargin);
                FirstTable.Cell(1, 4).Range.Text = "Версия";
                FirstTable.Cell(1, 4).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                FirstTable.Cell(1, 4).Width = (float)(2.95 * Word.ActiveDocument.Sections.PageSetup.RightMargin);
                FirstTable.Cell(1, 5).Range.Text = "Номер последнего изменения";
                FirstTable.Cell(1, 5).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                FirstTable.Cell(1, 5).Width = (float)(3.32 * Word.ActiveDocument.Sections.PageSetup.RightMargin);
            }

            FirstTable.Cell(FillIndex, 1).Range.Text = NumberPP.ToString();
            FirstTable.Cell(FillIndex, 1).Width = (float)(1.7 * Word.ActiveDocument.Sections.PageSetup.RightMargin);
            FirstTable.Cell(FillIndex, 2).Range.Text = FileName;
            FirstTable.Cell(FillIndex, 2).Width = (float)(5.5 * Word.ActiveDocument.Sections.PageSetup.RightMargin);
            FirstTable.Cell(FillIndex, 3).Range.Text = "Сметная документация";
            FirstTable.Cell(FillIndex, 3).Width = (float)(5.05 * Word.ActiveDocument.Sections.PageSetup.RightMargin);
            FirstTable.Cell(FillIndex, 4).Range.Text = "1";
            FirstTable.Cell(FillIndex, 4).Width = (float)(2.95 * Word.ActiveDocument.Sections.PageSetup.RightMargin);
            FirstTable.Cell(FillIndex, 5).Range.Text = "-";
            FirstTable.Cell(FillIndex, 5).Width = (float)(3.32 * Word.ActiveDocument.Sections.PageSetup.RightMargin);

            AddText(Word, "", false);

            var ParagraphToSecondTable = Word.ActiveDocument.Paragraphs.Add();
            ParagraphToSecondTable.SpaceAfter = 0;
            ParagraphToSecondTable.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            Table SecondTable = Word.Application.ActiveDocument.Tables.Add(ParagraphToSecondTable.Range, 1, 2, Type.Missing, Type.Missing);
            SecondTable.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
            SecondTable.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
            SecondTable.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            SecondTable.Range.ParagraphFormat.SpaceAfter = 0;
            SecondTable.Range.Font.Name = "Times New Roman";

            SecondTable.Cell(1, 1).Range.Text = "Алгоритм расчёта CRC32";
            SecondTable.Cell(1, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            SecondTable.Cell(1, 1).Width = (float)(4 * Word.ActiveDocument.Sections.PageSetup.RightMargin);
            SecondTable.Cell(1, 2).Range.Text = $"Контрольная сумма \r\n{Hash}";
            SecondTable.Cell(1, 2).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            SecondTable.Cell(1, 2).Width = (float)(14.52 * Word.ActiveDocument.Sections.PageSetup.RightMargin);
            AddText(Word, "", false);

        }

        private void AddText(Microsoft.Office.Interop.Word.Application Word, string Text, bool Bold, string FontName, WdParagraphAlignment Alignment)
        {
            int IntBold = 0;
            switch (Bold)
            {
                case true:
                    IntBold = 1;
                break;
                case false:
                    IntBold = 0;
                break;
            }
            var Paragraph = Word.ActiveDocument.Paragraphs.Add();
            Paragraph.Alignment = Alignment;
            Paragraph.SpaceAfter = 0;
            //Paragraph.LineSpacing = 1;
            Paragraph.Range.Font.Name = FontName;
            Paragraph.Range.Font.Bold = IntBold;
            Paragraph.Range.InsertBefore(Text);

        }
        private void AddText(Microsoft.Office.Interop.Word.Application Word, string Text, bool Bold)
        {
            AddText(Word, Text, Bold, "Times New Roman", WdParagraphAlignment.wdAlignParagraphLeft);
        }
        private void AddCenterText(Microsoft.Office.Interop.Word.Application Word, string Text, bool Bold)
        {
            AddText(Word, Text, Bold, "Times New Roman", WdParagraphAlignment.wdAlignParagraphCenter);
        }
    }
}
