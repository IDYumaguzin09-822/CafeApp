using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace CafeApp
{
    
    public partial class MainWindow : Window
    {
        List<Burger> burgers;
        List<Burger> burgersInCart = new List<Burger>();
        public string[] menuListarray = { "Популярное", "Новинки", "Сеты и боксы",
                                    "МакКомбо", "Бургеры", "Картофель и стартеры", 
                                    "Роллы", "Десерты и выпечка", "Напитки и коктейли" };
        
        public MainWindow()
        {
            InitializeComponent();
            LoadJson();

            this.Loaded += new RoutedEventHandler(buyButton_Click);

            burgersList.ItemsSource = burgers;
            leftMenuList.ItemsSource = menuListarray;

        }
        void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
        }

        public void LoadJson()
        {
            using (StreamReader r = new StreamReader("C:/Users/ADMIN/source/repos/CafeApp/CafeApp/data/MacDonalds_json.json"))
            {
                string json = r.ReadToEnd();    
                burgers = JsonConvert.DeserializeObject<List<Burger>>(json);

                /*dynamic array = JsonConvert.DeserializeObject(json);
                foreach (var item in array)
                {
                    Console.WriteLine("{0} {1}", item.name, item.food_value);
                }*/
            }

        }

        private void burgersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void leftMenuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void buyButton_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);

            Burger burger = (Burger)burgersList.SelectedItem;
            MessageBox.Show(parentWindow.ToString());
            burgersInCart.Add(burger);
            //Console.WriteLine(burgersInCart.Last().name);
        }

        private void Cart_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
