namespace ProdavnicaPiva.Models
{
    public static class RoleName
    {
        public const string CanManageBrands = "CanManageBrands";
        public const string CanManageBeer = "CanManageBeer";
        public const string CanManageAny = CanManageBrands + "," + CanManageBeer;

    }
}