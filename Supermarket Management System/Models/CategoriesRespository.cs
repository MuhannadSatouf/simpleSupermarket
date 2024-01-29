namespace Supermarket_Management_System.Models
{
    public static class CategoriesRespository
    {
        //In-memory 
        private static List<Category> _categories = new List<Category>()
        {
             new Category {CategoryId = 1 , CategoryName = "Beverage" , CategoryDescription = "Beverage Description"},
             new Category {CategoryId = 2 , CategoryName = "Bakery" , CategoryDescription = "Bakery Description"},
             new Category {CategoryId = 3 , CategoryName = "Meat" , CategoryDescription = "Meat Description"}
        };

        public static void AddCategory(Category category)
        {
            var maxId = _categories.Max(x => x.CategoryId);
            category.CategoryId = maxId + 1;
            _categories.Add(category);
        }

        public static List<Category> GetCategories() => _categories;

        public static Category? GetCategoryById(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (category != null)
            {
                return new Category
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    CategoryDescription = category.CategoryDescription,
                };
            }
            return null;
        }

        public static void UpdateCategory(int categoryId, Category category)
        {
            if (categoryId != category.CategoryId) return;

            var categeoryToUpdate = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (categeoryToUpdate != null)
            {
                categeoryToUpdate.CategoryName = category.CategoryName;
                categeoryToUpdate.CategoryDescription = category.CategoryDescription;
            }
        }

        public static void DeleteCategory(int categoryId)
        {
            var categoryToDelete = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (categoryToDelete != null)
            {
                _categories.Remove(categoryToDelete);
            }
        }
    }
}
