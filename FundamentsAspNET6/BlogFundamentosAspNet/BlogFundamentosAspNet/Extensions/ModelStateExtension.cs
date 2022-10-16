using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BlogFundamentosAspNet.Extensions
{
    public static class ModelStateExtension
    {
        public static List<string> GetErrors(this ModelStateDictionary modelState)
        {
            var errors = new List<string>();
            foreach (var error in modelState.Values)
            {
                foreach (var item in error.Errors)
                {
                    errors.Add(item.ErrorMessage);
                }
            }
            return errors;
        }
    }
}
