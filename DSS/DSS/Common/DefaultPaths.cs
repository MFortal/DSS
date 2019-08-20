namespace DSS.Common
{
    public static class DefaultPaths
    {
        public const string CategoriesImagesPath = "../../Images/Categories/";

        public static string ToRootPath(this string path) => path.Replace("../", "").Insert(0, "~/");
    }
}