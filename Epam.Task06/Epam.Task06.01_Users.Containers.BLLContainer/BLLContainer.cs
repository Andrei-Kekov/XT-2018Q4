namespace Epam.Task06._01_Users.Containers
{
    public static class BLLContainer
    {
        private static Interfaces.IBLL bll;

        public static Interfaces.IBLL GetBLL()
        {
            if (bll == null)
            {
                bll = new BLL.BLL();
            }

            return bll;
        }
    }
}
