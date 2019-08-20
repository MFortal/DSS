namespace DSS.Common
{
    public class Utils
    {
        public static void ClearOldFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
    }
}