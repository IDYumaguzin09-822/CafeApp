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
        List<Product> products;
        public static List<Product> productInCart = new List<Product>();
        public List<string> menuListarray = new List<string> { "Популярное", "Новинки", "Сеты и боксы",
                                    "МакКомбо", "Бургеры", "Картофель и стартеры",
                                    "Роллы", "Десерты и выпечка", "Напитки и коктейли" };

        public MainWindow()
        {
            InitializeComponent();
            LoadJson("C:/Users/ADMIN/source/repos/CafeApp/CafeApp/data/Populars.json");

            mainWindowListForProducts.ItemsSource = products;
            leftMenuList.ItemsSource = menuListarray;

        }

        public void LoadJson(string Path)
        {
            using (StreamReader r = new StreamReader(Path))
            {
                string json = r.ReadToEnd();
                products = JsonConvert.DeserializeObject<List<Product>>(json);

                /*dynamic array = JsonConvert.DeserializeObject(json);
                foreach (var item in array)
                {
                    Console.WriteLine("{0} {1}", item.name, item.food_value);
                }*/
            }

        }

        private void burgersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = mainWindowListForProducts.SelectedIndex;
            MessageBox.Show(products[index].name +"\n\n" + products[index].ingredients);

        }

        private void buyButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            Product product = (Product)button.DataContext;
            productInCart.Add(product);
        }

        private void Cart_Button_Click(object sender, RoutedEventArgs e)
        {
            if (productInCart.Count != 0)
            {
                CartWindow cartWindow = new CartWindow();
                cartWindow.Show();
                cartWindow.cartWindowListForProducts.ItemsSource = productInCart;
            }
            else
            {
                MessageBox.Show("Ваша корзина пуста!");
            }
        }

        private void ButtonFromMenu_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Content)
            {
                case "Популярное":
                    LoadJson("C:/Users/ADMIN/source/repos/CafeApp/CafeApp/data/Populars.json");
                    mainWindowListForProducts.ItemsSource = products;
                    break;
                case "Новинки":
                    LoadJson("C:/Users/ADMIN/source/repos/CafeApp/CafeApp/data/News1.json");
                    mainWindowListForProducts.ItemsSource = products;
                    break;
                case "Сеты и боксы":
                    MessageBox.Show("Эта вкладка находится на стадии разработки. Спасибо, что пользуетесь нашим приложением.");
                    break;
                case "МакКомбо":
                    MessageBox.Show("Эта вкладка находится на стадии разработки. Спасибо, что пользуетесь нашим приложением.");
                    break;
                case "Бургеры":
                    LoadJson("C:/Users/ADMIN/source/repos/CafeApp/CafeApp/data/MacDonalds_json.json");
                    mainWindowListForProducts.ItemsSource = products;
                    break;
                case "Картофель и стартеры":
                    MessageBox.Show("Эта вкладка находится на стадии разработки. Спасибо, что пользуетесь нашим приложением.");
                    break;
                case "Роллы":
                    MessageBox.Show("Эта вкладка находится на стадии разработки. Спасибо, что пользуетесь нашим приложением.");
                    break;
                case "Десерты и выпечка":
                    LoadJson("C:/Users/ADMIN/source/repos/CafeApp/CafeApp/data/Deserts.json");
                    mainWindowListForProducts.ItemsSource = products;
                    break;
                case "Напитки и коктейли":
                    MessageBox.Show("Эта вкладка находится на стадии разработки. Спасибо, что пользуетесь нашим приложением.");
                    break;

            }
        }
    }
}
