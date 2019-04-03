using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using ClassLibrary1;
using ClassLibraryplugin1;
using ClassLibraryplugin2;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //
        //class Human
        //

        List<Human> human = new List<Human>(0);
        public int ID_Human = 0;
        public string HumanSelectedFIO = "";

        private void HumanCreateButton_Click(object sender, EventArgs e)
        {
            HumanSelectedFIO = "";

            HumanlistBox.Items.Clear();

            HumanFIO.Clear();
            HumanAge.Clear();
            HumanAdress.Clear();
            HumanMaleOrFemale.Clear();
            
            human.Capacity++;
            ID_Human++;
            human.Add(new Human("ФИО" + ID_Human, "0", "Адрес", "Пол"));
            foreach (Human i in human)
            {
                HumanlistBox.Items.Add(i.FIO);
            }

        }

        private void HumanSavebutton_Click(object sender, EventArgs e)
        {
            if(HumanFIO.Text != "" &&
            HumanAge.Text != "" &&
            HumanAdress.Text != "" &&
            HumanMaleOrFemale.Text != "" && HumanSelectedFIO != "")
            {
                int flag = 0;
                foreach (Human i in human)
                {
                    if (i.FIO == HumanFIO.Text && i.FIO != HumanSelectedFIO)
                    {
                        flag++;
                    }
                }
                if (flag == 0)
                {
                    HumanlistBox.Items.Clear();
                    foreach (Human i in human)
                    {
                        if (i.FIO == HumanSelectedFIO)
                        {
                            i.FIO = HumanFIO.Text;
                            i.Age = HumanAge.Text;
                            i.Adress = HumanAdress.Text;
                            i.MaleOrFemale = HumanMaleOrFemale.Text;
                        }
                        HumanlistBox.Items.Add(i.FIO);
                    }
                    HumanFIO.Clear();
                    HumanAge.Clear();
                    HumanAdress.Clear();
                    HumanMaleOrFemale.Clear();
                } else{ MessageBox.Show("Объект с таким ФИО существует."); }
            } else { MessageBox.Show("Не заполнены все поля или не выбран объект."); }

        }

        private void HumanlistBox_Click(object sender, EventArgs e)
        {
            try
            {
                HumanSelectedFIO = HumanlistBox.SelectedItem.ToString();
                foreach (Human i in human)
                {
                    if (i.FIO == HumanSelectedFIO)
                    {
                        HumanFIO.Text = i.FIO;
                        HumanAge.Text = i.Age;
                        HumanAdress.Text = i.Adress;
                        HumanMaleOrFemale.Text = i.MaleOrFemale;
                    }
                }
            }
            catch
            {
            }
        }

        private void HumanDeletebutton_Click(object sender, EventArgs e)
        {
            if (HumanFIO.Text != "" &&
            HumanAge.Text != "" &&
            HumanAdress.Text != "" &&
            HumanMaleOrFemale.Text != "" && HumanSelectedFIO != "")
            {
                HumanlistBox.Items.Clear();
                foreach (Human i in human)
                {
                    if (i.FIO == HumanSelectedFIO)
                    {
                        human.Remove(i);
                        break;
                    }
                }
                foreach (Human i in human)
                {
                    HumanlistBox.Items.Add(i.FIO);
                }
                HumanFIO.Clear();
                HumanAge.Clear();
                HumanAdress.Clear();
                HumanMaleOrFemale.Clear();

            }
            else { MessageBox.Show("Не заполнены все поля или не выбран объект."); }
        }

        //
        //class Applicant
        //

        List<Applicant> applicant = new List<Applicant>(0);
        public int ID_Applicant = 0;
        public string ApplicantSelectedFIO = "";

        private void ApplicantCreatebutton_Click(object sender, EventArgs e)
        {
            ApplicantSelectedFIO = "";

            ApplicantlistBox.Items.Clear();

            ApplicantFIO.Clear();
            ApplicantAge.Clear();
            ApplicantAdress.Clear();
            ApplicantMaleOrFemale.Clear();
            ApplicantWantSpeciality.Clear();
            ApplicantPoints.Clear();

            applicant.Capacity++;
            ID_Applicant++;
            applicant.Add(new Applicant("ФИО" + ID_Applicant, "0", "Адрес", "Пол", "Специальность", "Количество баллов"));
            foreach (Applicant i in applicant)
            {
                ApplicantlistBox.Items.Add(i.FIO);
            }
        }

        private void ApplicantSavebutton_Click(object sender, EventArgs e)
        {
            if (ApplicantFIO.Text != "" &&
            ApplicantAge.Text != "" &&
            ApplicantAdress.Text != "" &&
            ApplicantMaleOrFemale.Text != "" &&
            ApplicantWantSpeciality.Text != "" &&
            ApplicantPoints.Text != "" && ApplicantSelectedFIO != "")
            {
                int flag = 0;
                foreach (Applicant i in applicant)
                {
                    if (i.FIO == ApplicantFIO.Text && i.FIO != ApplicantSelectedFIO)
                    {
                        flag++;
                    }
                }
                if (flag == 0)
                {
                    ApplicantlistBox.Items.Clear();
                    foreach (Applicant i in applicant)
                    {
                        if (i.FIO == ApplicantSelectedFIO)
                        {
                            i.FIO = ApplicantFIO.Text;
                            i.Age = ApplicantAge.Text;
                            i.Adress = ApplicantAdress.Text;
                            i.MaleOrFemale = ApplicantMaleOrFemale.Text;
                            i.WantSpeciality = ApplicantWantSpeciality.Text;
                            i.Points = ApplicantPoints.Text;
                        }
                        ApplicantlistBox.Items.Add(i.FIO);
                    }
                    ApplicantFIO.Clear();
                    ApplicantAge.Clear();
                    ApplicantAdress.Clear();
                    ApplicantMaleOrFemale.Clear();
                    ApplicantWantSpeciality.Clear();
                    ApplicantPoints.Clear();

                }
                else { MessageBox.Show("Объект с таким ФИО существует."); }
            }
            else { MessageBox.Show("Не заполнены все поля или не выбран объект."); }
        }

        private void ApplicantDeleteButton_Click(object sender, EventArgs e)
        {
            if (ApplicantFIO.Text != "" &&
            ApplicantAge.Text != "" &&
            ApplicantAdress.Text != "" &&
            ApplicantMaleOrFemale.Text != "" &&
            ApplicantWantSpeciality.Text != "" &&
            ApplicantPoints.Text != "" && ApplicantSelectedFIO != "")
            {
                ApplicantlistBox.Items.Clear();
                foreach (Applicant i in applicant)
                {
                    if (i.FIO == ApplicantSelectedFIO)
                    {
                        applicant.Remove(i);
                        break;
                    }
                }
                foreach (Applicant i in applicant)
                {
                    ApplicantlistBox.Items.Add(i.FIO);
                }
                ApplicantFIO.Clear();
                ApplicantAge.Clear();
                ApplicantAdress.Clear();
                ApplicantMaleOrFemale.Clear();
                ApplicantWantSpeciality.Clear();
                ApplicantPoints.Clear();

            }
            else { MessageBox.Show("Не заполнены все поля или не выбран объект."); }

        }

        private void ApplicantlistBox_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicantSelectedFIO = ApplicantlistBox.SelectedItem.ToString();
                foreach (Applicant i in applicant)
                {
                    if (i.FIO == ApplicantSelectedFIO)
                    {
                        ApplicantFIO.Text = i.FIO;
                        ApplicantAge.Text = i.Age;
                        ApplicantAdress.Text = i.Adress;
                        ApplicantMaleOrFemale.Text = i.MaleOrFemale;
                        ApplicantWantSpeciality.Text = i.WantSpeciality;
                        ApplicantPoints.Text = i.Points;
                    }
                }
            }
            catch
            {
            }
        }

        //
        //class Student
        //

        List<Student> student = new List<Student>(0);
        public int ID_Student = 0;
        public string StudentSelectedFIO = "";

        private void StudentCreatebutton_Click(object sender, EventArgs e)
        {
            StudentSelectedFIO = "";

            StudentlistBox.Items.Clear();

            StudentFIO.Clear();
            StudentAge.Clear();
            StudentAdress.Clear();
            StudentMaleOrFemale.Clear();
            StudentCourse.Clear();
            StudentSpeciality.Clear();
            StudentGroup.Clear();
            StudentTypeOfLearning.Clear();
            StudentFreeOrPaid.Clear();

            student.Capacity++;
            ID_Student++;
            student.Add(new Student("ФИО" + ID_Student, "0", "Адрес", "Пол", "Курс", "Специальность" , "Группа", "Дневное/вечернее/заочное/.." ,"Бюджет/платное"));
            foreach (Student i in student)
            {
                StudentlistBox.Items.Add(i.FIO);
            }
        }

        private void StudentSavebutton_Click(object sender, EventArgs e)
        {
            if (StudentFIO.Text != "" &&
            StudentAge.Text != "" &&
            StudentAdress.Text != "" &&
            StudentMaleOrFemale.Text != ""&&
            StudentCourse.Text !="" &&
            StudentSpeciality.Text != "" &&
            StudentGroup.Text != "" &&
            StudentTypeOfLearning.Text != "" &&
            StudentFreeOrPaid.Text != "" && StudentSelectedFIO != "")
            {
                int flag = 0;
                foreach (Student i in student)
                {
                    if (i.FIO == StudentFIO.Text && i.FIO != StudentSelectedFIO)
                    {
                        flag++;
                    }
                }
                if (flag == 0)
                {
                    StudentlistBox.Items.Clear();
                    foreach (Student i in student)
                    {
                        if (i.FIO == StudentSelectedFIO)
                        {
                            i.FIO = StudentFIO.Text;
                            i.Age = StudentAge.Text;
                            i.Adress = StudentAdress.Text;
                            i.MaleOrFemale = StudentMaleOrFemale.Text;
                            i.Course = StudentCourse.Text;
                            i.Speciality = StudentSpeciality.Text;
                            i.Group = StudentGroup.Text;
                            i.TypeOfLearning = StudentTypeOfLearning.Text;
                            i.FreeOrPaid = StudentFreeOrPaid.Text;
                        }
                        StudentlistBox.Items.Add(i.FIO);
                    }
                    StudentFIO.Clear();
                    StudentAge.Clear();
                    StudentAdress.Clear();
                    StudentMaleOrFemale.Clear();
                    StudentCourse.Clear();
                    StudentSpeciality.Clear();
                    StudentGroup.Clear();
                    StudentTypeOfLearning.Clear();
                    StudentFreeOrPaid.Clear();
                }
                else { MessageBox.Show("Объект с таким ФИО существует."); }
            }
            else { MessageBox.Show("Не заполнены все поля или не выбран объект."); }
        }

        private void StudentDeletebutton_Click(object sender, EventArgs e)
        {
            if (StudentFIO.Text != "" &&
            StudentAge.Text != "" &&
            StudentAdress.Text != "" &&
            StudentMaleOrFemale.Text != "" &&
            StudentCourse.Text != "" &&
            StudentSpeciality.Text != "" &&
            StudentGroup.Text != "" &&
            StudentTypeOfLearning.Text != "" &&
            StudentFreeOrPaid.Text != "" && StudentSelectedFIO != "")
            {
                StudentlistBox.Items.Clear();
                foreach (Student i in student)
                {
                    if (i.FIO == StudentSelectedFIO)
                    {
                        student.Remove(i);
                        break;
                    }
                }
                foreach (Student i in student)
                {
                    StudentlistBox.Items.Add(i.FIO);
                }
                StudentFIO.Clear();
                StudentAge.Clear();
                StudentAdress.Clear();
                StudentMaleOrFemale.Clear();
                StudentCourse.Clear();
                StudentSpeciality.Clear();
                StudentGroup.Clear();
                StudentTypeOfLearning.Clear();
                StudentFreeOrPaid.Clear();

            }
            else { MessageBox.Show("Не заполнены все поля или не выбран объект."); }
        }

        private void StudentlistBox_Click(object sender, EventArgs e)
        {
            try
            {
                StudentSelectedFIO = StudentlistBox.SelectedItem.ToString();
                foreach (Student i in student)
                {
                    if (i.FIO == StudentSelectedFIO)
                    {
                        StudentFIO.Text = i.FIO;
                        StudentAge.Text = i.Age;
                        StudentAdress.Text = i.Adress;
                        StudentMaleOrFemale.Text = i.MaleOrFemale;
                        StudentCourse.Text = i.Course;
                        StudentSpeciality.Text = i.Speciality;
                        StudentGroup.Text = i.Group;
                        StudentTypeOfLearning.Text = i.TypeOfLearning;
                        StudentFreeOrPaid.Text = i.FreeOrPaid;
                    }
                }
            }
            catch
            {
            }
        }

        // 
        //calss StudentLastCourse
        //
        List<StudentLastCourse> studentLastCourse = new List<StudentLastCourse>(0);
        public int ID_StudentLastCourse = 0;
        public string StudentLastCourseSelectedFIO = "";

        List<Diploma> diploma = new List<Diploma>(0);
        public int ID_Diploma = 0;

        private void StudentLastCourseCreatebutton_Click(object sender, EventArgs e)
        {
            StudentLastCourseSelectedFIO = "";

            StudentLastCourselistBox.Items.Clear();
            
            StudentLastCourseFIO.Clear();
            StudentLastCourseAge.Clear();
            StudentLastCourseAdress.Clear();
            StudentLastCourseMaleOrFemale.Clear();
            StudentLastCourseCourse.Clear();
            StudentLastCourseSpeciality.Clear();
            StudentLastCourseGroup.Clear();
            StudentLastCourseTypeOfLearning.Clear();
            StudentLastCourseFreeOrPaid.Clear();
            StudentLastCourseDistribution.Clear();
            DiplomaName.Clear();
            DiplomaDate.Clear();
            DiplomaNameProfessor.Clear();

            diploma.Capacity++;
            diploma.Add(new Diploma("Название дипломной работы","Дата сдачи","Имя преподавателя"));

            studentLastCourse.Capacity++;
            ID_StudentLastCourse++;
            studentLastCourse.Add(new StudentLastCourse("ФИО" + ID_StudentLastCourse, "0", "Адрес", "Пол", "Курс", "Специальность", "Группа", "Дневное/вечернее/заочное/..", "Бюджет/платное","Распределение", diploma[diploma.Count-1]));
            foreach (StudentLastCourse i in studentLastCourse)
            {
                StudentLastCourselistBox.Items.Add(i.FIO);
            }
        }

        private void StudentLastCourseSavebutton_Click(object sender, EventArgs e)
        {
            if (StudentLastCourseFIO.Text != "" &&
           StudentLastCourseAge.Text != "" &&
           StudentLastCourseAdress.Text != "" &&
           StudentLastCourseMaleOrFemale.Text != "" &&
           StudentLastCourseCourse.Text != "" &&
           StudentLastCourseSpeciality.Text != "" &&
           StudentLastCourseGroup.Text != "" &&
           StudentLastCourseTypeOfLearning.Text != "" &&
           StudentLastCourseFreeOrPaid.Text != "" &&
           StudentLastCourseDistribution.Text != "" &&
           DiplomaName.Text != "" &&
           DiplomaDate.Text != "" &&
           DiplomaNameProfessor.Text != "" && StudentLastCourseSelectedFIO != "")
            {
                int flag = 0;
                foreach (StudentLastCourse i in studentLastCourse)
                {
                    if (i.FIO == StudentLastCourseFIO.Text && i.FIO != StudentLastCourseSelectedFIO)
                    {
                        flag++;
                    }
                }
                if (flag == 0)
                {
                    StudentLastCourselistBox.Items.Clear();
                    foreach (StudentLastCourse i in studentLastCourse)
                    {
                        if (i.FIO == StudentLastCourseSelectedFIO)
                        {
                            i.FIO = StudentLastCourseFIO.Text;
                            i.Age = StudentLastCourseAge.Text;
                            i.Adress = StudentLastCourseAdress.Text;
                            i.MaleOrFemale = StudentLastCourseMaleOrFemale.Text;
                            i.Course = StudentLastCourseCourse.Text;
                            i.Speciality = StudentLastCourseSpeciality.Text;
                            i.Group = StudentLastCourseGroup.Text;
                            i.TypeOfLearning = StudentLastCourseTypeOfLearning.Text;
                            i.FreeOrPaid = StudentLastCourseFreeOrPaid.Text;
                            i.Distribution = StudentLastCourseDistribution.Text;
                            i.Diploma.Theme = DiplomaName.Text;
                            i.Diploma.DateOfDelivery = DiplomaDate.Text;
                            i.Diploma.NameProfessor = DiplomaNameProfessor.Text;
                        }
                        StudentLastCourselistBox.Items.Add(i.FIO);
                    }
                    StudentLastCourseFIO.Clear();
                    StudentLastCourseAge.Clear();
                    StudentLastCourseAdress.Clear();
                    StudentLastCourseMaleOrFemale.Clear();
                    StudentLastCourseCourse.Clear();
                    StudentLastCourseSpeciality.Clear();
                    StudentLastCourseGroup.Clear();
                    StudentLastCourseTypeOfLearning.Clear();
                    StudentLastCourseFreeOrPaid.Clear();
                    StudentLastCourseDistribution.Clear();
                    DiplomaName.Clear();
                    DiplomaDate.Clear();
                    DiplomaNameProfessor.Clear();
                }
                else { MessageBox.Show("Объект с таким ФИО существует."); }
            }
            else { MessageBox.Show("Не заполнены все поля или не выбран объект."); }
        }

        private void StudentLastCourseDeletebutton_Click(object sender, EventArgs e)
        {
            if (StudentLastCourseFIO.Text != "" &&
           StudentLastCourseAge.Text != "" &&
           StudentLastCourseAdress.Text != "" &&
           StudentLastCourseMaleOrFemale.Text != "" &&
           StudentLastCourseCourse.Text != "" &&
           StudentLastCourseSpeciality.Text != "" &&
           StudentLastCourseGroup.Text != "" &&
           StudentLastCourseTypeOfLearning.Text != "" &&
           StudentLastCourseFreeOrPaid.Text != "" &&
           StudentLastCourseDistribution.Text != "" &&
           DiplomaName.Text != "" &&
           DiplomaDate.Text != "" &&
           DiplomaNameProfessor.Text != "" && StudentLastCourseSelectedFIO != "")
            {
                StudentLastCourselistBox.Items.Clear();
                int flagstudent = 0, flagdiploma = 0;
                foreach (StudentLastCourse i in studentLastCourse)
                {
                    flagstudent++;
                    if (i.FIO == StudentLastCourseSelectedFIO)
                    {
                        studentLastCourse.Remove(i);
                        foreach (Diploma j in diploma)
                        {
                            flagdiploma++;
                            if (flagstudent == flagdiploma)
                            {
                                diploma.Remove(j);
                                break;
                            }
                        }
                        break;
                    }
                }
                foreach (StudentLastCourse i in studentLastCourse)
                {
                    StudentLastCourselistBox.Items.Add(i.FIO);
                }
                StudentLastCourseFIO.Clear();
                StudentLastCourseAge.Clear();
                StudentLastCourseAdress.Clear();
                StudentLastCourseMaleOrFemale.Clear();
                StudentLastCourseCourse.Clear();
                StudentLastCourseSpeciality.Clear();
                StudentLastCourseGroup.Clear();
                StudentLastCourseTypeOfLearning.Clear();
                StudentLastCourseFreeOrPaid.Clear();
                StudentLastCourseDistribution.Clear();
                DiplomaName.Clear();
                DiplomaDate.Clear();
                DiplomaNameProfessor.Clear();

            }
            else { MessageBox.Show("Не заполнены все поля или не выбран объект."); }
        }

        private void StudentLastCourselistBox_Click(object sender, EventArgs e)
        {
            try
            {
                StudentLastCourseSelectedFIO = StudentLastCourselistBox.SelectedItem.ToString();
                foreach (StudentLastCourse i in studentLastCourse)
                {
                    if (i.FIO == StudentLastCourseSelectedFIO)
                    {
                        StudentLastCourseFIO.Text = i.FIO;
                        StudentLastCourseAge.Text = i.Age;
                        StudentLastCourseAdress.Text = i.Adress;
                        StudentLastCourseMaleOrFemale.Text = i.MaleOrFemale;
                        StudentLastCourseCourse.Text = i.Course;
                        StudentLastCourseSpeciality.Text = i.Speciality;
                        StudentLastCourseGroup.Text = i.Group;
                        StudentLastCourseTypeOfLearning.Text = i.TypeOfLearning;
                        StudentLastCourseFreeOrPaid.Text = i.FreeOrPaid;
                        StudentLastCourseDistribution.Text = i.Distribution;
                        DiplomaName.Text = i.Diploma.Theme;
                        DiplomaDate.Text = i.Diploma.DateOfDelivery;
                        DiplomaNameProfessor.Text = i.Diploma.NameProfessor;
                    }
                }
            }
            catch
            {
            }
        }

        //
        //class Workers
        //

        List<Workers> workers = new List<Workers>(0);
        public int ID_Workers = 0;
        public string WorkersSelectedFIO = "";

        private void WorkersCreatebutton_Click(object sender, EventArgs e)
        {
            WorkersSelectedFIO = "";

            WorkerslistBox.Items.Clear();

            WorkersFIO.Clear();
            WorkersAge.Clear();
            WorkersAdress.Clear();
            WorkersMaleOrFemale.Clear();
            WorkersPost.Clear();
            WorkersSalary.Clear();
            WorkersLenghtOfService.Clear();

            workers.Capacity++;
            ID_Workers++;
            workers.Add(new Workers("ФИО" + ID_Workers, "0", "Адрес", "Пол", "Должность", "Заработная плата", "Стаж работы"));
            foreach (Workers i in workers)
            {
                WorkerslistBox.Items.Add(i.FIO);
            }
        }

        private void WorkersSavebutton_Click(object sender, EventArgs e)
        {
            if (WorkersFIO.Text != "" &&
            WorkersAge.Text != "" &&
            WorkersAdress.Text != "" &&
            WorkersMaleOrFemale.Text != "" &&
            WorkersPost.Text != "" &&
            WorkersSalary.Text != "" &&
            WorkersLenghtOfService.Text != "" && WorkersSelectedFIO != "")
            {
                int flag = 0;
                foreach (Workers i in workers)
                {
                    if (i.FIO == WorkersFIO.Text && i.FIO != WorkersSelectedFIO)
                    {
                        flag++;
                    }
                }
                if (flag == 0)
                {
                    WorkerslistBox.Items.Clear();
                    foreach (Workers i in workers)
                    {
                        if (i.FIO == WorkersSelectedFIO)
                        {
                            i.FIO = WorkersFIO.Text;
                            i.Age = WorkersAge.Text;
                            i.Adress = WorkersAdress.Text;
                            i.MaleOrFemale = WorkersMaleOrFemale.Text;
                            i.Post = WorkersPost.Text;
                            i.Salary = WorkersSalary.Text;
                            i.LenghtOfService = WorkersLenghtOfService.Text;
                        }
                        WorkerslistBox.Items.Add(i.FIO);
                    }
                    WorkersFIO.Clear();
                    WorkersAge.Clear();
                    WorkersAdress.Clear();
                    WorkersMaleOrFemale.Clear();
                    WorkersPost.Clear();
                    WorkersSalary.Clear();
                    WorkersLenghtOfService.Clear();
                }
                else { MessageBox.Show("Объект с таким ФИО существует."); }
            }
            else { MessageBox.Show("Не заполнены все поля или не выбран объект."); }
        }

        private void WorkersDeletebutton_Click(object sender, EventArgs e)
        {
            if (WorkersFIO.Text != "" &&
            WorkersAge.Text != "" &&
            WorkersAdress.Text != "" &&
            WorkersMaleOrFemale.Text != "" &&
            WorkersPost.Text != "" &&
            WorkersSalary.Text != "" &&
            WorkersLenghtOfService.Text != "" && WorkersSelectedFIO != "")
            {
                WorkerslistBox.Items.Clear();
                foreach (Workers i in workers)
                {
                    if (i.FIO == WorkersSelectedFIO)
                    {
                        workers.Remove(i);
                        break;
                    }
                }
                foreach (Workers i in workers)
                {
                    WorkerslistBox.Items.Add(i.FIO);
                }
                WorkersFIO.Clear();
                WorkersAge.Clear();
                WorkersAdress.Clear();
                WorkersMaleOrFemale.Clear();
                WorkersPost.Clear();
                WorkersSalary.Clear();
                WorkersLenghtOfService.Clear();

            }
            else { MessageBox.Show("Не заполнены все поля или не выбран объект."); }
        }

        private void WorkerslistBox_Click(object sender, EventArgs e)
        {
            try
            {
                WorkersSelectedFIO = WorkerslistBox.SelectedItem.ToString();
                foreach (Workers i in workers)
                {
                    if (i.FIO == WorkersSelectedFIO)
                    {
                        WorkersFIO.Text = i.FIO;
                        WorkersAge.Text = i.Age;
                        WorkersAdress.Text = i.Adress;
                        WorkersMaleOrFemale.Text = i.MaleOrFemale;
                        WorkersPost.Text = i.Post;
                        WorkersSalary.Text = i.Salary;
                        WorkersLenghtOfService.Text = i.LenghtOfService;
                    }
                }
            }
            catch
            {
            }
        }

        //
        //class Proffesor
        //

        List<Professor> professor = new List<Professor>(0);
        public int ID_Professor = 0;
        public string ProfessorSelectedFIO = "";

        private void ProfessorCreatebutton_Click(object sender, EventArgs e)
        {
            ProfessorSelectedFIO = "";

            ProfessorlistBox.Items.Clear();

            ProfessorFIO.Clear();
            ProfessorAge.Clear();
            ProfessorAdress.Clear();
            ProfessorMaleOrFemale.Clear();
            ProfessorPost.Clear();
            ProfessorSalary.Clear();
            ProfessorLenghtOfService.Clear();
            ProfessorSubject.Clear();
            ProfessorEducation.Clear();

            professor.Capacity++;
            ID_Professor++;
            professor.Add(new Professor("ФИО" + ID_Professor, "0", "Адрес", "Пол", "Должность", "Заработная плата", "Стаж работы", "Предмет/предметы", "Образование"));
            foreach (Professor i in professor)
            {
                ProfessorlistBox.Items.Add(i.FIO);
            }
        }

        private void ProfessorSavebutton_Click(object sender, EventArgs e)
        {
            if (ProfessorFIO.Text != "" &&
            ProfessorAge.Text != "" &&
            ProfessorAdress.Text != "" &&
            ProfessorMaleOrFemale.Text != "" &&
            ProfessorPost.Text != "" &&
            ProfessorSalary.Text != "" &&
            ProfessorLenghtOfService.Text != "" &&
            ProfessorEducation.Text != "" &&
            ProfessorSubject.Text != "" && ProfessorSelectedFIO != "")
            {
                int flag = 0;
                foreach (Workers i in workers)
                {
                    if (i.FIO == WorkersFIO.Text && i.FIO != WorkersSelectedFIO)
                    {
                        flag++;
                    }
                }
                if (flag == 0)
                {
                    ProfessorlistBox.Items.Clear();
                    foreach (Professor i in professor)
                    {
                        if (i.FIO == ProfessorSelectedFIO)
                        {
                            i.FIO = ProfessorFIO.Text;
                            i.Age = ProfessorAge.Text;
                            i.Adress = ProfessorAdress.Text;
                            i.MaleOrFemale = ProfessorMaleOrFemale.Text;
                            i.Post = ProfessorPost.Text;
                            i.Salary = ProfessorSalary.Text;
                            i.LenghtOfService = ProfessorLenghtOfService.Text;
                            i.Subject = ProfessorSubject.Text;
                            i.Education = ProfessorEducation.Text;
                        }
                        ProfessorlistBox.Items.Add(i.FIO);
                    }
                    ProfessorFIO.Clear();
                    ProfessorAge.Clear();
                    ProfessorAdress.Clear();
                    ProfessorMaleOrFemale.Clear();
                    ProfessorPost.Clear();
                    ProfessorSalary.Clear();
                    ProfessorLenghtOfService.Clear();
                    ProfessorSubject.Clear();
                    ProfessorEducation.Clear();
                }
                else { MessageBox.Show("Объект с таким ФИО существует."); }
            }
            else
            {
                MessageBox.Show("Не заполнены все поля или не выбран объект.");
            }
        }

        private void ProfessorDeletebutton_Click(object sender, EventArgs e)
        {
            if (ProfessorFIO.Text != "" &&
            ProfessorAge.Text != "" &&
            ProfessorAdress.Text != "" &&
            ProfessorMaleOrFemale.Text != "" &&
            ProfessorPost.Text != "" &&
            ProfessorSalary.Text != "" &&
            ProfessorLenghtOfService.Text != "" &&
            ProfessorEducation.Text != "" &&
            ProfessorSubject.Text != "" && ProfessorSelectedFIO != "")
            {
                ProfessorlistBox.Items.Clear();
                foreach (Professor i in professor)
                {
                    if (i.FIO == ProfessorSelectedFIO)
                    {
                        professor.Remove(i);
                        break;
                    }
                }
                foreach (Professor i in professor)
                {
                    ProfessorlistBox.Items.Add(i.FIO);
                }
                ProfessorFIO.Clear();
                ProfessorAge.Clear();
                ProfessorAdress.Clear();
                ProfessorMaleOrFemale.Clear();
                ProfessorPost.Clear();
                ProfessorSalary.Clear();
                ProfessorLenghtOfService.Clear();
                ProfessorSubject.Clear();
                ProfessorEducation.Clear();

            }
            else { MessageBox.Show("Не заполнены все поля или не выбран объект."); }
        }

        private void ProfessorlistBox_Click(object sender, EventArgs e)
        {
            try
            {
                ProfessorSelectedFIO = ProfessorlistBox.SelectedItem.ToString();
                foreach (Professor i in professor)
                {
                    if (i.FIO == ProfessorSelectedFIO)
                    {
                        ProfessorFIO.Text = i.FIO;
                        ProfessorAge.Text = i.Age;
                        ProfessorAdress.Text = i.Adress;
                        ProfessorMaleOrFemale.Text = i.MaleOrFemale;
                        ProfessorPost.Text = i.Post;
                        ProfessorSalary.Text = i.Salary;
                        ProfessorLenghtOfService.Text = i.LenghtOfService;
                        ProfessorSubject.Text = i.Subject;
                        ProfessorEducation.Text = i.Education;
                    }
                }
            }
            catch
            {
            }
        }

        //Serializer/Deserializer
        //class Human
        //

        private void HumanSerializerbutton_Click(object sender, EventArgs e)
        {
            if (!rbBinary.Checked && !rbJson.Checked && !rbUser.Checked) {
                { MessageBox.Show("Ошибка: не выбран способ сериализации"); }
                return;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                { MessageBox.Show("Ошибка: не выбран способ сохранения"); }
                return;
            }

            if (comboBox1.SelectedIndex == 1)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = saveFileDialog1.FileName;

                if (rbBinary.Checked)
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, human);
                    }
                }
                else if (rbJson.Checked)
                {
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Human>));

                    using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                    {
                        jsonFormatter.WriteObject(fs, human);
                    }
                }
                else if (rbUser.Checked)
                {

                    OpenFileDialog f = new OpenFileDialog();
                    f.FileName = filename;
                    string textout = "";
                    foreach (Human i in human)
                    {
                        textout = textout + i.FIO + Environment.NewLine + i.Age + Environment.NewLine + i.Adress + Environment.NewLine + i.MaleOrFemale + Environment.NewLine;
                    }
                    File.WriteAllText(f.FileName, textout);

                }

                return;
            }
            else if (comboBox1.SelectedIndex == 0)
            {

                ClassPlugin algorithms = new ClassPlugin("./Plugins/");
                if (algorithms.objects.Count == 0)
                {
                    MessageBox.Show("Нет плагинов");

                    return;
                }
                string filter = string.Empty;
                foreach (Class1 alg in algorithms.objects)
                {
                    filter += alg.Name + " archive (*" + alg.Format + ")|*" + alg.Format + "|";
                }
                saveFileDialog1.Filter = filter.TrimEnd('|');
                bool result = saveFileDialog1.ShowDialog() == DialogResult.OK;
                if (result == true)
                {
                    string filename = saveFileDialog1.FileName;
                    string ext = Path.GetExtension(saveFileDialog1.FileName);
                    string name = saveFileDialog1.FileName.Replace(ext, "");
                    Class1 compressor = algorithms.objects.Find(obj => obj.Format == ext);
                    if (rbBinary.Checked)
                    {
                        BinaryFormatter formatter = new BinaryFormatter();

                        using (FileStream fs = new FileStream(name, FileMode.OpenOrCreate))
                        {
                            formatter.Serialize(fs, human);
                        }
                        compressor.Compress(name, name + ext);
                    }
                    else if (rbJson.Checked)
                    {
                        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Human>));

                        using (FileStream fs = new FileStream(name, FileMode.OpenOrCreate))
                        {
                            jsonFormatter.WriteObject(fs, human);
                        }
                        compressor.Compress(name, name + ext);
                    }
                    else if (rbUser.Checked)
                    {


                        string textout = "";
                        foreach (Human i in human)
                        {
                            textout = textout + i.FIO + Environment.NewLine + i.Age + Environment.NewLine + i.Adress + Environment.NewLine + i.MaleOrFemale + Environment.NewLine;
                        }
                        File.WriteAllText(name, textout);
                        compressor.Compress(name, name + ext);
                    }
                    File.Delete(name);
                }
                
            }
        }

        private void HumanDeserializerbutton_Click(object sender, EventArgs e)
        {
            if (!rbBinary.Checked && !rbJson.Checked && !rbUser.Checked)
            {
                { MessageBox.Show("Ошибка: не выбран способ сериализации"); }
                return;
            }
            if (comboBox1.SelectedIndex == -1)
            {
                { MessageBox.Show("Ошибка: не выбран способ сохранения"); }
                return;
            }
            human.Clear();
            ID_Human = 0;
            HumanSelectedFIO = "";

            HumanlistBox.Items.Clear();

            HumanFIO.Clear();
            HumanAge.Clear();
            HumanAdress.Clear();
            HumanMaleOrFemale.Clear();


            if (comboBox1.SelectedIndex == 1)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = openFileDialog1.FileName;

                if (rbBinary.Checked)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                    {
                        human = (List<Human>)formatter.Deserialize(fs);
                    }

                    foreach (Human i in human)
                    {
                        ID_Human++;
                        HumanlistBox.Items.Add(i.FIO);
                    }
                }
                else if (rbJson.Checked)
                {
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Human>));

                    using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                    {
                        human = (List<Human>)jsonFormatter.ReadObject(fs);
                    }

                    foreach (Human i in human)
                    {
                        ID_Human++;
                        HumanlistBox.Items.Add(i.FIO);
                    }
                }
                else if (rbUser.Checked)
                {


                    string[] lines = File.ReadAllLines(filename);
                    for (int j = 0; j < lines.Length - 1; j += 4)
                    {

                        human.Capacity++;
                        human.Add(new Human(lines[j], lines[j + 1], lines[j + 2], lines[j + 3]));
                    }

                    foreach (Human i in human)
                    {
                        ID_Human++;
                        HumanlistBox.Items.Add(i.FIO);
                    }
                }
                return;
            } else if (comboBox1.SelectedIndex == 0) {
                ClassPlugin algorithms = new ClassPlugin("./Plugins/");
                if (algorithms.objects.Count == 0)
                {
                    MessageBox.Show("Нет плагинов");
                    return;
                }

                string filter = string.Empty;
                foreach (Class1 alg in algorithms.objects)
                {
                    filter += "*" + alg.Format + ";";
                }
                filter = filter.TrimEnd(';');
                openFileDialog1.Filter = "Archives (" + filter + ")|" + filter;

                bool result = openFileDialog1.ShowDialog() == DialogResult.OK;

                if (result == true)
                {
                    string filename = openFileDialog1.FileName;
                    string ext = System.IO.Path.GetExtension(filename);
                    string temp = filename.Replace(ext, "");

                    Class1 compressor = algorithms.objects.Find(obj => obj.Format == ext);
                    compressor.Decompress(filename, temp);

                    if (rbBinary.Checked)
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        using (FileStream fs = new FileStream(temp, FileMode.OpenOrCreate))
                        {
                            human = (List<Human>)formatter.Deserialize(fs);
                        }

                        foreach (Human i in human)
                        {
                            ID_Human++;
                            HumanlistBox.Items.Add(i.FIO);
                        }
                    }
                    else if (rbJson.Checked)
                    {
                        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Human>));

                        using (FileStream fs = new FileStream(temp, FileMode.OpenOrCreate))
                        {
                            human = (List<Human>)jsonFormatter.ReadObject(fs);
                        }

                        foreach (Human i in human)
                        {
                            ID_Human++;
                            HumanlistBox.Items.Add(i.FIO);
                        }
                    }
                    else if (rbUser.Checked)
                    {


                        string[] lines = File.ReadAllLines(temp);
                        for (int j = 0; j < lines.Length - 1; j += 4)
                        {

                            human.Capacity++;
                            human.Add(new Human(lines[j], lines[j + 1], lines[j + 2], lines[j + 3]));
                        }

                        foreach (Human i in human)
                        {
                            ID_Human++;
                            HumanlistBox.Items.Add(i.FIO);
                        }
                    }
                    File.Delete(temp);
                }
            }
        }

        //Serializer/Deserializer
        //class Applicant
        //

        private void ApplicantSerializerbutton_Click(object sender, EventArgs e)
        {
            if (!rbBinary.Checked && !rbJson.Checked && !rbUser.Checked)
            {
                { MessageBox.Show("Ошибка: не выбран способ сериализации"); }
                return;
            }



            string filter = string.Empty;


            ClassPlugin algorithms = new ClassPlugin("./");
            if (algorithms.objects.Count == 0)
            {
                MessageBox.Show("No plugins");
                return;
            }

            foreach (Class1 alg in algorithms.objects)
            {
                filter += alg.Name + " archive (*" + alg.Format + ")|*" + alg.Format + "|";
            }
            saveFileDialog1.Filter = filter.TrimEnd('|');
            bool result = saveFileDialog1.ShowDialog() == DialogResult.OK;
            if (result == true)
            {
                string filename = saveFileDialog1.FileName;
                string ext = Path.GetExtension(saveFileDialog1.FileName);
                string name = saveFileDialog1.FileName.Replace(ext, "");
                Class1 compressor = algorithms.objects.Find(obj => obj.Format == ext);
                if (rbBinary.Checked)
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    using (FileStream fs = new FileStream(name, FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, applicant);
                    }
                    compressor.Compress(name, name + ext);
                }
                else if (rbJson.Checked)
                {
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Applicant>));

                    using (FileStream fs = new FileStream(name, FileMode.OpenOrCreate))
                    {
                        jsonFormatter.WriteObject(fs, applicant);
                    }
                    compressor.Compress(name, name + ext);
                }
                else if (rbUser.Checked)
                {

                    //OpenFileDialog f = new OpenFileDialog();
                    //f.FileName = name;
                    string textout = "";
                    foreach (Applicant i in applicant)
                    {
                        textout = textout + i.FIO + Environment.NewLine + i.Age + Environment.NewLine + i.Adress + Environment.NewLine + i.MaleOrFemale + Environment.NewLine + i.WantSpeciality + Environment.NewLine + i.Points + Environment.NewLine;
                    }
                    File.WriteAllText(name, textout);
                    compressor.Compress(name, name + ext);
                }
                File.Delete(name);
            }
        }

        private void ApplicantDeserializerbutton_Click(object sender, EventArgs e)
        {
            if (!rbBinary.Checked && !rbJson.Checked && !rbUser.Checked)
            {
                { MessageBox.Show("Ошибка: не выбран способ сериализации"); }
                return;
            }
            applicant.Clear();
            ID_Applicant = 0;
            ApplicantSelectedFIO = "";

            ApplicantlistBox.Items.Clear();

            ApplicantFIO.Clear();
            ApplicantAge.Clear();
            ApplicantAdress.Clear();
            ApplicantMaleOrFemale.Clear();
            ApplicantWantSpeciality.Clear();
            ApplicantPoints.Clear();



            ClassPlugin algorithms = new ClassPlugin("./");
            if (algorithms.objects.Count == 0)
            {
                MessageBox.Show("No plugins");
            }

            string filter = string.Empty;
            foreach (Class1 alg in algorithms.objects)
            {
                filter += "*" + alg.Format + ";";
            }
            filter = filter.TrimEnd(';');
            openFileDialog1.Filter = "Archives (" + filter + ")|" + filter;

            bool result = openFileDialog1.ShowDialog() == DialogResult.OK;

            if (result == true)
            {
                string filename = openFileDialog1.FileName;
                string ext = System.IO.Path.GetExtension(filename);
                string temp = filename.Replace(ext, "");

                Class1 compressor = algorithms.objects.Find(obj => obj.Format == ext);
                compressor.Decompress(filename, temp);

                if (rbBinary.Checked)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (FileStream fs = new FileStream(temp, FileMode.OpenOrCreate))
                    {
                        applicant = (List<Applicant>)formatter.Deserialize(fs);
                    }

                    foreach (Applicant i in applicant)
                    {
                        ID_Applicant++;
                        ApplicantlistBox.Items.Add(i.FIO);
                    }
                }
                else if (rbJson.Checked)
                {
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Applicant>));

                    using (FileStream fs = new FileStream(temp, FileMode.OpenOrCreate))
                    {
                        applicant = (List<Applicant>)jsonFormatter.ReadObject(fs);
                    }

                    foreach (Applicant i in applicant)
                    {
                        ID_Applicant++;
                        ApplicantlistBox.Items.Add(i.FIO);
                    }
                }
                else if (rbUser.Checked)
                {


                    string[] lines = File.ReadAllLines(temp);
                    for (int j = 0; j < lines.Length - 1; j += 6)
                    {

                        applicant.Capacity++;
                        applicant.Add(new Applicant(lines[j], lines[j + 1], lines[j + 2], lines[j + 3], lines[j + 4], lines[j + 5]));
                    }

                    foreach (Applicant i in applicant)
                    {
                        ID_Applicant++;
                        ApplicantlistBox.Items.Add(i.FIO);
                    }
                }
                File.Delete(temp);
            }
        }

        //Serializer/Deserializer
        //class Student
        //

        private void StudentSerializerbutton_Click(object sender, EventArgs e)
        {
            if (!rbBinary.Checked && !rbJson.Checked && !rbUser.Checked)
            {
                { MessageBox.Show("Ошибка: не выбран способ сериализации"); }
                return;
            }



            string filter = string.Empty;


            ClassPlugin algorithms = new ClassPlugin("./");
            if (algorithms.objects.Count == 0)
            {
                MessageBox.Show("No plugins");
                return;
            }

            foreach (Class1 alg in algorithms.objects)
            {
                filter += alg.Name + " archive (*" + alg.Format + ")|*" + alg.Format + "|";
            }
            saveFileDialog1.Filter = filter.TrimEnd('|');
            bool result = saveFileDialog1.ShowDialog() == DialogResult.OK;
            if (result == true)
            {
                string filename = saveFileDialog1.FileName;
                string ext = Path.GetExtension(saveFileDialog1.FileName);
                string name = saveFileDialog1.FileName.Replace(ext, "");
                Class1 compressor = algorithms.objects.Find(obj => obj.Format == ext);
                if (rbBinary.Checked)
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    using (FileStream fs = new FileStream(name, FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, student);
                    }
                    compressor.Compress(name, name + ext);
                }
                else if (rbJson.Checked)
                {
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Student>));

                    using (FileStream fs = new FileStream(name, FileMode.OpenOrCreate))
                    {
                        jsonFormatter.WriteObject(fs, student);
                    }
                    compressor.Compress(name, name + ext);
                }
                else if (rbUser.Checked)
                {

                    //OpenFileDialog f = new OpenFileDialog();
                    //f.FileName = name;
                    string textout = "";
                    foreach (Student i in student)
                    {
                        textout = textout + i.FIO + Environment.NewLine + i.Age + Environment.NewLine + i.Adress + Environment.NewLine + i.MaleOrFemale + Environment.NewLine + i.Course + Environment.NewLine + i.Speciality + Environment.NewLine + i.Group + Environment.NewLine + i.TypeOfLearning + Environment.NewLine + i.FreeOrPaid + Environment.NewLine;
                    }
                    File.WriteAllText(name, textout);
                    compressor.Compress(name, name + ext);
                }
                File.Delete(name);
            }
        }

        private void StudentDeserializerbutton_Click(object sender, EventArgs e)
        {
            if (!rbBinary.Checked && !rbJson.Checked && !rbUser.Checked)
            {
                { MessageBox.Show("Ошибка: не выбран способ сериализации"); }
                return;
            }
            student.Clear();
            ID_Student = 0;
            StudentSelectedFIO = "";

            StudentlistBox.Items.Clear();

            StudentFIO.Clear();
            StudentAge.Clear();
            StudentAdress.Clear();
            StudentMaleOrFemale.Clear();
            StudentCourse.Clear();
            StudentSpeciality.Clear();
            StudentGroup.Clear();
            StudentTypeOfLearning.Clear();
            StudentFreeOrPaid.Clear();



            ClassPlugin algorithms = new ClassPlugin("./");
            if (algorithms.objects.Count == 0)
            {
                MessageBox.Show("No plugins");
            }

            string filter = string.Empty;
            foreach (Class1 alg in algorithms.objects)
            {
                filter += "*" + alg.Format + ";";
            }
            filter = filter.TrimEnd(';');
            openFileDialog1.Filter = "Archives (" + filter + ")|" + filter;

            bool result = openFileDialog1.ShowDialog() == DialogResult.OK;

            if (result == true)
            {
                string filename = openFileDialog1.FileName;
                string ext = System.IO.Path.GetExtension(filename);
                string temp = filename.Replace(ext, "");

                Class1 compressor = algorithms.objects.Find(obj => obj.Format == ext);
                compressor.Decompress(filename, temp);

                if (rbBinary.Checked)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (FileStream fs = new FileStream(temp, FileMode.OpenOrCreate))
                    {
                        student = (List<Student>)formatter.Deserialize(fs);
                    }

                    foreach (Student i in student)
                    {
                        ID_Student++;
                        StudentlistBox.Items.Add(i.FIO);
                    }
                }
                else if (rbJson.Checked)
                {
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Student>));

                    using (FileStream fs = new FileStream(temp, FileMode.OpenOrCreate))
                    {
                        student = (List<Student>)jsonFormatter.ReadObject(fs);
                    }

                    foreach (Student i in student)
                    {
                        ID_Student++;
                        StudentlistBox.Items.Add(i.FIO);
                    }
                }
                else if (rbUser.Checked)
                {


                    string[] lines = File.ReadAllLines(temp);
                    for (int j = 0; j < lines.Length - 1; j += 9)
                    {

                        student.Capacity++;
                        student.Add(new Student(lines[j], lines[j + 1], lines[j + 2], lines[j + 3], lines[j + 4], lines[j + 5], lines[j + 6], lines[j + 7], lines[j + 8]));
                    }

                    foreach (Student i in student)
                    {
                        ID_Student++;
                        StudentlistBox.Items.Add(i.FIO);
                    }
                }
                File.Delete(temp);
            }
        }

        //Serializer/Deserializer
        //class StudentLastCourse
        //

        private void StudentLastCourseSerializerbutton_Click(object sender, EventArgs e)
        {
            if (!rbBinary.Checked && !rbJson.Checked && !rbUser.Checked)
            {
                { MessageBox.Show("Ошибка: не выбран способ сериализации"); }
                return;
            }



            string filter = string.Empty;


            ClassPlugin algorithms = new ClassPlugin("./");
            if (algorithms.objects.Count == 0)
            {
                MessageBox.Show("No plugins");
                return;
            }

            foreach (Class1 alg in algorithms.objects)
            {
                filter += alg.Name + " archive (*" + alg.Format + ")|*" + alg.Format + "|";
            }
            saveFileDialog1.Filter = filter.TrimEnd('|');
            bool result = saveFileDialog1.ShowDialog() == DialogResult.OK;
            if (result == true)
            {
                string filename = saveFileDialog1.FileName;
                string ext = Path.GetExtension(saveFileDialog1.FileName);
                string name = saveFileDialog1.FileName.Replace(ext, "");
                Class1 compressor = algorithms.objects.Find(obj => obj.Format == ext);
                if (rbBinary.Checked)
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    using (FileStream fs = new FileStream(name, FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, studentLastCourse);
                    }
                    compressor.Compress(name, name + ext);
                }
                else if (rbJson.Checked)
                {
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<StudentLastCourse>));

                    using (FileStream fs = new FileStream(name, FileMode.OpenOrCreate))
                    {
                        jsonFormatter.WriteObject(fs, studentLastCourse);
                    }
                    compressor.Compress(name, name + ext);
                }
                else if (rbUser.Checked)
                {

                    //OpenFileDialog f = new OpenFileDialog();
                    //f.FileName = name;
                    string textout = "";
                    foreach (StudentLastCourse i in studentLastCourse)
                    {
                        textout = textout + i.FIO + Environment.NewLine + i.Age + Environment.NewLine + i.Adress + Environment.NewLine + i.MaleOrFemale + Environment.NewLine + i.Course + Environment.NewLine + i.Speciality + Environment.NewLine + i.Group + Environment.NewLine + i.TypeOfLearning + Environment.NewLine + i.FreeOrPaid + Environment.NewLine + i.Distribution + Environment.NewLine + i.Diploma.Theme + Environment.NewLine + i.Diploma.DateOfDelivery + Environment.NewLine + i.Diploma.NameProfessor + Environment.NewLine;
                    }
                    File.WriteAllText(name, textout);
                    compressor.Compress(name, name + ext);
                }
                File.Delete(name);
            }
        }

        private void StudentLastCourseDeserializerbutton_Click(object sender, EventArgs e)
        {
            if (!rbBinary.Checked && !rbJson.Checked && !rbUser.Checked)
            {
                { MessageBox.Show("Ошибка: не выбран способ сериализации"); }
                return;
            }
            studentLastCourse.Clear();
            ID_StudentLastCourse = 0;

            diploma.Clear();
            ID_Diploma = 0;

            StudentLastCourseSelectedFIO = "";

            StudentLastCourselistBox.Items.Clear();

            StudentLastCourseFIO.Clear();
            StudentLastCourseAge.Clear();
            StudentLastCourseAdress.Clear();
            StudentLastCourseMaleOrFemale.Clear();
            StudentLastCourseCourse.Clear();
            StudentLastCourseSpeciality.Clear();
            StudentLastCourseGroup.Clear();
            StudentLastCourseTypeOfLearning.Clear();
            StudentLastCourseFreeOrPaid.Clear();
            StudentLastCourseDistribution.Clear();
            DiplomaName.Clear();
            DiplomaDate.Clear();
            DiplomaNameProfessor.Clear();

            ClassPlugin algorithms = new ClassPlugin("./");
            if (algorithms.objects.Count == 0)
            {
                MessageBox.Show("No plugins");
            }

            string filter = string.Empty;
            foreach (Class1 alg in algorithms.objects)
            {
                filter += "*" + alg.Format + ";";
            }
            filter = filter.TrimEnd(';');
            openFileDialog1.Filter = "Archives (" + filter + ")|" + filter;

            bool result = openFileDialog1.ShowDialog() == DialogResult.OK;

            if (result == true)
            {
                string filename = openFileDialog1.FileName;
                string ext = System.IO.Path.GetExtension(filename);
                string temp = filename.Replace(ext, "");

                Class1 compressor = algorithms.objects.Find(obj => obj.Format == ext);
                compressor.Decompress(filename, temp);

                if (rbBinary.Checked)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (FileStream fs = new FileStream(temp, FileMode.OpenOrCreate))
                    {
                        studentLastCourse = (List<StudentLastCourse>)formatter.Deserialize(fs);
                    }

                    foreach (StudentLastCourse i in studentLastCourse)
                    {
                        ID_StudentLastCourse++;
                        ID_Diploma++;
                        StudentLastCourselistBox.Items.Add(i.FIO);
                    }
                }
                else if (rbJson.Checked)
                {
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<StudentLastCourse>));

                    using (FileStream fs = new FileStream(temp, FileMode.OpenOrCreate))
                    {
                        studentLastCourse = (List<StudentLastCourse>)jsonFormatter.ReadObject(fs);
                    }

                    foreach (StudentLastCourse i in studentLastCourse)
                    {
                        ID_StudentLastCourse++;
                        ID_Diploma++;
                        StudentLastCourselistBox.Items.Add(i.FIO);
                    }
                }
                else if (rbUser.Checked)
                {


                    string[] lines = File.ReadAllLines(temp);
                    for (int j = 0; j < lines.Length - 1; j += 13)
                    {

                        studentLastCourse.Capacity++;
                        diploma.Capacity++;
                        diploma.Add(new Diploma(lines[j + 10], lines[j + 11], lines[j + 12]));
                        studentLastCourse.Add(new StudentLastCourse(lines[j], lines[j + 1], lines[j + 2], lines[j + 3], lines[j + 4], lines[j + 5], lines[j + 6], lines[j + 7], lines[j + 8], lines[j + 9], diploma[diploma.Count-1]));
                    }

                    foreach (StudentLastCourse i in studentLastCourse)
                    {
                        ID_StudentLastCourse++;
                        ID_Diploma++;
                        StudentLastCourselistBox.Items.Add(i.FIO);
                    }
                }
                File.Delete(temp);
            }
        }

        //Serializer/Deserializer
        //class Workers
        //

        private void WorkersSerializerbutton_Click(object sender, EventArgs e)
        {
            if (!rbBinary.Checked && !rbJson.Checked && !rbUser.Checked)
            {
                { MessageBox.Show("Ошибка: не выбран способ сериализации"); }
                return;
            }



            string filter = string.Empty;


            ClassPlugin algorithms = new ClassPlugin("./");
            if (algorithms.objects.Count == 0)
            {
                MessageBox.Show("No plugins");
                return;
            }

            foreach (Class1 alg in algorithms.objects)
            {
                filter += alg.Name + " archive (*" + alg.Format + ")|*" + alg.Format + "|";
            }
            saveFileDialog1.Filter = filter.TrimEnd('|');
            bool result = saveFileDialog1.ShowDialog() == DialogResult.OK;
            if (result == true)
            {
                string filename = saveFileDialog1.FileName;
                string ext = Path.GetExtension(saveFileDialog1.FileName);
                string name = saveFileDialog1.FileName.Replace(ext, "");
                Class1 compressor = algorithms.objects.Find(obj => obj.Format == ext);
                if (rbBinary.Checked)
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    using (FileStream fs = new FileStream(name, FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, workers);
                    }
                    compressor.Compress(name, name + ext);
                }
                else if (rbJson.Checked)
                {
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Workers>));

                    using (FileStream fs = new FileStream(name, FileMode.OpenOrCreate))
                    {
                        jsonFormatter.WriteObject(fs, workers);
                    }
                    compressor.Compress(name, name + ext);
                }
                else if (rbUser.Checked)
                {

                    //OpenFileDialog f = new OpenFileDialog();
                    //f.FileName = name;
                    string textout = "";
                    foreach (Workers i in workers)
                    {
                        textout = textout + i.FIO + Environment.NewLine + i.Age + Environment.NewLine + i.Adress + Environment.NewLine + i.MaleOrFemale + Environment.NewLine + i.Post + Environment.NewLine + i.Salary + Environment.NewLine + i.LenghtOfService + Environment.NewLine;
                    }
                    File.WriteAllText(name, textout);
                    compressor.Compress(name, name + ext);
                }
                File.Delete(name);
            }
        }

        private void WorkersDeserializerbutton_Click(object sender, EventArgs e)
        {
            if (!rbBinary.Checked && !rbJson.Checked && !rbUser.Checked)
            {
                { MessageBox.Show("Ошибка: не выбран способ сериализации"); }
                return;
            }
            workers.Clear();
            ID_Workers = 0;
            WorkersSelectedFIO = "";

            WorkerslistBox.Items.Clear();

            WorkersFIO.Clear();
            WorkersAge.Clear();
            WorkersAdress.Clear();
            WorkersMaleOrFemale.Clear();
            WorkersPost.Clear();
            WorkersSalary.Clear();
            WorkersLenghtOfService.Clear();



            ClassPlugin algorithms = new ClassPlugin("./");
            if (algorithms.objects.Count == 0)
            {
                MessageBox.Show("No plugins");
            }

            string filter = string.Empty;
            foreach (Class1 alg in algorithms.objects)
            {
                filter += "*" + alg.Format + ";";
            }
            filter = filter.TrimEnd(';');
            openFileDialog1.Filter = "Archives (" + filter + ")|" + filter;

            bool result = openFileDialog1.ShowDialog() == DialogResult.OK;

            if (result == true)
            {
                string filename = openFileDialog1.FileName;
                string ext = System.IO.Path.GetExtension(filename);
                string temp = filename.Replace(ext, "");

                Class1 compressor = algorithms.objects.Find(obj => obj.Format == ext);
                compressor.Decompress(filename, temp);

                if (rbBinary.Checked)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (FileStream fs = new FileStream(temp, FileMode.OpenOrCreate))
                    {
                        workers = (List<Workers>)formatter.Deserialize(fs);
                    }

                    foreach (Workers i in workers)
                    {
                        ID_Workers++;
                        WorkerslistBox.Items.Add(i.FIO);
                    }
                }
                else if (rbJson.Checked)
                {
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Workers>));

                    using (FileStream fs = new FileStream(temp, FileMode.OpenOrCreate))
                    {
                        workers = (List<Workers>)jsonFormatter.ReadObject(fs);
                    }

                    foreach (Workers i in workers)
                    {
                        ID_Workers++;
                        WorkerslistBox.Items.Add(i.FIO);
                    }
                }
                else if (rbUser.Checked)
                {


                    string[] lines = File.ReadAllLines(temp);
                    for (int j = 0; j < lines.Length - 1; j += 7)
                    {

                        workers.Capacity++;
                        workers.Add(new Workers(lines[j], lines[j + 1], lines[j + 2], lines[j + 3], lines[j + 4], lines[j + 5], lines[j + 6]));
                    }

                    foreach (Workers i in workers)
                    {
                        ID_Workers++;
                        WorkerslistBox.Items.Add(i.FIO);
                    }
                }
                File.Delete(temp);
            }
        }

        //Serializer/Deserializer
        //class Professor
        //

        private void ProfessorSerializerbutton_Click(object sender, EventArgs e)
        {
            if (!rbBinary.Checked && !rbJson.Checked && !rbUser.Checked)
            {
                { MessageBox.Show("Ошибка: не выбран способ сериализации"); }
                return;
            }



            string filter = string.Empty;


            ClassPlugin algorithms = new ClassPlugin("./");
            if (algorithms.objects.Count == 0)
            {
                MessageBox.Show("No plugins");
                return;
            }

            foreach (Class1 alg in algorithms.objects)
            {
                filter += alg.Name + " archive (*" + alg.Format + ")|*" + alg.Format + "|";
            }
            saveFileDialog1.Filter = filter.TrimEnd('|');
            bool result = saveFileDialog1.ShowDialog() == DialogResult.OK;
            if (result == true)
            {
                string filename = saveFileDialog1.FileName;
                string ext = Path.GetExtension(saveFileDialog1.FileName);
                string name = saveFileDialog1.FileName.Replace(ext, "");
                Class1 compressor = algorithms.objects.Find(obj => obj.Format == ext);
                if (rbBinary.Checked)
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    using (FileStream fs = new FileStream(name, FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, professor);
                    }
                    compressor.Compress(name, name + ext);
                }
                else if (rbJson.Checked)
                {
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Professor>));

                    using (FileStream fs = new FileStream(name, FileMode.OpenOrCreate))
                    {
                        jsonFormatter.WriteObject(fs, professor);
                    }
                    compressor.Compress(name, name + ext);
                }
                else if (rbUser.Checked)
                {

                    //OpenFileDialog f = new OpenFileDialog();
                    //f.FileName = name;
                    string textout = "";
                    foreach (Professor i in professor)
                    {
                        textout = textout + i.FIO + Environment.NewLine + i.Age + Environment.NewLine + i.Adress + Environment.NewLine + i.MaleOrFemale + Environment.NewLine + i.Post + Environment.NewLine + i.Salary + Environment.NewLine + i.LenghtOfService + Environment.NewLine + i.Subject + Environment.NewLine + i.Education + Environment.NewLine;
                    }
                    File.WriteAllText(name, textout);
                    compressor.Compress(name, name + ext);
                }
                File.Delete(name);
            }
        }
        
        private void ProfessorDeserializerbutton_Click(object sender, EventArgs e)
        {
            if (!rbBinary.Checked && !rbJson.Checked && !rbUser.Checked)
            {
                { MessageBox.Show("Ошибка: не выбран способ сериализации"); }
                return;
            }
            professor.Clear();
            ID_Professor = 0;
            ProfessorSelectedFIO = "";

            ProfessorlistBox.Items.Clear();

            ProfessorFIO.Clear();
            ProfessorAge.Clear();
            ProfessorAdress.Clear();
            ProfessorMaleOrFemale.Clear();
            ProfessorPost.Clear();
            ProfessorSalary.Clear();
            ProfessorLenghtOfService.Clear();
            ProfessorSubject.Clear();
            ProfessorEducation.Clear();



            ClassPlugin algorithms = new ClassPlugin("./");
            if (algorithms.objects.Count == 0)
            {
                MessageBox.Show("No plugins");
            }

            string filter = string.Empty;
            foreach (Class1 alg in algorithms.objects)
            {
                filter += "*" + alg.Format + ";";
            }
            filter = filter.TrimEnd(';');
            openFileDialog1.Filter = "Archives (" + filter + ")|" + filter;

            bool result = openFileDialog1.ShowDialog() == DialogResult.OK;

            if (result == true)
            {
                string filename = openFileDialog1.FileName;
                string ext = System.IO.Path.GetExtension(filename);
                string temp = filename.Replace(ext, "");

                Class1 compressor = algorithms.objects.Find(obj => obj.Format == ext);
                compressor.Decompress(filename, temp);

                if (rbBinary.Checked)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (FileStream fs = new FileStream(temp, FileMode.OpenOrCreate))
                    {
                        professor = (List<Professor>)formatter.Deserialize(fs);
                    }

                    foreach (Professor i in professor)
                    {
                        ID_Professor++;
                        ProfessorlistBox.Items.Add(i.FIO);
                    }
                }
                else if (rbJson.Checked)
                {
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Professor>));

                    using (FileStream fs = new FileStream(temp, FileMode.OpenOrCreate))
                    {
                        professor = (List<Professor>)jsonFormatter.ReadObject(fs);
                    }

                    foreach (Professor i in professor)
                    {
                        ID_Professor++;
                        ProfessorlistBox.Items.Add(i.FIO);
                    }
                }
                else if (rbUser.Checked)
                {


                    string[] lines = File.ReadAllLines(temp);
                    for (int j = 0; j < lines.Length - 1; j += 9)
                    {

                        professor.Capacity++;
                        professor.Add(new Professor(lines[j], lines[j + 1], lines[j + 2], lines[j + 3], lines[j + 4], lines[j + 5], lines[j + 6], lines[j + 7], lines[j + 8]));
                    }

                    foreach (Professor i in professor)
                    {
                        ID_Professor++;
                        ProfessorlistBox.Items.Add(i.FIO);
                    }
                }
                File.Delete(temp);
            }

        }
    }
}
