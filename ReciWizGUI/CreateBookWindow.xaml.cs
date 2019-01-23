using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RecipeLib.Application;

namespace ReciWizGUI
{
    /// <summary>
    /// Interaction logic for CreateRecipe.xaml
    /// </summary>
    public partial class CreateBookWindow : Page
    {
        private Controller Control;
        public CreateBookWindow(RoutedEventHandler listener, Controller control)
        {
            InitializeComponent();
            Control = control;
            CreateBtn.Click += CreateMethod;
            CreateBtn.Click += listener;
        }

        public void CreateMethod(object sender, EventArgs e)
        {
            Control.CreateCookbook(BookName.Text, Author.Text);
        }
    }
}
