namespace DSS.Common
{
    public static class DefaultPaths
    {
        public const string CategoriesImagesPath = "../../Images/Categories/";

        public const string BlobsImagesPath = "../../Images/Blobs/";

        public const string HomeImageName = "image.jpg";

        public const string Contact1ImageName = "contact1.jpg";

        public const string Contact2ImageName = "contact2.jpg";

        public const string Contact3ImageName = "contact3.jpg";

        public const string MainIconImageName = "icon.ico";

        public static string ToRootPath(this string path) => path.Replace("../", "").Insert(0, "~/");
    }
}