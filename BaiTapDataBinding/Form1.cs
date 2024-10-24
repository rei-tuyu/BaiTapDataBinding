using BaiTapDataBinding.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapDataBinding
{
    public partial class frmSinhVien : Form
    {
        public frmSinhVien()
        {
            InitializeComponent();
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'schoolDBDataSet.Students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter.Fill(this.schoolDBDataSet.Students);
            cbbNganh.SelectedIndex = 0;
        }

        private void ResetForm()
        {
            txtTen.Clear();
            txtTuoi.Clear();
            cbbNganh.SelectedIndex = 0;
        }

        private void AddSinhVien(Student newStudent)
        {
            using (SchoolContexDB contex = new SchoolContexDB())
            {
                contex.Students.Add(newStudent);
                contex.SaveChanges();
                dgvSinhVien.DataSource = contex.Students.ToList();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Nhập tên!", "Anh nhắc em", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (string.IsNullOrEmpty(txtTuoi.Text))
            {
                MessageBox.Show("Nhập tuổi!", "Anh nhắc em", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (int.Parse(txtTuoi.Text) < 0)
            {
                MessageBox.Show("Nhập tuổi cho đúng!", "Anh nhắc em", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Student newStudent = new Student()
            {
                FullName = txtTen.Text.Trim(),
                Age = int.Parse(txtTuoi.Text.Trim()),
                Major = cbbNganh.SelectedItem.ToString()
            };

            AddSinhVien(newStudent);
            ResetForm();
            MessageBox.Show("Đã thêm sinh viên", "Anh báo em", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.SelectedRows.Count > 0)
            {
                int studentId = (int)dgvSinhVien.SelectedRows[0].Cells[0].Value;
                using (SchoolContexDB context = new SchoolContexDB())
                {
                    var student = context.Students.SingleOrDefault(s => s.StudentId == studentId);
                    if (student != null)
                    {
                        context.Students.Remove(student);
                        context.SaveChanges();

                        // Cập nhật lại DataGridView
                        dgvSinhVien.DataSource = context.Students.ToList();

                        ResetForm();
                        MessageBox.Show("Đã xoá", "Anh báo em", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sinh viên", "Anh nhắc em", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn sinh viên để xóa", "Anh nhắc em", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SchoolContexDB context = new SchoolContexDB())
            {
                if (dgvSinhVien.SelectedRows.Count > 0)
                {
                    int studentId = (int)dgvSinhVien.SelectedRows[0].Cells[0].Value;
                    var student = context.Students.SingleOrDefault(s => s.StudentId == studentId);
                    if (student != null)
                    {
                        student.FullName = txtTen.Text.Trim();
                        student.Age = int.Parse(txtTuoi.Text.Trim());
                        student.Major = cbbNganh.SelectedItem.ToString();
                        context.SaveChanges();

                        // Cập nhật DataGridView
                        dgvSinhVien.DataSource = context.Students.ToList();

                        MessageBox.Show("Cập nhật xong", "Anh báo em", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không có sinh viên này", "Anh nhắc em", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Chưa chọn", "Anh nhắc em", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
