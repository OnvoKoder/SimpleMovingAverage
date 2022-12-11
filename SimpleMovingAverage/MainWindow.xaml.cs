using SimpleMovingAverage.Class;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace SimpleMovingAverage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchAvg(object sender, RoutedEventArgs e)
        {
            lbAvg.ItemsSource = null;
            string[] data;
            if (txtArray.Text != string.Empty && txtStep.Text != string.Empty)
            {
                data = txtArray.Text.Split(',');
                if (data.Length <= Convert.ToInt32(txtStep.Text))
                    MessageBox.Show("Шаг больше, чем данных");
                else
                {
                    MovingAvg moveAvg=new MovingAvg();
                    moveAvg.Search(data, Convert.ToInt32(txtStep.Text), out List<double> avg);
                    lbAvg.ItemsSource = avg;
                    RenderGraph(avg);
                }
            }
            else
                MessageBox.Show("Заоплни данные");
        }
        private void RenderGraph(in List<double> avg)
        {
            graph.Visibility = Visibility.Visible;
            double []dataX=new double[avg.Count];
            double[] dataY = new double[avg.Count];
            for(int i=0; i<avg.Count; i++)
            {
                dataX[i]=i;
                dataY[i]=avg[i];
            }
            graph.Plot.AddScatter(dataX,dataY);
            graph.Refresh();
        }

        private void txtArray_PreviewTextInput(object sender, TextCompositionEventArgs e)=>txtArray.TextWrapping = TextWrapping.Wrap;


        private void txtStep_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
                e.Handled = true;
        }
    }
}
