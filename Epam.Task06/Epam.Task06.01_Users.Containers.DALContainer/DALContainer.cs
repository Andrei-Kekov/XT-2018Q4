namespace Epam.Task06._01_Users.Containers
{
    public static class DALContainer
    {
        private static Interfaces.IDAL dal;

        public static Interfaces.IDAL GetDAL()
        {
            if (dal == null)
            {
                dal = new DAL.DAL();
            }

            return dal;
        }
    }
}
