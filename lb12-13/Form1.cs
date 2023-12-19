using System.Drawing;

namespace lb12_13
{
    public partial class Form1 : Form
    {
        int[] M;
        const int maxNumber = 10000;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Rows[0].Cells[1].Value = "Обмен";
            dataGridView1.Rows[1].Cells[1].Value = "Выбор";
            dataGridView1.Rows[2].Cells[1].Value = "Включение";
            dataGridView1.Rows[3].Cells[1].Value = "Шелла";
            dataGridView1.Rows[4].Cells[1].Value = "Быстрая";
            dataGridView1.Rows[5].Cells[1].Value = "Линейная";
            dataGridView1.Rows[6].Cells[1].Value = "Встроенная";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] rez;
            generate_arr((int)numericUpDown1.Value);
            rez = change(M);
            dataGridView1.Rows[0].Cells[2].Value = rez[0];
            dataGridView1.Rows[0].Cells[3].Value = rez[1];
            dataGridView1.Rows[0].Cells[4].Value = rez[2];
            rez = Vibor(M);
            dataGridView1.Rows[1].Cells[2].Value = rez[0];
            dataGridView1.Rows[1].Cells[3].Value = rez[1];
            dataGridView1.Rows[1].Cells[4].Value = rez[2];
        }

        private int[] change(int[] arr)
        {
            int[] sortMas = (int[])arr.Clone();
            int sravn = 0;
            int perestan = 0;
            int fl = 0;
            int startTime = Environment.TickCount;
            // Для всех элементов
            for (int i = 0; i < sortMas.Length - 1; i++)
            {
                fl = 0;
                for (int j = (sortMas.Length - 1); j > i; j--) // для всех элементов после i-ого
                {
                    sravn++;
                    if (sortMas[j - 1] > sortMas[j]) // если текущий элемент меньше предыдущего
                    {
                        fl = 1;
                        perestan++;
                        //perestan++;
                        int temp = sortMas[j - 1]; // меняем их местами
                        sortMas[j - 1] = sortMas[j];
                        sortMas[j] = temp;
                    }
                }
                if (fl == 0) break;

            }
            return new int[] { sravn, perestan, Environment.TickCount - startTime };
        }
               
        static int[] Vibor(int[] masiv)
        {
            int[] mas = (int[])masiv.Clone();
            int sravn = 0;
            int perestan = 0;
            int startTime = Environment.TickCount;
            for (int i = 0; i < mas.Length - 1; i++)
            {
                //поиск минимального числа
                int min = i;
                for (int j = i + 1; j < mas.Length; j++)
                {
                    sravn++;
                    if (mas[j] < mas[min])
                    {
                        min = j;
                    }
                }
                perestan++;
                //обмен элементов
                int temp = mas[min];
                mas[min] = mas[i];
                mas[i] = temp;
            }
            return new int[] { sravn, perestan, Environment.TickCount - startTime };
        }

        private void generate_arr(int arrSize)
        {
            Random rnd = new Random();
            M = new int[arrSize];
            for (int i = 0; i < arrSize; i++)
            {
                M[i] = (int)rnd.Next(0, maxNumber);

            }
        }
    }
}