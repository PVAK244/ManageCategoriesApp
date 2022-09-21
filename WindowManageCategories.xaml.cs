using System;
using System.Windows;

namespace ManageCategoriesApp
{
    /// <summary>
    /// Interaction logic for WindowManageCategories.xaml
    /// </summary>
    public partial class WindowManageCategories : Window
    {
        public WindowManageCategories()
        {
            InitializeComponent();
        }
        ManageCategories categories = new ManageCategories();

        private void Window_Load(object sender, RoutedEventArgs e) => LoadCategories();

        private void LoadCategories()
        {
            lvCategories.ItemsSource = categories.GetCategories();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var category = new Category { CategoryName = txtCategoryName.Text };
                categories.InsertCategory(category);
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Category");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var category = new Category
                {
                    CategoryID = int.Parse(txtCategoryID.Text),
                    CategoryName = txtCategoryName.Text,
                };
                categories.UpdateCategory(category);
                LoadCategories();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Category");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Category = new Category
                {
                    CategoryID = int.Parse(txtCategoryID.Text)
                };
                categories.DeleteCategory(Category);
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Category");
            }
        }
    }
}
