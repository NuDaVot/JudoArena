using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Word = Microsoft.Office.Interop.Word;
using JudoArena.Model.DB;

namespace JudoArena.Model
{
    class DocumentWord
    {
        public DocumentWord() {  }
        public void GenerateWord(Competition competition)
        {
            List<Category> categories = new List<Category>();
            ControlCompetition controlCompetition = new();

            categories = controlCompetition.GetCategory(competition.Id);

            List<ParticipantCategory> participantsCategory = new List<ParticipantCategory>();

            Word.Application oWordApp = new Word.Application();
            oWordApp.Visible = true;

            Word.Document oDoc = oWordApp.Documents.Add();

            const float cmToPoints = 2.835f; // Константа для преобразования сантиметров в пункты

            // Удаление отступов на странице (в сантиметрах)
            oDoc.PageSetup.LeftMargin = 10 * cmToPoints;
            oDoc.PageSetup.RightMargin = 20 * cmToPoints;
            oDoc.PageSetup.TopMargin = 10 * cmToPoints;
            oDoc.PageSetup.BottomMargin = 20 * cmToPoints;

            // Добавление заголовка
            Word.Paragraph titlePara = oDoc.Paragraphs.Add();
            titlePara.Range.Text = $"Соревнование {competition.Name}";
            titlePara.Range.Font.Size = 14;
            titlePara.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            titlePara.Range.InsertParagraphAfter();

            // Добавление даты соревнования
            Word.Paragraph infoCompetition = oDoc.Paragraphs.Add();
            infoCompetition.Range.Text = $"Дата соревнования: {competition.Date.Value.ToShortDateString()}г. " +
                $"Адрес: {competition.Address}";
            infoCompetition.Range.Font.Size = 10;
            infoCompetition.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            infoCompetition.Range.InsertParagraphAfter();

            int col = 0;
            foreach (Category category in categories)
            {
                Word.Paragraph categoryName = oDoc.Paragraphs.Add();
                categoryName.Range.Text = $"Категория " +
                    $"до {category.IdWeightNavigation.WeightEnd}кг. " +
                    $"c {category.IdAgeNavigation.AgeStart.Value.Year}г. " +
                    $"до {category.IdAgeNavigation.AgeEnd.Value.Year}г.";
                categoryName.Range.Font.Size = 10;
                categoryName.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                categoryName.Range.InsertParagraphAfter();

                Word.Paragraph para = oDoc.Paragraphs.Add();

                participantsCategory = (controlCompetition.GetParticipantCategory(category.Id));

                
                Word.Table table = oDoc.Tables.Add(para.Range, participantsCategory.Count + 1, 6); // Создание таблицы

                // Заголовки столбцов
                table.Cell(1, 1).Range.Text = "Фамилия";
                table.Cell(1, 2).Range.Text = "Имя";
                table.Cell(1, 3).Range.Text = "Отчество";
                table.Cell(1, 4).Range.Text = "Вес";
                table.Cell(1, 5).Range.Text = "Дата рождения";
                table.Cell(1, 6).Range.Text = "ФИО тренера";

                // Заполнение данных
                for (int i = 0; i < participantsCategory.Count; i++)
                {
                    ParticipantCategory pc = participantsCategory[i];

                    // Фамилия
                    table.Cell(i + 2, 1).Range.Text = pc.IdParticipantNavigation.Surname;
                    // Имя
                    table.Cell(i + 2, 2).Range.Text = pc.IdParticipantNavigation.Name;
                    // Отчество
                    table.Cell(i + 2, 3).Range.Text = pc.IdParticipantNavigation.Patronymic;
                    // Вес
                    table.Cell(i + 2, 4).Range.Text = pc.IdParticipantNavigation.Weight.ToString();
                    // Дата рождения
                    table.Cell(i + 2, 5).Range.Text = pc.IdParticipantNavigation.DateBirth.Value.ToShortDateString();
                    // ФИО тренера
                    table.Cell(i + 2, 6).Range.Text = $"{pc.IdTrainerNavigation.Surname} " +
                        $"{pc.IdTrainerNavigation.Name[0]}." +
                        $"{pc.IdTrainerNavigation.Patronymic[0]}.";
                    col++;
                }

                // Форматирование таблицы
                table.Borders.Enable = 1; // Включение границ таблицы
                table.Rows[1].Range.Font.Bold = 1; // Жирный шрифт для заголовков

                // Количесво участников
                Word.Paragraph catpar = oDoc.Paragraphs.Add();
                catpar.Range.Text = $"Количество участников: {participantsCategory.Count}";
                catpar.Range.Font.Size = 10;
                catpar.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                catpar.Range.InsertParagraphAfter();

                para.Range.InsertParagraphAfter(); // Добавление пустого абзаца после таблицы
                
            }
            // Количесво категорий
            Word.Paragraph categoryPara = oDoc.Paragraphs.Add();
            categoryPara.Range.Text = $"Количество категорий: {categories.Count}";
            categoryPara.Range.Font.Size = 10;
            categoryPara.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            categoryPara.Range.InsertParagraphAfter();

            // Количесво участников
            Word.Paragraph colPara = oDoc.Paragraphs.Add();
            colPara.Range.Text = $"Количество всего участников: {col}";
            colPara.Range.Font.Size = 10;
            colPara.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            colPara.Range.InsertParagraphAfter();

            // Добавление даты
            Word.Paragraph OrganizerPara = oDoc.Paragraphs.Add();
            OrganizerPara.Range.Text =  $"{competition.OrganizerNavigation.Surname} " +
                $"{competition.OrganizerNavigation.Name[0]}." +
                $"{competition.OrganizerNavigation.Patronymic[0]}.________________";
            OrganizerPara.Range.Font.Size = 10;
            OrganizerPara.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
            OrganizerPara.Range.InsertParagraphAfter();

            // Добавление даты
            Word.Paragraph datePara = oDoc.Paragraphs.Add();
            datePara.Range.Text = $"Документ сформирован: {DateTime.Now.ToString()}";
            datePara.Range.Font.Size = 10;
            datePara.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
            datePara.Range.InsertParagraphAfter();

        }
    }
}
