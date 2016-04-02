using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OPR.lb1;
using TPL_Lab.Methods.Best_Sample_Algorithm.cs;

namespace TPL_Lab
{
    public partial class Form1 : Form
    {
        private BestSampleAlgorithm best;
        private static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        private CancellationToken token = cancelTokenSource.Token;
        private int progressValueStart = 2;

        public Form1()
        {
            InitializeComponent();
            InitializeBSA();
            label10.Text = string.Empty;
        }

        static async Task Display(string message)
        {
            await Task.Delay(3000);
            MessageBox.Show(message);
        }

        private void Start_All_Click(object sender, EventArgs e)
        {
            Parallel.For(1, 4, new ParallelOptions { CancellationToken = token }, RunMethods);
        }

        //добавить остальные методы
        private async void RunMethods(int index)
        {
            switch (index)
            {
                case 1:
                    await BSA_Method();
                    break;
                case 2:
                    await Display("Илья");
                    break;
                case 3:
                    await Display("Антон");
                    break;
            }
        }

        #region BSA Method Roma

        private void InitializeBSA()
        {
            best = new BestSampleAlgorithm(BSA_FunctionText.Text, 0.1);
            best.Progress += Best_Progress;
            BSA_ProgressBar.Maximum = 10;
        }

        private void Best_Progress(double value)
        {
            progressValueStart += (int)(value * 100);
            BSA_ProgressBar.Invoke(new Action(() => BSA_ProgressBar.Value = progressValueStart));
        }

        private async void StartBestSampleAlgorithm_Click(object sender, EventArgs e)
        {
            await BSA_Method();
        }

        private async Task BSA_Method()
        {
            await Task.Factory.StartNew(() =>
            {
                Random random = new Random(DateTime.Now.Millisecond);
                ExtendedPoint point = new ExtendedPoint();
                point.X = random.Next(-10, 10);
                point.Y = random.Next(-10, 10);
                best.QuantityVectrors = 10;
                var result = best.StartSolution(point);
                string Res = string.Format("Результат: {0}\nX: {1}\nY: {2}", result.ToString(), best.EndPoint.X, best.EndPoint.Y);
                BSA_Result.Invoke(new Action(() => BSA_Result.Text = Res));
                BSA_Result.Invoke(new Action(() => BSA_ProgressBar.Value = 0));
                progressValueStart = 2;
            });
        }
        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
            float x = -1.2f,
                   y = 1,
                   sideLength = 30,
                   minSideLength = 0.000001f,
                   deltaSideLenth = 1.1f; // reduce side length 
            int iterationCount = 200,
                innerPointsCount = 1400; // count of gennereted points 

            SquarePoint startPoint = new SquarePoint(x, y);
            HyperCube HC = new HyperCube(startPoint, sideLength, minSideLength, deltaSideLenth, iterationCount, innerPointsCount); // Create Hyper cube
            var task = Task.Run(()=> HC.Calculate(new Progress<int>(UpdateProgessBar)));
            task.Wait();
            label10.Text = string.Format("x={0}, y={1}, z={2}", task.Result.Point.x, task.Result.Point.y, task.Result.Z);
        }

        private void UpdateProgessBar(int value)
        {
            progressBar2.Invoke(new Action(() => { progressBar2.Value = value; }));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label10.Text = string.Empty;
            progressBar2.Value = 0;
        }
    }
}
